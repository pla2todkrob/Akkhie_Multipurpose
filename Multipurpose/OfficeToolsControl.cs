using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose
{
    public partial class OfficeToolsControl : UserControl
    {
        private const string LicenseCsvFileName = @"Licenses\LicenseOffice.csv";
        private Dictionary<string, List<string>> _officeProductKeys = new Dictionary<string, List<string>>();
        private string _osppPath = "";

        public OfficeToolsControl()
        {
            InitializeComponent();
        }

        private async void OfficeToolsControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            ToggleAllButtons(false);
            _osppPath = FindOsppScriptPath();
            if (string.IsNullOrEmpty(_osppPath))
            {
                Log("ไม่พบสคริปต์ OSPP.VBS ของ Microsoft Office ในเครื่องนี้");
                Log("ฟังก์ชันในหน้านี้อาจไม่สามารถใช้งานได้");
            }

            LoadLicenseKeysFromCsv();
            await RefreshCurrentStatusAsync();
            ToggleAllButtons(true);
        }

        #region Core Logic

        private async Task ActivateOfficeProductAsync(string productName)
        {
            if (string.IsNullOrEmpty(_osppPath))
            {
                MessageBox.Show("ไม่พบสคริปต์ OSPP.VBS ของ Microsoft Office ในเครื่องนี้", "Activation Script Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_officeProductKeys.ContainsKey(productName) || !_officeProductKeys[productName].Any())
            {
                MessageBox.Show($"ไม่พบ License Key สำหรับ '{productName}' ในไฟล์ CSV", "No Keys Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogClear();
            Log($"--- เริ่มการ Activate: '{productName}' ---");
            ToggleAllButtons(false);

            await UninstallAllRetailKeys();

            List<string> keysToTry = _officeProductKeys[productName];
            bool activationSuccess = false;

            foreach (var key in keysToTry)
            {
                Log($"\n--- ลองใช้คีย์: ...{key.Substring(key.Length - 5)} ---");

                await RunOsppCommand($"/inpkey:{key}");
                await RunOsppCommand("/act");

                if (await IsOfficeActivatedAsync())
                {
                    Log($"\nSUCCESS! Activate สำเร็จด้วยคีย์: {key}");
                    activationSuccess = true;
                    break;
                }
                else
                {
                    Log($"คีย์ ...{key.Substring(key.Length - 5)} ล้มเหลว. ลองคีย์ถัดไป...");
                }
            }

            if (!activationSuccess)
            {
                Log("\n--- การ ACTIVATE ล้มเหลว ---");
                Log($"ลองใช้คีย์ทั้งหมดสำหรับ '{productName}' แล้ว แต่ไม่สำเร็จ");
            }

            await RefreshCurrentStatusAsync();
            ToggleAllButtons(true);
        }

        private async Task UninstallAllRetailKeys()
        {
            Log("--- กำลังถอนการติดตั้ง Retail keys ที่มีอยู่ (ถ้ามี) ---");
            string statusResult = await RunOsppCommand("/dstatus");
            var matches = Regex.Matches(statusResult, @"Last 5 characters of installed product key: ([\w\d]{5})");
            if (matches.Count == 0)
            {
                Log("ไม่พบ Retail key ที่ติดตั้งไว้");
                return;
            }

            foreach (Match match in matches)
            {
                string last5 = match.Groups[1].Value;
                Log($"กำลังถอนการติดตั้งคีย์ที่ลงท้ายด้วย: {last5}");
                await RunOsppCommand($"/unpkey:{last5}");
            }
        }

        #endregion

        #region UI Event Handlers
        private async void btnActivateOffice_Click(object sender, EventArgs e)
        {
            if (cboOfficeProducts.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกผลิตภัณฑ์ Office ที่ต้องการ", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await ActivateOfficeProductAsync(cboOfficeProducts.SelectedItem.ToString());
        }

        private async void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            await RefreshCurrentStatusAsync();
        }
        #endregion

        #region Helper Methods
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
        private async Task RefreshCurrentStatusAsync()
        {
            if (string.IsNullOrEmpty(_osppPath))
            {
                lblCurrentProductName.Text = "Not Found";
                lblCurrentStatus.Text = "Not Found";
                return;
            }
            LogClear();
            Log("--- กำลังตรวจสอบสถานะ Office ---");
            lblCurrentProductName.Text = "Loading...";
            lblCurrentStatus.Text = "Loading...";
            ToggleAllButtons(false);

            string statusResult = await RunOsppCommand("/dstatus");
            Log(statusResult); // Log the full output for debugging

            Match nameMatch = Regex.Match(statusResult, @"LICENSE NAME:.*?(Office.*?)[\s,]*$|LICENSE NAME: (.*)", RegexOptions.Multiline);
            lblCurrentProductName.Text = nameMatch.Success ? (nameMatch.Groups[1].Success ? nameMatch.Groups[1].Value.Trim() : nameMatch.Groups[2].Value.Trim()) : "No License Found";

            Match statusMatch = Regex.Match(statusResult, @"LICENSE STATUS:\s*---(.*?)---");
            lblCurrentStatus.Text = statusMatch.Success ? statusMatch.Groups[1].Value.Trim() : "Unknown";

            Log("--- ตรวจสอบสถานะเสร็จสิ้น ---");
            ToggleAllButtons(true);
        }

        private string FindOsppScriptPath()
        {
            string[] officeFolders = { "Office16", "Office15", "Office14", "Office12" };
            string[] programFilesPaths = {
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
            };

            foreach (var pfPath in programFilesPaths)
            {
                foreach (var officeFolder in officeFolders)
                {
                    string potentialPath = Path.Combine(pfPath, "Microsoft Office", officeFolder, "OSPP.VBS");
                    if (File.Exists(potentialPath))
                    {
                        Log($"พบ OSPP.VBS ที่: {potentialPath}");
                        return potentialPath;
                    }
                }
            }
            return null;
        }

        private async Task<string> RunOsppCommand(string arguments)
        {
            return await RunProcessAsync("cscript.exe", $"\"{_osppPath}\" {arguments}");
        }

        private async Task<bool> IsOfficeActivatedAsync()
        {
            string result = await RunOsppCommand("/dstatus");
            return result.Contains("---LICENSED---");
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
                outputBuilder.AppendLine($"An error occurred: {ex.Message}");
            }
            return outputBuilder.ToString();
        }

        private void ToggleAllButtons(bool isEnabled)
        {
            btnRefreshStatus.Enabled = isEnabled;
            btnActivateOffice.Enabled = isEnabled;
            cboOfficeProducts.Enabled = isEnabled;
        }

        private void LoadLicenseKeysFromCsv()
        {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LicenseCsvFileName);
            if (!File.Exists(csvPath))
            {
                MessageBox.Show($"ไม่พบไฟล์ License: '{csvPath}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _officeProductKeys.Clear();
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

                        if (!_officeProductKeys.ContainsKey(product))
                        {
                            _officeProductKeys[product] = new List<string>();
                        }
                        _officeProductKeys[product].Add(key);
                    }
                }
                cboOfficeProducts.DataSource = _officeProductKeys.Keys.ToList();
                cboOfficeProducts.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing '{LicenseCsvFileName}':\n{ex.Message}", "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
