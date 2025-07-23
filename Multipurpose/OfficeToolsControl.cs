using System;
using System.Collections.Generic;
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
    public partial class OfficeToolsControl : UserControl
    {
        private const string LicenseCsvFileName = @"Licenses\LicenseOffice.csv";
        private readonly Dictionary<string, List<string>> _officeProductKeys = new Dictionary<string, List<string>>();
        private string _osppPath = "";
        private CancellationTokenSource _cancellationTokenSource;

        public OfficeToolsControl()
        {
            InitializeComponent();
        }

        private async void OfficeToolsControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            ToggleAllButtons(false, false);
            _osppPath = FindOsppScriptPath();
            if (string.IsNullOrEmpty(_osppPath))
            {
                Log("OSPP.VBS script for Microsoft Office not found on this machine.");
                Log("Functions on this page may not be available.");
            }

            LoadLicenseKeysFromCsv();
            await RefreshCurrentStatusAsync();
            ToggleAllButtons(true, false);
        }

        #region Core Logic

        private async Task ActivateOfficeProductAsync(string productName, CancellationToken token)
        {
            if (string.IsNullOrEmpty(_osppPath))
            {
                MessageBox.Show("OSPP.VBS script for Microsoft Office not found on this machine.", "Activation Script Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_officeProductKeys.ContainsKey(productName) || !_officeProductKeys[productName].Any())
            {
                MessageBox.Show($"No License Key found for '{productName}' in the CSV file.", "No Keys Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LogClear();
            Log($"--- Starting Activation: '{productName}' ---");
            ToggleAllButtons(false, true);

            await UninstallAllRetailKeys(token);
            token.ThrowIfCancellationRequested();

            List<string> keysToTry = _officeProductKeys[productName];
            bool activationSuccess = false;

            foreach (var key in keysToTry)
            {
                token.ThrowIfCancellationRequested();
                Log($"\n--- Trying key: ...{key.Substring(key.Length - 5)} ---");

                await RunOsppCommand($"/inpkey:{key}", token);
                token.ThrowIfCancellationRequested();
                await RunOsppCommand("/act", token);
                token.ThrowIfCancellationRequested();

                if (await IsOfficeActivatedAsync(token))
                {
                    Log($"\nSUCCESS! Activation successful with key: {key}");
                    activationSuccess = true;
                    break;
                }
                else
                {
                    Log($"Key ...{key.Substring(key.Length - 5)} failed. Trying next key...");
                }
            }

            if (!activationSuccess)
            {
                Log("\n--- ACTIVATION FAILED ---");
                Log($"Tried all keys for '{productName}' without success.");
            }

            await RefreshCurrentStatusAsync();
        }

        private async Task UninstallAllRetailKeys(CancellationToken token)
        {
            Log("--- Uninstalling existing Retail keys (if any) ---");
            string statusResult = await RunOsppCommand("/dstatus", token);
            var matches = Regex.Matches(statusResult, @"Last 5 characters of installed product key: ([\w\d]{5})");
            if (matches.Count == 0)
            {
                Log("No installed Retail key found.");
                return;
            }

            foreach (Match match in matches)
            {
                token.ThrowIfCancellationRequested();
                string last5 = match.Groups[1].Value;
                Log($"Uninstalling key ending with: {last5}");
                await RunOsppCommand($"/unpkey:{last5}", token);
            }
        }

        #endregion

        #region UI Event Handlers
        private async void btnActivateOffice_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null) // Is processing
            {
                _cancellationTokenSource.Cancel();
                return;
            }

            if (cboOfficeProducts.SelectedItem == null)
            {
                MessageBox.Show("Please select an Office product to activate.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                await ActivateOfficeProductAsync(cboOfficeProducts.SelectedItem.ToString(), _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                Log("\n--- Activation process cancelled by user. ---");
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

        private async void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            await RefreshCurrentStatusAsync();
        }
        #endregion

        #region Helper Methods
        private void Log(string message)
        {
            // *** FIX: Check if control is disposed before accessing it from an async method ***
            if (this.IsDisposed || (txtStatus != null && txtStatus.IsDisposed))
            {
                return;
            }

            if (txtStatus.InvokeRequired)
            {
                try
                {
                    txtStatus.Invoke(new Action(() => Log(message)));
                }
                catch (ObjectDisposedException) { /* Ignore error if control is disposed during invoke */ }
            }
            else
            {
                txtStatus.AppendText(message + Environment.NewLine);
            }
        }
        private void LogClear()
        {
            if (this.IsDisposed || (txtStatus != null && txtStatus.IsDisposed)) return;
            if (txtStatus.InvokeRequired)
            {
                try
                {
                    txtStatus.Invoke(new Action(LogClear));
                }
                catch (ObjectDisposedException) { /* Ignore */ }
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
                lblCurrentProductNameValue.Text = "Not Found";
                lblCurrentStatusValue.Text = "Not Found";
                return;
            }
            LogClear();
            Log("--- Checking Office status ---");

            // *** FIX: Check IsDisposed before updating UI ***
            if (!this.IsDisposed)
            {
                lblCurrentProductNameValue.Text = "Loading...";
                lblCurrentStatusValue.Text = "Loading...";
                ToggleAllButtons(false, false);
            }

            string statusResult = await RunOsppCommand("/dstatus", CancellationToken.None);
            Log(statusResult);

            // *** FIX: Check IsDisposed before updating UI ***
            if (this.IsDisposed) return;

            Match nameMatch = Regex.Match(statusResult, @"LICENSE NAME:.*?(Office.*?)[\s,]*$|LICENSE NAME: (.*)", RegexOptions.Multiline);
            lblCurrentProductNameValue.Text = nameMatch.Success ? (nameMatch.Groups[1].Success ? nameMatch.Groups[1].Value.Trim() : nameMatch.Groups[2].Value.Trim()) : "No License Found";

            Match statusMatch = Regex.Match(statusResult, @"LICENSE STATUS:\s*---(.*?)---");
            lblCurrentStatusValue.Text = statusMatch.Success ? statusMatch.Groups[1].Value.Trim() : "Unknown";

            Log("--- Status check complete ---");
            ToggleAllButtons(true, false);
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
                        Log($"Found OSPP.VBS at: {potentialPath}");
                        return potentialPath;
                    }
                }
            }
            return null;
        }

        private async Task<string> RunOsppCommand(string arguments, CancellationToken token)
        {
            return await RunProcessAsync("cscript.exe", $"\"{_osppPath}\" {arguments}", token);
        }

        private async Task<bool> IsOfficeActivatedAsync(CancellationToken token)
        {
            string result = await RunOsppCommand("/dstatus", token);
            return result.Contains("---LICENSED---");
        }

        private async Task<string> RunProcessAsync(string fileName, string arguments, CancellationToken token)
        {
            var outputBuilder = new StringBuilder();
            try
            {
                await Task.Run(() =>
                {
                    if (token.IsCancellationRequested) return;
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
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
                                try { process.Kill(); } catch { /* Ignore */ }
                                token.ThrowIfCancellationRequested();
                            }
                        }

                        Task.WaitAll(new Task[] { outputTask, errorTask }, token);

                        outputBuilder.Append(outputTask.Result);
                        outputBuilder.Append(errorTask.Result);
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
            // *** FIX: Check IsDisposed before invoking ***
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => ToggleAllButtons(isEnabled, isProcessing)));
                }
                catch (ObjectDisposedException) { /* Ignore */ }
            }
            else
            {
                btnRefreshStatus.Enabled = isEnabled && !isProcessing;
                btnActivateOffice.Enabled = isEnabled;
                cboOfficeProducts.Enabled = isEnabled && !isProcessing;

                if (isProcessing)
                {
                    btnActivateOffice.Text = "Cancel";
                }
                else
                {
                    btnActivateOffice.Text = "Activate";
                }
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
                if (cboOfficeProducts.Items.Count > 0)
                    cboOfficeProducts.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing '{LicenseCsvFileName}':\n{ex.GetBaseException().Message}", "CSV Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
