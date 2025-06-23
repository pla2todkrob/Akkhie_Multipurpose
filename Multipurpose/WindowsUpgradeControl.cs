using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Multipurpose
{
    public partial class WindowsUpgradeControl : UserControl
    {
        // Registry path for state management across reboots
        private const string RegistryStatePath = @"Software\AkkhieMultipurpose";
        private const string RegistryStateValue = "UpgradeState";
        private const string StatePendingActivation = "PendingActivation";

        public WindowsUpgradeControl()
        {
            InitializeComponent();
        }

        private void WindowsUpgradeControl_Load(object sender, EventArgs e)
        {
            // --- START FIX ---
            // This check is CRUCIAL. It prevents the code below from running in the Visual Studio Designer.
            // The Designer cannot execute processes or access the registry, which causes it to crash.
            if (this.DesignMode)
                return;
            // --- END FIX ---

            // The rest of the code will now only run when the application is actually running, not in the designer.
            LoadLicenseKeyFromConfig();
            btnRefreshStatus_Click(sender, e);
            CheckForPendingActivation();
        }

        #region Helper and Core Logic Methods

        /// <summary>
        /// The core process runner. Can run cmd or powershell commands.
        /// </summary>
        private async Task<string> RunProcessAsync(string fileName, string arguments)
        {
            var outputBuilder = new StringBuilder();
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
                        Verb = "runas", // Ensure admin privileges
                        StandardOutputEncoding = Encoding.UTF8, // Handle Thai characters
                        StandardErrorEncoding = Encoding.UTF8
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        var errorBuilder = new StringBuilder();
                        process.OutputDataReceived += (s, args) => { if (args.Data != null) outputBuilder.AppendLine(args.Data); };
                        process.ErrorDataReceived += (s, args) => { if (args.Data != null) errorBuilder.AppendLine(args.Data); };

                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        process.WaitForExit(); // Use async wait

                        string error = errorBuilder.ToString();
                        Invoke((MethodInvoker)delegate
                        {
                            if (!string.IsNullOrWhiteSpace(error))
                            {
                                listBoxStatus.Items.Add("[Error]");
                                foreach (var line in error.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    listBoxStatus.Items.Add($"  {line}");
                                }
                            }
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)delegate
                {
                    listBoxStatus.Items.Add($"An error occurred: {ex.Message}");
                });
            }
            finally
            {
                Invoke((MethodInvoker)delegate
                {
                    ToggleAllButtons(true);
                    listBoxStatus.Items.Add("--- Done ---");
                    listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                });
            }
            return outputBuilder.ToString();
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            btnRefreshStatus.Enabled = isEnabled;
            btnStartUpgrade.Enabled = isEnabled;
            btnActivate.Enabled = isEnabled;
        }

        /// <summary>
        /// Sets a registry key to remember the upgrade state.
        /// </summary>
        private void SetUpgradeState(string state)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryStatePath);
                key.SetValue(RegistryStateValue, state);
                key.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถบันทึกสถานะลง Registry ได้: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reads the upgrade state from the registry.
        /// </summary>
        private string GetUpgradeState()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryStatePath);
                if (key != null)
                {
                    return key.GetValue(RegistryStateValue, "").ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถอ่านสถานะจาก Registry ได้: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "";
        }

        /// <summary>
        /// Configures the UI based on the state saved in the registry.
        /// </summary>
        private void CheckForPendingActivation()
        {
            if (GetUpgradeState() == StatePendingActivation)
            {
                // UI for after-restart state
                lblProcessDescription.Text = "ตรวจพบว่าเครื่องเพิ่งผ่านการ Restart เพื่อเปลี่ยน Edition กรุณากดปุ่ม 'Activate' เพื่อดำเนินการในขั้นตอนสุดท้าย";
                btnStartUpgrade.Visible = false;
                btnActivate.Visible = true;
            }
            else
            {
                // UI for initial state
                lblProcessDescription.Text = "โปรแกรมจะทำการล้างคีย์เก่า, เปลี่ยน Edition เป็น Pro (อาจมีการ Restart) และลงทะเบียนด้วยคีย์ใหม่";
                btnStartUpgrade.Visible = true;
                btnActivate.Visible = false;
            }
        }

        /// <summary>
        /// Loads the license key from App.config into the textbox.
        /// </summary>
        private void LoadLicenseKeyFromConfig()
        {
            try
            {
                string licenseKey = ConfigurationManager.AppSettings["LicenseKey"];
                if (!string.IsNullOrEmpty(licenseKey))
                {
                    txtLicenseKey.Text = licenseKey;
                }
            }
            catch (Exception ex)
            {
                listBoxStatus.Items.Add($"เกิดข้อผิดพลาดในการโหลด License Key: {ex.Message}");
            }
        }

        #endregion

        #region UI Event Handlers

        private async void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Add("--- Checking Current Windows Status ---");
            lblCurrentEdition.Text = "Loading...";
            lblCurrentStatus.Text = "Loading...";

            string result = await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /dli");

            // Simple parsing of slmgr output
            string edition = "N/A";
            string status = "N/A";

            var lines = result.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("Name:"))
                {
                    edition = line.Split(':').Last().Trim();
                }
                if (line.Trim().StartsWith("License Status:"))
                {
                    status = line.Split(':').Last().Trim();
                }
            }

            lblCurrentEdition.Text = edition;
            lblCurrentStatus.Text = status;
        }

        private async void btnStartUpgrade_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "ขั้นตอนนี้จะทำการล้าง License Key เก่า และเปลี่ยน Edition ของ Windows ซึ่งอาจทำให้เครื่องคอมพิวเตอร์ Restart อัตโนมัติ\n\nคุณต้องการดำเนินการต่อหรือไม่?",
                "ยืนยันการเริ่มกระบวนการ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No)
            {
                return;
            }

            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- Step 1: Preparing and Changing Edition ---");

            // 1. Uninstall old key
            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /upk");
            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /cpky");

            // 2. Prepare services
            await RunProcessAsync("sc.exe", "config LicenseManager start=auto");
            await RunProcessAsync("sc.exe", "config wuauserv start=auto");

            // 3. Change edition with Generic Key
            string genericKey = ConfigurationManager.AppSettings["GenericWinProKey"];
            if (string.IsNullOrEmpty(genericKey))
            {
                MessageBox.Show("ไม่พบ GenericWinProKey ในไฟล์ App.config", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxStatus.Items.Add("Attempting to change edition... The system may restart.");
            SetUpgradeState(StatePendingActivation); // Set state before the command that might reboot
            await RunProcessAsync("changepk.exe", $"/productkey {genericKey}");

            listBoxStatus.Items.Add("--- Pre-restart process finished. If the system did not restart, please do it manually and run this tool again. ---");
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- Step 2: Installing New License and Activating ---");

            string licenseKey = txtLicenseKey.Text.Trim();
            if (string.IsNullOrEmpty(licenseKey) || licenseKey.Length != 29 || licenseKey.Split('-').Length != 5)
            {
                MessageBox.Show("กรุณากรอก License Key ให้ถูกต้อง (รูปแบบ: XXXXX-XXXXX-XXXXX-XXXXX-XXXXX)", "Invalid Key", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Install new key
            await RunProcessAsync("cscript.exe", $"//Nologo C:\\Windows\\System32\\slmgr.vbs /ipk {licenseKey}");

            // 5. Activate Windows
            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /ato");

            // 6. Display final status
            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /xpr");
            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /dli");

            SetUpgradeState("Completed"); // Clear the state
            CheckForPendingActivation(); // Reset UI to initial state
            listBoxStatus.Items.Add("--- Activation process completed! ---");

            // Refresh the status panel
            btnRefreshStatus_Click(sender, e);
        }

        #endregion
    }
}
