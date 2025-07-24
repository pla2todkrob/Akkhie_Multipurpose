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
    /// Implements the logic for the "Unlock Quotation" button.
    /// </summary>
    public class UnlockQuotationTool : ITroubleshooterTool
    {
        public string ToolName => "ปลดล็อค Quotation";

        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.QuotationSource))
            {
                MessageBox.Show("กรุณาป้อน Quotation No. ในช่อง Quotation ต้นทาง", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS [Select],
                    QuotationID, 
                    QuotationNo,
                    isApproved 
                FROM tbQuotationHeader
                WHERE QuotationNo = @QuotationNo";

            return await TroubleshooterControl.DataAccess.GetDataTableAsync(query, new SqlParameter("@QuotationNo", parameters.QuotationSource));
        }

        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            var result = new ProcessResult();

            foreach (var row in selectedRows)
            {
                try
                {
                    string quotationNo = row["QuotationNo"].ToString();

                    string query = @"
                        UPDATE tbQuotationHeader 
                        SET isApproved = 'N' 
                        WHERE QuotationNo = @QuotationNo";

                    var sqlParameters = new[]
                    {
                        new SqlParameter("@QuotationNo", quotationNo)
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
                    Console.WriteLine($"Error processing QuotationNo {row["QuotationNo"]}: {ex.Message}");
                }
            }

            result.Message = $"ดำเนินการปลดล็อค Quotation เสร็จสิ้น\nสำเร็จ: {result.SuccessCount} รายการ\nผิดพลาด: {result.ErrorCount} รายการ";
            return result;
        }
    }
}
