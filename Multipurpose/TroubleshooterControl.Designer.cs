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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panelProcess = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.pnlActionsContainer = new System.Windows.Forms.Panel();
            this.flpVerticalActions = new System.Windows.Forms.FlowLayoutPanel();
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
            this.tlpMain.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.tlpFilters.SuspendLayout();
            this.panelDateRange.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panelProcess.SuspendLayout();
            this.pnlActionsContainer.SuspendLayout();
            this.flpVerticalActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpMain.Controls.Add(this.headerPanel, 0, 0);
            this.tlpMain.Controls.Add(this.grpFilters, 0, 1);
            this.tlpMain.Controls.Add(this.grpResults, 0, 2);
            this.tlpMain.Controls.Add(this.panelProcess, 0, 3);
            this.tlpMain.Controls.Add(this.pnlActionsContainer, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(784, 611);
            this.tlpMain.TabIndex = 1;
            // 
            // headerPanel
            // 
            this.tlpMain.SetColumnSpan(this.headerPanel, 2);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(13, 13);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(758, 44);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Troubleshooter";
            // 
            // grpFilters
            // 
            this.grpFilters.AutoSize = true;
            this.grpFilters.Controls.Add(this.tlpFilters);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilters.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilters.Location = new System.Drawing.Point(13, 63);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Padding = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.grpFilters.Size = new System.Drawing.Size(578, 164);
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "ตัวกรองข้อมูล";
            // 
            // tlpFilters
            // 
            this.tlpFilters.AutoSize = true;
            this.tlpFilters.ColumnCount = 5;
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFilters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilters.Controls.Add(this.txtQuotationSource, 1, 0);
            this.tlpFilters.Controls.Add(this.lblQuotationSource, 0, 0);
            this.tlpFilters.Controls.Add(this.lblArrow, 2, 0);
            this.tlpFilters.Controls.Add(this.lblQuotationDest, 3, 0);
            this.tlpFilters.Controls.Add(this.txtQuotationDest, 4, 0);
            this.tlpFilters.Controls.Add(this.lblManifest, 0, 1);
            this.tlpFilters.Controls.Add(this.txtManifest, 1, 1);
            this.tlpFilters.Controls.Add(this.panelDateRange, 0, 3);
            this.tlpFilters.Controls.Add(this.chkUseDateRange, 0, 2);
            this.tlpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilters.Location = new System.Drawing.Point(3, 21);
            this.tlpFilters.Name = "tlpFilters";
            this.tlpFilters.RowCount = 4;
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFilters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFilters.Size = new System.Drawing.Size(572, 135);
            this.tlpFilters.TabIndex = 0;
            // 
            // txtQuotationSource
            // 
            this.txtQuotationSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuotationSource.Location = new System.Drawing.Point(155, 3);
            this.txtQuotationSource.Name = "txtQuotationSource";
            this.txtQuotationSource.Size = new System.Drawing.Size(107, 25);
            this.txtQuotationSource.TabIndex = 1;
            // 
            // lblQuotationSource
            // 
            this.lblQuotationSource.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuotationSource.AutoSize = true;
            this.lblQuotationSource.Location = new System.Drawing.Point(3, 7);
            this.lblQuotationSource.Name = "lblQuotationSource";
            this.lblQuotationSource.Size = new System.Drawing.Size(146, 17);
            this.lblQuotationSource.TabIndex = 0;
            this.lblQuotationSource.Text = "Quotation ต้นทาง:";
            // 
            // lblArrow
            // 
            this.lblArrow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArrow.AutoSize = true;
            this.lblArrow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow.Location = new System.Drawing.Point(271, 5);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(27, 21);
            this.lblArrow.TabIndex = 2;
            this.lblArrow.Text = "→";
            // 
            // lblQuotationDest
            // 
            this.lblQuotationDest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuotationDest.AutoSize = true;
            this.lblQuotationDest.Location = new System.Drawing.Point(304, 7);
            this.lblQuotationDest.Name = "lblQuotationDest";
            this.lblQuotationDest.Size = new System.Drawing.Size(150, 17);
            this.lblQuotationDest.TabIndex = 3;
            this.lblQuotationDest.Text = "Quotation ปลายทาง:";
            // 
            // txtQuotationDest
            // 
            this.txtQuotationDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuotationDest.Location = new System.Drawing.Point(460, 3);
            this.txtQuotationDest.Name = "txtQuotationDest";
            this.txtQuotationDest.Size = new System.Drawing.Size(109, 25);
            this.txtQuotationDest.TabIndex = 4;
            // 
            // lblManifest
            // 
            this.lblManifest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblManifest.AutoSize = true;
            this.lblManifest.Location = new System.Drawing.Point(82, 38);
            this.lblManifest.Name = "lblManifest";
            this.lblManifest.Size = new System.Drawing.Size(67, 17);
            this.lblManifest.TabIndex = 5;
            this.lblManifest.Text = "Manifest:";
            // 
            // txtManifest
            // 
            this.txtManifest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFilters.SetColumnSpan(this.txtManifest, 4);
            this.txtManifest.Location = new System.Drawing.Point(155, 34);
            this.txtManifest.Name = "txtManifest";
            this.txtManifest.Size = new System.Drawing.Size(414, 25);
            this.txtManifest.TabIndex = 6;
            // 
            // panelDateRange
            // 
            this.tlpFilters.SetColumnSpan(this.panelDateRange, 5);
            this.panelDateRange.Controls.Add(this.dtpTo);
            this.panelDateRange.Controls.Add(this.lblToDate);
            this.panelDateRange.Controls.Add(this.dtpFrom);
            this.panelDateRange.Controls.Add(this.lblFromDate);
            this.panelDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDateRange.Enabled = false;
            this.panelDateRange.Location = new System.Drawing.Point(3, 93);
            this.panelDateRange.Name = "panelDateRange";
            this.panelDateRange.Size = new System.Drawing.Size(566, 39);
            this.panelDateRange.TabIndex = 8;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(267, 7);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(150, 25);
            this.dtpTo.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(210, 11);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(51, 17);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "ถึงวันที่:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(54, 7);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(150, 25);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(0, 11);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(48, 17);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "จากวันที่:";
            // 
            // chkUseDateRange
            // 
            this.chkUseDateRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkUseDateRange.AutoSize = true;
            this.tlpFilters.SetColumnSpan(this.chkUseDateRange, 5);
            this.chkUseDateRange.Location = new System.Drawing.Point(3, 65);
            this.chkUseDateRange.Name = "chkUseDateRange";
            this.chkUseDateRange.Size = new System.Drawing.Size(137, 21);
            this.chkUseDateRange.TabIndex = 7;
            this.chkUseDateRange.Text = "กำหนดช่วงเวลา";
            this.chkUseDateRange.UseVisualStyleBackColor = true;
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.dgvResults);
            this.grpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResults.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResults.Location = new System.Drawing.Point(13, 233);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(578, 415);
            this.grpResults.TabIndex = 3;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "ผลการค้นหา";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(3, 21);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(572, 391);
            this.dgvResults.TabIndex = 0;
            // 
            // panelProcess
            // 
            this.panelProcess.Controls.Add(this.btnCancel);
            this.panelProcess.Controls.Add(this.btnProcess);
            this.panelProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProcess.Location = new System.Drawing.Point(13, 554);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(578, 44);
            this.panelProcess.TabIndex = 4;
            this.panelProcess.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(369, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(475, 6);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(100, 35);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "ดำเนินการ";
            this.btnProcess.UseVisualStyleBackColor = false;
            // 
            // pnlActionsContainer
            // 
            this.pnlActionsContainer.AutoScroll = true;
            this.pnlActionsContainer.Controls.Add(this.flpVerticalActions);
            this.pnlActionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActionsContainer.Location = new System.Drawing.Point(617, 63);
            this.pnlActionsContainer.Name = "pnlActionsContainer";
            this.tlpMain.SetRowSpan(this.pnlActionsContainer, 2);
            this.pnlActionsContainer.Size = new System.Drawing.Size(154, 485);
            this.pnlActionsContainer.TabIndex = 5;
            // 
            // flpVerticalActions
            // 
            this.flpVerticalActions.AutoSize = true;
            this.flpVerticalActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpVerticalActions.Controls.Add(this.btnUnlockQuotation);
            this.flpVerticalActions.Controls.Add(this.btnUpdateAddress);
            this.flpVerticalActions.Controls.Add(this.btnDeleteAllBoxes);
            this.flpVerticalActions.Controls.Add(this.btnFixShippingLocation);
            this.flpVerticalActions.Controls.Add(this.btnFixShippingCost);
            this.flpVerticalActions.Controls.Add(this.btnFixIncorrectShippingCost);
            this.flpVerticalActions.Controls.Add(this.btnFixShippingCostType);
            this.flpVerticalActions.Controls.Add(this.btnNewWaste);
            this.flpVerticalActions.Controls.Add(this.btnNewWasteAdd);
            this.flpVerticalActions.Controls.Add(this.btnChangeQuotation);
            this.flpVerticalActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpVerticalActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpVerticalActions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.flpVerticalActions.Location = new System.Drawing.Point(0, 0);
            this.flpVerticalActions.Name = "flpVerticalActions";
            this.flpVerticalActions.Size = new System.Drawing.Size(150, 500);
            this.flpVerticalActions.TabIndex = 5;
            this.flpVerticalActions.WrapContents = false;
            // 
            // btnUnlockQuotation
            // 
            this.btnUnlockQuotation.Location = new System.Drawing.Point(5, 5);
            this.btnUnlockQuotation.Margin = new System.Windows.Forms.Padding(5);
            this.btnUnlockQuotation.Name = "btnUnlockQuotation";
            this.btnUnlockQuotation.Size = new System.Drawing.Size(140, 40);
            this.btnUnlockQuotation.TabIndex = 0;
            this.btnUnlockQuotation.Text = "ปลดล็อค Quotation";
            this.btnUnlockQuotation.UseVisualStyleBackColor = true;
            // 
            // btnUpdateAddress
            // 
            this.btnUpdateAddress.Location = new System.Drawing.Point(5, 55);
            this.btnUpdateAddress.Margin = new System.Windows.Forms.Padding(5);
            this.btnUpdateAddress.Name = "btnUpdateAddress";
            this.btnUpdateAddress.Size = new System.Drawing.Size(140, 40);
            this.btnUpdateAddress.TabIndex = 1;
            this.btnUpdateAddress.Text = "อัปเดตที่อยู่";
            this.btnUpdateAddress.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAllBoxes
            // 
            this.btnDeleteAllBoxes.Location = new System.Drawing.Point(5, 105);
            this.btnDeleteAllBoxes.Margin = new System.Windows.Forms.Padding(5);
            this.btnDeleteAllBoxes.Name = "btnDeleteAllBoxes";
            this.btnDeleteAllBoxes.Size = new System.Drawing.Size(140, 40);
            this.btnDeleteAllBoxes.TabIndex = 2;
            this.btnDeleteAllBoxes.Text = "ลบ Box ทั้งหมด";
            this.btnDeleteAllBoxes.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingLocation
            // 
            this.btnFixShippingLocation.Location = new System.Drawing.Point(5, 155);
            this.btnFixShippingLocation.Margin = new System.Windows.Forms.Padding(5);
            this.btnFixShippingLocation.Name = "btnFixShippingLocation";
            this.btnFixShippingLocation.Size = new System.Drawing.Size(140, 40);
            this.btnFixShippingLocation.TabIndex = 3;
            this.btnFixShippingLocation.Text = "สถานที่ขนส่งไม่ขึ้น";
            this.btnFixShippingLocation.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingCost
            // 
            this.btnFixShippingCost.Location = new System.Drawing.Point(5, 205);
            this.btnFixShippingCost.Margin = new System.Windows.Forms.Padding(5);
            this.btnFixShippingCost.Name = "btnFixShippingCost";
            this.btnFixShippingCost.Size = new System.Drawing.Size(140, 40);
            this.btnFixShippingCost.TabIndex = 4;
            this.btnFixShippingCost.Text = "ค่าขนส่งไม่ขึ้น";
            this.btnFixShippingCost.UseVisualStyleBackColor = true;
            // 
            // btnFixIncorrectShippingCost
            // 
            this.btnFixIncorrectShippingCost.Location = new System.Drawing.Point(5, 255);
            this.btnFixIncorrectShippingCost.Margin = new System.Windows.Forms.Padding(5);
            this.btnFixIncorrectShippingCost.Name = "btnFixIncorrectShippingCost";
            this.btnFixIncorrectShippingCost.Size = new System.Drawing.Size(140, 40);
            this.btnFixIncorrectShippingCost.TabIndex = 5;
            this.btnFixIncorrectShippingCost.Text = "ค่าขนส่งไม่ถูกต้อง";
            this.btnFixIncorrectShippingCost.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingCostType
            // 
            this.btnFixShippingCostType.Location = new System.Drawing.Point(5, 305);
            this.btnFixShippingCostType.Margin = new System.Windows.Forms.Padding(5);
            this.btnFixShippingCostType.Name = "btnFixShippingCostType";
            this.btnFixShippingCostType.Size = new System.Drawing.Size(140, 40);
            this.btnFixShippingCostType.TabIndex = 6;
            this.btnFixShippingCostType.Text = "ค่าขนส่งไม่ตรงประเภทรถ";
            this.btnFixShippingCostType.UseVisualStyleBackColor = true;
            // 
            // btnNewWaste
            // 
            this.btnNewWaste.Location = new System.Drawing.Point(5, 355);
            this.btnNewWaste.Margin = new System.Windows.Forms.Padding(5);
            this.btnNewWaste.Name = "btnNewWaste";
            this.btnNewWaste.Size = new System.Drawing.Size(140, 40);
            this.btnNewWaste.TabIndex = 7;
            this.btnNewWaste.Text = "New waste";
            this.btnNewWaste.UseVisualStyleBackColor = true;
            // 
            // btnNewWasteAdd
            // 
            this.btnNewWasteAdd.Location = new System.Drawing.Point(5, 405);
            this.btnNewWasteAdd.Margin = new System.Windows.Forms.Padding(5);
            this.btnNewWasteAdd.Name = "btnNewWasteAdd";
            this.btnNewWasteAdd.Size = new System.Drawing.Size(140, 40);
            this.btnNewWasteAdd.TabIndex = 8;
            this.btnNewWasteAdd.Text = "New waste ADD";
            this.btnNewWasteAdd.UseVisualStyleBackColor = true;
            // 
            // btnChangeQuotation
            // 
            this.btnChangeQuotation.Location = new System.Drawing.Point(5, 455);
            this.btnChangeQuotation.Margin = new System.Windows.Forms.Padding(5);
            this.btnChangeQuotation.Name = "btnChangeQuotation";
            this.btnChangeQuotation.Size = new System.Drawing.Size(140, 40);
            this.btnChangeQuotation.TabIndex = 9;
            this.btnChangeQuotation.Text = "เปลี่ยนใบเสนอราคา";
            this.btnChangeQuotation.UseVisualStyleBackColor = true;
            // 
            // TroubleshooterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpMain);
            this.Name = "TroubleshooterControl";
            this.Size = new System.Drawing.Size(784, 611);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.tlpFilters.ResumeLayout(false);
            this.tlpFilters.PerformLayout();
            this.panelDateRange.ResumeLayout(false);
            this.panelDateRange.PerformLayout();
            this.grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panelProcess.ResumeLayout(false);
            this.pnlActionsContainer.ResumeLayout(false);
            this.pnlActionsContainer.PerformLayout();
            this.flpVerticalActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox grpFilters;
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
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flpVerticalActions;
        private System.Windows.Forms.Panel pnlActionsContainer;
    }
}
