namespace Multipurpose
{
    partial class ShippingCostControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabRateByArea = new System.Windows.Forms.TabPage();
            this.tlpAreaRateMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpAreaFilters = new System.Windows.Forms.GroupBox();
            this.cboAreaTruckType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAreaAumphur = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAreaProvince = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpAreaTumbol = new System.Windows.Forms.GroupBox();
            this.tlpTumbolSelection = new System.Windows.Forms.TableLayoutPanel();
            this.flpTumbolLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.linkAreaUnselectAll = new System.Windows.Forms.LinkLabel();
            this.linkAreaSelectAll = new System.Windows.Forms.LinkLabel();
            this.clbAreaTumbol = new System.Windows.Forms.CheckedListBox();
            this.grpAreaRateInput = new System.Windows.Forms.GroupBox();
            this.btnAreaDelete = new System.Windows.Forms.Button();
            this.btnAreaSave = new System.Windows.Forms.Button();
            this.numAreaRate = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvAreaRate = new System.Windows.Forms.DataGridView();
            this.tabRateByRoute = new System.Windows.Forms.TabPage();
            this.tlpRouteRateMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpRouteFilters = new System.Windows.Forms.GroupBox();
            this.cboRouteTruckType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboRouteToAumphur = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboRouteToProvince = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboRouteFromAumphur = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRouteFromProvince = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpRouteRateInput = new System.Windows.Forms.GroupBox();
            this.dtpRouteEndDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpRouteStartDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.numRouteTrailerRate = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRouteDelete = new System.Windows.Forms.Button();
            this.btnRouteSave = new System.Windows.Forms.Button();
            this.numRouteTripRate = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvRouteRate = new System.Windows.Forms.DataGridView();
            this.tabMain.SuspendLayout();
            this.tabRateByArea.SuspendLayout();
            this.tlpAreaRateMain.SuspendLayout();
            this.grpAreaFilters.SuspendLayout();
            this.grpAreaTumbol.SuspendLayout();
            this.tlpTumbolSelection.SuspendLayout();
            this.flpTumbolLinks.SuspendLayout();
            this.grpAreaRateInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreaRate)).BeginInit();
            this.tabRateByRoute.SuspendLayout();
            this.tlpRouteRateMain.SuspendLayout();
            this.grpRouteFilters.SuspendLayout();
            this.grpRouteRateInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTrailerRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTripRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteRate)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabRateByArea);
            this.tabMain.Controls.Add(this.tabRateByRoute);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(600, 366);
            this.tabMain.TabIndex = 0;
            // 
            // tabRateByArea
            // 
            this.tabRateByArea.Controls.Add(this.tlpAreaRateMain);
            this.tabRateByArea.Location = new System.Drawing.Point(4, 22);
            this.tabRateByArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRateByArea.Name = "tabRateByArea";
            this.tabRateByArea.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRateByArea.Size = new System.Drawing.Size(592, 340);
            this.tabRateByArea.TabIndex = 0;
            this.tabRateByArea.Text = "ค่าขนส่งตามพื้นที่ (ตำบล)";
            this.tabRateByArea.UseVisualStyleBackColor = true;
            // 
            // tlpAreaRateMain
            // 
            this.tlpAreaRateMain.ColumnCount = 3;
            this.tlpAreaRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tlpAreaRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tlpAreaRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAreaRateMain.Controls.Add(this.grpAreaFilters, 0, 0);
            this.tlpAreaRateMain.Controls.Add(this.grpAreaTumbol, 1, 0);
            this.tlpAreaRateMain.Controls.Add(this.grpAreaRateInput, 0, 1);
            this.tlpAreaRateMain.Controls.Add(this.dgvAreaRate, 2, 0);
            this.tlpAreaRateMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAreaRateMain.Location = new System.Drawing.Point(2, 2);
            this.tlpAreaRateMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpAreaRateMain.Name = "tlpAreaRateMain";
            this.tlpAreaRateMain.RowCount = 2;
            this.tlpAreaRateMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAreaRateMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAreaRateMain.Size = new System.Drawing.Size(588, 336);
            this.tlpAreaRateMain.TabIndex = 0;
            // 
            // grpAreaFilters
            // 
            this.grpAreaFilters.Controls.Add(this.cboAreaTruckType);
            this.grpAreaFilters.Controls.Add(this.label1);
            this.grpAreaFilters.Controls.Add(this.cboAreaAumphur);
            this.grpAreaFilters.Controls.Add(this.label2);
            this.grpAreaFilters.Controls.Add(this.cboAreaProvince);
            this.grpAreaFilters.Controls.Add(this.label6);
            this.grpAreaFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAreaFilters.Location = new System.Drawing.Point(2, 2);
            this.grpAreaFilters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpAreaFilters.Name = "grpAreaFilters";
            this.grpAreaFilters.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpAreaFilters.Size = new System.Drawing.Size(184, 164);
            this.grpAreaFilters.TabIndex = 0;
            this.grpAreaFilters.TabStop = false;
            this.grpAreaFilters.Text = "เลือกพื้นที่";
            // 
            // cboAreaTruckType
            // 
            this.cboAreaTruckType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaTruckType.FormattingEnabled = true;
            this.cboAreaTruckType.Location = new System.Drawing.Point(7, 127);
            this.cboAreaTruckType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboAreaTruckType.Name = "cboAreaTruckType";
            this.cboAreaTruckType.Size = new System.Drawing.Size(174, 21);
            this.cboAreaTruckType.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ประเภทรถ:";
            // 
            // cboAreaAumphur
            // 
            this.cboAreaAumphur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaAumphur.FormattingEnabled = true;
            this.cboAreaAumphur.Location = new System.Drawing.Point(7, 80);
            this.cboAreaAumphur.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboAreaAumphur.Name = "cboAreaAumphur";
            this.cboAreaAumphur.Size = new System.Drawing.Size(174, 21);
            this.cboAreaAumphur.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "อำเภอ:";
            // 
            // cboAreaProvince
            // 
            this.cboAreaProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAreaProvince.FormattingEnabled = true;
            this.cboAreaProvince.Location = new System.Drawing.Point(7, 35);
            this.cboAreaProvince.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboAreaProvince.Name = "cboAreaProvince";
            this.cboAreaProvince.Size = new System.Drawing.Size(174, 21);
            this.cboAreaProvince.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "จังหวัด:";
            // 
            // grpAreaTumbol
            // 
            this.grpAreaTumbol.Controls.Add(this.tlpTumbolSelection);
            this.grpAreaTumbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAreaTumbol.Location = new System.Drawing.Point(190, 2);
            this.grpAreaTumbol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpAreaTumbol.Name = "grpAreaTumbol";
            this.grpAreaTumbol.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpAreaRateMain.SetRowSpan(this.grpAreaTumbol, 2);
            this.grpAreaTumbol.Size = new System.Drawing.Size(184, 332);
            this.grpAreaTumbol.TabIndex = 1;
            this.grpAreaTumbol.TabStop = false;
            this.grpAreaTumbol.Text = "เลือกตำบล (ไม่เลือก = ทุกตำบล)";
            // 
            // tlpTumbolSelection
            // 
            this.tlpTumbolSelection.ColumnCount = 1;
            this.tlpTumbolSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTumbolSelection.Controls.Add(this.flpTumbolLinks, 0, 0);
            this.tlpTumbolSelection.Controls.Add(this.clbAreaTumbol, 0, 1);
            this.tlpTumbolSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTumbolSelection.Location = new System.Drawing.Point(2, 15);
            this.tlpTumbolSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpTumbolSelection.Name = "tlpTumbolSelection";
            this.tlpTumbolSelection.RowCount = 2;
            this.tlpTumbolSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTumbolSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTumbolSelection.Size = new System.Drawing.Size(180, 315);
            this.tlpTumbolSelection.TabIndex = 3;
            // 
            // flpTumbolLinks
            // 
            this.flpTumbolLinks.Controls.Add(this.linkAreaUnselectAll);
            this.flpTumbolLinks.Controls.Add(this.linkAreaSelectAll);
            this.flpTumbolLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTumbolLinks.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpTumbolLinks.Location = new System.Drawing.Point(0, 0);
            this.flpTumbolLinks.Margin = new System.Windows.Forms.Padding(0);
            this.flpTumbolLinks.Name = "flpTumbolLinks";
            this.flpTumbolLinks.Size = new System.Drawing.Size(180, 20);
            this.flpTumbolLinks.TabIndex = 0;
            // 
            // linkAreaUnselectAll
            // 
            this.linkAreaUnselectAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkAreaUnselectAll.AutoSize = true;
            this.linkAreaUnselectAll.Location = new System.Drawing.Point(106, 0);
            this.linkAreaUnselectAll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkAreaUnselectAll.Name = "linkAreaUnselectAll";
            this.linkAreaUnselectAll.Size = new System.Drawing.Size(72, 13);
            this.linkAreaUnselectAll.TabIndex = 2;
            this.linkAreaUnselectAll.TabStop = true;
            this.linkAreaUnselectAll.Text = "ยกเลิกทั้งหมด";
            // 
            // linkAreaSelectAll
            // 
            this.linkAreaSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkAreaSelectAll.AutoSize = true;
            this.linkAreaSelectAll.Location = new System.Drawing.Point(38, 0);
            this.linkAreaSelectAll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkAreaSelectAll.Name = "linkAreaSelectAll";
            this.linkAreaSelectAll.Size = new System.Drawing.Size(64, 13);
            this.linkAreaSelectAll.TabIndex = 1;
            this.linkAreaSelectAll.TabStop = true;
            this.linkAreaSelectAll.Text = "เลือกทั้งหมด";
            // 
            // clbAreaTumbol
            // 
            this.clbAreaTumbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAreaTumbol.FormattingEnabled = true;
            this.clbAreaTumbol.Location = new System.Drawing.Point(2, 22);
            this.clbAreaTumbol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clbAreaTumbol.Name = "clbAreaTumbol";
            this.clbAreaTumbol.Size = new System.Drawing.Size(176, 291);
            this.clbAreaTumbol.TabIndex = 1;
            // 
            // grpAreaRateInput
            // 
            this.grpAreaRateInput.Controls.Add(this.btnAreaDelete);
            this.grpAreaRateInput.Controls.Add(this.btnAreaSave);
            this.grpAreaRateInput.Controls.Add(this.numAreaRate);
            this.grpAreaRateInput.Controls.Add(this.label7);
            this.grpAreaRateInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAreaRateInput.Location = new System.Drawing.Point(2, 170);
            this.grpAreaRateInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpAreaRateInput.Name = "grpAreaRateInput";
            this.grpAreaRateInput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpAreaRateInput.Size = new System.Drawing.Size(184, 164);
            this.grpAreaRateInput.TabIndex = 2;
            this.grpAreaRateInput.TabStop = false;
            this.grpAreaRateInput.Text = "กำหนดค่าขนส่ง";
            // 
            // btnAreaDelete
            // 
            this.btnAreaDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAreaDelete.ForeColor = System.Drawing.Color.Red;
            this.btnAreaDelete.Location = new System.Drawing.Point(7, 123);
            this.btnAreaDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAreaDelete.Name = "btnAreaDelete";
            this.btnAreaDelete.Size = new System.Drawing.Size(68, 32);
            this.btnAreaDelete.TabIndex = 3;
            this.btnAreaDelete.Text = "ลบ";
            this.btnAreaDelete.UseVisualStyleBackColor = true;
            // 
            // btnAreaSave
            // 
            this.btnAreaSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAreaSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAreaSave.Location = new System.Drawing.Point(91, 123);
            this.btnAreaSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAreaSave.Name = "btnAreaSave";
            this.btnAreaSave.Size = new System.Drawing.Size(88, 32);
            this.btnAreaSave.TabIndex = 2;
            this.btnAreaSave.Text = "บันทึก";
            this.btnAreaSave.UseVisualStyleBackColor = true;
            // 
            // numAreaRate
            // 
            this.numAreaRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAreaRate.DecimalPlaces = 2;
            this.numAreaRate.Location = new System.Drawing.Point(7, 42);
            this.numAreaRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numAreaRate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numAreaRate.Name = "numAreaRate";
            this.numAreaRate.Size = new System.Drawing.Size(173, 20);
            this.numAreaRate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "อัตราค่าขนส่ง:";
            // 
            // dgvAreaRate
            // 
            this.dgvAreaRate.AllowUserToAddRows = false;
            this.dgvAreaRate.AllowUserToDeleteRows = false;
            this.dgvAreaRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreaRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAreaRate.Location = new System.Drawing.Point(378, 2);
            this.dgvAreaRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAreaRate.Name = "dgvAreaRate";
            this.dgvAreaRate.ReadOnly = true;
            this.dgvAreaRate.RowHeadersWidth = 51;
            this.tlpAreaRateMain.SetRowSpan(this.dgvAreaRate, 2);
            this.dgvAreaRate.RowTemplate.Height = 24;
            this.dgvAreaRate.Size = new System.Drawing.Size(208, 332);
            this.dgvAreaRate.TabIndex = 3;
            // 
            // tabRateByRoute
            // 
            this.tabRateByRoute.Controls.Add(this.tlpRouteRateMain);
            this.tabRateByRoute.Location = new System.Drawing.Point(4, 22);
            this.tabRateByRoute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRateByRoute.Name = "tabRateByRoute";
            this.tabRateByRoute.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabRateByRoute.Size = new System.Drawing.Size(592, 340);
            this.tabRateByRoute.TabIndex = 1;
            this.tabRateByRoute.Text = "ค่าขนส่งตามเส้นทาง";
            this.tabRateByRoute.UseVisualStyleBackColor = true;
            // 
            // tlpRouteRateMain
            // 
            this.tlpRouteRateMain.ColumnCount = 2;
            this.tlpRouteRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpRouteRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRouteRateMain.Controls.Add(this.grpRouteFilters, 0, 0);
            this.tlpRouteRateMain.Controls.Add(this.grpRouteRateInput, 0, 1);
            this.tlpRouteRateMain.Controls.Add(this.dgvRouteRate, 1, 0);
            this.tlpRouteRateMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRouteRateMain.Location = new System.Drawing.Point(2, 2);
            this.tlpRouteRateMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpRouteRateMain.Name = "tlpRouteRateMain";
            this.tlpRouteRateMain.RowCount = 2;
            this.tlpRouteRateMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tlpRouteRateMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRouteRateMain.Size = new System.Drawing.Size(588, 336);
            this.tlpRouteRateMain.TabIndex = 0;
            // 
            // grpRouteFilters
            // 
            this.grpRouteFilters.Controls.Add(this.cboRouteTruckType);
            this.grpRouteFilters.Controls.Add(this.label11);
            this.grpRouteFilters.Controls.Add(this.cboRouteToAumphur);
            this.grpRouteFilters.Controls.Add(this.label10);
            this.grpRouteFilters.Controls.Add(this.cboRouteToProvince);
            this.grpRouteFilters.Controls.Add(this.label9);
            this.grpRouteFilters.Controls.Add(this.cboRouteFromAumphur);
            this.grpRouteFilters.Controls.Add(this.label5);
            this.grpRouteFilters.Controls.Add(this.cboRouteFromProvince);
            this.grpRouteFilters.Controls.Add(this.label3);
            this.grpRouteFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRouteFilters.Location = new System.Drawing.Point(2, 2);
            this.grpRouteFilters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpRouteFilters.Name = "grpRouteFilters";
            this.grpRouteFilters.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpRouteFilters.Size = new System.Drawing.Size(296, 175);
            this.grpRouteFilters.TabIndex = 0;
            this.grpRouteFilters.TabStop = false;
            this.grpRouteFilters.Text = "เลือกเส้นทาง";
            // 
            // cboRouteTruckType
            // 
            this.cboRouteTruckType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRouteTruckType.FormattingEnabled = true;
            this.cboRouteTruckType.Location = new System.Drawing.Point(7, 145);
            this.cboRouteTruckType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboRouteTruckType.Name = "cboRouteTruckType";
            this.cboRouteTruckType.Size = new System.Drawing.Size(285, 21);
            this.cboRouteTruckType.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 129);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "ประเภทรถ:";
            // 
            // cboRouteToAumphur
            // 
            this.cboRouteToAumphur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRouteToAumphur.FormattingEnabled = true;
            this.cboRouteToAumphur.Location = new System.Drawing.Point(150, 95);
            this.cboRouteToAumphur.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboRouteToAumphur.Name = "cboRouteToAumphur";
            this.cboRouteToAumphur.Size = new System.Drawing.Size(142, 21);
            this.cboRouteToAumphur.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "อำเภอปลายทาง:";
            // 
            // cboRouteToProvince
            // 
            this.cboRouteToProvince.FormattingEnabled = true;
            this.cboRouteToProvince.Location = new System.Drawing.Point(7, 95);
            this.cboRouteToProvince.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboRouteToProvince.Name = "cboRouteToProvince";
            this.cboRouteToProvince.Size = new System.Drawing.Size(140, 21);
            this.cboRouteToProvince.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "จังหวัดปลายทาง:";
            // 
            // cboRouteFromAumphur
            // 
            this.cboRouteFromAumphur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRouteFromAumphur.FormattingEnabled = true;
            this.cboRouteFromAumphur.Location = new System.Drawing.Point(150, 39);
            this.cboRouteFromAumphur.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboRouteFromAumphur.Name = "cboRouteFromAumphur";
            this.cboRouteFromAumphur.Size = new System.Drawing.Size(142, 21);
            this.cboRouteFromAumphur.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "อำเภอต้นทาง:";
            // 
            // cboRouteFromProvince
            // 
            this.cboRouteFromProvince.FormattingEnabled = true;
            this.cboRouteFromProvince.Location = new System.Drawing.Point(7, 39);
            this.cboRouteFromProvince.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboRouteFromProvince.Name = "cboRouteFromProvince";
            this.cboRouteFromProvince.Size = new System.Drawing.Size(140, 21);
            this.cboRouteFromProvince.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "จังหวัดต้นทาง:";
            // 
            // grpRouteRateInput
            // 
            this.grpRouteRateInput.Controls.Add(this.dtpRouteEndDate);
            this.grpRouteRateInput.Controls.Add(this.label15);
            this.grpRouteRateInput.Controls.Add(this.dtpRouteStartDate);
            this.grpRouteRateInput.Controls.Add(this.label14);
            this.grpRouteRateInput.Controls.Add(this.numRouteTrailerRate);
            this.grpRouteRateInput.Controls.Add(this.label13);
            this.grpRouteRateInput.Controls.Add(this.btnRouteDelete);
            this.grpRouteRateInput.Controls.Add(this.btnRouteSave);
            this.grpRouteRateInput.Controls.Add(this.numRouteTripRate);
            this.grpRouteRateInput.Controls.Add(this.label12);
            this.grpRouteRateInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRouteRateInput.Location = new System.Drawing.Point(2, 181);
            this.grpRouteRateInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpRouteRateInput.Name = "grpRouteRateInput";
            this.grpRouteRateInput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpRouteRateInput.Size = new System.Drawing.Size(296, 153);
            this.grpRouteRateInput.TabIndex = 1;
            this.grpRouteRateInput.TabStop = false;
            this.grpRouteRateInput.Text = "กำหนดค่าขนส่ง";
            // 
            // dtpRouteEndDate
            // 
            this.dtpRouteEndDate.Location = new System.Drawing.Point(150, 83);
            this.dtpRouteEndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpRouteEndDate.Name = "dtpRouteEndDate";
            this.dtpRouteEndDate.Size = new System.Drawing.Size(142, 20);
            this.dtpRouteEndDate.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(148, 67);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "วันสิ้นสุด:";
            // 
            // dtpRouteStartDate
            // 
            this.dtpRouteStartDate.Location = new System.Drawing.Point(7, 83);
            this.dtpRouteStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpRouteStartDate.Name = "dtpRouteStartDate";
            this.dtpRouteStartDate.Size = new System.Drawing.Size(140, 20);
            this.dtpRouteStartDate.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 67);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "วันเริ่มต้น:";
            // 
            // numRouteTrailerRate
            // 
            this.numRouteTrailerRate.DecimalPlaces = 2;
            this.numRouteTrailerRate.Location = new System.Drawing.Point(150, 38);
            this.numRouteTrailerRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numRouteTrailerRate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numRouteTrailerRate.Name = "numRouteTrailerRate";
            this.numRouteTrailerRate.Size = new System.Drawing.Size(141, 20);
            this.numRouteTrailerRate.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(148, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "ค่าขนส่ง (รถพ่วง):";
            // 
            // btnRouteDelete
            // 
            this.btnRouteDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRouteDelete.ForeColor = System.Drawing.Color.Red;
            this.btnRouteDelete.Location = new System.Drawing.Point(7, 111);
            this.btnRouteDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRouteDelete.Name = "btnRouteDelete";
            this.btnRouteDelete.Size = new System.Drawing.Size(68, 32);
            this.btnRouteDelete.TabIndex = 3;
            this.btnRouteDelete.Text = "ลบ";
            this.btnRouteDelete.UseVisualStyleBackColor = true;
            // 
            // btnRouteSave
            // 
            this.btnRouteSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRouteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRouteSave.Location = new System.Drawing.Point(202, 111);
            this.btnRouteSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRouteSave.Name = "btnRouteSave";
            this.btnRouteSave.Size = new System.Drawing.Size(88, 32);
            this.btnRouteSave.TabIndex = 2;
            this.btnRouteSave.Text = "บันทึก";
            this.btnRouteSave.UseVisualStyleBackColor = true;
            // 
            // numRouteTripRate
            // 
            this.numRouteTripRate.DecimalPlaces = 2;
            this.numRouteTripRate.Location = new System.Drawing.Point(7, 38);
            this.numRouteTripRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numRouteTripRate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numRouteTripRate.Name = "numRouteTripRate";
            this.numRouteTripRate.Size = new System.Drawing.Size(139, 20);
            this.numRouteTripRate.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 23);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "ค่าขนส่ง (ต่อเที่ยว):";
            // 
            // dgvRouteRate
            // 
            this.dgvRouteRate.AllowUserToAddRows = false;
            this.dgvRouteRate.AllowUserToDeleteRows = false;
            this.dgvRouteRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouteRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRouteRate.Location = new System.Drawing.Point(302, 2);
            this.dgvRouteRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRouteRate.Name = "dgvRouteRate";
            this.dgvRouteRate.ReadOnly = true;
            this.dgvRouteRate.RowHeadersWidth = 51;
            this.tlpRouteRateMain.SetRowSpan(this.dgvRouteRate, 2);
            this.dgvRouteRate.RowTemplate.Height = 24;
            this.dgvRouteRate.Size = new System.Drawing.Size(284, 332);
            this.dgvRouteRate.TabIndex = 2;
            // 
            // ShippingCostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShippingCostControl";
            this.Size = new System.Drawing.Size(600, 366);
            this.tabMain.ResumeLayout(false);
            this.tabRateByArea.ResumeLayout(false);
            this.tlpAreaRateMain.ResumeLayout(false);
            this.grpAreaFilters.ResumeLayout(false);
            this.grpAreaFilters.PerformLayout();
            this.grpAreaTumbol.ResumeLayout(false);
            this.tlpTumbolSelection.ResumeLayout(false);
            this.flpTumbolLinks.ResumeLayout(false);
            this.flpTumbolLinks.PerformLayout();
            this.grpAreaRateInput.ResumeLayout(false);
            this.grpAreaRateInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreaRate)).EndInit();
            this.tabRateByRoute.ResumeLayout(false);
            this.tlpRouteRateMain.ResumeLayout(false);
            this.grpRouteFilters.ResumeLayout(false);
            this.grpRouteFilters.PerformLayout();
            this.grpRouteRateInput.ResumeLayout(false);
            this.grpRouteRateInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTrailerRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTripRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabRateByArea;
        private System.Windows.Forms.TabPage tabRateByRoute;
        private System.Windows.Forms.TableLayoutPanel tlpAreaRateMain;
        private System.Windows.Forms.GroupBox grpAreaFilters;
        private System.Windows.Forms.GroupBox grpAreaTumbol;
        private System.Windows.Forms.GroupBox grpAreaRateInput;
        private System.Windows.Forms.DataGridView dgvAreaRate;
        private System.Windows.Forms.TableLayoutPanel tlpRouteRateMain;
        private System.Windows.Forms.GroupBox grpRouteFilters;
        private System.Windows.Forms.GroupBox grpRouteRateInput;
        private System.Windows.Forms.DataGridView dgvRouteRate;
        private System.Windows.Forms.ComboBox cboAreaTruckType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAreaAumphur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAreaProvince;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkAreaUnselectAll;
        private System.Windows.Forms.LinkLabel linkAreaSelectAll;
        private System.Windows.Forms.CheckedListBox clbAreaTumbol;
        private System.Windows.Forms.Button btnAreaDelete;
        private System.Windows.Forms.Button btnAreaSave;
        private System.Windows.Forms.NumericUpDown numAreaRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRouteFromAumphur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRouteFromProvince;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRouteToAumphur;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboRouteToProvince;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboRouteTruckType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRouteDelete;
        private System.Windows.Forms.Button btnRouteSave;
        private System.Windows.Forms.NumericUpDown numRouteTripRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numRouteTrailerRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpRouteEndDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpRouteStartDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tlpTumbolSelection;
        private System.Windows.Forms.FlowLayoutPanel flpTumbolLinks;
    }
}
