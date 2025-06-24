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
        private const string LicenseCsvFileName = "LicenseWindows.csv";
        private Dictionary<string, List<string>> _productKeys = new Dictionary<string, List<string>>();
        private string _currentWindowsEdition = "Unknown";

        public WindowsUpgradeControl()
        {
            InitializeComponent();
        }

        private async void WindowsUpgradeControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            LoadLicenseKeysFromCsv();
            await RefreshCurrentStatusAsync();
        }

        #region Core Logic

        private async Task ActivateProductAsync(string productName)
        {
            if (!_productKeys.ContainsKey(productName) || !_productKeys[productName].Any())
            {
                MessageBox.Show($"ไม่พบ License Key สำหรับ '{productName}' ในไฟล์ CSV", "No Keys Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add($"--- เริ่มการ Activate: '{productName}' ---");
            ToggleAllButtons(false);

            List<string> keysToTry = _productKeys[productName];
            bool activationSuccess = false;

            foreach (var key in keysToTry)
            {
                listBoxStatus.Items.Add($"\n--- ลองใช้คีย์: ...{key.Substring(key.Length - 5)} ---");

                await RunProcessAsync("cscript.exe", $"//Nologo C:\\Windows\\System32\\slmgr.vbs /ipk {key}");
                await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /ato");

                if (await IsWindowsActivatedAsync())
                {
                    listBoxStatus.Items.Add($"\nSUCCESS! Activate สำเร็จด้วยคีย์: {key}");
                    activationSuccess = true;
                    break;
                }
                else
                {
                    listBoxStatus.Items.Add($"คีย์ ...{key.Substring(key.Length - 5)} ล้มเหลว. ลองคีย์ถัดไป...");
                }
            }

            if (!activationSuccess)
            {
                listBoxStatus.Items.Add("\n--- การ ACTIVATE ล้มเหลว ---");
                listBoxStatus.Items.Add($"ลองใช้คีย์ทั้งหมดสำหรับ '{productName}' แล้ว แต่ไม่สำเร็จ");
            }

            await RefreshCurrentStatusAsync();
            ToggleAllButtons(true);
        }

        private async Task UpgradeEditionAsync(string targetProduct)
        {
            string genericKey = ConfigurationManager.AppSettings[$"GenericKey:{targetProduct}"];
            if (string.IsNullOrEmpty(genericKey))
            {
                MessageBox.Show($"ไม่พบ Generic Key สำหรับการอัปเกรดเป็น '{targetProduct}' ใน App.config", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"คุณกำลังจะอัปเกรด Windows จาก '{_currentWindowsEdition}' เป็น '{targetProduct}'.\nขั้นตอนนี้อาจทำให้เครื่อง Restart อัตโนมัติ.\n\nดำเนินการต่อหรือไม่?",
                "ยืนยันการอัปเกรด Edition",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add($"--- เริ่มการอัปเกรดเป็น: '{targetProduct}' ---");
            ToggleAllButtons(false);

            await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /upk");
            await RunProcessAsync("changepk.exe", $"/productkey {genericKey}");

            listBoxStatus.Items.Add("\n--- การอัปเกรดเสร็จสิ้น ---");
            listBoxStatus.Items.Add("กรุณา Restart เครื่องคอมพิวเตอร์ แล้วเปิดโปรแกรมนี้อีกครั้งเพื่อทำการ Activate");
            ToggleAllButtons(true);
        }

        #endregion

        #region UI Event Handlers

        private async void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            await RefreshCurrentStatusAsync();
        }

        private async void btnStartProcess_Click(object sender, EventArgs e)
        {
            if (cboProducts.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกผลิตภัณฑ์เป้าหมาย", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetProduct = cboProducts.SelectedItem.ToString();

            if (_currentWindowsEdition.IndexOf(targetProduct, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                await ActivateProductAsync(targetProduct);
            }
            else
            {
                await UpgradeEditionAsync(targetProduct);
            }
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducts.SelectedItem == null)
            {
                lblProcessDescription.Text = "เลือกผลิตภัณฑ์เป้าหมายเพื่อดูขั้นตอนต่อไป";
                btnStartProcess.Enabled = false;
                return;
            }

            btnStartProcess.Enabled = true;
            string targetProduct = cboProducts.SelectedItem.ToString();

            if (_currentWindowsEdition.IndexOf(targetProduct, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                lblProcessDescription.Text = $"Edition ปัจจุบันตรงกับเป้าหมายแล้ว โปรแกรมจะเข้าสู่โหมด Activate โดยตรง";
                btnStartProcess.Text = "Activate";
            }
            else
            {
                lblProcessDescription.Text = $"Edition ปัจจุบัน ('{_currentWindowsEdition}') ไม่ตรงกับเป้าหมาย โปรแกรมจะทำการ Upgrade Edition ก่อน";
                btnStartProcess.Text = "Upgrade Edition";
            }
        }
        #endregion

        #region Helper Methods
        private async Task RefreshCurrentStatusAsync()
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- กำลังตรวจสอบสถานะเครื่องปัจจุบัน ---");
            lblCurrentEdition.Text = "Loading...";
            lblCurrentStatus.Text = "Loading...";
            ToggleAllButtons(false);

            // Use wmic which is more reliable for product name
            string wmicResult = await RunProcessAsync("wmic", "os get Caption");
            _currentWindowsEdition = wmicResult.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault()?.Trim() ?? "Unknown";

            string slmgrResult = await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /dli");
            Match statusMatch = Regex.Match(slmgrResult, @"License Status: (.*)");
            string status = statusMatch.Success ? statusMatch.Groups[1].Value.Trim() : "Unknown";

            lblCurrentEdition.Text = _currentWindowsEdition;
            lblCurrentStatus.Text = status;

            ToggleAllButtons(true);
            cboProducts_SelectedIndexChanged(null, null); // Update description label
        }

        private async Task<bool> IsWindowsActivatedAsync()
        {
            string result = await RunProcessAsync("cscript.exe", "//Nologo C:\\Windows\\System32\\slmgr.vbs /dli");
            return result.Contains("Licensed");
        }

        private async Task<string> RunProcessAsync(string fileName, string arguments)
        {
            var outputBuilder = new StringBuilder();
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
                        StandardOutputEncoding = Encoding.UTF8
                    };

                    using (Process process = new Process { StartInfo = startInfo })
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
                outputBuilder.AppendLine($"An error occurred: {ex.Message}");
            }
            return outputBuilder.ToString();
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            btnRefreshStatus.Enabled = isEnabled;
            btnStartProcess.Enabled = isEnabled;
            cboProducts.Enabled = isEnabled;
        }

        private void LoadLicenseKeysFromCsv()
        {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LicenseCsvFileName);
            if (!File.Exists(csvPath))
            {
                MessageBox.Show($"ไม่พบไฟล์ License: '{csvPath}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _productKeys.Clear();
            try
            {
                var lines = File.ReadAllLines(csvPath).Skip(1);
                foreach (var line in lines)
                {
                    var columns = line.Split(',');
                    if (columns.Length >= 2)
                    {
                        string product = columns[0].Trim().Replace("\"", "");
                        string key = columns[1].Trim().Replace("\"", "");
                        if (string.IsNullOrEmpty(product) || string.IsNullOrEmpty(key)) continue;

                        if (!_productKeys.ContainsKey(product))
                        {
                            _productKeys[product] = new List<string>();
                        }
                        _productKeys[product].Add(key);
                    }
                }
                cboProducts.DataSource = _productKeys.Keys.ToList();
                cboProducts.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing '{LicenseCsvFileName}':\n{ex.Message}", "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
