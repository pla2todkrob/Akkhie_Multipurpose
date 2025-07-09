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
    /// Implements the logic for the "New Waste ADD" button.
    /// This tool works with the 'Com_vwManifestWastAdd' view.
    /// </summary>
    public class NewWasteAddTool : ITroubleshooterTool
    {
        public string ToolName => "New waste ADD";

        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.ManifestDocNo))
            {
                MessageBox.Show("กรุณาป้อนค่า DocNo ในช่อง Manifest", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // Query from the new view 'Com_vwManifestWastAdd'
            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS [Select], 
                    MenifestID, DocNo, WasteDataID, WasteName, WasteNo, 
                    IsNewWaste, isPrinted, isCanceled, isClosed, JobID
                FROM Com_vwManifestWastAdd
                WHERE DocNo = @DocNo";

            return await TroubleshooterControl.DataAccess.GetDataTableAsync(query, new SqlParameter("@DocNo", parameters.ManifestDocNo));
        }

        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows)
        {
            var result = new ProcessResult();

            foreach (var row in selectedRows)
            {
                try
                {
                    string docNo = row["DocNo"].ToString();
                    string wasteDataId = row["WasteDataID"].ToString();

                    // Update the new view 'Com_vwManifestWastAdd'
                    string query = @"
                        UPDATE Com_vwManifestWastAdd
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
                    Console.WriteLine($"Error processing DocNo {row["DocNo"]} for NewWasteAddTool: {ex.Message}");
                }
            }

            result.Message = $"ดำเนินการเสร็จสิ้น\nสำเร็จ: {result.SuccessCount} รายการ\nผิดพลาด: {result.ErrorCount} รายการ";
            return result;
        }
    }
}
