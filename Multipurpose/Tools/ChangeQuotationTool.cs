using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose.Troubleshooter.Tools
{
    public class ChangeQuotationTool : ITroubleshooterTool
    {
        public string ToolName => "เปลี่ยนใบเสนอราคาในใบนำส่ง";

        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.QuotationSource))
            {
                MessageBox.Show("กรุณาระบุเลขที่ใบเสนอราคา (Quotation (ต้นทาง))", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }

            if (string.IsNullOrWhiteSpace(parameters.QuotationDestination))
            {
                MessageBox.Show("กรุณาระบุเลขที่ใบเสนอราคา (Quotation (ปลายทาง))", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }

            if (string.IsNullOrWhiteSpace(parameters.ManifestDocNo))
            {
                MessageBox.Show("กรุณาระบุเลขที่ใบนำส่ง (Manifest No.)", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }

            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS [Select], 
                    DocNo, 
                    WorkDate, 
                    QuotationID, 
                    QuotationNo, 
                    WasteNo, 
                    WasteName,
                    JobDetID, 
                    JobNo 
                FROM vw_MenifestQuotation 
                WHERE DocNo = @DocNo";

            var sqlParams = new SqlParameter("@DocNo", SqlDbType.NVarChar) { Value = parameters.ManifestDocNo };
            return await TroubleshooterControl.DataAccess.GetDataTableAsync(query,"กรุณาเลือกรายการทั้งหมดที่ต้องการเปลี่ยนใบเสนอราคา", sqlParams);
        }

        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            // --- 1. ตรวจสอบ Input ---
            var jobDetailIds = selectedRows?.Select(r => r.Field<string>("JobDetID")).ToList();
            if (jobDetailIds == null || !jobDetailIds.Any())
            {
                return new ProcessResult { Message = "กรุณาเลือกรายการที่ต้องการเปลี่ยนใบเสนอราคา" };
            }
            if (string.IsNullOrWhiteSpace(parameters.QuotationSource))
            {
                return new ProcessResult { Message = "กรุณาระบุ Quotation (ต้นทาง)" };
            }
            if (string.IsNullOrWhiteSpace(parameters.QuotationDestination))
            {
                return new ProcessResult { Message = "กรุณาระบุ Quotation (ปลายทาง)" };
            }
            if (string.IsNullOrWhiteSpace(parameters.ManifestDocNo))
            {
                return new ProcessResult { Message = "ไม่พบเลขที่ใบนำส่ง (Manifest No.)" };
            }

            try
            {
                // --- 2. ดึงข้อมูล Quotation ID ---
                var srcIdTable = await TroubleshooterControl.DataAccess.GetDataTableAsync("SELECT QuotationID FROM tbQuotationHeader WHERE QuotationNo = @QuotationNo","", new SqlParameter("@QuotationNo", parameters.QuotationSource));
                if (srcIdTable.Rows.Count == 0) throw new DataException($"ไม่พบ Quotation ต้นทาง: {parameters.QuotationSource}");
                var sourceQuotationId = srcIdTable.Rows[0]["QuotationID"].ToString();

                var destIdTable = await TroubleshooterControl.DataAccess.GetDataTableAsync("SELECT QuotationID FROM tbQuotationHeader WHERE QuotationNo = @QuotationNo","", new SqlParameter("@QuotationNo", parameters.QuotationDestination));
                if (destIdTable.Rows.Count == 0) throw new DataException($"ไม่พบ Quotation ปลายทาง: {parameters.QuotationDestination}");
                var destinationQuotationId = destIdTable.Rows[0]["QuotationID"].ToString();

                // --- 3. อัปเดต tbJobDataDetail ---
                string jobDetIdParams = string.Join(",", jobDetailIds.Select((id, i) => $"@id{i}"));
                var updateJobDetailQuery = $"UPDATE tbJobDataDetail SET QuotationID = @DestinationQuotationID WHERE JobDetID IN ({jobDetIdParams}) AND QuotationID = @SourceQuotationID";

                var jobDetailParams = new List<SqlParameter>
                {
                    new SqlParameter("@DestinationQuotationID", destinationQuotationId),
                    new SqlParameter("@SourceQuotationID", sourceQuotationId)
                };
                for (int i = 0; i < jobDetailIds.Count; i++)
                {
                    jobDetailParams.Add(new SqlParameter($"@id{i}", jobDetailIds[i]));
                }
                int updatedRows = await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(updateJobDetailQuery, jobDetailParams.ToArray());

                if (updatedRows != jobDetailIds.Count)
                {
                    throw new DataException($"อัปเดต Job Details ได้เพียง {updatedRows} จาก {jobDetailIds.Count} รายการที่เลือก อาจมีบางรายการถูกแก้ไขไปแล้ว การทำงานหยุดลง");
                }

                // --- 4. อัปเดต View Com_vwUpdate_Manifest_Quotation_Minweight_Price ---
                // *** แก้ไขตาม Logic ที่ถูกต้อง คือนำคอลัมน์ใน View มาอัปเดตซึ่งกันและกัน ***
                async Task UpdateManifestField(string destinationField, string sourceField)
                {
                    // หมายเหตุ: การสร้าง Query แบบนี้ปลอดภัยเมื่อชื่อคอลัมน์เป็นค่าคงที่และไม่ได้รับมาจาก User Input
                    string query = $"UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET {destinationField} = {sourceField} WHERE DocNo = @DocNo";
                    await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(query, new SqlParameter("@DocNo", parameters.ManifestDocNo));
                }

                await UpdateManifestField("TreatmentRate", "QTreatmentRate");
                await UpdateManifestField("TreatmentUnitID", "QTreatmentUnitID");
                await UpdateManifestField("TreatmentCharge", "QTreatmentRate");
                await UpdateManifestField("ManifestFee", "QTreatmentRate");
                await UpdateManifestField("MinWeightPerCar", "QMinWeight");
                await UpdateManifestField("TransportFee", "QTransportFee");
                await UpdateManifestField("TransferUnitID", "QTrasnferUnitID");
                await UpdateManifestField("TripTranFee", "QTransportFee");
                await UpdateManifestField("isPriceIncTrans", "QisPriceIncTransport");

                // --- 5. คืนค่าผลลัพธ์ ---
                return new ProcessResult
                {
                    SuccessCount = updatedRows,
                    Message = $"ดำเนินการสำเร็จ! เปลี่ยนใบเสนอราคาใน {updatedRows} รายการ และอัปเดตราคาในใบนำส่ง '{parameters.ManifestDocNo}' เรียบร้อยแล้ว"
                };
            }
            catch (Exception ex)
            {
                return new ProcessResult { ErrorCount = jobDetailIds.Count, Message = $"เกิดข้อผิดพลาด: {ex.Message}" };
            }
        }
    }
}
