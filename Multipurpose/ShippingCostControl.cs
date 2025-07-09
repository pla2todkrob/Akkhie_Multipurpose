using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose
{
    public partial class ShippingCostControl : UserControl
    {
        #region Data Access Helper Class
        private static class DataAccess
        {
            private static readonly string ConnectionString;

            static DataAccess()
            {
                try
                {
                    var settings = ConfigurationManager.AppSettings;
                    var builder = new SqlConnectionStringBuilder
                    {
                        DataSource = settings["OdbcServer"],
                        InitialCatalog = settings["OdbcDatabase"],
                        UserID = settings["OdbcUid"],
                        Password = settings["OdbcPwd"],
                        ConnectTimeout = 15
                    };
                    ConnectionString = builder.ConnectionString;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ไม่สามารถสร้าง Connection String ได้จาก App.config: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
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
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }

            /// <summary>
            /// Executes a stored procedure that returns a single value.
            /// </summary>
            /// <param name="storedProcedureName">The name of the stored procedure to execute.</param>
            /// <returns>The single value returned by the stored procedure.</returns>
            public static async Task<object> GetScalarFromStoredProcedureAsync(string storedProcedureName)
            {
                if (!IsConnectionConfigured()) return null;

                using (var conn = new SqlConnection(ConnectionString))
                using (var cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    return await cmd.ExecuteScalarAsync();
                }
            }


            public static SqlConnection GetConnection()
            {
                if (!IsConnectionConfigured()) return null;
                return new SqlConnection(ConnectionString);
            }
        }
        #endregion

        #region DTOs and Local Data Cache
        private class Province { public string ID { get; set; } public string Name { get; set; } }
        private class Aumphur { public string ID { get; set; } public string Name { get; set; } public string ProvinceID { get; set; } }
        private class Tumbol { public string ID { get; set; } public string Name { get; set; } public string AumphurID { get; set; } }
        private class TruckType { public string ID { get; set; } public string Description { get; set; } }

        private List<Province> _provinces = new List<Province>();
        private List<Aumphur> _aumphurs = new List<Aumphur>();
        private List<Tumbol> _tumbols = new List<Tumbol>();
        private List<TruckType> _truckTypes = new List<TruckType>();

        private string _selectedAreaRateId = null;
        private string _selectedRouteRateId = null;
        #endregion

        public ShippingCostControl()
        {
            InitializeComponent();
            this.Load += ShippingCostControl_Load;
        }

        private async void ShippingCostControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            if (!DataAccess.IsConnectionConfigured())
            {
                this.Enabled = false;
                return;
            }

            await LoadInitialDataAsync();
            AssignEventHandlers();
            ResetAreaTab();
            ResetRouteTab();
        }

        private void AssignEventHandlers()
        {
            // Area Rate Tab
            cboAreaProvince.SelectedIndexChanged += cboAreaProvince_SelectedIndexChanged;
            cboAreaAumphur.SelectedIndexChanged += cboAreaAumphur_SelectedIndexChanged;
            cboAreaTruckType.SelectedIndexChanged += async (s, e) => await DisplayAreaRatesAsync();
            linkAreaSelectAll.LinkClicked += (s, e) => SelectAllTumbols(true);
            linkAreaUnselectAll.LinkClicked += (s, e) => SelectAllTumbols(false);
            btnAreaSave.Click += btnAreaSave_Click;
            btnAreaDelete.Click += btnAreaDelete_Click;
            dgvAreaRate.SelectionChanged += dgvAreaRate_SelectionChanged;

            // Route Rate Tab
            cboRouteFromProvince.SelectedIndexChanged += cboRouteFromProvince_SelectedIndexChanged;
            cboRouteToProvince.SelectedIndexChanged += cboRouteToProvince_SelectedIndexChanged;
            cboRouteFromAumphur.SelectedIndexChanged += async (s, e) => await DisplayRouteRatesAsync();
            cboRouteToAumphur.SelectedIndexChanged += async (s, e) => await DisplayRouteRatesAsync();
            cboRouteTruckType.SelectedIndexChanged += async (s, e) => await DisplayRouteRatesAsync();
            btnRouteSave.Click += btnRouteSave_Click;
            btnRouteDelete.Click += btnRouteDelete_Click;
            dgvRouteRate.SelectionChanged += dgvRouteRate_SelectionChanged;
        }

        #region Initial Data Loading
        private async Task LoadInitialDataAsync()
        {
            try
            {
                _provinces = (await DataAccess.GetDataTableAsync("SELECT ProvinceID, ProvinceName FROM tbProvince WHERE isDeleted = 'N' ORDER BY ProvinceName"))
                    .AsEnumerable().Select(r => new Province { ID = r.Field<string>("ProvinceID"), Name = r.Field<string>("ProvinceName") }).ToList();

                _aumphurs = (await DataAccess.GetDataTableAsync("SELECT AumphurID, AumphurName, ProvinceID FROM tbAumphur ORDER BY AumphurName"))
                    .AsEnumerable().Select(r => new Aumphur { ID = r.Field<string>("AumphurID"), Name = r.Field<string>("AumphurName"), ProvinceID = r.Field<string>("ProvinceID") }).ToList();

                _tumbols = (await DataAccess.GetDataTableAsync("SELECT TumbolID, TumbolName, AumphurID FROM tbTumbol ORDER BY TumbolName"))
                    .AsEnumerable().Select(r => new Tumbol { ID = r.Field<string>("TumbolID"), Name = r.Field<string>("TumbolName"), AumphurID = r.Field<string>("AumphurID") }).ToList();

                _truckTypes = (await DataAccess.GetDataTableAsync("SELECT TruckTypeID, TruckTypeDesc FROM tbTruckType WHERE isActive = 'Y' ORDER BY TruckTypeDesc"))
                    .AsEnumerable().Select(r => new TruckType { ID = r.Field<string>("TruckTypeID"), Description = r.Field<string>("TruckTypeDesc") }).ToList();

                // --- Populate ComboBoxes ---
                PopulateComboBox(cboAreaProvince, _provinces, "Name", "ID");

                PopulateComboBox(cboRouteFromProvince, new List<Province>(_provinces), "Name", "ID");
                PopulateComboBox(cboRouteToProvince, new List<Province>(_provinces), "Name", "ID");
                PopulateComboBox(cboAreaTruckType, new List<TruckType>(_truckTypes), "Description", "ID");
                PopulateComboBox(cboRouteTruckType, new List<TruckType>(_truckTypes), "Description", "ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการโหลดข้อมูลเริ่มต้น: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateComboBox(ComboBox cbo, object dataSource, string displayMember, string valueMember)
        {
            cbo.DataSource = dataSource;
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
            cbo.SelectedIndex = -1;
        }
        #endregion

        #region Area Rate Tab Logic

        private void ResetAreaTab()
        {
            cboAreaProvince.SelectedIndex = -1;
            cboAreaAumphur.DataSource = null;
            cboAreaTruckType.SelectedIndex = -1;
            clbAreaTumbol.DataSource = null;
            clbAreaTumbol.Items.Clear();
            numAreaRate.Value = 0;
            dgvAreaRate.DataSource = null;
            btnAreaSave.Text = "บันทึก";
            _selectedAreaRateId = null;
        }

        private void cboAreaProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAreaProvince.SelectedValue is string provinceId)
            {
                var filteredAumphurs = _aumphurs.Where(a => a.ProvinceID == provinceId).ToList();
                PopulateComboBox(cboAreaAumphur, filteredAumphurs, "Name", "ID");
            }
            else { cboAreaAumphur.DataSource = null; }
            clbAreaTumbol.Items.Clear();
        }

        private async void cboAreaAumphur_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbAreaTumbol.DataSource = null;
            clbAreaTumbol.Items.Clear();
            if (cboAreaAumphur.SelectedValue is string aumphurId)
            {
                var filteredTumbols = _tumbols.Where(t => t.AumphurID == aumphurId).ToList();
                clbAreaTumbol.DataSource = filteredTumbols;
                clbAreaTumbol.DisplayMember = "Name";
                clbAreaTumbol.ValueMember = "ID";
            }
            await DisplayAreaRatesAsync();
        }

        private void SelectAllTumbols(bool isSelected)
        {
            for (int i = 0; i < clbAreaTumbol.Items.Count; i++)
                clbAreaTumbol.SetItemChecked(i, isSelected);
        }

        private async Task DisplayAreaRatesAsync()
        {
            if (cboAreaAumphur.SelectedValue == null || cboAreaTruckType.SelectedValue == null)
            {
                dgvAreaRate.DataSource = null;
                return;
            }

            try
            {
                string query = @"
                    SELECT r.TruckRateID, t.TumbolName, r.Rate 
                    FROM tbTruckRate r
                    JOIN tbTumbol t ON r.TumbolID = t.TumbolID
                    WHERE t.AumphurID = @AumphurID AND r.TruckTypeID = @TruckTypeID
                    ORDER BY t.TumbolName";
                var dt = await DataAccess.GetDataTableAsync(query,
                    new SqlParameter("@AumphurID", cboAreaAumphur.SelectedValue),
                    new SqlParameter("@TruckTypeID", cboAreaTruckType.SelectedValue));
                dgvAreaRate.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการแสดงข้อมูล: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAreaRate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAreaRate.CurrentRow == null || dgvAreaRate.CurrentRow.DataBoundItem == null) return;

            var row = (dgvAreaRate.CurrentRow.DataBoundItem as DataRowView).Row;
            _selectedAreaRateId = row["TruckRateID"].ToString();
            numAreaRate.Value = Convert.ToDecimal(row["Rate"]);
            btnAreaSave.Text = "อัปเดต";
            btnAreaDelete.Enabled = true;
        }

        private async void btnAreaSave_Click(object sender, EventArgs e)
        {
            if (cboAreaTruckType.SelectedValue == null)
            {
                MessageBox.Show("กรุณาเลือกประเภทรถ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTumbols = clbAreaTumbol.CheckedItems.Cast<Tumbol>().ToList();
            if (!selectedTumbols.Any())
            {
                if (MessageBox.Show("คุณไม่ได้เลือกตำบลใดๆ ระบบจะกำหนดค่าขนส่งนี้ให้กับ 'ทุกตำบล' ในอำเภอที่เลือก ยืนยันหรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    selectedTumbols = clbAreaTumbol.Items.Cast<Tumbol>().ToList();
                }
                else return;
            }

            using (var conn = DataAccess.GetConnection())
            {
                await conn.OpenAsync();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var tumbol in selectedTumbols)
                        {
                            SqlCommand cmd = new SqlCommand
                            {
                                Connection = conn,
                                Transaction = transaction
                            };
                            cmd.Parameters.AddWithValue("@TruckTypeID", cboAreaTruckType.SelectedValue);
                            cmd.Parameters.AddWithValue("@TumbolID", tumbol.ID);
                            cmd.Parameters.AddWithValue("@Rate", numAreaRate.Value);

                            cmd.CommandText = "UPDATE tbTruckRate SET Rate = @Rate WHERE TruckTypeID = @TruckTypeID AND TumbolID = @TumbolID";
                            int rowsAffected = await cmd.ExecuteNonQueryAsync();
                            if (rowsAffected == 0)
                            {
                                // If no record was updated, insert a new one.
                                cmd.CommandText = "INSERT INTO tbTruckRate (TruckRateID, TruckTypeID, TumbolID, Rate) VALUES (@TruckRateID, @TruckTypeID, @TumbolID, @Rate)";

                                // *** MODIFIED: Call Stored Procedure to get new ID ***
                                object newIdResult;
                                using (var spCmd = new SqlCommand("sp_GetID", conn, transaction))
                                {
                                    spCmd.CommandType = CommandType.StoredProcedure;
                                    newIdResult = await spCmd.ExecuteScalarAsync();
                                }

                                if (newIdResult == null || newIdResult.ToString().Equals("Error", StringComparison.OrdinalIgnoreCase))
                                {
                                    throw new Exception("ไม่สามารถสร้าง ID ใหม่จากฐานข้อมูลได้");
                                }
                                string newTruckRateID = newIdResult.ToString();
                                cmd.Parameters.AddWithValue("@TruckRateID", newTruckRateID);
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show($"บันทึกค่าขนส่งสำหรับ {selectedTumbols.Count} ตำบลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"เกิดข้อผิดพลาดในการบันทึก: {ex.Message}", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            await DisplayAreaRatesAsync();
        }

        private async void btnAreaDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedAreaRateId))
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการลบจากตาราง", "ไม่ได้เลือกรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบรายการนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await DataAccess.ExecuteNonQueryAsync("DELETE FROM tbTruckRate WHERE TruckRateID = @ID", new SqlParameter("@ID", _selectedAreaRateId));
                    MessageBox.Show("ลบรายการเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await DisplayAreaRatesAsync();
                    ResetAreaTab();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"เกิดข้อผิดพลาดในการลบ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Route Rate Tab Logic
        private void ResetRouteTab()
        {
            cboRouteFromProvince.SelectedIndex = -1;
            cboRouteFromAumphur.DataSource = null;
            cboRouteToProvince.SelectedIndex = -1;
            cboRouteToAumphur.DataSource = null;
            cboRouteTruckType.SelectedIndex = -1;
            numRouteTripRate.Value = 0;
            numRouteTrailerRate.Value = 0;
            dtpRouteStartDate.Value = DateTime.Now;
            dtpRouteEndDate.Value = DateTime.Now.AddYears(1);
            dgvRouteRate.DataSource = null;
            btnRouteSave.Text = "บันทึก";
            _selectedRouteRateId = null;
            btnRouteDelete.Enabled = false;
        }

        private void cboRouteFromProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRouteFromProvince.SelectedValue is string provinceId)
            {
                var filteredAumphurs = _aumphurs.Where(a => a.ProvinceID == provinceId).ToList();
                PopulateComboBox(cboRouteFromAumphur, filteredAumphurs, "Name", "ID");
            }
            else { cboRouteFromAumphur.DataSource = null; }
        }

        private void cboRouteToProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRouteToProvince.SelectedValue is string provinceId)
            {
                var filteredAumphurs = _aumphurs.Where(a => a.ProvinceID == provinceId).ToList();
                PopulateComboBox(cboRouteToAumphur, filteredAumphurs, "Name", "ID");
            }
            else { cboRouteToAumphur.DataSource = null; }
        }

        private async Task DisplayRouteRatesAsync()
        {
            if (cboRouteFromAumphur.SelectedValue == null || cboRouteToAumphur.SelectedValue == null || cboRouteTruckType.SelectedValue == null)
            {
                dgvRouteRate.DataSource = null;
                return;
            }
            try
            {
                // CORRECTED: Using CarTypeID in the WHERE clause as per the schema
                string query = "SELECT * FROM tbTransChargeRate2 WHERE FromAumphurID = @FromID AND ToAumphurID = @ToID AND CarTypeID = @CarTypeID ORDER BY StartDate DESC";
                var dt = await DataAccess.GetDataTableAsync(query,
                    new SqlParameter("@FromID", cboRouteFromAumphur.SelectedValue),
                    new SqlParameter("@ToID", cboRouteToAumphur.SelectedValue),
                    new SqlParameter("@CarTypeID", cboRouteTruckType.SelectedValue)); // Pass TruckTypeID to the parameter named @CarTypeID
                dgvRouteRate.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการแสดงข้อมูล: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRouteRate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRouteRate.CurrentRow == null || dgvRouteRate.CurrentRow.DataBoundItem == null) return;

            var row = (dgvRouteRate.CurrentRow.DataBoundItem as DataRowView).Row;
            _selectedRouteRateId = row["ChargeRateID"].ToString();
            numRouteTripRate.Value = row.Field<decimal?>("CustRatePerTrip") ?? 0;
            numRouteTrailerRate.Value = row.Field<decimal?>("TrailerCustRateTrip") ?? 0;

            if (DateTime.TryParseExact(row["StartDate"].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
            {
                if (startDate >= dtpRouteStartDate.MinDate && startDate <= dtpRouteStartDate.MaxDate)
                {
                    dtpRouteStartDate.Value = startDate;
                }
            }

            if (DateTime.TryParseExact(row["EndDate"].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
            {
                if (endDate >= dtpRouteEndDate.MaxDate)
                {
                    dtpRouteEndDate.Value = dtpRouteEndDate.MaxDate;
                }
                else if (endDate <= dtpRouteEndDate.MinDate)
                {
                    dtpRouteEndDate.Value = dtpRouteEndDate.MinDate;
                }
                else
                {
                    dtpRouteEndDate.Value = endDate;
                }
            }

            btnRouteSave.Text = "อัปเดต";
            btnRouteDelete.Enabled = true;
        }

        private async void btnRouteSave_Click(object sender, EventArgs e)
        {
            if (cboRouteFromAumphur.SelectedValue == null || cboRouteToAumphur.SelectedValue == null || cboRouteTruckType.SelectedValue == null)
            {
                MessageBox.Show("กรุณาเลือกเส้นทางและประเภทรถให้ครบถ้วน", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query;
                var parameters = new List<SqlParameter>
                {
                    // CORRECTED: The parameter name is @CarTypeID to match the column in tbTransChargeRate2
                    new SqlParameter("@CarTypeID", cboRouteTruckType.SelectedValue),
                    new SqlParameter("@FromAumphurID", cboRouteFromAumphur.SelectedValue),
                    new SqlParameter("@ToAumphurID", cboRouteToAumphur.SelectedValue),
                    new SqlParameter("@CustRatePerTrip", numRouteTripRate.Value),
                    new SqlParameter("@TrailerCustRateTrip", numRouteTrailerRate.Value),
                    new SqlParameter("@StartDate", dtpRouteStartDate.Value.ToString("yyyy/MM/dd")),
                    new SqlParameter("@EndDate", dtpRouteEndDate.Value.ToString("yyyy/MM/dd"))
                };

                if (string.IsNullOrEmpty(_selectedRouteRateId)) // INSERT
                {
                    // *** MODIFIED: Call Stored Procedure to get new ID ***
                    query = @"INSERT INTO tbTransChargeRate2 (ChargeRateID, CarTypeID, FromAumphurID, ToAumphurID, CustRatePerTrip, TrailerCustRateTrip, StartDate, EndDate)
                              VALUES (@ChargeRateID, @CarTypeID, @FromAumphurID, @ToAumphurID, @CustRatePerTrip, @TrailerCustRateTrip, @StartDate, @EndDate)";

                    object newIdResult = await DataAccess.GetScalarFromStoredProcedureAsync("sp_GetID");
                    if (newIdResult == null || newIdResult.ToString().Equals("Error", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("ไม่สามารถสร้าง ID ใหม่จากฐานข้อมูลได้", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string newChargeRateID = newIdResult.ToString();
                    parameters.Add(new SqlParameter("@ChargeRateID", newChargeRateID));
                }
                else // UPDATE
                {
                    // CORRECTED: Using CarTypeID in the UPDATE statement
                    query = @"UPDATE tbTransChargeRate2 SET 
                                CarTypeID = @CarTypeID, FromAumphurID = @FromAumphurID, ToAumphurID = @ToAumphurID, 
                                CustRatePerTrip = @CustRatePerTrip, TrailerCustRateTrip = @TrailerCustRateTrip, 
                                StartDate = @StartDate, EndDate = @EndDate 
                              WHERE ChargeRateID = @ChargeRateID";
                    parameters.Add(new SqlParameter("@ChargeRateID", _selectedRouteRateId));
                }

                await DataAccess.ExecuteNonQueryAsync(query, parameters.ToArray());
                MessageBox.Show("บันทึกค่าขนส่งตามเส้นทางเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await DisplayRouteRatesAsync();
                ResetRouteTab();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการบันทึก: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRouteDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedRouteRateId))
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการลบจากตาราง", "ไม่ได้เลือกรายการ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบรายการนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await DataAccess.ExecuteNonQueryAsync("DELETE FROM tbTransChargeRate2 WHERE ChargeRateID = @ID", new SqlParameter("@ID", _selectedRouteRateId));
                    MessageBox.Show("ลบรายการเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await DisplayRouteRatesAsync();
                    ResetRouteTab();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"เกิดข้อผิดพลาดในการลบ: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
