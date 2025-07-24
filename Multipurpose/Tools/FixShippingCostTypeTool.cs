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
    /// Implements the logic for the "Fix Shipping Cost Type" button.
    /// </summary>
    public class FixShippingCostTypeTool : ITroubleshooterTool
    {
        public string ToolName => "แก้ไขค่าขนส่งตามประเภทรถ";

        /// <summary>
        /// Searches for manifest details that have mismatched truck types and transport fees.
        /// </summary>
        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.ManifestDocNo))
            {
                MessageBox.Show("กรุณาป้อนค่า DocNo ในช่อง Manifest", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // The query joins multiple tables to find the correct rate (e.Rate) and compares it with the existing one.
            // Aliases are used to differentiate between the current and correct values.
            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS [Select],
                    a.WasteName,
                    a.TruckTypeID AS CurrentTruckTypeID,
                    a.TruckTypeDesc AS CurrentTruckTypeDesc,
                    a.TransportFee AS CurrentTransportFee,
                    e.TruckTypeID AS CorrectTruckTypeID,
                    e.Rate AS CorrectRate,
                    a.DocNo,
                    a.MenifestID
                FROM vw_MenifestDetail a
                JOIN tbJobDataDetail b ON a.JobDetID = b.JobDetID
                JOIN tbJobDataCarUsed c ON b.JobID = c.JobID
                JOIN tbTruckSubType d ON c.TruckSubTypeID = d.SubTypeID
                JOIN vw_QuotationTruckRateSearch e ON b.QuotationID = e.QuotationID AND d.TruckTypeID = e.TruckTypeID
                WHERE a.DocNo = @DocNo";

            return await TroubleshooterControl.DataAccess.GetDataTableAsync(query, new SqlParameter("@DocNo", parameters.ManifestDocNo));
        }

        /// <summary>
        /// Processes the selected rows to update all items in the manifest with the correct fee and truck type.
        /// </summary>
        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            var result = new ProcessResult();

            // The user must select exactly one row to serve as the master record for correction.
            if (selectedRows.Count() != 1)
            {
                MessageBox.Show("กรุณาเลือกรายการที่ถูกต้องเพียง 1 รายการเท่านั้น เพื่อใช้เป็นข้อมูลอ้างอิงในการอัปเดต", "เลือกรายการไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result.Message = "การดำเนินการถูกยกเลิกโดยผู้ใช้";
                return result;
            }

            var masterRow = selectedRows.First();

            try
            {
                // Extract the correct data from the selected master row.
                string docNo = masterRow["DocNo"].ToString();
                string correctTruckTypeId = masterRow["CorrectTruckTypeID"].ToString();
                decimal correctRate = Convert.ToDecimal(masterRow["CorrectRate"]);

                // Prepare the UPDATE statement to correct all items in the manifest.
                string query = @"
                    UPDATE vw_MenifestDetail
                    SET 
                        TransportFee = @CorrectRate,
                        TruckTypeID = @CorrectTruckTypeID
                    WHERE DocNo = @DocNo";

                var sqlParameters = new[]
                {
                    new SqlParameter("@CorrectRate", correctRate),
                    new SqlParameter("@CorrectTruckTypeID", correctTruckTypeId),
                    new SqlParameter("@DocNo", docNo)
                };

                // Execute the update query.
                int rowsAffected = await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(query, sqlParameters);

                result.SuccessCount = rowsAffected;
                result.Message = $"ดำเนินการอัปเดตค่าขนส่งสำหรับเอกสาร {docNo} เสร็จสิ้น\nอัปเดตทั้งหมด: {rowsAffected} รายการ";
            }
            catch (Exception ex)
            {
                result.ErrorCount = 1; // Indicate that the entire operation failed.
                result.Message = $"เกิดข้อผิดพลาดในการอัปเดตข้อมูล: {ex.Message}";
                // For debugging purposes, you might want to log the full exception.
                Console.WriteLine($"Error processing manifest {masterRow["DocNo"]}: {ex.ToString()}");
            }

            return result;
        }
    }
}
