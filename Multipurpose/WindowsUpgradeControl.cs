using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private const string LicenseCsvFileName = "License\\MSLicense.csv";

        // NEW: Dictionary to hold all keys, grouped by product name.
        private readonly Dictionary<string, List<string>> _productKeys = new Dictionary<string, List<string>>();

        public WindowsUpgradeControl()
        {
            InitializeComponent();
        }

        private void WindowsUpgradeControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            LoadLicenseKeysFromCsv();
            btnRefreshStatus_Click(sender, e);
            CheckForPendingActivation();
        }

        #region Helper and Core Logic Methods

        private async Task<string> RunProcessAsync(string fileName, string arguments)
        {
            var outputBuilder = new StringBuilder();
            Invoke((MethodInvoker)delegate
            {
                listBoxStatus.Items.Add($"Executing: {fileName} {arguments}");
                listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                // Buttons are toggled in the specific handler now for better control
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
                        Verb = "runas",
                        StandardOutputEncoding = Encoding.UTF8,
                        StandardErrorEncoding = Encoding.UTF8
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        process.Start();
                        // Read streams synchronously on the background thread
                        outputBuilder.Append(process.StandardOutput.ReadToEnd());
                        outputBuilder.Append(process.StandardError.ReadToEnd());
                        process.WaitForExit();
                    }
                });
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)delegate { outputBuilder.AppendLine($"An error occurred: {ex.Message}"); });
            }

            Invoke((MethodInvoker)delegate
            {
                listBoxStatus.Items.Add(outputBuilder.ToString());
                listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
            });
            return outputBuilder.ToString();
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            btnRefreshStatus.Enabled = isEnabled;
            btnStartUpgrade.Enabled = isEnabled;
            btnActivate.Enabled = isEnabled;
            cboProducts.Enabled = isEnabled;
        }

        private void SetUpgradeState(string state)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryStatePath);
                key?.SetValue(RegistryStateValue, state);
                key?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถบันทึกสถานะลง Registry ได้: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUpgradeState()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryStatePath);
                return key?.GetValue(RegistryStateValue, "")?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถอ่านสถานะจาก Registry ได้: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "";
        }

        private void CheckForPendingActivation()
        {
            if (GetUpgradeState() == StatePendingActivation)
            {
                lblProcessDescription.Text = "ตรวจพบว่าเครื่องเพิ่งผ่านการ Restart เพื่อเปลี่ยน Edition กรุณาเลือกผลิตภัณฑ์ที่ต้องการ Activate แล้วกดปุ่มด้านล่าง";
                btnStartUpgrade.Visible = false;
                btnActivate.Visible = true;
            }
            else
            {
                lblProcessDescription.Text = "โปรแกรมจะทำการล้างคีย์เก่า, เปลี่ยน Edition เป็น Pro (อาจมีการ Restart) และลงทะเบียนด้วยผลิตภัณฑ์ที่เลือก";
                btnStartUpgrade.Visible = true;
                btnActivate.Visible = false;
            }
        }

        private void LoadLicenseKeysFromCsv()
        {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LicenseCsvFileName);
            if (!File.Exists(csvPath))
            {
                listBoxStatus.Items.Add($"Warning: License file '{LicenseCsvFileName}' not found.");
                return;
            }

            _productKeys.Clear();
            try
            {
                var lines = File.ReadAllLines(csvPath).Skip(1); // Skip header

                foreach (var line in lines)
                {
                    var columns = line.Split(',');
                    if (columns.Length >= 2)
                    {
                        string product = columns[0].Trim().Replace("\"", "");
                        string key = columns[1].Trim().Replace("\"", "");

                        if (!_productKeys.ContainsKey(product))
                        {
                            _productKeys[product] = new List<string>();
                        }
                        _productKeys[product].Add(key);
                    }
                }

                cboProducts.DataSource = _productKeys.Keys.ToList();
                cboProducts.SelectedIndex = -1;
                listBoxStatus.Items.Add($"Successfully loaded {_productKeys.Count} products from {LicenseCsvFileName}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing '{LicenseCsvFileName}':\n{ex.Message}", "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> IsWindowsActivatedAsync()
        {
            string result = await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /dli");
            // A simple check for the word "Licensed" in the output.
            return result.Contains("Licensed");
        }

        #endregion

        #region UI Event Handlers

        private async void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- Checking Current Windows Status ---");
            lblCurrentEdition.Text = "Loading...";
            lblCurrentStatus.Text = "Loading...";

            ToggleAllButtons(false);
            string result = await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /dli");
            ToggleAllButtons(true);

            string edition = Regex.Match(result, @"Name: (.*)").Groups[1].Value.Trim();
            string status = Regex.Match(result, @"License Status: (.*)").Groups[1].Value.Trim();

            lblCurrentEdition.Text = string.IsNullOrEmpty(edition) ? "N/A" : edition;
            lblCurrentStatus.Text = string.IsNullOrEmpty(status) ? "N/A" : status;
        }

        private async void btnStartUpgrade_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "ขั้นตอนนี้จะทำการล้าง License Key เก่า และเปลี่ยน Edition ของ Windows ซึ่งอาจทำให้เครื่องคอมพิวเตอร์ Restart อัตโนมัติ\n\nคุณต้องการดำเนินการต่อหรือไม่?",
                "ยืนยันการเริ่มกระบวนการ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            listBoxStatus.Items.Clear();
            ToggleAllButtons(false);

            listBoxStatus.Items.Add("--- Step 1: Preparing and Changing Edition ---");
            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /upk");
            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /cpky");
            await RunProcessAsync("sc.exe", "config LicenseManager start=auto");
            await RunProcessAsync("sc.exe", "config wuauserv start=auto");

            string genericKey = ConfigurationManager.AppSettings["GenericWinProKey"];
            if (string.IsNullOrEmpty(genericKey))
            {
                MessageBox.Show("ไม่พบ GenericWinProKey ในไฟล์ App.config", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleAllButtons(true);
                return;
            }

            listBoxStatus.Items.Add("Attempting to change edition... The system may restart.");
            SetUpgradeState(StatePendingActivation);
            await RunProcessAsync("changepk.exe", $"/productkey {genericKey}");

            listBoxStatus.Items.Add("--- Pre-restart process finished. If the system did not restart, please do it manually and run this tool again. ---");
            ToggleAllButtons(true);
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            if (cboProducts.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกผลิตภัณฑ์ที่ต้องการ Activate", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedProduct = cboProducts.SelectedItem.ToString();
            if (!_productKeys.ContainsKey(selectedProduct) || !_productKeys[selectedProduct].Any())
            {
                MessageBox.Show($"ไม่พบ License Key สำหรับ '{selectedProduct}' ในไฟล์ CSV", "No Keys Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add($"--- Attempting to activate '{selectedProduct}' ---");
            ToggleAllButtons(false);

            List<string> keysToTry = _productKeys[selectedProduct];
            bool activationSuccess = false;

            foreach (var key in keysToTry)
            {
                listBoxStatus.Items.Add($"\n--- Trying key: ...{key.Substring(key.Length - 5)} ---");

                // 1. Install the key
                await RunProcessAsync("cscript.exe", $"//Nologo C:\\Windows\\System32\\slmgr.vbs /ipk {key}");

                // 2. Attempt to activate
                await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /ato");

                // 3. Check if activation was successful
                if (await IsWindowsActivatedAsync())
                {
                    listBoxStatus.Items.Add($"\nSUCCESS! Successfully activated with key: {key}");
                    activationSuccess = true;
                    break; // Exit the loop on success
                }
                else
                {
                    listBoxStatus.Items.Add($"Activation failed with key: ...{key.Substring(key.Length - 5)}. Trying next key...");
                }
            }

            if (!activationSuccess)
            {
                listBoxStatus.Items.Add("\n--- ACTIVATION FAILED ---");
                listBoxStatus.Items.Add($"Tried all available keys for '{selectedProduct}' but none were successful.");
            }

            SetUpgradeState("Completed");
            CheckForPendingActivation();
            ToggleAllButtons(true);

            // Final status check
            await btnRefreshStatus.InvokeAsync(btnRefreshStatus_Click, sender, e);
        }

        #endregion
    }

    // Custom extension method to allow async click for refresh button
    public static class ControlExtensions
    {
        public static Task InvokeAsync(this Control control, Action<object, EventArgs> action, object sender, EventArgs e)
        {
            return Task.Run(() => control.Invoke(action, sender, e));
        }
    }
}
