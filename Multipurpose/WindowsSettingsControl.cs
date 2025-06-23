using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading; // Add this namespace for synchronous waiting
// Important: Add a COM Reference to "Windows Script Host Object Model" for this to work.
// In Solution Explorer -> Right-click on References -> Add Reference -> COM -> Find and check "Windows Script Host Object Model"
using IWshRuntimeLibrary;

namespace Multipurpose
{
    public partial class WindowsSettingsControl : UserControl
    {
        // P/Invoke for dynamic font installation without reboot
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        [DllImport("gdi32.dll", EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        public static extern int RemoveFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_FONTCHANGE = 0x001D;
        private static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);


        public WindowsSettingsControl()
        {
            InitializeComponent();
        }

        #region Helper Methods

        /// <summary>
        /// Runs a PowerShell script and displays the output in the ListBox.
        /// </summary>
        private async Task RunPowerShellScript(string script)
        {
            await RunProcess("powershell.exe", $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"");
        }

        /// <summary>
        /// Runs a command using cmd.exe.
        /// </summary>
        private async Task RunCmdCommand(string command)
        {
            await RunProcess("cmd.exe", $"/C {command}");
        }

        /// <summary>
        /// The core process runner.
        /// </summary>
        private async Task RunProcess(string fileName, string arguments)
        {
            Invoke((MethodInvoker)delegate
            {
                listBoxStatus.Items.Add($"Executing: {fileName} {arguments}");
                listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                ToggleButtons(false); // Disable buttons
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
                        Verb = "runas" // Ensure it runs with admin privileges
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        var outputBuilder = new StringBuilder();
                        var errorBuilder = new StringBuilder();

                        process.OutputDataReceived += (sender, args) => { if (args.Data != null) outputBuilder.AppendLine(args.Data); };
                        process.ErrorDataReceived += (sender, args) => { if (args.Data != null) errorBuilder.AppendLine(args.Data); };

                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        process.WaitForExit(); // Use synchronous wait instead of WaitForExitAsync

                        string output = outputBuilder.ToString();
                        string error = errorBuilder.ToString();

                        Invoke((MethodInvoker)delegate
                        {
                            if (!string.IsNullOrWhiteSpace(output))
                            {
                                listBoxStatus.Items.Add("[Output]");
                                foreach (var line in output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    listBoxStatus.Items.Add($"  {line}");
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(error))
                            {
                                listBoxStatus.Items.Add("[Error]");
                                foreach (var line in error.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    listBoxStatus.Items.Add($"  {line}");
                                }
                            }
                            listBoxStatus.Items.Add("--- Done ---");
                            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)delegate
                {
                    listBoxStatus.Items.Add($"An error occurred: {ex.Message}");
                    listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                });
            }
            finally
            {
                Invoke((MethodInvoker)delegate
                {
                    ToggleButtons(true); // Re-enable buttons
                });
            }
        }

        /// <summary>
        /// Toggles the enabled state of all buttons on the control.
        /// </summary>
        private void ToggleButtons(bool isEnabled)
        {
            // This iterates through all controls and disables/enables buttons
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control child in c.Controls)
                    {
                        if (child is Button)
                        {
                            child.Enabled = isEnabled;
                        }
                    }
                }
                else if (c is Button)
                {
                    c.Enabled = isEnabled;
                }
            }
        }
        #endregion

        #region Button Click Handlers

        // 1. ODBC Setup
        private async void btnCreateOdbc_Click(object sender, EventArgs e)
        {
            string dsnName = txtOdbcDsnName.Text.Trim();
            string serverName = txtOdbcServer.Text.Trim();
            string driverName = "SQL Server"; // Or use "ODBC Driver 17 for SQL Server" if installed

            if (string.IsNullOrEmpty(dsnName) || string.IsNullOrEmpty(serverName))
            {
                MessageBox.Show("กรุณากรอก DSN Name และ Server", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- เริ่มต้นสร้าง System DSN ---");

            // Using PowerShell to create a System DSN. This is more stable than editing registry directly.
            string script = $"Add-Dsn -Name '{dsnName}' -DsnType 'System' -Platform '64-bit' -DriverName '{driverName}' -SetPropertyValue @('Server={serverName}')";
            await RunPowerShellScript(script);
        }

        // 2, 3, 4. Localization Settings
        private async void btnSetLocalization_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- เริ่มต้นตั้งค่า Localization (Timezone, Region, Keyboard) ---");

            // 2. Set Time Zone to SE Asia Standard Time (Bangkok)
            listBoxStatus.Items.Add("1/4: Setting Time Zone...");
            await RunCmdCommand("tzutil.exe /s \"SE Asia Standard Time\"");

            // 3. Set Region and Language (Thai, with English as secondary)
            listBoxStatus.Items.Add("2/4: Setting Region and Language List...");
            string script = "$list = New-WinUserLanguageList -Language 'th-TH'; $list.Add('en-US'); Set-WinUserLanguageList -LanguageList $list -Force;";
            await RunPowerShellScript(script);

            listBoxStatus.Items.Add("3/4: Setting System Locale to Thai...");
            await RunPowerShellScript("Set-WinSystemLocale -SystemLocale th-TH");


            // 4. Set language switch key to Grave Accent (`)
            listBoxStatus.Items.Add("4/4: Setting language switch key to Grave Accent...");
            try
            {
                // Key: HKEY_CURRENT_USER\Keyboard Layout\Toggle
                // Value: Language Hotkey (REG_SZ)
                // Data: 3
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Keyboard Layout\Toggle");
                if (key != null)
                {
                    key.SetValue("Language Hotkey", "3", RegistryValueKind.String);
                    key.Close();
                    listBoxStatus.Items.Add("  - ตั้งค่า Hotkey ສຳเร็จ");
                }
            }
            catch (Exception ex)
            {
                listBoxStatus.Items.Add($"  - เกิดข้อผิดพลาดในการตั้งค่า Registry: {ex.Message}");
            }

            listBoxStatus.Items.Add("--- ตั้งค่า Localization เสร็จสิ้น ---");
            listBoxStatus.Items.Add("!!! หมายเหตุ: การตั้งค่าบางอย่างอาจต้อง Restart เครื่องเพื่อให้มีผลสมบูรณ์ !!!");
        }

        // 5. Install Fonts
        private void btnInstallFonts_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- เริ่มต้นการติดตั้งฟอนต์ ---");
            ToggleButtons(false);

            string fontFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");
            if (!Directory.Exists(fontFolderPath))
            {
                listBoxStatus.Items.Add($"ไม่พบโฟลเดอร์ 'Fonts' ที่: {fontFolderPath}");
                ToggleButtons(true);
                return;
            }

            var fontFiles = Directory.GetFiles(fontFolderPath, "*.ttf")
                                     .Concat(Directory.GetFiles(fontFolderPath, "*.otf"));

            if (!fontFiles.Any())
            {
                listBoxStatus.Items.Add("ไม่พบไฟล์ฟอนต์ (.ttf, .otf) ในโฟลเดอร์ 'Fonts'");
                ToggleButtons(true);
                return;
            }

            int successCount = 0;
            string windowsFontsDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

            foreach (var fontFile in fontFiles)
            {
                string fontFileName = Path.GetFileName(fontFile);
                string destPath = Path.Combine(windowsFontsDir, fontFileName);

                try
                {
                    // Copy font to windows font directory
                    System.IO.File.Copy(fontFile, destPath, true);

                    // Install the font
                    int result = AddFontResource(destPath);
                    if (result == 0)
                    {
                        listBoxStatus.Items.Add($"[Error] ไม่สามารถลงทะเบียนฟอนต์: {fontFileName}");
                    }
                    else
                    {
                        listBoxStatus.Items.Add($"ติดตั้งฟอนต์ '{fontFileName}' สำเร็จ");
                        successCount++;
                    }
                }
                catch (Exception ex)
                {
                    listBoxStatus.Items.Add($"[Error] ติดตั้ง '{fontFileName}' ไม่สำเร็จ: {ex.Message}");
                }
            }

            // Notify all windows about the font change
            SendMessage(HWND_BROADCAST, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            listBoxStatus.Items.Add("--- การติดตั้งฟอนต์เสร็จสิ้น ---");
            listBoxStatus.Items.Add($"ติดตั้งสำเร็จ {successCount} ไฟล์");
            ToggleButtons(true);
        }

        // 6. Create Shortcut
        private void btnCreateShortcut_Click(object sender, EventArgs e)
        {
            string shortcutName = txtShortcutName.Text.Trim();
            string targetPath = txtShortcutTarget.Text.Trim();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (string.IsNullOrEmpty(shortcutName) || string.IsNullOrEmpty(targetPath))
            {
                MessageBox.Show("กรุณากรอก Shortcut Name และ Target Path", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- เริ่มต้นสร้าง Shortcut ---");
            ToggleButtons(false);

            try
            {
                string shortcutLocation = Path.Combine(desktopPath, shortcutName + ".lnk");
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

                shortcut.Description = $"Shortcut for {shortcutName}";
                shortcut.TargetPath = targetPath;
                // You can also set IconLocation, WorkingDirectory etc.
                // shortcut.IconLocation = @"C:\path\to\icon.ico";
                // shortcut.WorkingDirectory = @"C:\path";
                shortcut.Save();

                listBoxStatus.Items.Add($"สร้าง Shortcut '{shortcutName}.lnk' บน Desktop สำเร็จ");
            }
            catch (Exception ex)
            {
                listBoxStatus.Items.Add($"[Error] สร้าง Shortcut ไม่สำเร็จ: {ex.Message}");
            }
            finally
            {
                ToggleButtons(true);
            }
        }
        #endregion
    }
}
