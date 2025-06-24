using IWshRuntimeLibrary;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private async Task RunPowerShellScript(string script)
        {
            // Simplified process runner
            Invoke((MethodInvoker)delegate
            {
                listBoxStatus.Items.Add($"Executing PowerShell...");
                listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                ToggleAllButtons(false);
            });
            try
            {
                await Task.Run(() =>
                {
                    // Implementation details...
                });
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)delegate { listBoxStatus.Items.Add($"[Exception] {ex.Message}"); });
            }
            finally
            {
                Invoke((MethodInvoker)delegate
                {
                    listBoxStatus.Items.Add("--- PowerShell script finished ---");
                    listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                    ToggleAllButtons(true);
                });
            }
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            btnCreateOdbc.Enabled = isEnabled;
            btnSetLocalization.Enabled = isEnabled;
            btnInstallFonts.Enabled = isEnabled;
            btnCreateAllShortcuts.Enabled = isEnabled;
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
                MessageBox.Show($"Error loading ODBC settings from App.config:\n{ex.Message}", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Implementation details...
        }

        private async Task<bool> TestDbConnectionAsync(string connectionString)
        {
            listBoxStatus.Items.Add("Attempting to connect to SQL Server...");
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    listBoxStatus.Items.Add("  -> Connection Successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                listBoxStatus.Items.Add("  -> Connection Failed!");
                listBoxStatus.Items.Add($"  -> Error: {ex.Message}");
                return false;
            }
        }

        private void UpdateAppConfig()
        {
            listBoxStatus.Items.Add("Checking for changes to update App.config...");
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                bool changed = false;
                if (settings["OdbcDsnName"].Value != txtOdbcDsnName.Text) { settings["OdbcDsnName"].Value = txtOdbcDsnName.Text; changed = true; }
                if (settings["OdbcServer"].Value != txtOdbcServer.Text) { settings["OdbcServer"].Value = txtOdbcServer.Text; changed = true; }
                if (settings["OdbcDatabase"].Value != txtOdbcDb.Text) { settings["OdbcDatabase"].Value = txtOdbcDb.Text; changed = true; }
                if (settings["OdbcUid"].Value != txtOdbcUid.Text) { settings["OdbcUid"].Value = txtOdbcUid.Text; changed = true; }
                if (settings["OdbcPwd"].Value != txtOdbcPwd.Text) { settings["OdbcPwd"].Value = txtOdbcPwd.Text; changed = true; }

                if (changed)
                {
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                    listBoxStatus.Items.Add("  -> App.config updated successfully.");
                }
                else
                {
                    listBoxStatus.Items.Add("  -> No changes detected. App.config is up to date.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                listBoxStatus.Items.Add($"[Error] Could not update App.config: {ex.Message}");
            }
        }
        #endregion

        #region Button Click Handlers

        private async void btnCreateOdbc_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            ToggleAllButtons(false);

            string server = txtOdbcServer.Text.Trim();
            string db = txtOdbcDb.Text.Trim();
            string user = txtOdbcUid.Text.Trim();
            string pass = txtOdbcPwd.Text.Trim();
            string dsnName = txtOdbcDsnName.Text.Trim();

            // Step 1: Test Connection
            var csBuilder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = db,
                UserID = user,
                Password = pass,
                ConnectTimeout = 5 // 5 seconds timeout
            };

            bool canConnect = await TestDbConnectionAsync(csBuilder.ConnectionString);

            if (!canConnect)
            {
                MessageBox.Show("Could not connect to the database. Please check the settings and try again.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleAllButtons(true);
                return;
            }

            // Step 2: Update App.config if needed
            UpdateAppConfig();

            // Step 3: Create the DSN
            listBoxStatus.Items.Add("Connection test passed. Creating DSN...");
            string driver = ConfigurationManager.AppSettings["OdbcDriver"] ?? "SQL Server";
            var properties = new List<string>
            {
                $"\"Server={server}\"",
                $"\"Database={db}\"",
                $"\"UID={user}\"",
                $"\"PWD={pass}\""
            };
            string propertyString = string.Join(",", properties);
            string script = $"Add-Dsn -Name '{dsnName}' -DsnType 'System' -Platform '64-bit' -DriverName '{driver}' -SetPropertyValue @({propertyString})";
            await RunPowerShellScript(script);

            ToggleAllButtons(true);
        }

        // 2, 3, 4. Localization Settings (Unchanged)
        private async void btnSetLocalization_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- Setting Localization (Timezone, Region, Keyboard) ---");
            await RunProcessAsync("tzutil.exe", "/s \"SE Asia Standard Time\"");
            string script = "$list = New-WinUserLanguageList -Language 'th-TH'; $list.Add('en-US'); Set-WinUserLanguageList -LanguageList $list -Force;";
            await RunPowerShellScript(script);
            await RunPowerShellScript("Set-WinSystemLocale -SystemLocale th-TH");
            try
            {
                Registry.CurrentUser.CreateSubKey(@"Keyboard Layout\Toggle")?.SetValue("Language Hotkey", "3", RegistryValueKind.String);
                listBoxStatus.Items.Add("  - Set language hotkey successfully.");
            }
            catch (Exception ex)
            {
                listBoxStatus.Items.Add($"  - Error setting registry key: {ex.Message}");
            }
        }

        // 5. Install Fonts (Unchanged)
        private void btnInstallFonts_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- Installing fonts ---");
            ToggleAllButtons(false);
            string fontFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");
            if (!Directory.Exists(fontFolderPath)) { listBoxStatus.Items.Add($"Folder 'Fonts' not found."); ToggleAllButtons(true); return; }
            var fontFiles = Directory.GetFiles(fontFolderPath, "*.ttf").Concat(Directory.GetFiles(fontFolderPath, "*.otf"));
            if (!fontFiles.Any()) { listBoxStatus.Items.Add("No font files (.ttf, .otf) found."); ToggleAllButtons(true); return; }
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
                catch (Exception ex) { listBoxStatus.Items.Add($"[Error] '{Path.GetFileName(fontFile)}': {ex.Message}"); }
            }
            SendMessage(HWND_BROADCAST, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            listBoxStatus.Items.Add($"Successfully installed {successCount} font(s).");
            ToggleAllButtons(true);
        }

        // 6. Create ALL shortcuts from JSON
        private void btnCreateAllShortcuts_Click(object sender, EventArgs e)
        {
            if (shortcutsToCreate == null || !shortcutsToCreate.Any())
            {
                MessageBox.Show("No shortcuts loaded from shortcuts.json.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add($"--- Creating {shortcutsToCreate.Count} shortcuts on Desktop ---");
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
                    listBoxStatus.Items.Add($"  - Created '{shortcutConfig.Name}.lnk'");
                    successCount++;
                }
                catch (Exception ex)
                {
                    listBoxStatus.Items.Add($"  - [Error] Failed to create '{shortcutConfig.Name}': {ex.Message}");
                }
            }

            listBoxStatus.Items.Add($"--- Successfully created {successCount} shortcut(s) ---");
            ToggleAllButtons(true);
        }
        #endregion
    }

    // Helper class to deserialize JSON
    public class ShortcutConfig
    {
        public string Name { get; set; }
        public string TargetPath { get; set; }
        public string Description { get; set; }
    }
}
