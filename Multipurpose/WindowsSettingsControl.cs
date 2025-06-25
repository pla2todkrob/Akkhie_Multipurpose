using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            if (txtStatus.InvokeRequired)
            {
                txtStatus.Invoke(new Action(() => Log(message)));
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


        private async Task<string> RunProcessAsync(string fileName, string arguments)
        {
            var outputBuilder = new StringBuilder();
            try
            {
                await Task.Run(() =>
                {
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
                        outputBuilder.Append(process.StandardOutput.ReadToEnd());
                        outputBuilder.Append(process.StandardError.ReadToEnd());
                        process.WaitForExit();
                    }
                });
            }
            catch (Exception ex)
            {
                outputBuilder.AppendLine($"An error occurred: {ex.GetBaseException().Message}");
            }
            return outputBuilder.ToString();
        }

        private async Task RunPowerShellScript(string script)
        {
            Log("--- Executing PowerShell Script ---");
            string powerShellExePath = Get64BitPowerShellPath();
            Log($"--- Executing with: {powerShellExePath} ---");
            string result = await RunProcessAsync(powerShellExePath, $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"");
            Log(result);
        }


        private void ToggleAllButtons(bool isEnabled)
        {
            btnCreateOdbc.Enabled = isEnabled;
            btnSetLocalization.Enabled = isEnabled;
            btnInstallFonts.Enabled = isEnabled;
            btnCreateAllShortcuts.Enabled = isEnabled;
            btnInstallCrystalReports.Enabled = isEnabled; // Add new button here
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

        private async Task<bool> TestDbConnectionAsync(string connectionString)
        {
            Log("Attempting to connect to SQL Server...");
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    Log("  -> Connection Successful!");
                    return true;
                }
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

            try
            {
                string server = txtOdbcServer.Text.Trim();
                string db = txtOdbcDb.Text.Trim();
                string user = txtOdbcUid.Text.Trim();
                string pass = txtOdbcPwd.Text.Trim();
                string dsnName = txtOdbcDsnName.Text.Trim();
                string driver = ConfigurationManager.AppSettings["OdbcDriver"] ?? "SQL Server";

                // Step 1: Test connection
                var csBuilder = new SqlConnectionStringBuilder { DataSource = server, ConnectTimeout = 5 };
                if (!string.IsNullOrEmpty(user))
                {
                    csBuilder.UserID = user;
                    csBuilder.Password = pass;
                }
                else
                {
                    csBuilder.IntegratedSecurity = true;
                }
                if (!string.IsNullOrEmpty(db))
                {
                    csBuilder.InitialCatalog = db;
                }

                if (!await TestDbConnectionAsync(csBuilder.ConnectionString))
                {
                    MessageBox.Show("Could not connect to the database. Please check settings.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Update config
                UpdateAppConfig();

                // Step 3: Build and run PowerShell script
                Log("Connection test passed. Creating 32-bit and 64-bit DSNs...");

                var scriptBuilder = new StringBuilder();
                scriptBuilder.AppendLine("$ErrorActionPreference = 'Stop';");

                scriptBuilder.AppendLine("function New-OdbcDsnInRegistry {");
                scriptBuilder.AppendLine("    param ([string]$RegistryPath, [string]$DsnName, [string]$Driver, [string]$Server, [string]$Database, [string]$User)");
                scriptBuilder.AppendLine("    $dsnKeyPath = Join-Path -Path $RegistryPath -ChildPath $DsnName;");
                scriptBuilder.AppendLine("    $odbcDataSourcesPath = Join-Path -Path $RegistryPath -ChildPath 'ODBC Data Sources';");
                scriptBuilder.AppendLine("    if (-not (Test-Path $odbcDataSourcesPath)) { New-Item -Path $odbcDataSourcesPath -Force | Out-Null; }");
                scriptBuilder.AppendLine("    if (-not (Test-Path $dsnKeyPath)) { New-Item -Path $dsnKeyPath -Force | Out-Null; }");
                scriptBuilder.AppendLine($"    Set-ItemProperty -Path $dsnKeyPath -Name 'Driver' -Value $Driver;");
                scriptBuilder.AppendLine($"    Set-ItemProperty -Path $dsnKeyPath -Name 'Server' -Value $Server;");
                scriptBuilder.AppendLine("    if ($Database) { Set-ItemProperty -Path $dsnKeyPath -Name 'Database' -Value $Database; }");
                scriptBuilder.AppendLine("    if ($User) { Set-ItemProperty -Path $dsnKeyPath -Name 'Trusted_Connection' -Value 'No'; Set-ItemProperty -Path $dsnKeyPath -Name 'LastUser' -Value $User; }");
                scriptBuilder.AppendLine("    else { Set-ItemProperty -Path $dsnKeyPath -Name 'Trusted_Connection' -Value 'Yes'; }");
                scriptBuilder.AppendLine($"    Set-ItemProperty -Path $odbcDataSourcesPath -Name $DsnName -Value $Driver;");
                scriptBuilder.AppendLine("}");

                scriptBuilder.AppendLine("try {");
                scriptBuilder.AppendLine("    Write-Output '--- Creating 64-bit System DSN ---';");
                scriptBuilder.AppendLine($"    New-OdbcDsnInRegistry -RegistryPath 'HKLM:\\SOFTWARE\\ODBC\\ODBC.INI' -DsnName '{dsnName}' -Driver '{driver}' -Server '{server}' -Database '{db}' -User '{user}';");
                scriptBuilder.AppendLine("    Write-Output '64-bit DSN created successfully.';");
                scriptBuilder.AppendLine("    Write-Output '--- Creating 32-bit System DSN ---';");
                scriptBuilder.AppendLine($"    New-OdbcDsnInRegistry -RegistryPath 'HKLM:\\SOFTWARE\\WOW6432Node\\ODBC\\ODBC.INI' -DsnName '{dsnName}' -Driver '{driver}' -Server '{server}' -Database '{db}' -User '{user}';");
                scriptBuilder.AppendLine("    Write-Output '32-bit DSN created successfully.';");
                scriptBuilder.AppendLine("    Write-Output 'PowerShell: DSN creation process completed successfully!';");
                scriptBuilder.AppendLine("} catch { $errMsg = 'PowerShell Registry Error: ' + $_.Exception.Message; Write-Error -Message $errMsg; exit 1; }");

                await RunPowerShellScript(scriptBuilder.ToString());
            }
            finally
            {
                ToggleAllButtons(true);
            }
        }

        private async void btnInstallCrystalReports_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Starting Crystal Reports Installation ---");
            ToggleAllButtons(false);

            try
            {
                // 1. Get Product Key from App.config
                string productKey = ConfigurationManager.AppSettings["CrystalReportsKey"];
                if (string.IsNullOrEmpty(productKey))
                {
                    Log("[Error] CrystalReportsKey not found in App.config.");
                    MessageBox.Show("Crystal Reports Product Key not found in App.config.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Log($"  -> Product Key found.");

                // 2. Define file paths
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string devInstallerPath = Path.Combine(baseDir, "scrdev.msi");
                string runtimeInstallerPath = Path.Combine(baseDir, "CRRuntime_64bit.msi");

                // 3. Check if installers exist
                if (!System.IO.File.Exists(devInstallerPath))
                {
                    Log($"[Error] Developer installer not found at: {devInstallerPath}");
                    MessageBox.Show("Crystal Reports Developer installer (scrdev.msi) not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!System.IO.File.Exists(runtimeInstallerPath))
                {
                    Log($"[Error] Runtime installer not found at: {runtimeInstallerPath}");
                    MessageBox.Show("Crystal Reports Runtime installer (CRRuntime_64bit.msi) not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Log("  -> All installer files found.");

                string msiexecPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "msiexec.exe");

                // 4. Install Developer version
                Log("\n--- Installing Crystal Reports for Visual Studio ---");
                Log("This may take several minutes. Please wait...");
                // msiexec prefers keys without dashes for the PIDKEY property
                string devArgs = $"/i \"{devInstallerPath}\" /qn PIDKEY={productKey.Replace("-", "")}";
                await RunProcessAsync(msiexecPath, devArgs);
                Log("--- Developer installation process finished. ---");

                // 5. Install Runtime version
                Log("\n--- Installing Crystal Reports Runtime (64-bit) ---");
                Log("This may take a moment...");
                string runtimeArgs = $"/i \"{runtimeInstallerPath}\" /qn";
                await RunProcessAsync(msiexecPath, runtimeArgs);
                Log("--- Runtime installation process finished. ---");

                Log("\n--- Crystal Reports installation process completed. ---");
                MessageBox.Show("Crystal Reports installation process has finished. Please check the log for details.", "Installation Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"[FATAL ERROR] An unexpected error occurred: {ex.GetBaseException().Message}");
                MessageBox.Show($"An unexpected error occurred during installation: \n{ex.GetBaseException().Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleAllButtons(true);
            }
        }

        private async void btnSetLocalization_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Setting Localization (Timezone, Region, Keyboard) ---");
            ToggleAllButtons(false);
            await RunProcessAsync("tzutil.exe", "/s \"SE Asia Standard Time\"");
            string script = "$list = New-WinUserLanguageList -Language 'th-TH'; $list.Add('en-US'); Set-WinUserLanguageList -LanguageList $list -Force;";
            await RunPowerShellScript(script);
            await RunPowerShellScript("Set-WinSystemLocale -SystemLocale th-TH");
            try
            {
                Registry.CurrentUser.CreateSubKey(@"Keyboard Layout\Toggle")?.SetValue("Language Hotkey", "3", RegistryValueKind.String);
                Log("  - Set language hotkey successfully.");
            }
            catch (Exception ex)
            {
                Log($"  - Error setting registry key: {ex.GetBaseException().Message}");
            }
            ToggleAllButtons(true);
        }

        private void btnInstallFonts_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Installing fonts ---");
            ToggleAllButtons(false);
            string fontFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");
            if (!Directory.Exists(fontFolderPath)) { Log($"Folder 'Fonts' not found."); ToggleAllButtons(true); return; }
            var fontFiles = Directory.GetFiles(fontFolderPath, "*.ttf").Concat(Directory.GetFiles(fontFolderPath, "*.otf"));
            if (!fontFiles.Any()) { Log("No font files (.ttf, .otf) found."); ToggleAllButtons(true); return; }
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
            ToggleAllButtons(true);
        }

        private void btnCreateAllShortcuts_Click(object sender, EventArgs e)
        {
            if (shortcutsToCreate == null || !shortcutsToCreate.Any())
            {
                MessageBox.Show("No shortcuts loaded from shortcuts.json.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtStatus.Clear();
            Log($"--- Creating {shortcutsToCreate.Count} shortcuts on Desktop ---");
            ToggleAllButtons(false);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int successCount = 0;

            foreach (var shortcutConfig in shortcutsToCreate)
            {
                try
                {
                    string shortcutLocation = Path.Combine(desktopPath, shortcutConfig.Name + ".lnk");
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                    shortcut.Description = shortcutConfig.Description;
                    shortcut.TargetPath = shortcutConfig.TargetPath;
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
            ToggleAllButtons(true);
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
