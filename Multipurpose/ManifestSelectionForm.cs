using System;
using System.Data;
using System.Windows.Forms;

namespace Multipurpose
{
    /// <summary>
    /// A modal dialog form for selecting a Manifest document number from a list.
    /// </summary>
    public partial class ManifestSelectionForm : Form
    {
        /// <summary>
        /// Gets the document number of the selected manifest.
        /// </summary>
        public string SelectedDocNo { get; private set; }

        public ManifestSelectionForm(DataTable data)
        {
            InitializeComponent(); // This line calls the code from the .Designer.cs file
            dgvManifests.DataSource = data;
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvManifests.DataSource == null) return;
            dgvManifests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvManifests.Columns.Contains("CompanyName"))
            {
                dgvManifests.Columns["CompanyName"].FillWeight = 200; // Give more space to company name
            }
        }

        private void SelectAndClose()
        {
            if (dgvManifests.CurrentRow != null)
            {
                this.SelectedDocNo = dgvManifests.CurrentRow.Cells["DocNo"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการ", "ไม่ได้เลือกรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void dgvManifests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectAndClose();
        }
    }

}
