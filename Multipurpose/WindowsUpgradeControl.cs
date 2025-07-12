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

namespace Multipurpose
{
    public partial class WindowsUpgradeControl : UserControl
    {
        private const string LicenseCsvFileName = @"Licenses\LicenseWindows.csv";
        private Dictionary<string, List<string>> _productKeys = new Dictionary<string, List<string>>();
        private string _currentWindowsEdition = "Unknown";
        private string _currentWindowsFamily = "Unknown";

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

        #region Core Logic: Two-Part Process

        /// <summary>
        /// Part 2: ทำงานหลัง Upgrade และ Restart สำเร็จแล้ว
        /// จะทำการติดตั้ง License Key ของจริงและพยายาม Activate
        /// </summary>
        private async Task ActivateProductAsync(string productName)
        {
            if (!_productKeys.ContainsKey(productName) || !_productKeys[productName].Any())
            {
                MessageBox.Show($"ไม่พบ License Key สำหรับ '{productName}' ในไฟล์ CSV", "No Keys Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogClear();
            Log($"--- PART 2: เริ่มการ Activate สำหรับ '{productName}' ---");
            ToggleAllButtons(false);

            List<string> keysToTry = _productKeys[productName];
            bool activationSuccess = false;

            foreach (var key in keysToTry)
            {
                Log($"\n[7] กำลังติดตั้ง License Key: ...{key.Substring(key.Length - 5)}");
                await RunSlmgrCommand($"/ipk {key}");

                Log("[8] กำลังพยายาม Activate Windows (Online)...");
                await RunSlmgrCommand("/ato");

                if (await IsWindowsActivatedAsync())
                {
                    Log($"\nSUCCESS! Activate สำเร็จด้วยคีย์: {key}");
                    activationSuccess = true;
                    break;
                }
                else
                {
                    Log($"คีย์ ...{key.Substring(key.Length - 5)} ล้มเหลว. ลองคีย์ถัดไป (ถ้ามี)...");
                }
            }

            if (!activationSuccess)
            {
                Log("\n--- การ ACTIVATE ล้มเหลว ---");
                Log($"ลองใช้คีย์ทั้งหมดสำหรับ '{productName}' แล้ว แต่ไม่สำเร็จ");
            }

            Log("\n[9] กำลังตรวจสอบวันหมดอายุ...");
            await RunSlmgrCommand("/xpr");

            Log("\n[10] กำลังแสดงข้อมูล License โดยละเอียด...");
            await RunSlmgrCommand("/dli");

            Log("\n--- กระบวนการทั้งหมดเสร็จสิ้น ---");

            await RefreshCurrentStatusAsync();
            ToggleAllButtons(true);
        }

        /// <summary>
        /// Part 1: เริ่มกระบวนการ Upgrade Edition
        /// จะเตรียมระบบและเริ่มการอัปเกรด ซึ่งจะทำให้เครื่อง Restart
        /// </summary>
        private async Task UpgradeEditionAsync(string targetProduct)
        {
            string genericKey = ConfigurationManager.AppSettings[$"GenericKey:{targetProduct}"];
            if (string.IsNullOrEmpty(genericKey))
            {
                MessageBox.Show($"ไม่พบ Generic Key สำหรับการอัปเกรดเป็น '{targetProduct}' ใน App.config", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"คุณกำลังจะอัปเกรด Windows เป็น '{targetProduct}'.\n\nขั้นตอนนี้จะทำให้เครื่องคอมพิวเตอร์ Restart อัตโนมัติ\n**หลังจาก Restart เสร็จสิ้น ให้เปิดโปรแกรมนี้อีกครั้งแล้วกด 'Activate'**\n\nดำเนินการต่อหรือไม่?",
                "ยืนยันการ Upgrade Edition",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            LogClear();
            Log($"--- PART 1: เริ่มการ Upgrade Edition เป็น '{targetProduct}' ---");
            ToggleAllButtons(false);

            Log("[1] กำลังล้าง Product Key เก่า (ถ้ามี)...");
            await RunSlmgrCommand("/upk");

            Log("[2] กำลังล้าง Product Key จาก Registry...");
            await RunSlmgrCommand("/cpky");

            Log("[3] กำลังตรวจสอบและเริ่ม Service 'License Manager'...");
            await RunProcessAsync("sc.exe", "config LicenseManager start= auto");
            await RunProcessAsync("net.exe", "start LicenseManager");

            Log("[4] กำลังตรวจสอบและเริ่ม Service 'Windows Update'...");
            await RunProcessAsync("sc.exe", "config wuauserv start= auto");
            await RunProcessAsync("net.exe", "start wuauserv");

            // --- CHANGE START ---
            // เปลี่ยนมาใช้ changepk.exe ที่มีความเสถียรและเข้ากันได้มากกว่า
            Log("\n[5] กำลังเริ่มการอัปเกรดด้วย 'changepk.exe'...");
            Log($"   - Generic Product Key: {genericKey}");
            Log("--- จะมีหน้าต่างของ Windows แสดงขึ้นมาเพื่อดำเนินการต่อ ---");
            string changepkResult = await RunProcessAsync("changepk.exe", $"/ProductKey {genericKey}");
            Log(changepkResult);
            // --- CHANGE END ---

            Log("\n--- กระบวนการอัปเกรดเริ่มต้นแล้ว ---");
            Log("เครื่องจะทำการอัปเกรดและ Restart ในไม่ช้า");
            Log("!!! สำคัญ: หลังจากเครื่องเปิดขึ้นมาใหม่ ให้เปิดโปรแกรมนี้อีกครั้งและกดปุ่ม 'Activate' เพื่อทำการ Activate ด้วย License Key ของคุณ !!!");
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

            // ตรวจสอบว่า Edition ปัจจุบันตรงกับเป้าหมายหรือไม่
            if (_currentWindowsEdition.IndexOf(targetProduct, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // ถ้าตรงกัน แสดงว่าเป็นการ Activate
                await ActivateProductAsync(targetProduct);
            }
            else
            {
                // ถ้าไม่ตรง แสดงว่าเป็นการ Upgrade
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

            // ตรรกะใหม่สำหรับปุ่มและคำอธิบาย
            if (_currentWindowsEdition.IndexOf(targetProduct, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                lblProcessDescription.Text = $"Edition ปัจจุบันตรงกับเป้าหมายแล้ว\nกดปุ่มด้านล่างเพื่อเริ่มการ Activate ด้วย License Key ของคุณ";
                btnStartProcess.Text = "Activate Windows";
            }
            else
            {
                lblProcessDescription.Text = $"Edition ปัจจุบัน ('{_currentWindowsEdition}') ไม่ตรงกับเป้าหมาย\nกดปุ่มด้านล่างเพื่อเริ่มการ Upgrade Edition (จำเป็นต้อง Restart)";
                btnStartProcess.Text = "Upgrade Edition";
            }
        }
        #endregion

        #region Helper Methods
        private void Log(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            if (txtStatus.InvokeRequired)
            {
                txtStatus.Invoke(new Action(() => Log(message)));
            }
            else
            {
                txtStatus.AppendText(message.Trim() + Environment.NewLine);
            }
        }

        private void LogClear()
        {
            if (txtStatus.InvokeRequired)
            {
                txtStatus.Invoke(new Action(LogClear));
            }
            else
            {
                txtStatus.Clear();
            }
        }

        private async Task<string> RunPowerShellScriptAsync(string script)
        {
            string powerShellExe = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "WindowsPowerShell\\v1.0\\powershell.exe");
            return await RunProcessAsync(powerShellExe, $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"");
        }


        private string Get64BitPowerShellPath()
        {
            if (Environment.Is64BitProcess) return "powershell.exe";
            if (Environment.Is64BitOperatingSystem)
            {
                string sysnativePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Sysnative", "WindowsPowerShell\\v1.0\\powershell.exe");
                if (File.Exists(sysnativePath)) return sysnativePath;
            }
            return "powershell.exe";
        }

        private async Task RefreshCurrentStatusAsync()
        {
            LogClear();
            Log("--- กำลังตรวจสอบสถานะเครื่องปัจจุบัน ---");
            lblCurrentEdition.Text = "Loading...";
            lblCurrentStatus.Text = "Loading...";
            ToggleAllButtons(false);

            try
            {
                string powerShellExe = Get64BitPowerShellPath();
                string psCommand = "(Get-CimInstance -ClassName Win32_OperatingSystem).Caption";
                string osCaptionResult = await RunProcessAsync(powerShellExe, $"-Command \"{psCommand}\"");

                _currentWindowsEdition = osCaptionResult.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim().Replace("Microsoft ", "");

                if (string.IsNullOrWhiteSpace(_currentWindowsEdition))
                {
                    _currentWindowsEdition = "Unknown (Error fetching)";
                    Log("[Error] Could not determine OS Edition via PowerShell.");
                }

                _currentWindowsFamily = GetWindowsFamily(_currentWindowsEdition);
                UpdateProductComboBox();

                string slmgrResult = await RunSlmgrCommand("/dli", false);
                Match statusMatch = Regex.Match(slmgrResult, @"License Status: (.*)", RegexOptions.IgnoreCase);
                string status = statusMatch.Success ? statusMatch.Groups[1].Value.Trim() : "Unknown";

                lblCurrentEdition.Text = _currentWindowsEdition;
                lblCurrentStatus.Text = status;
                Log($"OS Family: {_currentWindowsFamily}");
                Log($"OS Edition: {_currentWindowsEdition}");
                Log($"License Status: {status}");
                Log("--- ตรวจสอบสถานะเสร็จสิ้น ---");
            }
            catch (Exception ex)
            {
                Log($"[FATAL] An error occurred during status refresh: {ex.Message}");
                lblCurrentEdition.Text = "Error";
                lblCurrentStatus.Text = "Error";
            }
            finally
            {
                ToggleAllButtons(true);
                cboProducts_SelectedIndexChanged(null, null);
            }
        }

        private string GetWindowsFamily(string fullOsName)
        {
            if (string.IsNullOrWhiteSpace(fullOsName)) return "Unknown";
            if (fullOsName.IndexOf("Windows 11", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows 11";
            if (fullOsName.IndexOf("Windows 10", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows 10";
            if (fullOsName.IndexOf("Server 2016", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows Server 2016";
            if (fullOsName.IndexOf("Server 2012", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows Server 2012";
            if (fullOsName.IndexOf("Server 2008", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows Server 2008";
            if (fullOsName.IndexOf("Windows 8.1", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows 8.1";
            if (fullOsName.IndexOf("Windows 8", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows 8";
            if (fullOsName.IndexOf("Windows 7", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows 7";
            if (fullOsName.IndexOf("Vista", StringComparison.OrdinalIgnoreCase) >= 0) return "Windows Vista";
            return "Unknown";
        }

        private void UpdateProductComboBox()
        {
            if (_productKeys == null || !_productKeys.Any()) return;

            var filteredProducts = _productKeys.Keys
                                        .Where(p => p.StartsWith(_currentWindowsFamily, StringComparison.OrdinalIgnoreCase))
                                        .ToList();

            cboProducts.DataSource = filteredProducts;
            cboProducts.SelectedIndex = -1;

            if (!filteredProducts.Any())
            {
                Log($"[Warning] ไม่พบ License Key สำหรับ '{_currentWindowsFamily}' ในไฟล์ {LicenseCsvFileName}");
            }
        }

        private async Task<bool> IsWindowsActivatedAsync()
        {
            string result = await RunSlmgrCommand("/dli", false);
            return result.IndexOf("Licensed", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private async Task<string> RunSlmgrCommand(string arguments, bool logToUi = true)
        {
            string result = await RunProcessAsync("cscript.exe", $"//Nologo C:\\Windows\\System32\\slmgr.vbs {arguments}");
            if (logToUi)
            {
                Log(result);
            }
            return result;
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
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        if (!string.IsNullOrWhiteSpace(output)) outputBuilder.Append(output);
                        if (!string.IsNullOrWhiteSpace(error)) outputBuilder.Append(error);
                    }
                });
            }
            catch (Exception ex)
            {
                outputBuilder.AppendLine($"An error occurred: {ex.GetBaseException().Message}");
            }
            return outputBuilder.ToString();
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            btnRefreshStatus.Enabled = isEnabled;
            btnStartProcess.Enabled = isEnabled && cboProducts.Items.Count > 0;
            cboProducts.Enabled = isEnabled && cboProducts.Items.Count > 0;
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
                cboProducts.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing '{LicenseCsvFileName}':\n{ex.GetBaseException().Message}", "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
