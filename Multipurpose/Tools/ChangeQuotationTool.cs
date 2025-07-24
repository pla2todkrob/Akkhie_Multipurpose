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
    public class ChangeQuotationTool : ITroubleshooterTool
    {
        public string ToolName => "เปลี่ยนใบเสนอราคา";

        public async Task<DataTable> SearchAsync(ToolParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.ManifestDocNo))
            {
                MessageBox.Show("กรุณาระบุ Manifest No.", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }

            string query = @"
                SELECT 
                    CAST(0 AS BIT) AS Select, 
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
            return await TroubleshooterControl.DataAccess.GetDataTableAsync(query, sqlParams);
        }

        public async Task<ProcessResult> ProcessAsync(IEnumerable<DataRow> selectedRows, ToolParameters parameters)
        {
            // --- Validation ---
            if (string.IsNullOrWhiteSpace(parameters.QuotationSource))
                return new ProcessResult(false, "กรุณาระบุ Quotation (ต้นทาง)");
            if (string.IsNullOrWhiteSpace(parameters.QuotationDestination))
                return new ProcessResult(false, "กรุณาระบุ Quotation (ปลายทาง)");

            var jobDetailIds = selectedRows.Select(r => r.Field<int>("JobDetID")).ToList();
            if (!jobDetailIds.Any())
                return new ProcessResult(false, "กรุณาเลือกรายการที่ต้องการเปลี่ยนใบเสนอราคา");

            try
            {
                // --- Get Source Quotation ID ---
                var srcIdTable = await TroubleshooterControl.DataAccess.GetDataTableAsync("SELECT QuotationID FROM tbQuotationHeader WHERE QuotationNo = @QuotationNo", new SqlParameter("@QuotationNo", parameters.QuotationSource));
                if (srcIdTable.Rows.Count == 0)
                    return new ProcessResult(false, $"ไม่พบ Quotation ต้นทาง: {parameters.QuotationSource}");
                var sourceQuotationId = srcIdTable.Rows[0]["QuotationID"].ToString();

                // --- Get Destination Quotation Header and Details ---
                var destQuotationQuery = @"
                    SELECT 
                        h.QuotationID, 
                        d.TreatmentRate AS QTreatmentRate,
                        d.TreatmentUnitID AS QTreatmentUnitID,
                        d.MinWeight AS QMinWeight,
                        d.TransportFee AS QTransportFee,
                        d.TrasnferUnitID AS QTrasnferUnitID,
                        d.isPriceIncTransport AS QisPriceIncTransport
                    FROM tbQuotationHeader h
                    JOIN tbQuotationDetail d ON h.QuotationID = d.QuotationID
                    WHERE h.QuotationNo = @QuotationNo";

                var destQuotationTable = await TroubleshooterControl.DataAccess.GetDataTableAsync(destQuotationQuery, new SqlParameter("@QuotationNo", parameters.QuotationDestination));
                if (destQuotationTable.Rows.Count == 0)
                    return new ProcessResult(false, $"ไม่พบข้อมูล Detail ใน Quotation ปลายทาง: {parameters.QuotationDestination}");

                var destinationQuotationId = destQuotationTable.Rows[0]["QuotationID"].ToString();
                var destQuotationDetails = destQuotationTable.Rows[0];

                // --- Step 1: Update tbJobDataDetail (Single command) ---
                var idPlaceholders = string.Join(",", jobDetailIds.Select((_, i) => $"@id{i}"));
                var updateJobDetailQuery = $"UPDATE tbJobDataDetail SET QuotationID = @DestinationQuotationID WHERE JobDetID IN ({idPlaceholders}) AND QuotationID = @SourceQuotationID";

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

                // --- Step 2: Update Com_vwUpdate_Manifest_Quotation_Minweight_Price (9 separate commands) ---

                // Command 1: TreatmentRate
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET TreatmentRate = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QTreatmentRate"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 2: TreatmentUnitID
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET TreatmentUnitID = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QTreatmentUnitID"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 3: TreatmentCharge
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET TreatmentCharge = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QTreatmentRate"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 4: ManifestFee
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET ManifestFee = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QTreatmentRate"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 5: MinWeightPerCar
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET MinWeightPerCar = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QMinWeight"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 6: TransportFee
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET TransportFee = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QTransportFee"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 7: TransferUnitID
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET TransferUnitID = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QTrasnferUnitID"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 8: TripTranFee
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET TripTranFee = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QTransportFee"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));

                // Command 9: isPriceIncTrans
                await TroubleshooterControl.DataAccess.ExecuteNonQueryAsync(
                    "UPDATE Com_vwUpdate_Manifest_Quotation_Minweight_Price SET isPriceIncTrans = @Value WHERE DocNo = @DocNo",
                    new SqlParameter("@Value", destQuotationDetails["QisPriceIncTransport"]), new SqlParameter("@DocNo", parameters.ManifestDocNo));


                return new ProcessResult(true, $"ดำเนินการเปลี่ยนใบเสนอราคาสำเร็จ {updatedRows} รายการ และอัปเดตข้อมูลราคาใน Manifest เรียบร้อยแล้ว");
            }
            catch (Exception ex)
            {
                return new ProcessResult(false, $"เกิดข้อผิดพลาดระหว่างดำเนินการ: {ex.Message}");
            }
        }
    }
}
