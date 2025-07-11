using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multipurpose.Troubleshooter.Tools;

namespace Multipurpose
{
    public partial class TroubleshooterControl : UserControl
    {
        // This static class provides data access methods for all tools.
        // For even better separation, this could be moved to its own file in a "Data" folder.
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
                        ConnectTimeout = 15
                    };
                    ConnectionString = builder.ConnectionString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ไม่สามารถสร้าง Connection String ได้จาก App.config: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConnectionString = null;
                }
            }

            public static bool IsConnectionConfigured() => !string.IsNullOrEmpty(ConnectionString);

            public static async Task<DataTable> GetDataTableAsync(string query, params SqlParameter[] parameters)
            {
                var dt = new DataTable();
                if (!IsConnectionConfigured()) return dt;

                using (var conn = new SqlConnection(ConnectionString))
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

                using (var conn = new SqlConnection(ConnectionString))
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
                MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ กรุณาตรวจสอบการตั้งค่าใน App.config", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = false;
                return;
            }

            RegisterTools();
            SetupInitialState();
            AssignEventHandlers();
            UpdateToolButtonStates(); // Set initial enabled/disabled state for all tool buttons
        }

        /// <summary>
        /// Initializes and registers all available tool classes.
        /// To add a new tool, simply create its class and add it to the dictionary here.
        /// </summary>
        private void RegisterTools()
        {
            // The key is the button's 'Name' property from the designer.
            _tools.Add(btnNewWaste.Name, new NewWasteTool());
            _tools.Add(btnNewWasteAdd.Name, new NewWasteAddTool());
            _tools.Add(btnUnlockQuotation.Name, new UnlockQuotationTool());
            _tools.Add(btnDeleteAllBoxes.Name, new DeleteAllBoxesTool());

            // Unimplemented tools will cause their buttons to be disabled automatically.
            // _tools.Add(btnUpdateAddress.Name, new UpdateAddressTool());
        }

        /// <summary>
        /// Enables or disables tool buttons based on whether a corresponding tool
        /// has been registered in the _tools dictionary.
        /// </summary>
        private void UpdateToolButtonStates()
        {
            // --- CHANGE START ---
            // เปลี่ยน flpActions เป็น flpVerticalActions
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            // --- CHANGE END ---
            {
                // A button is enabled only if a tool is registered for it.
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

            // --- CHANGE START ---
            // เปลี่ยน flpActions เป็น flpVerticalActions และลบ grpActions ที่ไม่มีแล้วออกไป
            flpVerticalActions.Enabled = true; // The panel itself is enabled
            // --- CHANGE END ---
            UpdateToolButtonStates(); // But individual buttons are controlled

            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();

            panelProcess.Visible = false;
            btnProcess.Enabled = false;
            btnProcess.Text = "ดำเนินการ";

            _activeTool = null;
        }

        private void AssignEventHandlers()
        {
            chkUseDateRange.CheckedChanged += chkUseDateRange_CheckedChanged;

            // --- CHANGE START ---
            // เปลี่ยน flpActions เป็น flpVerticalActions
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            // --- CHANGE END ---
            {
                btn.Click += ActionButton_Click;
            }

            btnProcess.Click += btnProcess_Click;
            btnCancel.Click += btnCancel_Click;

            dgvResults.CellValueChanged += dgvResults_CellValueChanged;
            dgvResults.CurrentCellDirtyStateChanged += dgvResults_CurrentCellDirtyStateChanged;
        }

        /// <summary>
        /// Handles clicks on any of the action buttons. It finds the corresponding
        /// tool and executes its search logic.
        /// </summary>
        private async void ActionButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            // This check is now a safeguard, as disabled buttons shouldn't be clickable.
            if (clickedButton == null || !_tools.TryGetValue(clickedButton.Name, out _activeTool))
            {
                return;
            }

            grpFilters.Enabled = false;
            // --- CHANGE START ---
            // เปลี่ยน flpActions เป็น flpVerticalActions
            flpVerticalActions.Enabled = false;
            // --- CHANGE END ---
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

                // Special handling for DeleteAllBoxesTool to enable the process button immediately.
                if (_activeTool is DeleteAllBoxesTool)
                {
                    btnProcess.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการค้นหาข้อมูล: {ex.Message}", "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetupInitialState();
            }
        }

        private void FormatGrid()
        {
            if (dgvResults.DataSource == null) return;

            if (dgvResults.Columns.Contains("Select"))
            {
                dgvResults.Columns["Select"].HeaderText = "เลือก";
                dgvResults.Columns["Select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (dgvResults.Columns.Contains("DocNo"))
            {
                dgvResults.Columns["DocNo"].HeaderText = "เลขที่เอกสาร";
            }
            if (dgvResults.Columns.Contains("WasteName"))
            {
                dgvResults.Columns["WasteName"].HeaderText = "ชื่อของเสีย";
                dgvResults.Columns["WasteName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvResults.Columns.Contains("WasteDataID")) dgvResults.Columns["WasteDataID"].Visible = false;
            if (dgvResults.Columns.Contains("MenifestID")) dgvResults.Columns["MenifestID"].Visible = false;

            // --- Formatting for UnlockQuotationTool ---
            if (dgvResults.Columns.Contains("QuotationNo"))
            {
                dgvResults.Columns["QuotationNo"].HeaderText = "เลขที่ใบเสนอราคา";
                dgvResults.Columns["QuotationNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvResults.Columns.Contains("isApproved"))
            {
                dgvResults.Columns["isApproved"].HeaderText = "สถานะอนุมัติ";
            }
            if (dgvResults.Columns.Contains("QuotationID")) dgvResults.Columns["QuotationID"].Visible = false;

            // --- Formatting for DeleteAllBoxesTool ---
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

        /// <summary>
        /// Handles the click on the main "Process" button, delegating the work
        /// to the currently active tool.
        /// </summary>
        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (_activeTool == null) return;

            // For most tools, check if the 'Select' column exists.
            // For DeleteAllBoxesTool, this check is not necessary as it can operate on an empty selection.
            if (!(_activeTool is DeleteAllBoxesTool) && !dgvResults.Columns.Contains("Select"))
            {
                MessageBox.Show("ตารางผลลัพธ์ไม่ถูกต้อง ไม่มีคอลัมน์สำหรับเลือกรายการ (Select column is missing).", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRows = dgvResults.Rows.Cast<DataGridViewRow>()
                .Where(row => dgvResults.Columns.Contains("Select") && row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value))
                .Select(row => (row.DataBoundItem as DataRowView)?.Row)
                .Where(row => row != null)
                .ToList();

            // For most tools, require at least one selection.
            if (!(_activeTool is DeleteAllBoxesTool) && !selectedRows.Any())
            {
                MessageBox.Show("กรุณาเลือกอย่างน้อย 1 รายการเพื่อดำเนินการ", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // The confirmation logic is now handled inside the tool itself for better context.

            btnProcess.Enabled = false;
            btnCancel.Enabled = false;

            try
            {
                var result = await _activeTool.ProcessAsync(selectedRows);
                MessageBox.Show(result.Message, "Processing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการประมวลผล: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Do not enable/disable process button for DeleteAllBoxesTool on selection change.
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
