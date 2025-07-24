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
    /// Implements the logic for the "Set New Customer" button.
    /// This tool marks a job as a 'New Customer Job'.
    /// </summary>
    public class ChangeToNewCustomerTool : ITroubleshooterTool
    {
        public string ToolName => "กำหนดลูกค้าใหม่";

        /// <summary>
        /// Searches for manifest details using Job No or Manifest No.
        /// </summary>
        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.JobNo) && string.IsNullOrWhiteSpace(parameters.ManifestDocNo))
            {
                MessageBox.Show("กรุณาป้อน Job No หรือ Manifest No เพื่อค้นหา", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }

            var queryBuilder = new StringBuilder("SELECT CAST(0 AS BIT) AS [Select], JobNo, DocNo, CustomerCode, CompanyName, WasteNo, WasteName, QuotationNo, TruckTypeDesc, TransportFee, WorkDate, JobID FROM vw_MenifestDetailSearch WHERE 1=1");
            var sqlParams = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(parameters.JobNo))
            {
                queryBuilder.Append(" AND JobNo = @JobNo");
                sqlParams.Add(new SqlParameter("@JobNo", parameters.JobNo));
            }

            if (!string.IsNullOrWhiteSpace(parameters.ManifestDocNo))
            {
                queryBuilder.Append(" AND DocNo = @DocNo");
                sqlParams.Add(new SqlParameter("@DocNo", parameters.ManifestDocNo));
            }

            return await TroubleshooterControl.DataAccess.GetDataTableAsync(queryBuilder.ToString(),"กรุณาเลือกรายการที่ต้องการติ๊กลูกค้าใหม่", sqlParams.ToArray());
        }

        /// <summary>
        /// Processes the selected rows to update the NewCustJob flag.
        /// </summary>
        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            var result = new ProcessResult();
            var jobIdsToUpdate = selectedRows.Select(r => r["JobID"].ToString()).Distinct().ToList();

            if (!jobIdsToUpdate.Any())
            {
                result.Message = "ไม่ได้เลือกรายการใดๆ";
                return result;
            }

            string query = "UPDATE tbJobDataCarUsed SET NewCustJob = 'Y' WHERE JobID = @JobID";

            foreach (var jobId in jobIdsToUpdate)
            {
                try
                {
                    int rowsAffected = await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(query, new SqlParameter("@JobID", jobId));
                    if (rowsAffected > 0)
                    {
                        result.SuccessCount++;
                    }
                }
                catch (Exception ex)
                {
                    result.ErrorCount++;
                    // Optionally log the error for debugging
                    Console.WriteLine($"Failed to update JobID {jobId}: {ex.Message}");
                }
            }

            result.Message = $"กำหนดลูกค้าใหม่เสร็จสิ้น\nสำเร็จ: {result.SuccessCount} รายการ\nล้มเหลว: {result.ErrorCount} รายการ";
            return result;
        }
    }
}