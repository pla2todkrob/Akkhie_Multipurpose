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
        // ... (ส่วนของ DataAccess ไม่มีการเปลี่ยนแปลง)
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
        private Button _activeButton = null; // Track the currently active button
        private ToolParameters _currentParameters;

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
                ApplyModernButtonStyle(button); // Apply new style to each button

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

        private void SetupInitialState()
        {
            grpFilters.Enabled = true;
            txtQuotationSource.Clear();
            txtQuotationDest.Clear();
            txtManifest.Clear();
            txtJobNo.Clear();

            flpVerticalActions.Enabled = true;
            ResetAllButtonStyles(); // Reset button styles to default

            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();

            panelProcess.Visible = false;
            btnCancel.Enabled = true;
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

            SetActiveButton(clickedButton); // Set the clicked button as active

            grpFilters.Enabled = false;
            flpVerticalActions.Enabled = false;
            panelProcess.Visible = true;
            btnProcess.Text = _activeTool.ToolName;

            _currentParameters = new ToolParameters
            {
                ManifestDocNo = txtManifest.Text.Trim(),
                JobNo = txtJobNo.Text.Trim(),
                QuotationSource = txtQuotationSource.Text.Trim(),
                QuotationDestination = txtQuotationDest.Text.Trim()
            };

            try
            {
                DataTable dt = await _activeTool.SearchAsync(_currentParameters);
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
            // ... (ส่วนที่เหลือของ FormatGrid ไม่มีการเปลี่ยนแปลง)

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

        #region UI Styling Methods

        /// <summary>
        /// Applies a modern, flat style to a button.
        /// </summary>
        private void ApplyModernButtonStyle(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.Gainsboro;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.FromArgb(64, 64, 64);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btn.Size = new Size(200, 40);
            btn.Margin = new Padding(3, 3, 3, 5);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
        }

        /// <summary>
        /// Resets all action buttons to their default, inactive style.
        /// </summary>
        private void ResetAllButtonStyles()
        {
            foreach (Button btn in flpVerticalActions.Controls.OfType<Button>())
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(64, 64, 64);
                btn.FlatAppearance.BorderColor = Color.Gainsboro;
            }
        }

        /// <summary>
        /// Sets the visual state for the active button and resets the previous one.
        /// </summary>
        private void SetActiveButton(Button clickedButton)
        {
            // Reset the previously active button
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.White;
                _activeButton.ForeColor = Color.FromArgb(64, 64, 64);
                _activeButton.FlatAppearance.BorderColor = Color.Gainsboro;
            }

            // Set the new active button
            _activeButton = clickedButton;
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.FromArgb(0, 123, 255); // A modern blue
                _activeButton.ForeColor = Color.White;
                _activeButton.FlatAppearance.BorderColor = Color.FromArgb(0, 123, 255);
            }
        }

        #endregion
    }
}
