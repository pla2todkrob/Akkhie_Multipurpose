using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Multipurpose
{
    public partial class WindowsSettingsControl : UserControl
    {
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_FONTCHANGE = 0x001D;
        private static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);

        private CancellationTokenSource _cancellationTokenSource;

        public WindowsSettingsControl()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.WindowsSettingsControl_Load);
        }

        private void WindowsSettingsControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            LoadOdbcSettingsToForm();
            LoadFontList();
        }

        #region Helper and Core Logic Methods

        private void Log(string message)
        {
            if (this.IsDisposed || (txtStatus != null && txtStatus.IsDisposed)) return;
            if (txtStatus.InvokeRequired)
            {
                try { txtStatus.Invoke(new Action(() => Log(message))); }
                catch (ObjectDisposedException) { /* Ignore */ }
            }
            else { txtStatus.AppendText(message + Environment.NewLine); }
        }

        private async Task<string> RunProcessAsync(string fileName, string arguments, CancellationToken token)
        {
            var outputBuilder = new StringBuilder();
            try
            {
                await Task.Run(() =>
                {
                    if (token.IsCancellationRequested) return;
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Verb = "runas",
                        StandardOutputEncoding = Encoding.UTF8
                    };
                    using (var process = new Process { StartInfo = startInfo })
                    {
                        process.Start();
                        var outputTask = process.StandardOutput.ReadToEndAsync();
                        var errorTask = process.StandardError.ReadToEndAsync();
                        while (!process.WaitForExit(100))
                        {
                            if (token.IsCancellationRequested)
                            {
                                try { process.Kill(); } catch { /* Ignore */ }
                                token.ThrowIfCancellationRequested();
                            }
                        }
                        Task.WaitAll(new Task[] { outputTask, errorTask }, token);
                        outputBuilder.Append(outputTask.Result);
                        outputBuilder.Append(errorTask.Result);
                    }
                }, token);
            }
            catch (OperationCanceledException) { outputBuilder.AppendLine("\n[CANCELLED] The operation was cancelled by the user."); }
            catch (Exception ex) { outputBuilder.AppendLine($"An error occurred: {ex.GetBaseException().Message}"); }
            return outputBuilder.ToString();
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
            {
                try { this.Invoke(new Action(() => ToggleAllButtons(isEnabled))); }
                catch (ObjectDisposedException) { /* Ignore */ }
                return;
            }
            btnCreateOdbc.Enabled = isEnabled;
            btnSetLocalization.Enabled = isEnabled;
            btnInstallFonts.Enabled = isEnabled;
            radLangSwitchGrave.Enabled = isEnabled;
            radLangSwitchAltShift.Enabled = isEnabled;
            btnCancel.Visible = !isEnabled;
        }

        private void LoadOdbcSettingsToForm()
        {
            try
            {
                txtOdbcDsnName.Text = ConfigurationManager.AppSettings["OdbcDsnName"] ?? "";
                txtOdbcServer.Text = ConfigurationManager.AppSettings["OdbcServer"] ?? "";
                txtOdbcDb.Text = ConfigurationManager.AppSettings["OdbcDatabase"] ?? "";
                txtOdbcUid.Text = ConfigurationManager.AppSettings["OdbcUid"] ?? "";
                txtOdbcPwd.Text = ConfigurationManager.AppSettings["OdbcPwd"] ?? "";
            }
            catch (Exception ex) { MessageBox.Show($"Error loading ODBC settings from App.config:\n{ex.GetBaseException().Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadFontList()
        {
            listViewFonts.Items.Clear();
            string fontFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");
            if (!Directory.Exists(fontFolderPath)) return;
            var fontFiles = Directory.GetFiles(fontFolderPath, "*.ttf").Concat(Directory.GetFiles(fontFolderPath, "*.otf"));
            foreach (var fontFile in fontFiles) { listViewFonts.Items.Add(Path.GetFileName(fontFile)); }
        }

        private async Task<bool> TestDbConnectionAsync(string connectionString, CancellationToken token)
        {
            Log("Attempting to connect to SQL Server...");
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync(token);
                    Log("  -> Connection Successful!");
                    return true;
                }
            }
            catch (OperationCanceledException) { Log("  -> Connection test cancelled."); return false; }
            catch (Exception ex) { Log("  -> Connection Failed!"); Log($"  -> Error: {ex.GetBaseException().Message}"); return false; }
        }

        #endregion

        #region Button Click Handlers

        private async void btnCreateOdbc_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            ToggleAllButtons(false);
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                string server = txtOdbcServer.Text.Trim();
                string db = txtOdbcDb.Text.Trim();
                string user = txtOdbcUid.Text.Trim();
                string pass = txtOdbcPwd.Text.Trim();
                string dsnName = txtOdbcDsnName.Text.Trim();
                string driver = ConfigurationManager.AppSettings["OdbcDriver"] ?? "SQL Server";

                if (!await TestDbConnectionAsync(new SqlConnectionStringBuilder { DataSource = server, UserID = user, Password = pass, InitialCatalog = db, ConnectTimeout = 5 }.ConnectionString, _cancellationTokenSource.Token))
                {
                    MessageBox.Show("Could not connect to the database. Please check settings.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Log("Connection test passed. Creating 32-bit and 64-bit DSNs...");
                var scriptBuilder = new StringBuilder();
                scriptBuilder.AppendLine("$ErrorActionPreference = 'Stop';");
                scriptBuilder.AppendLine("function New-OdbcDsnInRegistry { param ([string]$RegistryPath, [string]$DsnName, [string]$Driver, [string]$Server, [string]$Database, [string]$User) $dsnKeyPath = Join-Path -Path $RegistryPath -ChildPath $DsnName; $odbcDataSourcesPath = Join-Path -Path $RegistryPath -ChildPath 'ODBC Data Sources'; if (-not (Test-Path $odbcDataSourcesPath)) { New-Item -Path $odbcDataSourcesPath -Force | Out-Null; } if (-not (Test-Path $dsnKeyPath)) { New-Item -Path $dsnKeyPath -Force | Out-Null; } Set-ItemProperty -Path $dsnKeyPath -Name 'Driver' -Value $Driver; Set-ItemProperty -Path $dsnKeyPath -Name 'Server' -Value $Server; if ($Database) { Set-ItemProperty -Path $dsnKeyPath -Name 'Database' -Value $Database; } if ($User) { Set-ItemProperty -Path $dsnKeyPath -Name 'Trusted_Connection' -Value 'No'; Set-ItemProperty -Path $dsnKeyPath -Name 'LastUser' -Value $User; } else { Set-ItemProperty -Path $dsnKeyPath -Name 'Trusted_Connection' -Value 'Yes'; } Set-ItemProperty -Path $odbcDataSourcesPath -Name $DsnName -Value $Driver; }");
                scriptBuilder.AppendLine("try { Write-Output '--- Creating 64-bit System DSN ---'; New-OdbcDsnInRegistry -RegistryPath 'HKLM:\\SOFTWARE\\ODBC\\ODBC.INI' -DsnName '" + dsnName + "' -Driver '" + driver + "' -Server '" + server + "' -Database '" + db + "' -User '" + user + "'; Write-Output '64-bit DSN created successfully.'; Write-Output '--- Creating 32-bit System DSN ---'; New-OdbcDsnInRegistry -RegistryPath 'HKLM:\\SOFTWARE\\WOW6432Node\\ODBC\\ODBC.INI' -DsnName '" + dsnName + "' -Driver '" + driver + "' -Server '" + server + "' -Database '" + db + "' -User '" + user + "'; Write-Output '32-bit DSN created successfully.'; Write-Output 'PowerShell: DSN creation process completed successfully!'; } catch { $errMsg = 'PowerShell Registry Error: ' + $_.Exception.Message; Write-Error -Message $errMsg; exit 1; }");
                string powerShellExePath = "powershell.exe";
                var encodedCommand = Convert.ToBase64String(Encoding.Unicode.GetBytes(scriptBuilder.ToString()));
                string result = await RunProcessAsync(powerShellExePath, $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedCommand}", _cancellationTokenSource.Token);
                Log(result);
            }
            catch (OperationCanceledException) { Log("ODBC creation cancelled."); }
            finally { ToggleAllButtons(true); _cancellationTokenSource.Dispose(); }
        }

        private async void btnSetLocalization_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Applying All Localization Settings ---");
            ToggleAllButtons(false);
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                await Task.Run(() =>
                {
                    // 1. Set Region to Thailand
                    Log("1. Setting Region and Formats to Thailand...");
                    try
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
                        key.SetValue("sCountry", "Thailand");
                        key.SetValue("sShortDate", "d/M/yyyy");
                        key.SetValue("sLongDate", "d MMMM yyyy");
                        key.SetValue("iCountry", "66");
                        key.SetValue("sCurrency", "฿");
                        key.SetValue("sDecimal", ".");
                        key.SetValue("sThousand", ",");
                        key.SetValue("Locale", "0000041e"); // Thai Locale ID
                        key.Close();
                        Log("   -> Region settings applied.");
                    }
                    catch (Exception ex) { Log($"   -> [ERROR] Failed to set region: {ex.Message}"); }

                    // 2. Set Keyboard Layouts (EN/TH)
                    Log("2. Setting Keyboard Layouts to EN-US and TH-Kedmanee...");
                    try
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Keyboard Layout\Preload", true);
                        key.SetValue("1", "00000409"); // English - United States
                        key.SetValue("2", "0000041e"); // Thai - Kedmanee
                        key.Close();
                        Log("   -> Keyboard layouts applied.");
                    }
                    catch (Exception ex) { Log($"   -> [ERROR] Failed to set keyboard layouts: {ex.Message}"); }

                    // 3. Set Language Hotkey
                    Log("3. Setting language switch hotkey...");
                    try
                    {
                        string hotkey = radLangSwitchGrave.Checked ? "3" : "1"; // 3 for Grave, 1 for Alt+Shift
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Keyboard Layout\Toggle", true);
                        key.SetValue("Language Hotkey", hotkey, RegistryValueKind.String);
                        key.Close();
                        Log(radLangSwitchGrave.Checked ? "   -> Hotkey set to Grave Accent (~)." : "   -> Hotkey set to Left Alt + Shift.");
                    }
                    catch (Exception ex) { Log($"   -> [ERROR] Failed to set language hotkey: {ex.Message}"); }
                }, _cancellationTokenSource.Token);

                // 4. Set Time Zone
                Log("4. Setting Time Zone to SE Asia Standard Time...");
                string tzResult = await RunProcessAsync("tzutil.exe", "/s \"SE Asia Standard Time\"", _cancellationTokenSource.Token);
                Log(tzResult);

                if (!_cancellationTokenSource.IsCancellationRequested)
                {
                    Log("\n--- All Localization Steps Completed ---");
                    MessageBox.Show("Localization settings have been applied. A restart may be required for all changes to take full effect.", "Process Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (OperationCanceledException) { Log("Localization cancelled."); }
            catch (Exception ex)
            {
                Log($"[FATAL ERROR] An unexpected error occurred: {ex.GetBaseException().Message}");
                MessageBox.Show($"An unexpected error occurred: \n{ex.GetBaseException().Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { ToggleAllButtons(true); _cancellationTokenSource.Dispose(); }
        }

        private void btnInstallFonts_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Installing fonts for All Users ---");
            ToggleAllButtons(false);
            try
            {
                string fontFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");
                if (!Directory.Exists(fontFolderPath)) { Log($"Folder 'Fonts' not found."); return; }
                var fontFiles = Directory.GetFiles(fontFolderPath, "*.ttf").Concat(Directory.GetFiles(fontFolderPath, "*.otf"));
                if (!fontFiles.Any()) { Log("No font files (.ttf, .otf) found."); return; }
                int successCount = 0;
                string windowsFontsDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
                foreach (var fontFile in fontFiles)
                {
                    try
                    {
                        string destPath = Path.Combine(windowsFontsDir, Path.GetFileName(fontFile));
                        System.IO.File.Copy(fontFile, destPath, true);
                        if (AddFontResource(destPath) != 0) { successCount++; }
                    }
                    catch (Exception ex) { Log($"[Error] '{Path.GetFileName(fontFile)}': {ex.GetBaseException().Message}"); }
                }
                SendMessage(HWND_BROADCAST, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
                Log($"Successfully installed {successCount} font(s).");
            }
            finally { ToggleAllButtons(true); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null) { _cancellationTokenSource.Cancel(); }
        }
        #endregion
    }
}
