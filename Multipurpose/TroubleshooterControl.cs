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
                        Pooling = true
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

            RegisterAndOrderTools();
            SetupInitialState();
            AssignEventHandlers();
        }

        /// <summary>
        /// Registers tools based on a predefined order and maps them to buttons.
        /// </summary>
        private void RegisterAndOrderTools()
        {
            _tools.Clear();

            // Define the exact order of tools.
            var orderedToolTypes = new List<Type>
            {
                typeof(UnlockQuotationTool),
                typeof(FixShippingCostTypeTool),
                typeof(NewWasteTool),
                typeof(NewWasteAddTool),
                typeof(ChangeQuotationTool),
                typeof(DeleteAllBoxesTool),
                typeof(FixShippingLocationTool),
                typeof(FixShippingCostTool),
                typeof(UpdateAddressTool),
                typeof(ChangeToNewCustomerTool)
            };

            // Get all buttons from the panel, assuming they are in the correct visual order.
            var buttons = flpVerticalActions.Controls.OfType<Button>().ToList();

            // Create instances of all available tools in the assembly.
            var availableTools = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ITroubleshooterTool).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (ITroubleshooterTool)Activator.CreateInstance(t))
                .ToDictionary(t => t.GetType());

            for (int i = 0; i < buttons.Count; i++)
            {
                var button = buttons[i];
                if (i < orderedToolTypes.Count)
                {
                    var toolType = orderedToolTypes[i];
                    if (availableTools.TryGetValue(toolType, out ITroubleshooterTool toolInstance))
                    {
                        // Map the button to its tool instance and set its text.
                        _tools.Add(button.Name, toolInstance);
                        button.Text = toolInstance.ToolName;
                    }
                    else
                    {
                        // Disable the button if the corresponding tool class is not found.
                        button.Enabled = false;
                        button.Text += " (Not Found)";
                    }
                }
                else
                {
                    // Disable any extra buttons that don't have a tool defined in the order.
                    button.Enabled = false;
                }
            }
        }

        private void SetupInitialState()
        {
            grpFilters.Enabled = true;
            txtQuotationSource.Clear();
            txtQuotationDest.Clear();
            txtManifest.Clear();
            txtJobNo.Clear(); // Clear the new Job No textbox

            flpVerticalActions.Enabled = true;

            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();

            panelProcess.Visible = false;
            btnCancel.Enabled = true;
            btnProcess.Enabled = false;

            btnProcess.Text = "ดำเนินการ";

            _activeTool = null;
        }

        private void AssignEventHandlers()
        {
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            {
                // Only add click handlers for buttons that have a registered tool.
                if (_tools.ContainsKey(btn.Name))
                {
                    btn.Click += ActionButton_Click;
                }
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

            // Pass all required parameters to the tool.
            var parameters = new ToolParameters
            {
                ManifestDocNo = txtManifest.Text.Trim(),
                JobNo = txtJobNo.Text.Trim(), // Pass the new Job No value
                QuotationSource = txtQuotationSource.Text.Trim(),
                QuotationDestination = txtQuotationDest.Text.Trim()
            };

            try
            {
                DataTable dt = await _activeTool.SearchAsync(parameters);
                dgvResults.DataSource = dt;
                FormatGrid();

                // Special handling for tools that don't require item selection.
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
            dgvResults.SuspendLayout(); // Suspend layout for performance

            // Apply formatting based on column names.
            if (dgvResults.Columns.Contains("Select"))
            {
                dgvResults.Columns["Select"].HeaderText = "เลือก";
                dgvResults.Columns["Select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgvResults.Columns.Contains("JobNo")) dgvResults.Columns["JobNo"].HeaderText = "Job No";
            if (dgvResults.Columns.Contains("DocNo")) dgvResults.Columns["DocNo"].HeaderText = "Manifest No";
            if (dgvResults.Columns.Contains("CustomerCode")) dgvResults.Columns["CustomerCode"].HeaderText = "รหัสลูกค้า";
            if (dgvResults.Columns.Contains("CompanyName"))
            {
                dgvResults.Columns["CompanyName"].HeaderText = "ชื่อลูกค้า";
                dgvResults.Columns["CompanyName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvResults.Columns.Contains("WasteNo")) dgvResults.Columns["WasteNo"].HeaderText = "รหัสของเสีย";
            if (dgvResults.Columns.Contains("WasteName"))
            {
                dgvResults.Columns["WasteName"].HeaderText = "ชื่อของเสีย";
                dgvResults.Columns["WasteName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvResults.Columns.Contains("QuotationNo")) dgvResults.Columns["QuotationNo"].HeaderText = "ใบเสนอราคา";
            if (dgvResults.Columns.Contains("TruckTypeDesc")) dgvResults.Columns["TruckTypeDesc"].HeaderText = "ประเภทรถ";
            if (dgvResults.Columns.Contains("TransportFee")) dgvResults.Columns["TransportFee"].HeaderText = "ค่าขนส่ง";
            if (dgvResults.Columns.Contains("WorkDate")) dgvResults.Columns["WorkDate"].HeaderText = "วันที่เข้าหน้างาน";

            if (dgvResults.Columns.Contains("CurrentTruckTypeDesc")) dgvResults.Columns["CurrentTruckTypeDesc"].HeaderText = "ประเภทรถ (ปัจจุบัน)";
            if (dgvResults.Columns.Contains("CurrentTransportFee")) dgvResults.Columns["CurrentTransportFee"].HeaderText = "ค่าขนส่ง (ปัจจุบัน)";
            if (dgvResults.Columns.Contains("CorrectRate")) dgvResults.Columns["CorrectRate"].HeaderText = "ค่าขนส่ง (ถูกต้อง)";

            // Hide ID columns
            foreach (DataGridViewColumn col in dgvResults.Columns)
            {
                if (col.Name.EndsWith("ID", StringComparison.OrdinalIgnoreCase))
                {
                    col.Visible = false;
                }
            }

            dgvResults.ResumeLayout();
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (_activeTool == null) return;

            // Check if the grid requires selection.
            bool requiresSelection = dgvResults.Columns.Contains("Select");

            var selectedRows = dgvResults.Rows.Cast<DataGridViewRow>()
                .Where(row => requiresSelection && row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value))
                .Select(row => (row.DataBoundItem as DataRowView)?.Row)
                .Where(row => row != null)
                .ToList();

            if (requiresSelection && !selectedRows.Any())
            {
                MessageBox.Show("กรุณาเลือกอย่างน้อย 1 รายการเพื่อดำเนินการ", "ไม่ได้เลือกรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnProcess.Enabled = false;

            try
            {
                // For tools like DeleteAllBoxes, pass an empty list.
                var rowsToProcess = requiresSelection ? selectedRows : Enumerable.Empty<DataRow>();
                var result = await _activeTool.ProcessAsync(rowsToProcess);
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

        private void dgvResults_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvResults.IsCurrentCellDirty)
            {
                dgvResults.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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
