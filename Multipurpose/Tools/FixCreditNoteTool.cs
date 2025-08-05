using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// เครื่องมือสำหรับแก้ไขสถานะของใบลดหนี้ (Credit Note) ที่ไม่แสดงผล
    /// โดยจะค้นหาจากเลขที่เอกสาร และอัปเดตสถานะในตาราง tbAdjustDeptHeader
    /// </summary>
    public class FixCreditNoteTool : ITroubleshooterTool
    {
        public string ToolName => "แก้ไขใบลดหนี้ไม่แสดง";

        /// <summary>
        /// ค้นหาข้อมูลใบลดหนี้จากเลขที่เอกสาร
        /// </summary>
        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            // ใช้ txtManifest (ที่เปลี่ยนป้ายกำกับเป็น 'เลขที่เอกสาร') ในการรับ Input
            if (string.IsNullOrWhiteSpace(parameters.CreditNoteNo))
            {
                MessageBox.Show("กรุณาระบุเลขที่ใบลดหนี้ในช่อง 'เลขที่เอกสาร'", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS [Select],
                    AdjustID, 
                    IssuedDate,
                    AdjustBillNo, 
                    CustomerName,
                    ProvinceName,
                    AumphurName,
                    TumbolName,
                    AdjReason 
                FROM vw_AdjDeptHeaderSearch
                WHERE AdjustBillNo = @AdjustBillNo";

            var sqlParams = new SqlParameter("@AdjustBillNo", parameters.CreditNoteNo);
            DataTable dt = await TroubleshooterControl.DataAccess.GetDataTableAsync(query, "กรุณาเลือกรายการที่ต้องการแก้ไข", sqlParams);
            return dt;
        }

        /// <summary>
        /// ประมวลผลรายการที่เลือก โดยการอัปเดต Status เป็น 'N'
        /// </summary>
        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            if (selectedRows == null || !selectedRows.Any())
            {
                return new ProcessResult { Message = "ไม่ได้เลือกรายการใดๆ" };
            }

            int successCount = 0;
            int errorCount = 0;
            var errors = new StringBuilder();

            foreach (var row in selectedRows)
            {
                try
                {
                    // ดึงค่า AdjustID จากแถวที่เลือก
                    var adjustId = row["AdjustID"].ToString();
                    if (string.IsNullOrEmpty(adjustId))
                    {
                        errors.AppendLine("ไม่พบ AdjustID ในแถวที่เลือก");
                        errorCount++;
                        continue;
                    }

                    string query = "UPDATE tbAdjustDeptHeader SET Status = 'N' WHERE AdjustID = @AdjustID";
                    var sqlParams = new SqlParameter("@AdjustID", adjustId);

                    int affectedRows = await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(query, sqlParams);
                    if (affectedRows > 0)
                    {
                        successCount++;
                    }
                    else
                    {
                        errors.AppendLine($"ไม่สามารถอัปเดตใบลดหนี้ AdjustID: {adjustId}");
                        errorCount++;
                    }
                }
                catch (Exception ex)
                {
                    errors.AppendLine($"เกิดข้อผิดพลาดในการประมวลผล: {ex.Message}");
                    errorCount++;
                }
            }

            string finalMessage = $"ดำเนินการเสร็จสิ้น อัปเดตสำเร็จ {successCount} รายการ";
            if (errors.Length > 0)
            {
                finalMessage += $"\nพบข้อผิดพลาด {errorCount} รายการ:\n" + errors.ToString();
            }

            return new ProcessResult
            {
                SuccessCount = successCount,
                ErrorCount = errorCount,
                Message = finalMessage
            };
        }
    }
}
