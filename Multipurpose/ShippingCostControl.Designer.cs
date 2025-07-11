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
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabRateByArea = new System.Windows.Forms.TabPage();
            this.tlpAreaRateMain = new System.Windows.Forms.TableLayoutPanel();
            this.areaControlsPanel = new System.Windows.Forms.Panel();
            this.grpAreaRateInput = new System.Windows.Forms.GroupBox();
            this.btnAreaDelete = new System.Windows.Forms.Button();
            this.btnAreaSave = new System.Windows.Forms.Button();
            this.numAreaRate = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.grpAreaTumbol = new System.Windows.Forms.GroupBox();
            this.tlpTumbolSelection = new System.Windows.Forms.TableLayoutPanel();
            this.flpTumbolLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.linkAreaUnselectAll = new System.Windows.Forms.LinkLabel();
            this.linkAreaSelectAll = new System.Windows.Forms.LinkLabel();
            this.clbAreaTumbol = new System.Windows.Forms.CheckedListBox();
            this.grpAreaFilters = new System.Windows.Forms.GroupBox();
            this.cboAreaTruckType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAreaAumphur = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAreaProvince = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvAreaRate = new System.Windows.Forms.DataGridView();
            this.tabRateByRoute = new System.Windows.Forms.TabPage();
            this.tlpRouteRateMain = new System.Windows.Forms.TableLayoutPanel();
            this.routeControlsPanel = new System.Windows.Forms.Panel();
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
            this.dgvRouteRate = new System.Windows.Forms.DataGridView();
            this.mainTableLayoutPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabRateByArea.SuspendLayout();
            this.tlpAreaRateMain.SuspendLayout();
            this.areaControlsPanel.SuspendLayout();
            this.grpAreaRateInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaRate)).BeginInit();
            this.grpAreaTumbol.SuspendLayout();
            this.tlpTumbolSelection.SuspendLayout();
            this.flpTumbolLinks.SuspendLayout();
            this.grpAreaFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreaRate)).BeginInit();
            this.tabRateByRoute.SuspendLayout();
            this.tlpRouteRateMain.SuspendLayout();
            this.routeControlsPanel.SuspendLayout();
            this.grpRouteRateInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTrailerRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTripRate)).BeginInit();
            this.grpRouteFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteRate)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.headerPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.tabMain, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(858, 633);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(13, 13);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(832, 44);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(294, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Shipping Cost Management";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabRateByArea);
            this.tabMain.Controls.Add(this.tabRateByRoute);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(13, 63);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(832, 557);
            this.tabMain.TabIndex = 1;
            // 
            // tabRateByArea
            // 
            this.tabRateByArea.Controls.Add(this.tlpAreaRateMain);
            this.tabRateByArea.Location = new System.Drawing.Point(4, 26);
            this.tabRateByArea.Name = "tabRateByArea";
            this.tabRateByArea.Padding = new System.Windows.Forms.Padding(3);
            this.tabRateByArea.Size = new System.Drawing.Size(824, 527);
            this.tabRateByArea.TabIndex = 0;
            this.tabRateByArea.Text = "ค่าขนส่งตามพื้นที่ (ตำบล)";
            this.tabRateByArea.UseVisualStyleBackColor = true;
            // 
            // tlpAreaRateMain
            // 
            this.tlpAreaRateMain.ColumnCount = 2;
            // --- CHANGE START ---
            // เปลี่ยนจาก Absolute(400F) เป็น Percent(50F)
            this.tlpAreaRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            // --- CHANGE END ---
            this.tlpAreaRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAreaRateMain.Controls.Add(this.areaControlsPanel, 0, 0);
            this.tlpAreaRateMain.Controls.Add(this.dgvAreaRate, 1, 0);
            this.tlpAreaRateMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAreaRateMain.Location = new System.Drawing.Point(3, 3);
            this.tlpAreaRateMain.Name = "tlpAreaRateMain";
            this.tlpAreaRateMain.RowCount = 1;
            this.tlpAreaRateMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAreaRateMain.Size = new System.Drawing.Size(818, 521);
            this.tlpAreaRateMain.TabIndex = 0;
            // 
            // areaControlsPanel
            // 
            this.areaControlsPanel.Controls.Add(this.grpAreaRateInput);
            this.areaControlsPanel.Controls.Add(this.grpAreaTumbol);
            this.areaControlsPanel.Controls.Add(this.grpAreaFilters);
            this.areaControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.areaControlsPanel.Location = new System.Drawing.Point(3, 3);
            this.areaControlsPanel.Name = "areaControlsPanel";
            this.areaControlsPanel.Size = new System.Drawing.Size(403, 515);
            this.areaControlsPanel.TabIndex = 0;
            // 
            // grpAreaRateInput
            // 
            this.grpAreaRateInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAreaRateInput.Controls.Add(this.btnAreaDelete);
            this.grpAreaRateInput.Controls.Add(this.btnAreaSave);
            this.grpAreaRateInput.Controls.Add(this.numAreaRate);
            this.grpAreaRateInput.Controls.Add(this.label7);
            this.grpAreaRateInput.Location = new System.Drawing.Point(3, 412);
            this.grpAreaRateInput.Name = "grpAreaRateInput";
            this.grpAreaRateInput.Size = new System.Drawing.Size(397, 100);
            this.grpAreaRateInput.TabIndex = 2;
            this.grpAreaRateInput.TabStop = false;
            this.grpAreaRateInput.Text = "กำหนดค่าขนส่ง";
            // 
            // btnAreaDelete
            // 
            this.btnAreaDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAreaDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAreaDelete.ForeColor = System.Drawing.Color.Red;
            this.btnAreaDelete.Location = new System.Drawing.Point(9, 59);
            this.btnAreaDelete.Name = "btnAreaDelete";
            this.btnAreaDelete.Size = new System.Drawing.Size(90, 35);
            this.btnAreaDelete.TabIndex = 3;
            this.btnAreaDelete.Text = "ลบ";
            this.btnAreaDelete.UseVisualStyleBackColor = true;
            // 
            // btnAreaSave
            // 
            this.btnAreaSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAreaSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAreaSave.Location = new System.Drawing.Point(291, 59);
            this.btnAreaSave.Name = "btnAreaSave";
            this.btnAreaSave.Size = new System.Drawing.Size(100, 35);
            this.btnAreaSave.TabIndex = 2;
            this.btnAreaSave.Text = "บันทึก";
            this.btnAreaSave.UseVisualStyleBackColor = true;
            // 
            // numAreaRate
            // 
            this.numAreaRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAreaRate.DecimalPlaces = 2;
            this.numAreaRate.Location = new System.Drawing.Point(111, 24);
            this.numAreaRate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numAreaRate.Name = "numAreaRate";
            this.numAreaRate.Size = new System.Drawing.Size(280, 25);
            this.numAreaRate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "อัตราค่าขนส่ง:";
            // 
            // grpAreaTumbol
            // 
            this.grpAreaTumbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAreaTumbol.Controls.Add(this.tlpTumbolSelection);
            this.grpAreaTumbol.Location = new System.Drawing.Point(3, 173);
            this.grpAreaTumbol.Name = "grpAreaTumbol";
            this.grpAreaTumbol.Size = new System.Drawing.Size(397, 233);
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
            this.tlpTumbolSelection.Location = new System.Drawing.Point(3, 21);
            this.tlpTumbolSelection.Name = "tlpTumbolSelection";
            this.tlpTumbolSelection.RowCount = 2;
            this.tlpTumbolSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpTumbolSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTumbolSelection.Size = new System.Drawing.Size(391, 209);
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
            this.flpTumbolLinks.Size = new System.Drawing.Size(391, 25);
            this.flpTumbolLinks.TabIndex = 0;
            // 
            // linkAreaUnselectAll
            // 
            this.linkAreaUnselectAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkAreaUnselectAll.AutoSize = true;
            this.linkAreaUnselectAll.Location = new System.Drawing.Point(301, 4);
            this.linkAreaUnselectAll.Name = "linkAreaUnselectAll";
            this.linkAreaUnselectAll.Size = new System.Drawing.Size(87, 17);
            this.linkAreaUnselectAll.TabIndex = 2;
            this.linkAreaUnselectAll.TabStop = true;
            this.linkAreaUnselectAll.Text = "ยกเลิกทั้งหมด";
            // 
            // linkAreaSelectAll
            // 
            this.linkAreaSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkAreaSelectAll.AutoSize = true;
            this.linkAreaSelectAll.Location = new System.Drawing.Point(218, 4);
            this.linkAreaSelectAll.Margin = new System.Windows.Forms.Padding(3);
            this.linkAreaSelectAll.Name = "linkAreaSelectAll";
            this.linkAreaSelectAll.Size = new System.Drawing.Size(77, 17);
            this.linkAreaSelectAll.TabIndex = 1;
            this.linkAreaSelectAll.TabStop = true;
            this.linkAreaSelectAll.Text = "เลือกทั้งหมด";
            // 
            // clbAreaTumbol
            // 
            this.clbAreaTumbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAreaTumbol.FormattingEnabled = true;
            this.clbAreaTumbol.Location = new System.Drawing.Point(3, 28);
            this.clbAreaTumbol.Name = "clbAreaTumbol";
            this.clbAreaTumbol.Size = new System.Drawing.Size(385, 178);
            this.clbAreaTumbol.TabIndex = 1;
            // 
            // grpAreaFilters
            // 
            this.grpAreaFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAreaFilters.Controls.Add(this.cboAreaTruckType);
            this.grpAreaFilters.Controls.Add(this.label1);
            this.grpAreaFilters.Controls.Add(this.cboAreaAumphur);
            this.grpAreaFilters.Controls.Add(this.label2);
            this.grpAreaFilters.Controls.Add(this.cboAreaProvince);
            this.grpAreaFilters.Controls.Add(this.label6);
            this.grpAreaFilters.Location = new System.Drawing.Point(3, 3);
            this.grpAreaFilters.Name = "grpAreaFilters";
            this.grpAreaFilters.Size = new System.Drawing.Size(397, 164);
            this.grpAreaFilters.TabIndex = 0;
            this.grpAreaFilters.TabStop = false;
            this.grpAreaFilters.Text = "เลือกพื้นที่";
            // 
            // cboAreaTruckType
            // 
            this.cboAreaTruckType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaTruckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaTruckType.FormattingEnabled = true;
            this.cboAreaTruckType.Location = new System.Drawing.Point(9, 129);
            this.cboAreaTruckType.Name = "cboAreaTruckType";
            this.cboAreaTruckType.Size = new System.Drawing.Size(382, 25);
            this.cboAreaTruckType.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "ประเภทรถ:";
            // 
            // cboAreaAumphur
            // 
            this.cboAreaAumphur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaAumphur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaAumphur.FormattingEnabled = true;
            this.cboAreaAumphur.Location = new System.Drawing.Point(9, 81);
            this.cboAreaAumphur.Name = "cboAreaAumphur";
            this.cboAreaAumphur.Size = new System.Drawing.Size(382, 25);
            this.cboAreaAumphur.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "อำเภอ:";
            // 
            // cboAreaProvince
            // 
            this.cboAreaProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreaProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAreaProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAreaProvince.FormattingEnabled = true;
            this.cboAreaProvince.Location = new System.Drawing.Point(9, 33);
            this.cboAreaProvince.Name = "cboAreaProvince";
            this.cboAreaProvince.Size = new System.Drawing.Size(382, 25);
            this.cboAreaProvince.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "จังหวัด:";
            // 
            // dgvAreaRate
            // 
            this.dgvAreaRate.AllowUserToAddRows = false;
            this.dgvAreaRate.AllowUserToDeleteRows = false;
            this.dgvAreaRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAreaRate.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAreaRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAreaRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreaRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAreaRate.Location = new System.Drawing.Point(412, 3);
            this.dgvAreaRate.Name = "dgvAreaRate";
            this.dgvAreaRate.ReadOnly = true;
            this.dgvAreaRate.RowHeadersWidth = 51;
            this.dgvAreaRate.RowTemplate.Height = 24;
            this.dgvAreaRate.Size = new System.Drawing.Size(403, 515);
            this.dgvAreaRate.TabIndex = 1;
            // 
            // tabRateByRoute
            // 
            this.tabRateByRoute.Controls.Add(this.tlpRouteRateMain);
            this.tabRateByRoute.Location = new System.Drawing.Point(4, 26);
            this.tabRateByRoute.Name = "tabRateByRoute";
            this.tabRateByRoute.Padding = new System.Windows.Forms.Padding(3);
            this.tabRateByRoute.Size = new System.Drawing.Size(824, 527);
            this.tabRateByRoute.TabIndex = 1;
            this.tabRateByRoute.Text = "ค่าขนส่งตามเส้นทาง";
            this.tabRateByRoute.UseVisualStyleBackColor = true;
            // 
            // tlpRouteRateMain
            // 
            this.tlpRouteRateMain.ColumnCount = 2;
            // --- CHANGE START ---
            // เปลี่ยนจาก Absolute(400F) เป็น Percent(50F)
            this.tlpRouteRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            // --- CHANGE END ---
            this.tlpRouteRateMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRouteRateMain.Controls.Add(this.routeControlsPanel, 0, 0);
            this.tlpRouteRateMain.Controls.Add(this.dgvRouteRate, 1, 0);
            this.tlpRouteRateMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRouteRateMain.Location = new System.Drawing.Point(3, 3);
            this.tlpRouteRateMain.Name = "tlpRouteRateMain";
            this.tlpRouteRateMain.RowCount = 1;
            this.tlpRouteRateMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRouteRateMain.Size = new System.Drawing.Size(818, 521);
            this.tlpRouteRateMain.TabIndex = 1;
            // 
            // routeControlsPanel
            // 
            this.routeControlsPanel.Controls.Add(this.grpRouteRateInput);
            this.routeControlsPanel.Controls.Add(this.grpRouteFilters);
            this.routeControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeControlsPanel.Location = new System.Drawing.Point(3, 3);
            this.routeControlsPanel.Name = "routeControlsPanel";
            this.routeControlsPanel.Size = new System.Drawing.Size(403, 515);
            this.routeControlsPanel.TabIndex = 0;
            // 
            // grpRouteRateInput
            // 
            this.grpRouteRateInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpRouteRateInput.Location = new System.Drawing.Point(3, 237);
            this.grpRouteRateInput.Name = "grpRouteRateInput";
            this.grpRouteRateInput.Size = new System.Drawing.Size(397, 200);
            this.grpRouteRateInput.TabIndex = 1;
            this.grpRouteRateInput.TabStop = false;
            this.grpRouteRateInput.Text = "กำหนดค่าขนส่ง";
            // 
            // dtpRouteEndDate
            // 
            this.dtpRouteEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRouteEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRouteEndDate.Location = new System.Drawing.Point(198, 97);
            this.dtpRouteEndDate.Name = "dtpRouteEndDate";
            this.dtpRouteEndDate.Size = new System.Drawing.Size(184, 25);
            this.dtpRouteEndDate.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(195, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 17);
            this.label15.TabIndex = 8;
            this.label15.Text = "วันสิ้นสุด:";
            // 
            // dtpRouteStartDate
            // 
            this.dtpRouteStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRouteStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRouteStartDate.Location = new System.Drawing.Point(9, 97);
            this.dtpRouteStartDate.Name = "dtpRouteStartDate";
            this.dtpRouteStartDate.Size = new System.Drawing.Size(183, 25);
            this.dtpRouteStartDate.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "วันเริ่มต้น:";
            // 
            // numRouteTrailerRate
            // 
            this.numRouteTrailerRate.DecimalPlaces = 2;
            this.numRouteTrailerRate.Location = new System.Drawing.Point(198, 49);
            this.numRouteTrailerRate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numRouteTrailerRate.Name = "numRouteTrailerRate";
            this.numRouteTrailerRate.Size = new System.Drawing.Size(184, 25);
            this.numRouteTrailerRate.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(195, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "ค่าขนส่ง (รถพ่วง):";
            // 
            // btnRouteDelete
            // 
            this.btnRouteDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRouteDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRouteDelete.ForeColor = System.Drawing.Color.Red;
            this.btnRouteDelete.Location = new System.Drawing.Point(9, 159);
            this.btnRouteDelete.Name = "btnRouteDelete";
            this.btnRouteDelete.Size = new System.Drawing.Size(90, 35);
            this.btnRouteDelete.TabIndex = 3;
            this.btnRouteDelete.Text = "ลบ";
            this.btnRouteDelete.UseVisualStyleBackColor = true;
            // 
            // btnRouteSave
            // 
            this.btnRouteSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRouteSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRouteSave.Location = new System.Drawing.Point(291, 159);
            this.btnRouteSave.Name = "btnRouteSave";
            this.btnRouteSave.Size = new System.Drawing.Size(100, 35);
            this.btnRouteSave.TabIndex = 2;
            this.btnRouteSave.Text = "บันทึก";
            this.btnRouteSave.UseVisualStyleBackColor = true;
            // 
            // numRouteTripRate
            // 
            this.numRouteTripRate.DecimalPlaces = 2;
            this.numRouteTripRate.Location = new System.Drawing.Point(9, 49);
            this.numRouteTripRate.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numRouteTripRate.Name = "numRouteTripRate";
            this.numRouteTripRate.Size = new System.Drawing.Size(183, 25);
            this.numRouteTripRate.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "ค่าขนส่ง (ต่อเที่ยว):";
            // 
            // grpRouteFilters
            // 
            this.grpRouteFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpRouteFilters.Location = new System.Drawing.Point(3, 3);
            this.grpRouteFilters.Name = "grpRouteFilters";
            this.grpRouteFilters.Size = new System.Drawing.Size(397, 228);
            this.grpRouteFilters.TabIndex = 0;
            this.grpRouteFilters.TabStop = false;
            this.grpRouteFilters.Text = "เลือกเส้นทาง";
            // 
            // cboRouteTruckType
            // 
            this.cboRouteTruckType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRouteTruckType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteTruckType.FormattingEnabled = true;
            this.cboRouteTruckType.Location = new System.Drawing.Point(9, 189);
            this.cboRouteTruckType.Name = "cboRouteTruckType";
            this.cboRouteTruckType.Size = new System.Drawing.Size(382, 25);
            this.cboRouteTruckType.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "ประเภทรถ:";
            // 
            // cboRouteToAumphur
            // 
            this.cboRouteToAumphur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRouteToAumphur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteToAumphur.FormattingEnabled = true;
            this.cboRouteToAumphur.Location = new System.Drawing.Point(9, 141);
            this.cboRouteToAumphur.Name = "cboRouteToAumphur";
            this.cboRouteToAumphur.Size = new System.Drawing.Size(382, 25);
            this.cboRouteToAumphur.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "อำเภอปลายทาง:";
            // 
            // cboRouteToProvince
            // 
            this.cboRouteToProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRouteToProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteToProvince.FormattingEnabled = true;
            this.cboRouteToProvince.Location = new System.Drawing.Point(9, 93);
            this.cboRouteToProvince.Name = "cboRouteToProvince";
            this.cboRouteToProvince.Size = new System.Drawing.Size(382, 25);
            this.cboRouteToProvince.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "จังหวัดปลายทาง:";
            // 
            // cboRouteFromAumphur
            // 
            this.cboRouteFromAumphur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRouteFromAumphur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteFromAumphur.FormattingEnabled = true;
            this.cboRouteFromAumphur.Location = new System.Drawing.Point(198, 45);
            this.cboRouteFromAumphur.Name = "cboRouteFromAumphur";
            this.cboRouteFromAumphur.Size = new System.Drawing.Size(184, 25);
            this.cboRouteFromAumphur.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "อำเภอต้นทาง:";
            // 
            // cboRouteFromProvince
            // 
            this.cboRouteFromProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRouteFromProvince.FormattingEnabled = true;
            this.cboRouteFromProvince.Location = new System.Drawing.Point(9, 45);
            this.cboRouteFromProvince.Name = "cboRouteFromProvince";
            this.cboRouteFromProvince.Size = new System.Drawing.Size(183, 25);
            this.cboRouteFromProvince.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "จังหวัดต้นทาง:";
            // 
            // dgvRouteRate
            // 
            this.dgvRouteRate.AllowUserToAddRows = false;
            this.dgvRouteRate.AllowUserToDeleteRows = false;
            this.dgvRouteRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRouteRate.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRouteRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRouteRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouteRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRouteRate.Location = new System.Drawing.Point(412, 3);
            this.dgvRouteRate.Name = "dgvRouteRate";
            this.dgvRouteRate.ReadOnly = true;
            this.dgvRouteRate.RowHeadersWidth = 51;
            this.dgvRouteRate.RowTemplate.Height = 24;
            this.dgvRouteRate.Size = new System.Drawing.Size(403, 515);
            this.dgvRouteRate.TabIndex = 2;
            // 
            // ShippingCostControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "ShippingCostControl";
            this.Size = new System.Drawing.Size(858, 633);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabRateByArea.ResumeLayout(false);
            this.tlpAreaRateMain.ResumeLayout(false);
            this.areaControlsPanel.ResumeLayout(false);
            this.grpAreaRateInput.ResumeLayout(false);
            this.grpAreaRateInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaRate)).EndInit();
            this.grpAreaTumbol.ResumeLayout(false);
            this.tlpTumbolSelection.ResumeLayout(false);
            this.flpTumbolLinks.ResumeLayout(false);
            this.flpTumbolLinks.PerformLayout();
            this.grpAreaFilters.ResumeLayout(false);
            this.grpAreaFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreaRate)).EndInit();
            this.tabRateByRoute.ResumeLayout(false);
            this.tlpRouteRateMain.ResumeLayout(false);
            this.routeControlsPanel.ResumeLayout(false);
            this.grpRouteRateInput.ResumeLayout(false);
            this.grpRouteRateInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTrailerRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRouteTripRate)).EndInit();
            this.grpRouteFilters.ResumeLayout(false);
            this.grpRouteFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabRateByArea;
        private System.Windows.Forms.TableLayoutPanel tlpAreaRateMain;
        private System.Windows.Forms.Panel areaControlsPanel;
        private System.Windows.Forms.GroupBox grpAreaRateInput;
        private System.Windows.Forms.Button btnAreaDelete;
        private System.Windows.Forms.Button btnAreaSave;
        private System.Windows.Forms.NumericUpDown numAreaRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpAreaTumbol;
        private System.Windows.Forms.TableLayoutPanel tlpTumbolSelection;
        private System.Windows.Forms.FlowLayoutPanel flpTumbolLinks;
        private System.Windows.Forms.LinkLabel linkAreaUnselectAll;
        private System.Windows.Forms.LinkLabel linkAreaSelectAll;
        private System.Windows.Forms.CheckedListBox clbAreaTumbol;
        private System.Windows.Forms.GroupBox grpAreaFilters;
        private System.Windows.Forms.ComboBox cboAreaTruckType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAreaAumphur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAreaProvince;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvAreaRate;
        private System.Windows.Forms.TabPage tabRateByRoute;
        private System.Windows.Forms.TableLayoutPanel tlpRouteRateMain;
        private System.Windows.Forms.Panel routeControlsPanel;
        private System.Windows.Forms.GroupBox grpRouteRateInput;
        private System.Windows.Forms.DateTimePicker dtpRouteEndDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpRouteStartDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numRouteTrailerRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRouteDelete;
        private System.Windows.Forms.Button btnRouteSave;
        private System.Windows.Forms.NumericUpDown numRouteTripRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpRouteFilters;
        private System.Windows.Forms.ComboBox cboRouteTruckType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboRouteToAumphur;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboRouteToProvince;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboRouteFromAumphur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRouteFromProvince;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvRouteRate;
    }
}
