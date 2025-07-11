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

                        if (!process.WaitForExit(120000))
                        {
                            process.Kill();
                            outputBuilder.AppendLine("\n[FATAL] SCRIPT TIMEOUT: The process took too long to execute and was terminated.");
                        }
                        else
                        {
                            outputBuilder.Append(process.StandardOutput.ReadToEnd());
                            outputBuilder.Append(process.StandardError.ReadToEnd());
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                outputBuilder.AppendLine($"An error occurred: {ex.GetBaseException().Message}");
            }
            return outputBuilder.ToString();
        }

        private async Task RunPowerShellScript(string script, string stepName)
        {
            Log($"\n--- {stepName} ---");
            string powerShellExePath = Get64BitPowerShellPath();
            var encodedCommand = Convert.ToBase64String(Encoding.Unicode.GetBytes(script));
            string result = await RunProcessAsync(powerShellExePath, $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedCommand}");
            Log(result);
        }


        private void ToggleAllButtons(bool isEnabled)
        {
            btnCreateOdbc.Enabled = isEnabled;
            btnSetLocalization.Enabled = isEnabled;
            btnInstallFonts.Enabled = isEnabled;
            btnCreateAllShortcuts.Enabled = isEnabled;
            radLangSwitchGrave.Enabled = isEnabled;
            radLangSwitchAltShift.Enabled = isEnabled;
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

                if (!await TestDbConnectionAsync(new SqlConnectionStringBuilder { DataSource = server, UserID = user, Password = pass, InitialCatalog = db, ConnectTimeout = 5 }.ConnectionString))
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

                await RunPowerShellScript(scriptBuilder.ToString(), "Creating ODBC DSN");
            }
            finally
            {
                ToggleAllButtons(true);
            }
        }

        private async void btnSetLocalization_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            Log("--- Applying All Localization Settings ---");
            ToggleAllButtons(false);

            try
            {
                string hotkey = radLangSwitchGrave.Checked ? "3" : "1";

                // --- Step 1: System-Wide Settings ---
                var script1 = new StringBuilder();
                script1.AppendLine("$ErrorActionPreference = 'Stop'");
                script1.AppendLine("Write-Output 'Setting Time Zone...'");
                script1.AppendLine("Set-TimeZone -Id 'SE Asia Standard Time'");
                script1.AppendLine("Write-Output 'Configuring Time Sync Service...'");
                script1.AppendLine("if ((Get-CimInstance -ClassName Win32_ComputerSystem).PartOfDomain) {");
                script1.AppendLine("    Write-Output '-> Skipping Time Sync on domain-joined machine.'");
                script1.AppendLine("} else {");
                script1.AppendLine("    Set-Service -Name w32time -StartupType Automatic; Start-Service -Name w32time");
                script1.AppendLine("}");
                script1.AppendLine("Write-Output 'Setting System Locale...'");
                script1.AppendLine("Set-WinSystemLocale -SystemLocale 'th-TH'");
                script1.AppendLine("Write-Output 'Setting Home Location...'");
                script1.AppendLine("Set-WinHomeLocation -GeoId 244");
                script1.AppendLine("Write-Output 'Setting Regional Format...'");
                script1.AppendLine("Set-Culture -CultureInfo 'th-TH'");
                script1.AppendLine("Write-Output 'Setting Display Language and Input Preferences...'");
                script1.AppendLine("$LangList = New-WinUserLanguageList en-US");
                script1.AppendLine("$LangList.Add('th-TH')");
                script1.AppendLine("$LangList[0].InputMethodTips.Clear()");
                script1.AppendLine("$LangList[0].InputMethodTips.Add('0409:00000409')");
                script1.AppendLine("$LangList[1].InputMethodTips.Clear()");
                script1.AppendLine("$LangList[1].InputMethodTips.Add('041e:0000041e')");
                script1.AppendLine("Set-WinUserLanguageList $LangList -Force");
                script1.AppendLine("Set-WinUILanguageOverride -Language 'en-US'");
                await RunPowerShellScript(script1.ToString(), "Step 1/3: Applying System-Wide Settings");

                // --- Step 2: Default User Settings (for new users) ---
                var script2 = new StringBuilder();
                script2.AppendLine("$ErrorActionPreference = 'Stop'");
                script2.AppendLine($"$regContent = @\"");
                script2.AppendLine("Windows Registry Editor Version 5.00`r`n");
                script2.AppendLine("[HKEY_LOCAL_MACHINE\\DefaultUser\\Control Panel\\International]");
                script2.AppendLine("\"\"sCountry\"\"=\"\"Thailand\"\"");
                script2.AppendLine("\"\"LocaleName\"\"=\"\"th-TH\"\"`r`n");
                script2.AppendLine("[HKEY_LOCAL_MACHINE\\DefaultUser\\Control Panel\\International\\Geo]");
                script2.AppendLine("\"\"Nation\"\"=\"\"244\"\"`r`n");
                script2.AppendLine("[HKEY_LOCAL_MACHINE\\DefaultUser\\Keyboard Layout\\Preload]");
                script2.AppendLine("\"\"1\"\"=\"\"00000409\"\"");
                script2.AppendLine("\"\"2\"\"=\"\"0000041e\"\"`r`n");
                script2.AppendLine("[HKEY_LOCAL_MACHINE\\DefaultUser\\Control Panel\\International\\User Profile]");
                script2.AppendLine("\"\"Languages\"\"=hex(7):65,00,6e,00,2d,00,55,00,53,00,00,00,74,00,68,00,2d,00,54,00,48,00,00,00,00,00`r`n");
                script2.AppendLine("[HKEY_LOCAL_MACHINE\\DefaultUser\\Keyboard Layout\\Toggle]");
                script2.AppendLine($"\"\"Language Hotkey\"\"=\"\"{hotkey}\"\"");
                script2.AppendLine("\"\"Layout Hotkey\"\"=\"\"3\"\"");
                script2.AppendLine("\"@");
                script2.AppendLine("$regFile = Join-Path $env:TEMP 'default_user.reg'");
                script2.AppendLine("$regContent | Out-File -FilePath $regFile -Encoding Unicode -Force");
                script2.AppendLine("$regExeHivePath = 'HKLM\\DefaultUser'");
                script2.AppendLine("try {");
                script2.AppendLine("    Write-Output 'Loading Default User hive...'");
                script2.AppendLine("    reg load $regExeHivePath 'C:\\Users\\Default\\NTUSER.DAT'");
                script2.AppendLine("    Write-Output 'Importing settings...'");
                script2.AppendLine("    reg import $regFile");
                script2.AppendLine("}");
                script2.AppendLine("finally {");
                script2.AppendLine("    if (Test-Path 'HKLM:\\DefaultUser') {");
                script2.AppendLine("        Write-Output 'Unloading Default User hive...'");
                script2.AppendLine("        reg unload $regExeHivePath");
                script2.AppendLine("    }");
                script2.AppendLine("    Remove-Item $regFile -Force -ErrorAction SilentlyContinue");
                script2.AppendLine("}");
                await RunPowerShellScript(script2.ToString(), "Step 2/3: Applying Settings for New Users");

                // --- Step 3: Existing User Settings ---
                var script3 = new StringBuilder();
                script3.AppendLine("$ErrorActionPreference = 'Stop'");
                script3.AppendLine("Get-ChildItem 'Registry::HKEY_USERS' | Where-Object { $_.Name -match 'S-1-5-21-' } | ForEach-Object {");
                script3.AppendLine("    $regHivePath = $_.Name.Replace('HKEY_USERS', 'HKEY_USERS')");
                script3.AppendLine("    $sid = $_.PSChildName");
                script3.AppendLine("    try { $userName = (New-Object System.Security.Principal.SecurityIdentifier($sid)).Translate([System.Security.Principal.NTAccount]).Value } catch { $userName = \"SID: $sid\" }");
                script3.AppendLine("    Write-Output \"Processing user: $userName\"");
                script3.AppendLine($"   $regContent = @\"");
                script3.AppendLine("Windows Registry Editor Version 5.00`r`n");
                script3.AppendLine("[$($regHivePath)\\Control Panel\\International]");
                script3.AppendLine("\"\"sCountry\"\"=\"\"Thailand\"\"");
                script3.AppendLine("\"\"LocaleName\"\"=\"\"th-TH\"\"`r`n");
                script3.AppendLine("[$($regHivePath)\\Control Panel\\International\\Geo]");
                script3.AppendLine("\"\"Nation\"\"=\"\"244\"\"`r`n");
                script3.AppendLine("[$($regHivePath)\\Keyboard Layout\\Preload]");
                script3.AppendLine("\"\"1\"\"=\"\"00000409\"\"");
                script3.AppendLine("\"\"2\"\"=\"\"0000041e\"\"`r`n");
                script3.AppendLine("[$($regHivePath)\\Control Panel\\International\\User Profile]");
                script3.AppendLine("\"\"Languages\"\"=hex(7):65,00,6e,00,2d,00,55,00,53,00,00,00,74,00,68,00,2d,00,54,00,48,00,00,00,00,00`r`n");
                script3.AppendLine("[$($regHivePath)\\Keyboard Layout\\Toggle]");
                script3.AppendLine($"\"\"Language Hotkey\"\"=\"\"{hotkey}\"\"");
                script3.AppendLine("\"\"Layout Hotkey\"\"=\"\"3\"\"");
                script3.AppendLine("\"@");
                script3.AppendLine("    $regFile = Join-Path $env:TEMP \"user_$($sid).reg\"");
                script3.AppendLine("    $regContent | Out-File -FilePath $regFile -Encoding Unicode -Force");
                script3.AppendLine("    reg import $regFile");
                script3.AppendLine("    Remove-Item $regFile -Force -ErrorAction SilentlyContinue");
                script3.AppendLine("}");
                await RunPowerShellScript(script3.ToString(), "Step 3/3: Applying Settings for Existing Users");

                Log("\n--- All Localization Steps Completed ---");
                MessageBox.Show("Localization settings have been applied for all users. A restart is required for all changes to take full effect.", "Process Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log($"[FATAL ERROR] An unexpected error occurred: {ex.GetBaseException().Message}");
                MessageBox.Show($"An unexpected error occurred: \n{ex.GetBaseException().Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleAllButtons(true);
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
        #endregion
    }

    public class ShortcutConfig
    {
        public string Name { get; set; }
        public string TargetPath { get; set; }
        public string Description { get; set; }
    }
}
