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

        private readonly Color _btnDefaultBackColor = Color.FromArgb(240, 242, 245);
        private readonly Color _btnDefaultForeColor = Color.FromArgb(51, 65, 85);
        private readonly Color _btnDefaultBorderColor = Color.FromArgb(203, 213, 225);

        private readonly Color _btnHoverBackColor = Color.FromArgb(226, 232, 240);
        private readonly Color _btnHoverBorderColor = Color.FromArgb(148, 163, 184);

        private readonly Color _btnActiveBackColor = Color.FromArgb(37, 99, 235);
        private readonly Color _btnActiveForeColor = Color.White;
        private readonly Color _btnActiveBorderColor = Color.FromArgb(30, 64, 175);

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
            ResetState(true); // เริ่มต้นแบบล้างค่าทั้งหมด
            AssignEventHandlers();
        }

        private void RegisterAndOrderTools()
        {
            _tools.Clear();
            var orderedToolTypes = new List<Type>
            {
                typeof(UnlockQuotationTool), typeof(FixShippingCostTypeTool), typeof(NewWasteTool),
                typeof(NewWasteAddTool), typeof(ChangeQuotationTool), typeof(DeleteAllBoxesTool),
                typeof(FixShippingLocationTool), typeof(FixShippingCostTool), typeof(UpdateAddressTool),
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
                    }
                    else
                    {
                        button.Enabled = false;
                        button.Text += " (Not Found)";
                    }
                }
                else
                {
                    button.Enabled = false;
                }
            }
        }

        /// <summary>
        /// NEW: Centralized method to reset the UI state.
        /// </summary>
        /// <param name="clearFilters">If true, clears the filter textboxes. If false, preserves their content.</param>
        private void ResetState(bool clearFilters)
        {
            if (clearFilters)
            {
                txtQuotationSource.Clear();
                txtQuotationDest.Clear();
                txtManifest.Clear();
                txtJobNo.Clear();
            }

            grpFilters.Enabled = true;
            flpVerticalActions.Enabled = true;
            ResetAllButtonStyles();

            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();

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
        }

        private async void ActionButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null || !_tools.TryGetValue(clickedButton.Name, out _activeTool))
            {
                return;
            }

            _currentParameters = new ToolParameters
            {
                ManifestDocNo = txtManifest.Text.Trim(),
                JobNo = txtJobNo.Text.Trim(),
                QuotationSource = txtQuotationSource.Text.Trim(),
                QuotationDestination = txtQuotationDest.Text.Trim()
            };

            // Lock UI for processing
            SetActiveButton(clickedButton);
            grpFilters.Enabled = false;
            flpVerticalActions.Enabled = false;
            panelProcess.Visible = true;
            btnProcess.Text = _activeTool.ToolName;
            btnProcess.Enabled = false;

            try
            {
                DataTable dt = await _activeTool.SearchAsync(_currentParameters);

                // --- MODIFIED: Check search result here ---
                // If the tool returns null (e.g., from a validation message) or an empty table, reset automatically.
                if (dt == null || dt.Rows.Count == 0)
                {
                    if (dt != null) // Only show this generic message if the tool didn't already show one by returning null.
                    {
                        MessageBox.Show("ไม่พบข้อมูลตามเงื่อนไขที่ระบุ", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ResetState(false); // Reset UI but KEEP filter values.
                    return; // Stop further execution.
                }

                // If search is successful, populate the grid
                dgvResults.DataSource = dt;
                FormatGrid();

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
                ResetState(false); // On error, reset but keep filters for correction.
            }
        }

        private void FormatGrid()
        {
            if (dgvResults.DataSource == null) return;
            dgvResults.SuspendLayout();

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
                // After a process is complete, reset and clear filters for the next task.
                ResetState(true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // MODIFIED: Cancel now preserves filter text.
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

        #region UI Styling Methods

        /// <summary>
        /// MODIFIED: Applies an enhanced modern, flat style to a button.
        /// </summary>
        private void ApplyModernButtonStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = _btnDefaultBackColor;
            btn.ForeColor = _btnDefaultForeColor;
            btn.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            btn.Size = new Size(220, 45); // Increased size
            btn.Margin = new Padding(3, 3, 3, 6);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(15, 0, 0, 0);
            btn.Cursor = Cursors.Hand;

            // Add hover effects
            btn.MouseEnter += Button_MouseEnter;
            btn.MouseLeave += Button_MouseLeave;
        }

        // --- NEW: Event handler for mouse enter (hover) ---
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn != _activeButton) // Only change if it's not the currently active button
            {
                btn.BackColor = _btnHoverBackColor;
                btn.FlatAppearance.BorderColor = _btnHoverBorderColor;
            }
        }

        // --- NEW: Event handler for mouse leave (hover) ---
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn != _activeButton) // Only change if it's not the currently active button
            {
                btn.BackColor = _btnDefaultBackColor;
                btn.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            }
        }

        /// <summary>
        /// MODIFIED: Resets all action buttons to the new default, inactive style.
        /// </summary>
        private void ResetAllButtonStyles()
        {
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            {
                btn.BackColor = _btnDefaultBackColor;
                btn.ForeColor = _btnDefaultForeColor;
                btn.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            }
        }

        /// <summary>
        /// MODIFIED: Sets the visual state for the active button using the new styles.
        /// </summary>
        private void SetActiveButton(Button clickedButton)
        {
            // Reset the previously active button
            if (_activeButton != null)
            {
                _activeButton.BackColor = _btnDefaultBackColor;
                _activeButton.ForeColor = _btnDefaultForeColor;
                _activeButton.FlatAppearance.BorderColor = _btnDefaultBorderColor;
            }

            // Set the new active button
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
