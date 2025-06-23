using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
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
            // Assign the Load event handler
            this.Load += new System.EventHandler(this.WindowsSettingsControl_Load);
        }

        private void WindowsSettingsControl_Load(object sender, EventArgs e)
        {
            // Prevent execution in Visual Studio Designer
            if (this.DesignMode) return;

            LoadShortcutsToListView();
        }

        #region Helper and Core Logic Methods
        private async Task RunProcessAsync(string fileName, string arguments)
        {
            // This is a simplified version for this control.
            // A more robust version exists in WindowsUpgradeControl.
            Invoke((MethodInvoker)delegate
            {
                listBoxStatus.Items.Add($"Executing: {fileName} {arguments}");
                listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                ToggleAllButtons(false);
            });

            try
            {
                await Task.Run(() =>
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Verb = "runas"
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        process.Start();
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        Invoke((MethodInvoker)delegate
                        {
                            if (!string.IsNullOrWhiteSpace(output)) listBoxStatus.Items.Add($"[Output] {output.Trim()}");
                            if (!string.IsNullOrWhiteSpace(error)) listBoxStatus.Items.Add($"[Error] {error.Trim()}");
                        });
                    }
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
                    listBoxStatus.Items.Add("--- Done ---");
                    listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                    ToggleAllButtons(true);
                });
            }
        }

        private async Task RunPowerShellScript(string script)
        {
            await RunProcessAsync("powershell.exe", $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"");
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            btnCreateOdbc.Enabled = isEnabled;
            btnSetLocalization.Enabled = isEnabled;
            btnInstallFonts.Enabled = isEnabled;
            btnCreateAllShortcuts.Enabled = isEnabled;
        }

        private void LoadShortcutsToListView()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "shortcuts.json");
            if (!System.IO.File.Exists(jsonPath))
            {
                MessageBox.Show("File 'shortcuts.json' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string jsonContent = System.IO.File.ReadAllText(jsonPath);
                shortcutsToCreate = JsonConvert.DeserializeObject<List<ShortcutConfig>>(jsonContent);

                listViewShortcuts.Items.Clear();
                foreach (var shortcut in shortcutsToCreate)
                {
                    var listViewItem = new ListViewItem(shortcut.Name);
                    listViewItem.SubItems.Add(shortcut.TargetPath);
                    listViewItem.Tag = shortcut; // Store the full object
                    listViewShortcuts.Items.Add(listViewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing shortcuts.json:\n{ex.Message}", "JSON Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Click Handlers
        // 1. ODBC Setup from App.config
        private async void btnCreateOdbc_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- Creating System DSN from App.config ---");

            // Read settings from App.config
            string dsnName = ConfigurationManager.AppSettings["OdbcDsnName"];
            string driver = ConfigurationManager.AppSettings["OdbcDriver"];
            string server = ConfigurationManager.AppSettings["OdbcServer"];
            string database = ConfigurationManager.AppSettings["OdbcDatabase"];
            string uid = ConfigurationManager.AppSettings["OdbcUid"];
            string pwd = ConfigurationManager.AppSettings["OdbcPwd"];

            if (string.IsNullOrEmpty(dsnName) || string.IsNullOrEmpty(driver) || string.IsNullOrEmpty(server))
            {
                MessageBox.Show("OdbcDsnName, OdbcDriver, and OdbcServer must be set in App.config.", "Missing Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build the property list for PowerShell
            var properties = new List<string>
            {
                $"\"Server={server}\""
            };
            if (!string.IsNullOrEmpty(database)) properties.Add($"\"Database={database}\"");
            if (!string.IsNullOrEmpty(uid)) properties.Add($"\"UID={uid}\"");
            if (!string.IsNullOrEmpty(pwd)) properties.Add($"\"PWD={pwd}\"");
            // If UID is provided, assume SQL Auth. Otherwise, assume Windows Auth.
            if (string.IsNullOrEmpty(uid)) properties.Add("\"Trusted_Connection=Yes\"");

            string propertyString = string.Join(",", properties);

            string script = $"Add-Dsn -Name '{dsnName}' -DsnType 'System' -Platform '64-bit' -DriverName '{driver}' -SetPropertyValue @({propertyString})";

            await RunPowerShellScript(script);
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
