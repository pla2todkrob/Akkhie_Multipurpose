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
            finally { ToggleAllButtons(true); if (_cancellationTokenSource != null) _cancellationTokenSource.Dispose(); }
        }

        private async void btnSetLocalization_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Applying System-Wide Localization Settings ---");
            ToggleAllButtons(false);
            _cancellationTokenSource = new CancellationTokenSource();

            string tempPath = Path.GetTempPath();
            string xmlPath = Path.Combine(tempPath, "multipurpose_intl.xml");
            string scriptPath = Path.Combine(tempPath, "multipurpose_localize.ps1");

            try
            {
                // --- 1. Create the XML file to copy settings ---
                Log("1. Preparing configuration file...");
                string xmlContent = @"
<gs:GlobalizationServices xmlns:gs=""urn:longhornGlobalizationUnattended"">
    <gs:UserList>
        <gs:User UserID=""Current"" CopySettingsToDefaultUserAcct=""true"" CopySettingsToSystemAcct=""true"" />
    </gs:UserList>
</gs:GlobalizationServices>
".Trim();
                File.WriteAllText(xmlPath, xmlContent);
                Log($"   -> Configuration file created at: {xmlPath}");

                // --- 2. Create the PowerShell script ---
                Log("2. Preparing PowerShell script...");
                string hotkey = radLangSwitchGrave.Checked ? "3" : "1"; // 3 for Grave, 1 for Alt+Shift
                var scriptBuilder = new StringBuilder();
                scriptBuilder.AppendLine("$ErrorActionPreference = 'Stop'");
                scriptBuilder.AppendLine("try {");
                scriptBuilder.AppendLine("    Write-Output '--- Step A: Setting registry for current administrator session (as template) ---'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'sCountry' -Value 'Thailand'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'sShortDate' -Value 'd/M/yyyy'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'sLongDate' -Value 'd MMMM yyyy'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'iCountry' -Value '66'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'sCurrency' -Value '฿'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'sDecimal' -Value '.'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'sThousand' -Value ','");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Control Panel\\International' -Name 'Locale' -Value '0000041e'");
                scriptBuilder.AppendLine("    Write-Output '  - Region and formats set.'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Keyboard Layout\\Preload' -Name '1' -Value '00000409'");
                scriptBuilder.AppendLine("    Set-ItemProperty -Path 'HKCU:\\Keyboard Layout\\Preload' -Name '2' -Value '0000041e'");
                scriptBuilder.AppendLine("    Write-Output '  - Keyboard layouts (EN/TH) set.'");
                scriptBuilder.AppendLine("    if (-not (Test-Path 'HKCU:\\Keyboard Layout\\Toggle')) { New-Item -Path 'HKCU:\\Keyboard Layout\\Toggle' | Out-Null }");
                scriptBuilder.AppendLine($"   Set-ItemProperty -Path 'HKCU:\\Keyboard Layout\\Toggle' -Name 'Language Hotkey' -Value '{hotkey}'");
                scriptBuilder.AppendLine("    Write-Output '  - Language hotkey set.'");
                scriptBuilder.AppendLine("    Write-Output '--- Step B: Setting system-wide time zone ---'");
                scriptBuilder.AppendLine("    Set-TimeZone -Id 'SE Asia Standard Time'");
                scriptBuilder.AppendLine("    Write-Output '  - Time zone set to SE Asia Standard Time.'");
                scriptBuilder.AppendLine("    Write-Output '--- Step C: Applying settings to Default User and Welcome Screen ---'");
                // --- FIX: Use Start-Process for robust execution of control.exe ---
                scriptBuilder.AppendLine($"   Start-Process -FilePath 'control.exe' -ArgumentList 'intl.cpl,, /f:\"{xmlPath}\"' -Wait");
                scriptBuilder.AppendLine("    Write-Output '--- PowerShell script completed successfully! ---'");
                scriptBuilder.AppendLine("} catch {");
                scriptBuilder.AppendLine("    Write-Error -Message \"PowerShell Error: $($_.Exception.Message)\"");
                scriptBuilder.AppendLine("    exit 1");
                scriptBuilder.AppendLine("}");

                File.WriteAllText(scriptPath, scriptBuilder.ToString(), Encoding.UTF8);
                Log($"   -> PowerShell script created at: {scriptPath}");

                // --- 3. Execute the script ---
                Log("3. Executing script with administrator privileges...");
                string powerShellExePath = "powershell.exe";
                string arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\"";
                string result = await RunProcessAsync(powerShellExePath, arguments, _cancellationTokenSource.Token);
                Log(result);

                if (!_cancellationTokenSource.IsCancellationRequested && !result.Contains("PowerShell Error"))
                {
                    Log("\n--- All System-Wide Localization Steps Completed ---");
                    MessageBox.Show("System-wide localization settings have been applied.\nThese settings will take effect for any NEW user logging into this machine.\nA restart may be required for all changes to take full effect.", "Process Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result.Contains("PowerShell Error"))
                {
                    MessageBox.Show("The script encountered an error. Please check the log for details.", "Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (OperationCanceledException) { Log("Localization cancelled by user."); }
            catch (Exception ex)
            {
                Log($"[FATAL ERROR] An unexpected error occurred: {ex.GetBaseException().Message}");
                MessageBox.Show($"An unexpected error occurred: \n{ex.GetBaseException().Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // --- 4. Clean up temporary files ---
                try
                {
                    if (File.Exists(xmlPath)) File.Delete(xmlPath);
                    if (File.Exists(scriptPath)) File.Delete(scriptPath);
                    Log("Temporary files cleaned up.");
                }
                catch (Exception ex)
                {
                    Log($"Warning: Could not clean up temporary files. {ex.Message}");
                }

                ToggleAllButtons(true);
                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = null;
                }
            }
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
