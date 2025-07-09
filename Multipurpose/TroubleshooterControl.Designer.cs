namespace Multipurpose
{
    partial class TroubleshooterControl
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.tlpFilters = new System.Windows.Forms.TableLayoutPanel();
            this.txtQuotationSource = new System.Windows.Forms.TextBox();
            this.lblQuotationSource = new System.Windows.Forms.Label();
            this.lblArrow = new System.Windows.Forms.Label();
            this.lblQuotationDest = new System.Windows.Forms.Label();
            this.txtQuotationDest = new System.Windows.Forms.TextBox();
            this.lblManifest = new System.Windows.Forms.Label();
            this.txtManifest = new System.Windows.Forms.TextBox();
            this.panelDateRange = new System.Windows.Forms.Panel();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.chkUseDateRange = new System.Windows.Forms.CheckBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUnlockQuotation = new System.Windows.Forms.Button();
            this.btnUpdateAddress = new System.Windows.Forms.Button();
            this.btnDeleteAllBoxes = new System.Windows.Forms.Button();
            this.btnFixShippingLocation = new System.Windows.Forms.Button();
            this.btnFixShippingCost = new System.Windows.Forms.Button();
            this.btnFixIncorrectShippingCost = new System.Windows.Forms.Button();
            this.btnFixShippingCostType = new System.Windows.Forms.Button();
            this.btnNewWaste = new System.Windows.Forms.Button();
            this.btnNewWasteAdd = new System.Windows.Forms.Button();
            this.btnChangeQuotation = new System.Windows.Forms.Button();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panelProcess = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.tlpFilters.SuspendLayout();
            this.panelDateRange.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panelProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.grpFilters, 0, 0);
            this.tlpMain.Controls.Add(this.grpActions, 0, 1);
            this.tlpMain.Controls.Add(this.grpResults, 0, 2);
            this.tlpMain.Controls.Add(this.panelProcess, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpMain.Size = new System.Drawing.Size(718, 513);
            this.tlpMain.TabIndex = 0;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.tlpFilters);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilters.Location = new System.Drawing.Point(10, 10);
            this.grpFilters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFilters.Size = new System.Drawing.Size(698, 102);
            this.grpFilters.TabIndex = 0;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "ตัวกรองข้อมูล";
            // 
            // tlpFilters
            // 
            this.tlpFilters.ColumnCount = 5;
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilters.Controls.Add(this.txtQuotationSource, 1, 0);
            this.tlpFilters.Controls.Add(this.lblQuotationSource, 0, 0);
            this.tlpFilters.Controls.Add(this.lblArrow, 2, 0);
            this.tlpFilters.Controls.Add(this.lblQuotationDest, 3, 0);
            this.tlpFilters.Controls.Add(this.txtQuotationDest, 4, 0);
            this.tlpFilters.Controls.Add(this.lblManifest, 0, 1);
            this.tlpFilters.Controls.Add(this.txtManifest, 1, 1);
            this.tlpFilters.Controls.Add(this.panelDateRange, 1, 2);
            this.tlpFilters.Controls.Add(this.chkUseDateRange, 0, 2);
            this.tlpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilters.Location = new System.Drawing.Point(2, 15);
            this.tlpFilters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpFilters.Name = "tlpFilters";
            this.tlpFilters.RowCount = 3;
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFilters.Size = new System.Drawing.Size(694, 85);
            this.tlpFilters.TabIndex = 0;
            // 
            // txtQuotationSource
            // 
            this.txtQuotationSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuotationSource.Location = new System.Drawing.Point(137, 4);
            this.txtQuotationSource.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuotationSource.Name = "txtQuotationSource";
            this.txtQuotationSource.Size = new System.Drawing.Size(208, 20);
            this.txtQuotationSource.TabIndex = 1;
            // 
            // lblQuotationSource
            // 
            this.lblQuotationSource.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuotationSource.AutoSize = true;
            this.lblQuotationSource.Location = new System.Drawing.Point(42, 7);
            this.lblQuotationSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuotationSource.Name = "lblQuotationSource";
            this.lblQuotationSource.Size = new System.Drawing.Size(91, 13);
            this.lblQuotationSource.TabIndex = 0;
            this.lblQuotationSource.Text = "Quotation ต้นทาง:";
            // 
            // lblArrow
            // 
            this.lblArrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArrow.AutoSize = true;
            this.lblArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow.Location = new System.Drawing.Point(350, 5);
            this.lblArrow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(23, 17);
            this.lblArrow.TabIndex = 2;
            this.lblArrow.Text = "→";
            // 
            // lblQuotationDest
            // 
            this.lblQuotationDest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuotationDest.AutoSize = true;
            this.lblQuotationDest.Location = new System.Drawing.Point(379, 7);
            this.lblQuotationDest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuotationDest.Name = "lblQuotationDest";
            this.lblQuotationDest.Size = new System.Drawing.Size(101, 13);
            this.lblQuotationDest.TabIndex = 3;
            this.lblQuotationDest.Text = "Quotation ปลายทาง:";
            // 
            // txtQuotationDest
            // 
            this.txtQuotationDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuotationDest.Location = new System.Drawing.Point(484, 4);
            this.txtQuotationDest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuotationDest.Name = "txtQuotationDest";
            this.txtQuotationDest.Size = new System.Drawing.Size(208, 20);
            this.txtQuotationDest.TabIndex = 4;
            // 
            // lblManifest
            // 
            this.lblManifest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblManifest.AutoSize = true;
            this.lblManifest.Location = new System.Drawing.Point(83, 35);
            this.lblManifest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManifest.Name = "lblManifest";
            this.lblManifest.Size = new System.Drawing.Size(50, 13);
            this.lblManifest.TabIndex = 5;
            this.lblManifest.Text = "Manifest:";
            // 
            // txtManifest
            // 
            this.txtManifest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFilters.SetColumnSpan(this.txtManifest, 4);
            this.txtManifest.Location = new System.Drawing.Point(137, 32);
            this.txtManifest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtManifest.Name = "txtManifest";
            this.txtManifest.Size = new System.Drawing.Size(555, 20);
            this.txtManifest.TabIndex = 6;
            // 
            // panelDateRange
            // 
            this.tlpFilters.SetColumnSpan(this.panelDateRange, 4);
            this.panelDateRange.Controls.Add(this.dtpTo);
            this.panelDateRange.Controls.Add(this.lblToDate);
            this.panelDateRange.Controls.Add(this.dtpFrom);
            this.panelDateRange.Controls.Add(this.lblFromDate);
            this.panelDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDateRange.Location = new System.Drawing.Point(137, 58);
            this.panelDateRange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDateRange.Name = "panelDateRange";
            this.panelDateRange.Size = new System.Drawing.Size(555, 25);
            this.panelDateRange.TabIndex = 8;
            // 
            // dtpTo
            // 
            this.dtpTo.Enabled = false;
            this.dtpTo.Location = new System.Drawing.Point(235, 3);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(151, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(194, 6);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(43, 13);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "ถึงวันที่:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Location = new System.Drawing.Point(59, 3);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(132, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(2, 6);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(58, 13);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "ตั้งแต่วันที่:";
            // 
            // chkUseDateRange
            // 
            this.chkUseDateRange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkUseDateRange.AutoSize = true;
            this.chkUseDateRange.Location = new System.Drawing.Point(2, 62);
            this.chkUseDateRange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkUseDateRange.Name = "chkUseDateRange";
            this.chkUseDateRange.Size = new System.Drawing.Size(131, 17);
            this.chkUseDateRange.TabIndex = 7;
            this.chkUseDateRange.Text = "ใช้การกำหนดช่วงเวลา";
            this.chkUseDateRange.UseVisualStyleBackColor = true;
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.flpActions);
            this.grpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActions.Location = new System.Drawing.Point(10, 116);
            this.grpActions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpActions.Name = "grpActions";
            this.grpActions.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpActions.Size = new System.Drawing.Size(698, 102);
            this.grpActions.TabIndex = 1;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "เครื่องมือแก้ไขปัญหา";
            // 
            // flpActions
            // 
            this.flpActions.Controls.Add(this.btnUnlockQuotation);
            this.flpActions.Controls.Add(this.btnUpdateAddress);
            this.flpActions.Controls.Add(this.btnDeleteAllBoxes);
            this.flpActions.Controls.Add(this.btnFixShippingLocation);
            this.flpActions.Controls.Add(this.btnFixShippingCost);
            this.flpActions.Controls.Add(this.btnFixIncorrectShippingCost);
            this.flpActions.Controls.Add(this.btnFixShippingCostType);
            this.flpActions.Controls.Add(this.btnNewWaste);
            this.flpActions.Controls.Add(this.btnNewWasteAdd);
            this.flpActions.Controls.Add(this.btnChangeQuotation);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpActions.Location = new System.Drawing.Point(2, 15);
            this.flpActions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpActions.Name = "flpActions";
            this.flpActions.Size = new System.Drawing.Size(694, 85);
            this.flpActions.TabIndex = 0;
            // 
            // btnUnlockQuotation
            // 
            this.btnUnlockQuotation.Location = new System.Drawing.Point(2, 2);
            this.btnUnlockQuotation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUnlockQuotation.Name = "btnUnlockQuotation";
            this.btnUnlockQuotation.Size = new System.Drawing.Size(135, 37);
            this.btnUnlockQuotation.TabIndex = 0;
            this.btnUnlockQuotation.Text = "ปลดล็อค Quotation";
            this.btnUnlockQuotation.UseVisualStyleBackColor = true;
            // 
            // btnUpdateAddress
            // 
            this.btnUpdateAddress.Location = new System.Drawing.Point(141, 2);
            this.btnUpdateAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateAddress.Name = "btnUpdateAddress";
            this.btnUpdateAddress.Size = new System.Drawing.Size(135, 37);
            this.btnUpdateAddress.TabIndex = 1;
            this.btnUpdateAddress.Text = "อัปเดตที่อยู่";
            this.btnUpdateAddress.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAllBoxes
            // 
            this.btnDeleteAllBoxes.Location = new System.Drawing.Point(280, 2);
            this.btnDeleteAllBoxes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteAllBoxes.Name = "btnDeleteAllBoxes";
            this.btnDeleteAllBoxes.Size = new System.Drawing.Size(135, 37);
            this.btnDeleteAllBoxes.TabIndex = 2;
            this.btnDeleteAllBoxes.Text = "ลบ Box ทั้งหมด";
            this.btnDeleteAllBoxes.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingLocation
            // 
            this.btnFixShippingLocation.Location = new System.Drawing.Point(419, 2);
            this.btnFixShippingLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFixShippingLocation.Name = "btnFixShippingLocation";
            this.btnFixShippingLocation.Size = new System.Drawing.Size(135, 37);
            this.btnFixShippingLocation.TabIndex = 3;
            this.btnFixShippingLocation.Text = "สถานที่ขนส่งไม่ขึ้น";
            this.btnFixShippingLocation.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingCost
            // 
            this.btnFixShippingCost.Location = new System.Drawing.Point(558, 2);
            this.btnFixShippingCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFixShippingCost.Name = "btnFixShippingCost";
            this.btnFixShippingCost.Size = new System.Drawing.Size(128, 37);
            this.btnFixShippingCost.TabIndex = 4;
            this.btnFixShippingCost.Text = "ค่าขนส่งไม่ขึ้น";
            this.btnFixShippingCost.UseVisualStyleBackColor = true;
            // 
            // btnFixIncorrectShippingCost
            // 
            this.btnFixIncorrectShippingCost.Location = new System.Drawing.Point(2, 43);
            this.btnFixIncorrectShippingCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFixIncorrectShippingCost.Name = "btnFixIncorrectShippingCost";
            this.btnFixIncorrectShippingCost.Size = new System.Drawing.Size(135, 37);
            this.btnFixIncorrectShippingCost.TabIndex = 5;
            this.btnFixIncorrectShippingCost.Text = "ค่าขนส่งไม่ถูกต้อง";
            this.btnFixIncorrectShippingCost.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingCostType
            // 
            this.btnFixShippingCostType.Location = new System.Drawing.Point(141, 43);
            this.btnFixShippingCostType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFixShippingCostType.Name = "btnFixShippingCostType";
            this.btnFixShippingCostType.Size = new System.Drawing.Size(135, 37);
            this.btnFixShippingCostType.TabIndex = 6;
            this.btnFixShippingCostType.Text = "ค่าขนส่งไม่ตรงประเภทรถ";
            this.btnFixShippingCostType.UseVisualStyleBackColor = true;
            // 
            // btnNewWaste
            // 
            this.btnNewWaste.Location = new System.Drawing.Point(280, 43);
            this.btnNewWaste.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewWaste.Name = "btnNewWaste";
            this.btnNewWaste.Size = new System.Drawing.Size(135, 37);
            this.btnNewWaste.TabIndex = 7;
            this.btnNewWaste.Text = "New waste";
            this.btnNewWaste.UseVisualStyleBackColor = true;
            // 
            // btnNewWasteAdd
            // 
            this.btnNewWasteAdd.Location = new System.Drawing.Point(419, 43);
            this.btnNewWasteAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewWasteAdd.Name = "btnNewWasteAdd";
            this.btnNewWasteAdd.Size = new System.Drawing.Size(135, 37);
            this.btnNewWasteAdd.TabIndex = 8;
            this.btnNewWasteAdd.Text = "New waste ADD";
            this.btnNewWasteAdd.UseVisualStyleBackColor = true;
            // 
            // btnChangeQuotation
            // 
            this.btnChangeQuotation.Location = new System.Drawing.Point(558, 43);
            this.btnChangeQuotation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangeQuotation.Name = "btnChangeQuotation";
            this.btnChangeQuotation.Size = new System.Drawing.Size(128, 37);
            this.btnChangeQuotation.TabIndex = 9;
            this.btnChangeQuotation.Text = "เปลี่ยนใบเสนอราคา";
            this.btnChangeQuotation.UseVisualStyleBackColor = true;
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.dgvResults);
            this.grpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResults.Location = new System.Drawing.Point(10, 222);
            this.grpResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpResults.Name = "grpResults";
            this.grpResults.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpResults.Size = new System.Drawing.Size(698, 240);
            this.grpResults.TabIndex = 2;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "ผลการค้นหา";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(2, 15);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(694, 223);
            this.dgvResults.TabIndex = 0;
            // 
            // panelProcess
            // 
            this.panelProcess.Controls.Add(this.btnCancel);
            this.panelProcess.Controls.Add(this.btnProcess);
            this.panelProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProcess.Location = new System.Drawing.Point(10, 466);
            this.panelProcess.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(698, 37);
            this.panelProcess.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(496, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(598, 2);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 32);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "ดำเนินการ";
            this.btnProcess.UseVisualStyleBackColor = false;
            // 
            // TroubleshooterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TroubleshooterControl";
            this.Size = new System.Drawing.Size(718, 513);
            this.tlpMain.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.tlpFilters.ResumeLayout(false);
            this.tlpFilters.PerformLayout();
            this.panelDateRange.ResumeLayout(false);
            this.panelDateRange.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.flpActions.ResumeLayout(false);
            this.grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panelProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.TableLayoutPanel tlpFilters;
        private System.Windows.Forms.Label lblQuotationSource;
        private System.Windows.Forms.TextBox txtQuotationSource;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Label lblQuotationDest;
        private System.Windows.Forms.TextBox txtQuotationDest;
        private System.Windows.Forms.Label lblManifest;
        private System.Windows.Forms.TextBox txtManifest;
        private System.Windows.Forms.CheckBox chkUseDateRange;
        private System.Windows.Forms.Panel panelDateRange;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnUnlockQuotation;
        private System.Windows.Forms.Button btnUpdateAddress;
        private System.Windows.Forms.Button btnDeleteAllBoxes;
        private System.Windows.Forms.Button btnFixShippingLocation;
        private System.Windows.Forms.Button btnFixShippingCost;
        private System.Windows.Forms.Button btnFixIncorrectShippingCost;
        private System.Windows.Forms.Button btnFixShippingCostType;
        private System.Windows.Forms.Button btnNewWaste;
        private System.Windows.Forms.Button btnNewWasteAdd;
        private System.Windows.Forms.Button btnChangeQuotation;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Panel panelProcess;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProcess;
    }
}
