using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// Placeholder for "Change Quotation" functionality.
    /// </summary>
    public class ChangeQuotationTool : ITroubleshooterTool
    {
        public string ToolName => "เปลี่ยนใบเสนอราคา";

        public Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            MessageBox.Show("ฟังก์ชัน 'เปลี่ยนใบเสนอราคา' ยังไม่ถูกพัฒนา", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(new DataTable());
        }

        public Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows)
        {
            MessageBox.Show("ฟังก์ชัน 'เปลี่ยนใบเสนอราคา' ยังไม่ถูกพัฒนา", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(new ProcessResult { Message = "ยังไม่ถูกพัฒนา" });
        }
    }
}
