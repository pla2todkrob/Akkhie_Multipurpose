using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multipurpose.Troubleshooter.Tools;

namespace Multipurpose
{
    public partial class TroubleshooterControl : UserControl
    {
        #region Data Access Helper Class
        public static class DataAccess
        {
            private static readonly string ConnectionString;

            static DataAccess()
            {
                try
                {
                    var settings = ConfigurationManager.AppSettings;
                    var builder = new SqlConnectionStringBuilder
                    {
                        DataSource = settings["OdbcServer"],
                        InitialCatalog = settings["OdbcDatabase"],
                        UserID = settings["OdbcUid"],
                        Password = settings["OdbcPwd"],
                        ConnectTimeout = 15,
                        Pooling = true // Ensure pooling is enabled
                    };
                    ConnectionString = builder.ConnectionString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not create Connection String from App.config: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConnectionString = null;
                }
            }

            public static bool IsConnectionConfigured() => !string.IsNullOrEmpty(ConnectionString);

            private static SqlConnection GetConnection()
            {
                return new SqlConnection(ConnectionString);
            }

            public static async Task<DataTable> GetDataTableAsync(string query, params SqlParameter[] parameters)
            {
                var dt = new DataTable();
                if (!IsConnectionConfigured()) return dt;

                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    await conn.OpenAsync();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }

            public static async Task<int> ExecuteNonQueryAsync(string query, params SqlParameter[] parameters)
            {
                if (!IsConnectionConfigured()) return 0;

                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        #endregion

        private readonly Dictionary<string, ITroubleshooterTool> _tools;
        private ITroubleshooterTool _activeTool = null;

        public TroubleshooterControl()
        {
            InitializeComponent();
            _tools = new Dictionary<string, ITroubleshooterTool>();
            this.Load += TroubleshooterControl_Load;
        }

        private void TroubleshooterControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            if (!DataAccess.IsConnectionConfigured())
            {
                MessageBox.Show("Cannot connect to the database. Please check the settings in App.config", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }

            RegisterTools();
            SetupInitialState();
            AssignEventHandlers();
        }

        private void RegisterTools()
        {
            _tools.Clear();
            var toolTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ITroubleshooterTool).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in toolTypes)
            {
                var tool = (ITroubleshooterTool)Activator.CreateInstance(type);
                // Find button by convention: btnUnlockQuotation -> UnlockQuotationTool
                var buttonName = $"btn{type.Name.Replace("Tool", "")}";
                var button = flpVerticalActions.Controls.Find(buttonName, true).FirstOrDefault() as Button;

                if (button != null)
                {
                    _tools.Add(button.Name, tool);
                    button.Text = tool.ToolName; // Set button text from tool
                }
            }
        }

        private void UpdateToolButtonStates()
        {
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            {
                btn.Enabled = _tools.ContainsKey(btn.Name);
            }
        }

        private void SetupInitialState()
        {
            grpFilters.Enabled = true;
            txtQuotationSource.Clear();
            txtQuotationDest.Clear();
            txtManifest.Clear();
            chkUseDateRange.Checked = false;
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            panelDateRange.Enabled = false;

            flpVerticalActions.Enabled = true;

            UpdateToolButtonStates();

            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();

            panelProcess.Visible = false;
            btnCancel.Enabled = true;
            btnProcess.Enabled = false;

            btnProcess.Text = "Process";

            _activeTool = null;
        }

        private void AssignEventHandlers()
        {
            chkUseDateRange.CheckedChanged += chkUseDateRange_CheckedChanged;

            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            {
                btn.Click += ActionButton_Click;
            }

            btnProcess.Click += btnProcess_Click;
            btnCancel.Click += btnCancel_Click;

            dgvResults.CellValueChanged += dgvResults_CellValueChanged;
            dgvResults.CurrentCellDirtyStateChanged += dgvResults_CurrentCellDirtyStateChanged;
        }

        private async void ActionButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null || !_tools.TryGetValue(clickedButton.Name, out _activeTool))
            {
                return;
            }

            grpFilters.Enabled = false;
            flpVerticalActions.Enabled = false;
            panelProcess.Visible = true;
            btnProcess.Text = _activeTool.ToolName;

            var parameters = new ToolParameters
            {
                ManifestDocNo = txtManifest.Text.Trim(),
                QuotationSource = txtQuotationSource.Text.Trim(),
                QuotationDestination = txtQuotationDest.Text.Trim()
            };

            try
            {
                DataTable dt = await _activeTool.SearchAsync(parameters);
                dgvResults.DataSource = dt;
                FormatGrid();

                if (_activeTool is DeleteAllBoxesTool)
                {
                    btnProcess.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}", "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetupInitialState();
            }
        }

        private void FormatGrid()
        {
            if (dgvResults.DataSource == null) return;

            if (dgvResults.Columns.Contains("Select"))
            {
                dgvResults.Columns["Select"].HeaderText = "Select";
                dgvResults.Columns["Select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgvResults.Columns.Contains("DocNo"))
            {
                dgvResults.Columns["DocNo"].HeaderText = "Document No.";
            }
            if (dgvResults.Columns.Contains("WasteName"))
            {
                dgvResults.Columns["WasteName"].HeaderText = "Waste Name";
                dgvResults.Columns["WasteName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvResults.Columns.Contains("WasteDataID")) dgvResults.Columns["WasteDataID"].Visible = false;
            if (dgvResults.Columns.Contains("MenifestID")) dgvResults.Columns["MenifestID"].Visible = false;

            if (dgvResults.Columns.Contains("QuotationNo"))
            {
                dgvResults.Columns["QuotationNo"].HeaderText = "Quotation No.";
                dgvResults.Columns["QuotationNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvResults.Columns.Contains("isApproved"))
            {
                dgvResults.Columns["isApproved"].HeaderText = "Approved Status";
            }
            if (dgvResults.Columns.Contains("QuotationID")) dgvResults.Columns["QuotationID"].Visible = false;

            if (dgvResults.Columns.Contains("JobDataCarID"))
            {
                dgvResults.Columns["JobDataCarID"].HeaderText = "Job Data Car ID";
                dgvResults.Columns["JobDataCarID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgvResults.Columns.Contains("BoxReservNumber"))
            {
                dgvResults.Columns["BoxReservNumber"].HeaderText = "Box Reserve Number";
                dgvResults.Columns["BoxReservNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (_activeTool == null) return;

            if (!(_activeTool is DeleteAllBoxesTool) && !dgvResults.Columns.Contains("Select"))
            {
                MessageBox.Show("The results table is not valid. The column for selecting items is missing.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvResults.Rows.Cast<DataGridViewRow>()
                .Where(row => dgvResults.Columns.Contains("Select") && row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value))
                .Select(row => (row.DataBoundItem as DataRowView)?.Row)
                .Where(row => row != null)
                .ToList();

            if (!(_activeTool is DeleteAllBoxesTool) && !selectedRows.Any())
            {
                MessageBox.Show("Please select at least one item to process.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnProcess.Enabled = false;

            try
            {
                var result = await _activeTool.ProcessAsync(selectedRows);
                MessageBox.Show(result.Message, "Processing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during processing: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetupInitialState();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetupInitialState();
        }

        private void chkUseDateRange_CheckedChanged(object sender, EventArgs e)
        {
            panelDateRange.Enabled = chkUseDateRange.Checked;
        }

        private void dgvResults_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvResults.IsCurrentCellDirty)
            {
                dgvResults.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_activeTool is DeleteAllBoxesTool) return;

            if (dgvResults.Columns.Contains("Select") && e.ColumnIndex == dgvResults.Columns["Select"].Index)
            {
                UpdateProcessButtonState();
            }
        }

        private void UpdateProcessButtonState()
        {
            if (dgvResults.Rows.Count == 0 || !dgvResults.Columns.Contains("Select"))
            {
                btnProcess.Enabled = false;
                return;
            }
            bool anySelected = dgvResults.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value));
            btnProcess.Enabled = anySelected;
        }
    }
}
