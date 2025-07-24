using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose.Troubleshooter.Tools
{
    /// <summary>
    /// Implements the logic for the "Delete All Boxes" button.
    /// This tool connects to a separate database (BWG_BOX) to perform its operations.
    /// </summary>
    public class DeleteAllBoxesTool : ITroubleshooterTool
    {
        /// <summary>
        /// A dedicated data access class to handle connections to the BWG_BOX database.
        /// </summary>
        private static class BoxDataAccess
        {
            private static readonly string ConnectionString;

            static BoxDataAccess()
            {
                try
                {
                    var settings = ConfigurationManager.AppSettings;
                    var builder = new SqlConnectionStringBuilder
                    {
                        DataSource = settings["OdbcServer"],
                        // IMPORTANT: Reads the specific database key for the BOX database.
                        InitialCatalog = settings["OdbcDatabaseBox"],
                        UserID = settings["OdbcUid"],
                        Password = settings["OdbcPwd"],
                        ConnectTimeout = 15
                    };
                    ConnectionString = builder.ConnectionString;
                }
                catch (Exception)
                {
                    // Error is handled by the IsConnectionConfigured check.
                    ConnectionString = null;
                }
            }

            public static bool IsConnectionConfigured() => !string.IsNullOrEmpty(ConnectionString);

            public static async Task<DataTable> GetDataTableAsync(string query, params SqlParameter[] parameters)
            {
                var dt = new DataTable();
                if (!IsConnectionConfigured()) return dt;

                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    await conn.OpenAsync();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }

            public static async Task<int> ExecuteNonQueryAsync(string query, params SqlParameter[] parameters)
            {
                if (!IsConnectionConfigured()) return 0;

                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public string ToolName => "ลบ Box ทั้งหมด";

        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (!BoxDataAccess.IsConnectionConfigured())
            {
                MessageBox.Show("ไม่พบการตั้งค่าฐานข้อมูลสำหรับ BWG_BOX ใน App.config (OdbcDatabaseBox)", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS [Select],
                    [JobDataCarID],
                    [TruckSubTypeID],
                    [BoxType],
                    [BoxReservNumber]
                FROM [Box_BoxReserve]";

            return await BoxDataAccess.GetDataTableAsync(query);
        }

        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            var result = new ProcessResult();
            var selectedIds = selectedRows.Select(r => r["JobDataCarID"].ToString()).ToList();
            int totalRowCount = selectedRows.FirstOrDefault()?.Table.Rows.Count ?? 0;

            // Case 1: No rows are selected, or all rows are selected -> Delete all
            if (!selectedIds.Any() || selectedIds.Count == totalRowCount)
            {
                if (MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบข้อมูล **ทั้งหมด** ออกจากตาราง Box_BoxReserve?\n\nการกระทำนี้ไม่สามารถย้อนกลับได้", "ยืนยันการลบข้อมูลทั้งหมด", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return new ProcessResult { Message = "การดำเนินการถูกยกเลิก" };
                }

                try
                {
                    // Using TRUNCATE is more efficient for deleting all rows if permissions allow.
                    // Using DELETE as requested.
                    int rowsAffected = await BoxDataAccess.ExecuteNonQueryAsync("DELETE FROM [Box_BoxReserve]");
                    result.SuccessCount = rowsAffected;
                    result.Message = $"ลบข้อมูลทั้งหมด {rowsAffected} รายการเรียบร้อยแล้ว";
                }
                catch (Exception ex)
                {
                    result.ErrorCount = totalRowCount;
                    result.Message = $"เกิดข้อผิดพลาดในการลบข้อมูลทั้งหมด: {ex.Message}";
                }
            }
            // Case 2: Some rows are selected -> Delete only selected rows
            else
            {
                var deleteQuery = new StringBuilder("DELETE FROM [Box_BoxReserve] WHERE [JobDataCarID] IN (");
                var sqlParameters = new List<SqlParameter>();
                for (int i = 0; i < selectedIds.Count; i++)
                {
                    string paramName = $"@ID{i}";
                    deleteQuery.Append(paramName + ",");
                    sqlParameters.Add(new SqlParameter(paramName, selectedIds[i]));
                }
                deleteQuery.Length--; // Remove trailing comma
                deleteQuery.Append(")");

                try
                {
                    int rowsAffected = await BoxDataAccess.ExecuteNonQueryAsync(deleteQuery.ToString(), sqlParameters.ToArray());
                    result.SuccessCount = rowsAffected;
                    result.ErrorCount = selectedIds.Count - rowsAffected;
                }
                catch (Exception ex)
                {
                    result.ErrorCount = selectedIds.Count;
                    Console.WriteLine($"Error processing selective delete: {ex.Message}");
                }
                result.Message = $"ดำเนินการลบข้อมูลที่เลือกเสร็จสิ้น\nสำเร็จ: {result.SuccessCount} รายการ\nผิดพลาด: {result.ErrorCount} รายการ";
            }

            return result;
        }
    }
}
