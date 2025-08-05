using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

            public static async Task<DataTable> GetDataTableAsync(string query, string remark = "", params SqlParameter[] parameters)
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

                if (!string.IsNullOrEmpty(remark) && dt.Rows.Count > 0)
                {
                    MessageBox.Show(remark, "Remark", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private Button _activeButton = null;
        private ToolParameters _currentParameters;

        private readonly Color _btnDefaultBackColor = Color.White;
        private readonly Color _btnDefaultForeColor = Color.FromArgb(51, 65, 85);
        private readonly Color _btnDefaultBorderColor = Color.FromArgb(203, 213, 225);

        private readonly Color _btnHoverBackColor = Color.FromArgb(248, 250, 252);
        private readonly Color _btnHoverBorderColor = Color.FromArgb(148, 163, 184);

        private readonly Color _btnActiveBackColor = Color.FromArgb(79, 70, 229);
        private readonly Color _btnActiveForeColor = Color.White;
        private readonly Color _btnActiveBorderColor = Color.FromArgb(67, 56, 202);

        private bool _isHandlingSelectAll = false;


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
            ResetState(true);
            AssignEventHandlers();
        }

        private void RegisterAndOrderTools()
        {
            _tools.Clear();
            var orderedToolTypes = new List<Type>
            {
                typeof(UnlockQuotationTool),
                typeof(FixShippingCostTypeTool),
                typeof(NewWasteTool),
                typeof(NewWasteAddTool),
                typeof(ChangeQuotationTool),
                typeof(DeleteAllBoxesTool),
                typeof(FixShippingLocationTool),
                typeof(FixCreditNoteTool),
                typeof(UpdateAddressTool),
                typeof(ChangeToNewCustomerTool)
            };

            var buttons = flpVerticalActions.Controls.OfType<Button>().ToList();
            var availableTools = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ITroubleshooterTool).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (ITroubleshooterTool)Activator.CreateInstance(t))
                .ToDictionary(t => t.GetType());

            for (int i = 0; i < buttons.Count; i++)
            {
                var button = buttons[i];
                ApplyModernButtonStyle(button);

                if (i < orderedToolTypes.Count)
                {
                    var toolType = orderedToolTypes[i];
                    if (availableTools.TryGetValue(toolType, out ITroubleshooterTool toolInstance))
                    {
                        _tools.Add(button.Name, toolInstance);
                        button.Text = toolInstance.ToolName;
                        button.Visible = true;
                    }
                    else
                    {
                        button.Enabled = false;
                        button.Text += " (Not Found)";
                        button.Visible = true;
                    }
                }
                else
                {
                    button.Enabled = false;
                    button.Visible = false;
                }
            }
        }

        private void ResetState(bool clearFilters)
        {
            if (clearFilters)
            {
                txtQuotationSource.Clear();
                txtQuotationDest.Clear();
                txtManifest.Clear();
                txtJobNo.Clear();
                txtCreditNote.Clear(); // <-- ADDED: Clear the new textbox
            }

            grpFilters.Enabled = true;
            flpVerticalActions.Enabled = true;
            ResetAllButtonStyles();

            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();

            pnlGridHeader.Visible = false;
            _isHandlingSelectAll = true;
            chkSelectAll.CheckState = CheckState.Unchecked;
            _isHandlingSelectAll = false;

            panelProcess.Visible = false;
            btnProcess.Enabled = false;
            btnProcess.Text = "ดำเนินการ";

            _activeTool = null;
            _activeButton = null;
        }


        private void AssignEventHandlers()
        {
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            {
                if (_tools.ContainsKey(btn.Name))
                {
                    btn.Click += ActionButton_Click;
                }
            }
            btnProcess.Click += btnProcess_Click;
            btnCancel.Click += btnCancel_Click;
            dgvResults.CellValueChanged += dgvResults_CellValueChanged;
            dgvResults.CurrentCellDirtyStateChanged += dgvResults_CurrentCellDirtyStateChanged;
            btnFindManifest.Click += btnFindManifest_Click;
            chkSelectAll.CheckedChanged += chkSelectAll_CheckedChanged;
        }

        private async void btnFindManifest_Click(object sender, EventArgs e)
        {
            string quotationSource = txtQuotationSource.Text.Trim();
            if (string.IsNullOrWhiteSpace(quotationSource))
            {
                MessageBox.Show("กรุณาระบุ Quotation (ต้นทาง) เพื่อใช้ค้นหา Manifest", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuotationSource.Focus();
                return;
            }

            try
            {
                string query = @"
                    SELECT DocNo, CompanyName, WorkDate, JobNo, WasteNo, WasteName, TruckTypeDesc 
                    FROM vw_MenifestQuotation
                    WHERE QuotationNo = @QuotationNo";

                DataTable manifestData = await DataAccess.GetDataTableAsync(query, "", new SqlParameter("@QuotationNo", quotationSource));

                if (manifestData.Rows.Count == 0)
                {
                    MessageBox.Show($"ไม่พบ Manifest ที่ใช้ Quotation No: '{quotationSource}'", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var selectionForm = new ManifestSelectionForm(manifestData))
                {
                    if (selectionForm.ShowDialog() == DialogResult.OK)
                    {
                        txtManifest.Text = selectionForm.SelectedDocNo;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการค้นหา Manifest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void ActionButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null || !_tools.TryGetValue(clickedButton.Name, out _activeTool))
            {
                return;
            }

            // *** UPDATED: Read value from the new textbox ***
            _currentParameters = new ToolParameters
            {
                ManifestDocNo = txtManifest.Text.Trim(),
                JobNo = txtJobNo.Text.Trim(),
                QuotationSource = txtQuotationSource.Text.Trim(),
                QuotationDestination = txtQuotationDest.Text.Trim(),
                CreditNoteNo = txtCreditNote.Text.Trim()
            };

            SetActiveButton(clickedButton);
            grpFilters.Enabled = false;
            flpVerticalActions.Enabled = false;

            try
            {
                DataTable dt = await _activeTool.SearchAsync(_currentParameters);

                if (dt == null || dt.Rows.Count == 0)
                {
                    if (dt != null)
                    {
                        MessageBox.Show("ไม่พบข้อมูลตามเงื่อนไขที่ระบุ", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ResetState(false);
                    return;
                }

                panelProcess.Visible = true;
                btnProcess.Text = _activeTool.ToolName;
                btnProcess.Enabled = false;

                dgvResults.DataSource = dt;
                FormatGrid();

                if (dgvResults.Columns.Contains("Select"))
                {
                    pnlGridHeader.Visible = true;
                }

                if (_activeTool is DeleteAllBoxesTool || !dgvResults.Columns.Contains("Select"))
                {
                    btnProcess.Enabled = true;
                }
                else
                {
                    UpdateProcessButtonState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}", "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetState(false);
            }
        }

        // *** UPDATED: FormatGrid method as requested ***
        private void FormatGrid()
        {
            if (dgvResults.DataSource == null) return;
            dgvResults.SuspendLayout();

            // Set all columns to auto-size based on content.
            foreach (DataGridViewColumn col in dgvResults.Columns)
            {
                if (col.Name != "Select")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }

            // Apply specific settings for the 'Select' column.
            if (dgvResults.Columns.Contains("Select"))
            {
                dgvResults.Columns["Select"].HeaderText = "เลือก";
                dgvResults.Columns["Select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvResults.Columns["Select"].Width = 60;
            }

            dgvResults.ResumeLayout();
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (_activeTool == null) return;
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
                var rowsToProcess = requiresSelection ? selectedRows : Enumerable.Empty<DataRow>();
                var result = await _activeTool.ProcessAsync(rowsToProcess, _currentParameters);
                MessageBox.Show(result.Message, "Processing Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during processing: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResetState(true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetState(false);
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
                UpdateSelectAllCheckBoxState();
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

        #region Select All Logic
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_isHandlingSelectAll) return;

            if (dgvResults.Rows.Count == 0 || !dgvResults.Columns.Contains("Select")) return;

            bool isChecked = chkSelectAll.Checked;

            dgvResults.SuspendLayout();
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (row.Cells["Select"] is DataGridViewCheckBoxCell cell)
                {
                    cell.Value = isChecked;
                }
            }
            dgvResults.ResumeLayout();

            dgvResults.Refresh();
            UpdateProcessButtonState();
        }

        private void UpdateSelectAllCheckBoxState()
        {
            if (dgvResults.Rows.Count == 0 || !dgvResults.Columns.Contains("Select")) return;

            int totalRows = dgvResults.Rows.Count;
            int checkedRows = 0;

            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    checkedRows++;
                }
            }

            _isHandlingSelectAll = true;
            if (checkedRows == totalRows)
            {
                chkSelectAll.CheckState = CheckState.Checked;
            }
            else if (checkedRows == 0)
            {
                chkSelectAll.CheckState = CheckState.Unchecked;
            }
            else
            {
                chkSelectAll.CheckState = CheckState.Indeterminate;
            }
            _isHandlingSelectAll = false;
        }
        #endregion

        #region UI Styling Methods

        private void ApplyModernButtonStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = _btnDefaultBackColor;
            btn.ForeColor = _btnDefaultForeColor;
            btn.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            btn.Size = new Size(200, 45);
            btn.Margin = new Padding(3, 3, 3, 6);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += Button_MouseEnter;
            btn.MouseLeave += Button_MouseLeave;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn != _activeButton)
            {
                btn.BackColor = _btnHoverBackColor;
                btn.FlatAppearance.BorderColor = _btnHoverBorderColor;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn != _activeButton)
            {
                btn.BackColor = _btnDefaultBackColor;
                btn.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            }
        }

        private void ResetAllButtonStyles()
        {
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            {
                btn.BackColor = _btnDefaultBackColor;
                btn.ForeColor = _btnDefaultForeColor;
                btn.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            }
        }

        private void SetActiveButton(Button clickedButton)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = _btnDefaultBackColor;
                _activeButton.ForeColor = _btnDefaultForeColor;
                _activeButton.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            }

            _activeButton = clickedButton;
            if (_activeButton != null)
            {
                _activeButton.BackColor = _btnActiveBackColor;
                _activeButton.ForeColor = _btnActiveForeColor;
                _activeButton.FlatAppearance.BorderColor = _btnActiveBorderColor;
            }
        }

        #endregion
    }
}
