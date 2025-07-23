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
using IWshRuntimeLibrary;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Multipurpose
{
    public partial class WindowsSettingsControl : UserControl
    {
        // P/Invoke for dynamic font installation
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_FONTCHANGE = 0x001D;
        private static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);

        private List<ShortcutConfig> shortcutsToCreate = new List<ShortcutConfig>();
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
            LoadShortcutsToListView();
        }

        #region Helper and Core Logic Methods

        private void Log(string message)
        {
            // *** FIX: Check if control is disposed before accessing it from an async method ***
            if (this.IsDisposed || (txtStatus != null && txtStatus.IsDisposed))
            {
                return;
            }

            if (txtStatus.InvokeRequired)
            {
                try
                {
                    txtStatus.Invoke(new Action(() => Log(message)));
                }
                catch (ObjectDisposedException) { /* Ignore error if control is disposed during invoke */ }
            }
            else
            {
                txtStatus.AppendText(message + Environment.NewLine);
            }
        }

        private string Get64BitPowerShellPath()
        {
            if (Environment.Is64BitProcess)
            {
                return "powershell.exe";
            }
            if (Environment.Is64BitOperatingSystem)
            {
                string sysnativePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Sysnative", "WindowsPowerShell\\v1.0\\powershell.exe");
                if (System.IO.File.Exists(sysnativePath))
                {
                    return sysnativePath;
                }
            }
            return "powershell.exe";
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
            catch (OperationCanceledException)
            {
                outputBuilder.AppendLine("\n[CANCELLED] The operation was cancelled by the user.");
            }
            catch (Exception ex)
            {
                outputBuilder.AppendLine($"An error occurred: {ex.GetBaseException().Message}");
            }
            return outputBuilder.ToString();
        }

        private async Task RunPowerShellScriptFromFile(string scriptFileName, string stepName, CancellationToken token, Dictionary<string, string> environmentVariables = null)
        {
            Log($"\n--- {stepName} ---");
            string scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts", scriptFileName);

            if (!System.IO.File.Exists(scriptPath))
            {
                Log($"[ERROR] Script file not found: {scriptPath}");
                return;
            }

            string powerShellExePath = Get64BitPowerShellPath();
            string scriptContent = System.IO.File.ReadAllText(scriptPath);

            var scriptBuilder = new StringBuilder();
            if (environmentVariables != null)
            {
                foreach (var kvp in environmentVariables)
                {
                    scriptBuilder.AppendLine($"$env:{kvp.Key} = '{kvp.Value}'");
                }
            }
            scriptBuilder.Append(scriptContent);

            var encodedCommand = Convert.ToBase64String(Encoding.Unicode.GetBytes(scriptBuilder.ToString()));
            string result = await RunProcessAsync(powerShellExePath, $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedCommand}", token);
            Log(result);
        }


        private void ToggleAllButtons(bool isEnabled)
        {
            // *** FIX: Check IsDisposed before invoking ***
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => ToggleAllButtons(isEnabled)));
                }
                catch (ObjectDisposedException) { /* Ignore */ }
                return;
            }

            btnCreateOdbc.Enabled = isEnabled;
            btnSetLocalization.Enabled = isEnabled;
            btnInstallFonts.Enabled = isEnabled;
            btnCreateAllShortcuts.Enabled = isEnabled;
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ODBC settings from App.config:\n{ex.GetBaseException().Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFontList()
        {
            listViewFonts.Items.Clear();
            string fontFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");
            if (!Directory.Exists(fontFolderPath)) return;

            var fontFiles = Directory.GetFiles(fontFolderPath, "*.ttf")
                                     .Concat(Directory.GetFiles(fontFolderPath, "*.otf"));

            foreach (var fontFile in fontFiles)
            {
                listViewFonts.Items.Add(Path.GetFileName(fontFile));
            }
        }

        private void LoadShortcutsToListView()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "shortcuts.json");
            if (!System.IO.File.Exists(jsonPath)) return;
            try
            {
                string jsonContent = System.IO.File.ReadAllText(jsonPath);
                shortcutsToCreate = JsonConvert.DeserializeObject<List<ShortcutConfig>>(jsonContent);

                listViewShortcuts.Items.Clear();
                foreach (var shortcut in shortcutsToCreate)
                {
                    var listViewItem = new ListViewItem(shortcut.Name);
                    listViewItem.SubItems.Add(shortcut.TargetPath);
                    listViewItem.Tag = shortcut;
                    listViewShortcuts.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing shortcuts.json:\n{ex.GetBaseException().Message}", "JSON Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            catch (OperationCanceledException)
            {
                Log("  -> Connection test cancelled.");
                return false;
            }
            catch (Exception ex)
            {
                Log("  -> Connection Failed!");
                Log($"  -> Error: {ex.GetBaseException().Message}");
                return false;
            }
        }

        private void UpdateAppConfig()
        {
            Log("Checking for changes to update App.config...");
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                bool changed = false;
                if (settings["OdbcDsnName"]?.Value != txtOdbcDsnName.Text) { settings["OdbcDsnName"].Value = txtOdbcDsnName.Text; changed = true; }
                if (settings["OdbcServer"]?.Value != txtOdbcServer.Text) { settings["OdbcServer"].Value = txtOdbcServer.Text; changed = true; }
                if (settings["OdbcDatabase"]?.Value != txtOdbcDb.Text) { settings["OdbcDatabase"].Value = txtOdbcDb.Text; changed = true; }
                if (settings["OdbcUid"]?.Value != txtOdbcUid.Text) { settings["OdbcUid"].Value = txtOdbcUid.Text; changed = true; }
                if (settings["OdbcPwd"]?.Value != txtOdbcPwd.Text) { settings["OdbcPwd"].Value = txtOdbcPwd.Text; changed = true; }

                if (changed)
                {
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                    Log("  -> App.config updated successfully.");
                }
                else
                {
                    Log("  -> No changes detected. App.config is up to date.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                Log($"[Error] Could not update App.config: {ex.GetBaseException().Message}");
            }
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

                UpdateAppConfig();
                Log("Connection test passed. Creating 32-bit and 64-bit DSNs...");

                var scriptBuilder = new StringBuilder();
                scriptBuilder.AppendLine("$ErrorActionPreference = 'Stop';");
                scriptBuilder.AppendLine("function New-OdbcDsnInRegistry { param ([string]$RegistryPath, [string]$DsnName, [string]$Driver, [string]$Server, [string]$Database, [string]$User) $dsnKeyPath = Join-Path -Path $RegistryPath -ChildPath $DsnName; $odbcDataSourcesPath = Join-Path -Path $RegistryPath -ChildPath 'ODBC Data Sources'; if (-not (Test-Path $odbcDataSourcesPath)) { New-Item -Path $odbcDataSourcesPath -Force | Out-Null; } if (-not (Test-Path $dsnKeyPath)) { New-Item -Path $dsnKeyPath -Force | Out-Null; } Set-ItemProperty -Path $dsnKeyPath -Name 'Driver' -Value $Driver; Set-ItemProperty -Path $dsnKeyPath -Name 'Server' -Value $Server; if ($Database) { Set-ItemProperty -Path $dsnKeyPath -Name 'Database' -Value $Database; } if ($User) { Set-ItemProperty -Path $dsnKeyPath -Name 'Trusted_Connection' -Value 'No'; Set-ItemProperty -Path $dsnKeyPath -Name 'LastUser' -Value $User; } else { Set-ItemProperty -Path $dsnKeyPath -Name 'Trusted_Connection' -Value 'Yes'; } Set-ItemProperty -Path $odbcDataSourcesPath -Name $DsnName -Value $Driver; }");
                scriptBuilder.AppendLine("try { Write-Output '--- Creating 64-bit System DSN ---'; New-OdbcDsnInRegistry -RegistryPath 'HKLM:\\SOFTWARE\\ODBC\\ODBC.INI' -DsnName '" + dsnName + "' -Driver '" + driver + "' -Server '" + server + "' -Database '" + db + "' -User '" + user + "'; Write-Output '64-bit DSN created successfully.'; Write-Output '--- Creating 32-bit System DSN ---'; New-OdbcDsnInRegistry -RegistryPath 'HKLM:\\SOFTWARE\\WOW6432Node\\ODBC\\ODBC.INI' -DsnName '" + dsnName + "' -Driver '" + driver + "' -Server '" + server + "' -Database '" + db + "' -User '" + user + "'; Write-Output '32-bit DSN created successfully.'; Write-Output 'PowerShell: DSN creation process completed successfully!'; } catch { $errMsg = 'PowerShell Registry Error: ' + $_.Exception.Message; Write-Error -Message $errMsg; exit 1; }");

                string powerShellExePath = Get64BitPowerShellPath();
                var encodedCommand = Convert.ToBase64String(Encoding.Unicode.GetBytes(scriptBuilder.ToString()));
                string result = await RunProcessAsync(powerShellExePath, $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedCommand}", _cancellationTokenSource.Token);
                Log(result);
            }
            catch (OperationCanceledException)
            {
                Log("ODBC creation cancelled.");
            }
            finally
            {
                ToggleAllButtons(true);
                _cancellationTokenSource.Dispose();
            }
        }

        private async void btnSetLocalization_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Applying All Localization Settings ---");
            ToggleAllButtons(false);
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                string hotkey = radLangSwitchGrave.Checked ? "3" : "1";
                var envVars = new Dictionary<string, string> { { "LanguageHotkey", hotkey } };

                await RunPowerShellScriptFromFile("Set-Localization.ps1", "Applying Localization Settings", _cancellationTokenSource.Token, envVars);

                if (!_cancellationTokenSource.IsCancellationRequested)
                {
                    Log("\n--- All Localization Steps Completed ---");
                    MessageBox.Show("Localization settings have been applied for all users. A restart is required for all changes to take full effect.", "Process Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (OperationCanceledException)
            {
                Log("Localization cancelled.");
            }
            catch (Exception ex)
            {
                Log($"[FATAL ERROR] An unexpected error occurred: {ex.GetBaseException().Message}");
                MessageBox.Show($"An unexpected error occurred: \n{ex.GetBaseException().Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleAllButtons(true);
                _cancellationTokenSource.Dispose();
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
            finally
            {
                ToggleAllButtons(true);
            }
        }

        private void btnCreateAllShortcuts_Click(object sender, EventArgs e)
        {
            if (shortcutsToCreate == null || !shortcutsToCreate.Any())
            {
                MessageBox.Show("No shortcuts loaded from shortcuts.json.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtStatus.Clear();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            Log($"--- Creating {shortcutsToCreate.Count} shortcuts on Public Desktop for All Users ---");
            Log($"Target Path: {desktopPath}");

            ToggleAllButtons(false);
            try
            {
                int successCount = 0;

                foreach (var shortcutConfig in shortcutsToCreate)
                {
                    try
                    {
                        string shortcutLocation = Path.Combine(desktopPath, shortcutConfig.Name + ".lnk");
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                        shortcut.Description = shortcutConfig.Description;
                        shortcut.TargetPath = Environment.ExpandEnvironmentVariables(shortcutConfig.TargetPath);
                        shortcut.Save();
                        Log($"  - Created '{shortcutConfig.Name}.lnk'");
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        Log($"  - [Error] Failed to create '{shortcutConfig.Name}': {ex.GetBaseException().Message}");
                    }
                }
                Log($"--- Successfully created {successCount} shortcut(s) ---");
            }
            finally
            {
                ToggleAllButtons(true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }
        #endregion
    }

    public class ShortcutConfig
    {
        public string Name { get; set; }
        public string TargetPath { get; set; }
        public string Description { get; set; }
    }
}
