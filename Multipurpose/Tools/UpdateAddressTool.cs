using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// Placeholder for "Update Address" functionality.
    /// </summary>
    public class UpdateAddressTool : ITroubleshooterTool
    {
        public string ToolName => "อัปเดตที่อยู่";

        public Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            MessageBox.Show("ฟังก์ชัน 'อัปเดตที่อยู่' ยังไม่ถูกพัฒนา", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(new DataTable());
        }

        public Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            MessageBox.Show("ฟังก์ชัน 'อัปเดตที่อยู่' ยังไม่ถูกพัฒนา", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(new ProcessResult { Message = "ยังไม่ถูกพัฒนา" });
        }
    }
}
