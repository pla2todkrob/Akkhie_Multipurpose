using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// Implements the logic for the "New Waste" button.
    /// </summary>
    public class NewWasteTool : ITroubleshooterTool
    {
        public string ToolName => "New waste";

        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.ManifestDocNo))
            {
                MessageBox.Show("กรุณาป้อนค่า DocNo ในช่อง Manifest", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS [Select], 
                    MenifestID, DocNo, WasteDataID, WasteName, WasteNo, 
                    IsNewWaste, IsNewWasteCR, isCanceled, isClosed, JobID, JobNo
                FROM vw_MenifestDetailSearch
                WHERE DocNo = @DocNo";

            // Note: This assumes a static DataAccess class exists in the parent scope.
            // For better design, consider injecting it via the constructor (Dependency Injection).
            return await TroubleshooterControl.DataAccess.GetDataTableAsync(query, "กรุณาเลือกรายการทั้งหมดที่ต้องการติ๊ก New Waste", new SqlParameter("@DocNo", parameters.ManifestDocNo));
        }

        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            var result = new ProcessResult();

            foreach (var row in selectedRows)
            {
                try
                {
                    string docNo = row["DocNo"].ToString();
                    string wasteDataId = row["WasteDataID"].ToString();

                    string query = @"
                        UPDATE vw_MenifestDetailSearch
                        SET IsNewWaste = 'New'
                        WHERE DocNo = @DocNo AND WasteDataID = @WasteDataID";

                    var sqlParameters = new[]
                    {
                        new SqlParameter("@DocNo", docNo),
                        new SqlParameter("@WasteDataID", wasteDataId)
                    };

                    int rowsAffected = await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(query, sqlParameters);
                    if (rowsAffected > 0)
                    {
                        result.SuccessCount++;
                    }
                    else
                    {
                        result.ErrorCount++;
                    }
                }
                catch (Exception ex)
                {
                    result.ErrorCount++;
                    // For debugging, log the detailed error.
                    Console.WriteLine($"Error processing DocNo {row["DocNo"]}: {ex.Message}");
                }
            }

            result.Message = $"ดำเนินการเสร็จสิ้น\nสำเร็จ: {result.SuccessCount} รายการ\nผิดพลาด: {result.ErrorCount} รายการ";
            return result;
        }
    }
}
