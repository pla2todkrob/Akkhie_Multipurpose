using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// Placeholder for "Fix Shipping Cost" functionality.
    /// </summary>
    public class FixShippingCostTool : ITroubleshooterTool
    {
        public string ToolName => "ค่าขนส่งไม่ขึ้น";

        public Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            MessageBox.Show("ฟังก์ชัน 'ค่าขนส่งไม่ขึ้น' ยังไม่ถูกพัฒนา", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(new DataTable());
        }

        public Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows)
        {
            MessageBox.Show("ฟังก์ชัน 'ค่าขนส่งไม่ขึ้น' ยังไม่ถูกพัฒนา", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.FromResult(new ProcessResult { Message = "ยังไม่ถูกพัฒนา" });
        }
    }
}
