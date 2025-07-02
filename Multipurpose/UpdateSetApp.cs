using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Multipurpose
{
    public partial class UpdateSetApp : UserControl
    {
        // Enum to manage the state of the control
        private enum AppMode
        {
            Idle,
            Processing
        }

        private AppMode _currentMode = AppMode.Idle;
        private Button _activeActionButton = null;

        public UpdateSetApp()
        {
            InitializeComponent();
            this.Load += UpdateSetApp_Load;
        }

        private void UpdateSetApp_Load(object sender, EventArgs e)
        {
            // Initial setup when the control loads
            SetupInitialState();
            AssignEventHandlers();
        }

        /// <summary>
        /// Sets the initial state of all controls.
        /// </summary>
        private void SetupInitialState()
        {
            // --- Filters ---
            grpFilters.Enabled = true;
            txtQuotationSource.Clear();
            txtQuotationDest.Clear();
            txtManifest.Clear();
            chkUseDateRange.Checked = false;
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            panelDateRange.Enabled = false;

            // --- Actions ---
            grpActions.Enabled = true;
            flpActions.Enabled = true;

            // --- Results ---
            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();

            // --- Process/Cancel Buttons ---
            panelProcess.Visible = false;
            btnProcess.Enabled = false;
            btnProcess.Text = "ดำเนินการ";

            // Reset state variables
            _currentMode = AppMode.Idle;
            _activeActionButton = null;
        }

        /// <summary>
        /// Assigns click events to all action buttons.
        /// </summary>
        private void AssignEventHandlers()
        {
            // Filter events
            chkUseDateRange.CheckedChanged += chkUseDateRange_CheckedChanged;

            // Action button events
            foreach (Button btn in flpActions.Controls.OfType<Button>())
            {
                btn.Click += ActionButton_Click;
            }

            // Process/Cancel button events
            btnProcess.Click += btnProcess_Click;
            btnCancel.Click += btnCancel_Click;

            // DataGridView events
            dgvResults.CellValueChanged += dgvResults_CellValueChanged;
            dgvResults.CurrentCellDirtyStateChanged += dgvResults_CurrentCellDirtyStateChanged;
        }

        /// <summary>
        /// Handles the click event for any of the main action buttons.
        /// </summary>
        private void ActionButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null) return;

            // --- Enter Processing Mode ---
            _currentMode = AppMode.Processing;
            _activeActionButton = clickedButton;

            // Update UI for processing mode
            grpFilters.Enabled = false;
            flpActions.Enabled = false; // Disable the whole panel of actions
            panelProcess.Visible = true;
            btnProcess.Text = clickedButton.Text; // Set the process button text to the action name

            // --- Search Phase ---
            // This is where you would run the specific query based on the button clicked.
            // For now, we'll just simulate it with mock data.
            SearchForData(clickedButton.Name);
        }

        /// <summary>
        /// Simulates searching for data and populating the DataGridView.
        /// </summary>
        private void SearchForData(string actionName)
        {
            // TODO: Replace this with your actual database query logic.
            // You can use a switch statement on `actionName` (e.g., "btnUnlockQuotation")
            // to call the correct search method.

            // Example:
            // switch (actionName)
            // {
            //     case "btnUnlockQuotation":
            //         dgvResults.DataSource = YourDataAccess.SearchUnlockableQuotations(...);
            //         break;
            //     // ... other cases
            // }

            // Mockup Data for demonstration
            var dt = new DataTable();
            dt.Columns.Add("Select", typeof(bool));
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Status", typeof(string));

            for (int i = 1; i <= 10; i++)
            {
                dt.Rows.Add(false, i, $"ผลลัพธ์จาก '{actionName}' รายการที่ {i}", "Pending");
            }

            dgvResults.DataSource = dt;
            dgvResults.Columns["ID"].ReadOnly = true;
            dgvResults.Columns["Description"].ReadOnly = true;
            dgvResults.Columns["Status"].ReadOnly = true;
            dgvResults.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        /// <summary>
        /// Handles the "ดำเนินการ" button click.
        /// </summary>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (_activeActionButton == null) return;

            // Get selected items from DataGridView
            var selectedIds = new List<int>();
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    selectedIds.Add(Convert.ToInt32(row.Cells["ID"].Value));
                }
            }

            if (!selectedIds.Any())
            {
                MessageBox.Show("กรุณาเลือกอย่างน้อย 1 รายการเพื่อดำเนินการ", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Execution Phase ---
            // TODO: Add your specific logic here based on the active action button.
            // You can use a switch on `_activeActionButton.Name`.

            MessageBox.Show($"กำลังดำเนินการ '{_activeActionButton.Text}' กับ {selectedIds.Count} รายการที่เลือก.", "Processing", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // For example:
            // switch (_activeActionButton.Name)
            // {
            //     case "btnUnlockQuotation":
            //         YourDataAccess.UnlockQuotations(selectedIds);
            //         break;
            //     // ... other cases
            // }

            // --- Reset to initial state after processing ---
            SetupInitialState();
        }

        /// <summary>
        /// Handles the "ยกเลิก" button click.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetupInitialState();
        }

        #region Control and DataGridView Event Handlers

        private void chkUseDateRange_CheckedChanged(object sender, EventArgs e)
        {
            panelDateRange.Enabled = chkUseDateRange.Checked;
        }

        // This is necessary to make the checkbox click register immediately.
        private void dgvResults_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvResults.IsCurrentCellDirty)
            {
                dgvResults.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // After a checkbox value changes, check if we should enable the Process button.
        private void dgvResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_currentMode == AppMode.Processing && e.ColumnIndex == dgvResults.Columns["Select"].Index)
            {
                UpdateProcessButtonState();
            }
        }

        /// <summary>
        /// Checks all rows and enables the Process button if at least one is selected.
        /// </summary>
        private void UpdateProcessButtonState()
        {
            bool anySelected = false;
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    anySelected = true;
                    break;
                }
            }
            btnProcess.Enabled = anySelected;
        }

        #endregion
    }
}
