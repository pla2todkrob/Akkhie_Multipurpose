using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        private CancellationTokenSource _cancellationTokenSource;

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

        private async Task ActivateProductAsync(string productName, CancellationToken token)
        {
            if (!_productKeys.ContainsKey(productName) || !_productKeys[productName].Any())
            {
                MessageBox.Show($"No License Key found for '{productName}' in the CSV file.", "No Keys Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogClear();
            Log($"--- PART 2: Starting Activation for '{productName}' ---");
            ToggleAllButtons(false, true);

            List<string> keysToTry = _productKeys[productName];
            bool activationSuccess = false;

            foreach (var key in keysToTry)
            {
                token.ThrowIfCancellationRequested();
                Log($"\n[7] Installing License Key: ...{key.Substring(key.Length - 5)}");
                await RunSlmgrCommand($"/ipk {key}", token);

                token.ThrowIfCancellationRequested();
                Log("[8] Attempting to Activate Windows (Online)...");
                await RunSlmgrCommand("/ato", token);

                if (await IsWindowsActivatedAsync(token))
                {
                    Log($"\nSUCCESS! Activation successful with key: {key}");
                    activationSuccess = true;
                    break;
                }
                else
                {
                    Log($"Key ...{key.Substring(key.Length - 5)} failed. Trying next key (if available)...");
                }
            }

            if (!activationSuccess)
            {
                Log("\n--- ACTIVATION FAILED ---");
                Log($"Tried all keys for '{productName}' without success.");
            }

            token.ThrowIfCancellationRequested();
            Log("\n[9] Checking expiration date...");
            await RunSlmgrCommand("/xpr", token);

            token.ThrowIfCancellationRequested();
            Log("\n[10] Displaying detailed license information...");
            await RunSlmgrCommand("/dli", token);

            Log("\n--- All processes complete ---");

            await RefreshCurrentStatusAsync();
            ToggleAllButtons(true, false);
        }

        private async Task UpgradeEditionAsync(string targetProduct, CancellationToken token)
        {
            string genericKey = ConfigurationManager.AppSettings[$"GenericKey:{targetProduct}"];
            if (string.IsNullOrEmpty(genericKey))
            {
                MessageBox.Show($"Generic Key for upgrading to '{targetProduct}' not found in App.config.", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"You are about to upgrade Windows to '{targetProduct}'.\n\nThis process will automatically restart your computer.\n**After restarting, open this program again and click 'Activate'**\n\nContinue?",
                "Confirm Edition Upgrade",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            LogClear();
            Log($"--- PART 1: Starting Edition Upgrade to '{targetProduct}' ---");
            ToggleAllButtons(false, true);

            token.ThrowIfCancellationRequested();
            Log("[1] Clearing old Product Key (if any)...");
            await RunSlmgrCommand("/upk", token);

            token.ThrowIfCancellationRequested();
            Log("[2] Clearing Product Key from Registry...");
            await RunSlmgrCommand("/cpky", token);

            token.ThrowIfCancellationRequested();
            Log("[3] Checking and starting 'License Manager' Service...");
            await RunProcessAsync("sc.exe", "config LicenseManager start= auto", token);
            await RunProcessAsync("net.exe", "start LicenseManager", token);

            token.ThrowIfCancellationRequested();
            Log("[4] Checking and starting 'Windows Update' Service...");
            await RunProcessAsync("sc.exe", "config wuauserv start= auto", token);
            await RunProcessAsync("net.exe", "start wuauserv", token);

            token.ThrowIfCancellationRequested();
            Log("\n[5] Starting upgrade with 'changepk.exe'...");
            Log($"   - Generic Product Key: {genericKey}");
            Log("--- A Windows dialog will appear to continue the process ---");
            string changepkResult = await RunProcessAsync("changepk.exe", $"/ProductKey {genericKey}", token);
            Log(changepkResult);

            Log("\n--- Upgrade process initiated ---");
            Log("The computer will upgrade and restart shortly.");
            Log("!!! IMPORTANT: After the computer restarts, open this program again and click the 'Activate' button to activate with your license key !!!");
        }

        #endregion

        #region UI Event Handlers

        private async void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            await RefreshCurrentStatusAsync();
        }

        private async void btnStartProcess_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null) // Is processing
            {
                _cancellationTokenSource.Cancel();
                return;
            }

            if (cboProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select a target product.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            string targetProduct = cboProducts.SelectedItem.ToString();

            try
            {
                if (_currentWindowsEdition.IndexOf(targetProduct, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    await ActivateProductAsync(targetProduct, _cancellationTokenSource.Token);
                }
                else
                {
                    await UpgradeEditionAsync(targetProduct, _cancellationTokenSource.Token);
                }
            }
            catch (OperationCanceledException)
            {
                Log("\n--- Process cancelled by user. ---");
            }
            catch (Exception ex)
            {
                Log($"\n--- An unexpected error occurred: {ex.Message} ---");
            }
            finally
            {
                ToggleAllButtons(true, false);
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducts.SelectedItem == null)
            {
                lblProcessDescription.Text = "Select a target product to see the next step.";
                btnStartProcess.Enabled = false;
                return;
            }

            btnStartProcess.Enabled = true;
            string targetProduct = cboProducts.SelectedItem.ToString();

            if (_currentWindowsEdition.IndexOf(targetProduct, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                lblProcessDescription.Text = $"Current edition matches the target.\nClick the button below to start activation with your license key.";
                btnStartProcess.Text = "Activate Windows";
            }
            else
            {
                lblProcessDescription.Text = $"Current edition ('{_currentWindowsEdition}') does not match the target.\nClick the button below to start the Edition Upgrade (requires restart).";
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
            Log("--- Checking current machine status ---");
            lblCurrentEdition.Text = "Loading...";
            lblCurrentStatus.Text = "Loading...";
            ToggleAllButtons(false, false);

            try
            {
                string powerShellExe = Get64BitPowerShellPath();
                string psCommand = "(Get-CimInstance -ClassName Win32_OperatingSystem).Caption";
                string osCaptionResult = await RunProcessAsync(powerShellExe, $"-Command \"{psCommand}\"", CancellationToken.None);

                _currentWindowsEdition = osCaptionResult.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim().Replace("Microsoft ", "");

                if (string.IsNullOrWhiteSpace(_currentWindowsEdition))
                {
                    _currentWindowsEdition = "Unknown (Error fetching)";
                    Log("[Error] Could not determine OS Edition via PowerShell.");
                }

                _currentWindowsFamily = GetWindowsFamily(_currentWindowsEdition);
                UpdateProductComboBox();

                string slmgrResult = await RunSlmgrCommand("/dli", CancellationToken.None, false);
                Match statusMatch = Regex.Match(slmgrResult, @"License Status: (.*)", RegexOptions.IgnoreCase);
                string status = statusMatch.Success ? statusMatch.Groups[1].Value.Trim() : "Unknown";

                lblCurrentEdition.Text = _currentWindowsEdition;
                lblCurrentStatus.Text = status;
                Log($"OS Family: {_currentWindowsFamily}");
                Log($"OS Edition: {_currentWindowsEdition}");
                Log($"License Status: {status}");
                Log("--- Status check complete ---");
            }
            catch (Exception ex)
            {
                Log($"[FATAL] An error occurred during status refresh: {ex.Message}");
                lblCurrentEdition.Text = "Error";
                lblCurrentStatus.Text = "Error";
            }
            finally
            {
                ToggleAllButtons(true, false);
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
                Log($"[Warning] No License Key found for '{_currentWindowsFamily}' in {LicenseCsvFileName}");
            }
        }

        private async Task<bool> IsWindowsActivatedAsync(CancellationToken token)
        {
            string result = await RunSlmgrCommand("/dli", token, false);
            return result.IndexOf("Licensed", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private async Task<string> RunSlmgrCommand(string arguments, CancellationToken token, bool logToUi = true)
        {
            string result = await RunProcessAsync("cscript.exe", $"//Nologo C:\\Windows\\System32\\slmgr.vbs {arguments}", token);
            if (logToUi)
            {
                Log(result);
            }
            return result;
        }

        private async Task<string> RunProcessAsync(string fileName, string arguments, CancellationToken token)
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

                        var outputTask = process.StandardOutput.ReadToEndAsync();
                        var errorTask = process.StandardError.ReadToEndAsync();

                        while (!process.WaitForExit(100))
                        {
                            if (token.IsCancellationRequested)
                            {
                                process.Kill();
                                token.ThrowIfCancellationRequested();
                            }
                        }

                        Task.WaitAll(new Task[] { outputTask, errorTask }, token);

                        if (!string.IsNullOrWhiteSpace(outputTask.Result)) outputBuilder.Append(outputTask.Result);
                        if (!string.IsNullOrWhiteSpace(errorTask.Result)) outputBuilder.Append(errorTask.Result);
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                outputBuilder.AppendLine("\n[CANCELLED] The operation was cancelled by the user.");
            }
            catch (Exception ex)
            {
                outputBuilder.AppendLine($"An error occurred: {ex.GetBaseException().Message}");
            }
            return outputBuilder.ToString();
        }

        private void ToggleAllButtons(bool isEnabled, bool isProcessing)
        {
            btnRefreshStatus.Enabled = isEnabled && !isProcessing;
            cboProducts.Enabled = isEnabled && !isProcessing;
            btnStartProcess.Enabled = isEnabled;

            if (isProcessing)
            {
                btnStartProcess.Text = "Cancel";
            }
            else
            {
                cboProducts_SelectedIndexChanged(null, null); // This will set the correct text
            }
        }

        private void LoadLicenseKeysFromCsv()
        {
            string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LicenseCsvFileName);
            if (!File.Exists(csvPath))
            {
                MessageBox.Show($"License file not found: '{csvPath}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
