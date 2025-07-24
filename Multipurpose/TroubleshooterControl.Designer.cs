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
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblQuotationSource = new System.Windows.Forms.Label();
            this.txtQuotationSource = new System.Windows.Forms.TextBox();
            this.lblQuotationDest = new System.Windows.Forms.Label();
            this.txtQuotationDest = new System.Windows.Forms.TextBox();
            this.lblManifest = new System.Windows.Forms.Label();
            this.txtManifest = new System.Windows.Forms.TextBox();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.flpVerticalActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUnlockQuotation = new System.Windows.Forms.Button();
            this.btnFixShippingCostType = new System.Windows.Forms.Button();
            this.btnNewWaste = new System.Windows.Forms.Button();
            this.btnNewWasteAdd = new System.Windows.Forms.Button();
            this.btnChangeQuotation = new System.Windows.Forms.Button();
            this.btnDeleteAllBoxes = new System.Windows.Forms.Button();
            this.btnFixShippingLocation = new System.Windows.Forms.Button();
            this.btnFixShippingCost = new System.Windows.Forms.Button();
            this.btnUpdateAddress = new System.Windows.Forms.Button();
            this.btnChangeToNewCustomer = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panelProcess = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.grpFilters.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flpVerticalActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panelProcess.SuspendLayout();
            this.tlpMainLayout.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.tableLayoutPanel1);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilters.Location = new System.Drawing.Point(6, 6);
            this.grpFilters.Margin = new System.Windows.Forms.Padding(2);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Padding = new System.Windows.Forms.Padding(8);
            this.grpFilters.Size = new System.Drawing.Size(726, 81);
            this.grpFilters.TabIndex = 0;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "ตัวกรองข้อมูล";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblQuotationSource, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtQuotationSource, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblQuotationDest, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtQuotationDest, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblManifest, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtManifest, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblJobNo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtJobNo, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 49);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblQuotationSource
            // 
            this.lblQuotationSource.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuotationSource.AutoSize = true;
            this.lblQuotationSource.Location = new System.Drawing.Point(2, 4);
            this.lblQuotationSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuotationSource.Name = "lblQuotationSource";
            this.lblQuotationSource.Size = new System.Drawing.Size(106, 15);
            this.lblQuotationSource.TabIndex = 0;
            this.lblQuotationSource.Text = "Quotation (ต้นทาง):";
            // 
            // txtQuotationSource
            // 
            this.txtQuotationSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuotationSource.Location = new System.Drawing.Point(112, 2);
            this.txtQuotationSource.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuotationSource.Name = "txtQuotationSource";
            this.txtQuotationSource.Size = new System.Drawing.Size(236, 23);
            this.txtQuotationSource.TabIndex = 1;
            // 
            // lblQuotationDest
            // 
            this.lblQuotationDest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuotationDest.AutoSize = true;
            this.lblQuotationDest.Location = new System.Drawing.Point(352, 4);
            this.lblQuotationDest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuotationDest.Name = "lblQuotationDest";
            this.lblQuotationDest.Size = new System.Drawing.Size(116, 15);
            this.lblQuotationDest.TabIndex = 2;
            this.lblQuotationDest.Text = "Quotation (ปลายทาง):";
            // 
            // txtQuotationDest
            // 
            this.txtQuotationDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuotationDest.Location = new System.Drawing.Point(472, 2);
            this.txtQuotationDest.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuotationDest.Name = "txtQuotationDest";
            this.txtQuotationDest.Size = new System.Drawing.Size(236, 23);
            this.txtQuotationDest.TabIndex = 3;
            // 
            // lblManifest
            // 
            this.lblManifest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblManifest.AutoSize = true;
            this.lblManifest.Location = new System.Drawing.Point(33, 29);
            this.lblManifest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManifest.Name = "lblManifest";
            this.lblManifest.Size = new System.Drawing.Size(75, 15);
            this.lblManifest.TabIndex = 4;
            this.lblManifest.Text = "Manifest No:";
            // 
            // txtManifest
            // 
            this.txtManifest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManifest.Location = new System.Drawing.Point(112, 26);
            this.txtManifest.Margin = new System.Windows.Forms.Padding(2);
            this.txtManifest.Name = "txtManifest";
            this.txtManifest.Size = new System.Drawing.Size(236, 23);
            this.txtManifest.TabIndex = 5;
            // 
            // lblJobNo
            // 
            this.lblJobNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Location = new System.Drawing.Point(421, 29);
            this.lblJobNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(47, 15);
            this.lblJobNo.TabIndex = 6;
            this.lblJobNo.Text = "Job No:";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobNo.Location = new System.Drawing.Point(472, 26);
            this.txtJobNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(236, 23);
            this.txtJobNo.TabIndex = 7;
            // 
            // flpVerticalActions
            // 
            this.flpVerticalActions.Controls.Add(this.btnUnlockQuotation);
            this.flpVerticalActions.Controls.Add(this.btnFixShippingCostType);
            this.flpVerticalActions.Controls.Add(this.btnNewWaste);
            this.flpVerticalActions.Controls.Add(this.btnNewWasteAdd);
            this.flpVerticalActions.Controls.Add(this.btnChangeQuotation);
            this.flpVerticalActions.Controls.Add(this.btnDeleteAllBoxes);
            this.flpVerticalActions.Controls.Add(this.btnFixShippingLocation);
            this.flpVerticalActions.Controls.Add(this.btnFixShippingCost);
            this.flpVerticalActions.Controls.Add(this.btnUpdateAddress);
            this.flpVerticalActions.Controls.Add(this.btnChangeToNewCustomer);
            this.flpVerticalActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpVerticalActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpVerticalActions.Location = new System.Drawing.Point(557, 2);
            this.flpVerticalActions.Margin = new System.Windows.Forms.Padding(2);
            this.flpVerticalActions.Name = "flpVerticalActions";
            this.flpVerticalActions.Size = new System.Drawing.Size(167, 375);
            this.flpVerticalActions.TabIndex = 1;
            this.flpVerticalActions.WrapContents = false;
            // 
            // btnUnlockQuotation
            // 
            this.btnUnlockQuotation.Location = new System.Drawing.Point(2, 2);
            this.btnUnlockQuotation.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnlockQuotation.Name = "btnUnlockQuotation";
            this.btnUnlockQuotation.Size = new System.Drawing.Size(150, 28);
            this.btnUnlockQuotation.TabIndex = 0;
            this.btnUnlockQuotation.Text = "ปลดล็อค Quotation";
            this.btnUnlockQuotation.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingCostType
            // 
            this.btnFixShippingCostType.Location = new System.Drawing.Point(2, 34);
            this.btnFixShippingCostType.Margin = new System.Windows.Forms.Padding(2);
            this.btnFixShippingCostType.Name = "btnFixShippingCostType";
            this.btnFixShippingCostType.Size = new System.Drawing.Size(150, 28);
            this.btnFixShippingCostType.TabIndex = 1;
            this.btnFixShippingCostType.Text = "ค่าขนส่งไม่ตรงประเภทรถ";
            this.btnFixShippingCostType.UseVisualStyleBackColor = true;
            // 
            // btnNewWaste
            // 
            this.btnNewWaste.Location = new System.Drawing.Point(2, 66);
            this.btnNewWaste.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewWaste.Name = "btnNewWaste";
            this.btnNewWaste.Size = new System.Drawing.Size(150, 28);
            this.btnNewWaste.TabIndex = 2;
            this.btnNewWaste.Text = "New waste";
            this.btnNewWaste.UseVisualStyleBackColor = true;
            // 
            // btnNewWasteAdd
            // 
            this.btnNewWasteAdd.Location = new System.Drawing.Point(2, 98);
            this.btnNewWasteAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewWasteAdd.Name = "btnNewWasteAdd";
            this.btnNewWasteAdd.Size = new System.Drawing.Size(150, 28);
            this.btnNewWasteAdd.TabIndex = 3;
            this.btnNewWasteAdd.Text = "New waste ADD";
            this.btnNewWasteAdd.UseVisualStyleBackColor = true;
            // 
            // btnChangeQuotation
            // 
            this.btnChangeQuotation.Location = new System.Drawing.Point(2, 130);
            this.btnChangeQuotation.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeQuotation.Name = "btnChangeQuotation";
            this.btnChangeQuotation.Size = new System.Drawing.Size(150, 28);
            this.btnChangeQuotation.TabIndex = 4;
            this.btnChangeQuotation.Text = "เปลี่ยนใบเสนอราคา";
            this.btnChangeQuotation.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAllBoxes
            // 
            this.btnDeleteAllBoxes.Location = new System.Drawing.Point(2, 162);
            this.btnDeleteAllBoxes.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteAllBoxes.Name = "btnDeleteAllBoxes";
            this.btnDeleteAllBoxes.Size = new System.Drawing.Size(150, 28);
            this.btnDeleteAllBoxes.TabIndex = 5;
            this.btnDeleteAllBoxes.Text = "ลบ Box ทั้งหมด";
            this.btnDeleteAllBoxes.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingLocation
            // 
            this.btnFixShippingLocation.Location = new System.Drawing.Point(2, 194);
            this.btnFixShippingLocation.Margin = new System.Windows.Forms.Padding(2);
            this.btnFixShippingLocation.Name = "btnFixShippingLocation";
            this.btnFixShippingLocation.Size = new System.Drawing.Size(150, 28);
            this.btnFixShippingLocation.TabIndex = 6;
            this.btnFixShippingLocation.Text = "สถานที่ขนส่งไม่ขึ้น";
            this.btnFixShippingLocation.UseVisualStyleBackColor = true;
            // 
            // btnFixShippingCost
            // 
            this.btnFixShippingCost.Location = new System.Drawing.Point(2, 226);
            this.btnFixShippingCost.Margin = new System.Windows.Forms.Padding(2);
            this.btnFixShippingCost.Name = "btnFixShippingCost";
            this.btnFixShippingCost.Size = new System.Drawing.Size(150, 28);
            this.btnFixShippingCost.TabIndex = 7;
            this.btnFixShippingCost.Text = "ค่าขนส่งไม่ขึ้น";
            this.btnFixShippingCost.UseVisualStyleBackColor = true;
            // 
            // btnUpdateAddress
            // 
            this.btnUpdateAddress.Location = new System.Drawing.Point(2, 258);
            this.btnUpdateAddress.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateAddress.Name = "btnUpdateAddress";
            this.btnUpdateAddress.Size = new System.Drawing.Size(150, 28);
            this.btnUpdateAddress.TabIndex = 8;
            this.btnUpdateAddress.Text = "อัปเดตที่อยู่";
            this.btnUpdateAddress.UseVisualStyleBackColor = true;
            // 
            // btnChangeToNewCustomer
            // 
            this.btnChangeToNewCustomer.Location = new System.Drawing.Point(2, 290);
            this.btnChangeToNewCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeToNewCustomer.Name = "btnChangeToNewCustomer";
            this.btnChangeToNewCustomer.Size = new System.Drawing.Size(150, 28);
            this.btnChangeToNewCustomer.TabIndex = 9;
            this.btnChangeToNewCustomer.Text = "กำหนดลูกค้าใหม่";
            this.btnChangeToNewCustomer.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(2);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.Size = new System.Drawing.Size(551, 334);
            this.dgvResults.TabIndex = 2;
            // 
            // panelProcess
            // 
            this.panelProcess.Controls.Add(this.btnCancel);
            this.panelProcess.Controls.Add(this.btnProcess);
            this.panelProcess.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProcess.Location = new System.Drawing.Point(0, 334);
            this.panelProcess.Margin = new System.Windows.Forms.Padding(2);
            this.panelProcess.Name = "panelProcess";
            this.panelProcess.Size = new System.Drawing.Size(551, 41);
            this.panelProcess.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(409, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(477, 7);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(2);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(64, 24);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "ดำเนินการ";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // tlpMainLayout
            // 
            this.tlpMainLayout.ColumnCount = 2;
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMainLayout.Controls.Add(this.flpVerticalActions, 1, 0);
            this.tlpMainLayout.Controls.Add(this.pnlMainContent, 0, 0);
            this.tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainLayout.Location = new System.Drawing.Point(6, 87);
            this.tlpMainLayout.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMainLayout.Name = "tlpMainLayout";
            this.tlpMainLayout.RowCount = 1;
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.Size = new System.Drawing.Size(726, 379);
            this.tlpMainLayout.TabIndex = 4;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.dgvResults);
            this.pnlMainContent.Controls.Add(this.panelProcess);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(2, 2);
            this.pnlMainContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(551, 375);
            this.pnlMainContent.TabIndex = 2;
            // 
            // TroubleshooterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpMainLayout);
            this.Controls.Add(this.grpFilters);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TroubleshooterControl";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(738, 472);
            this.grpFilters.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flpVerticalActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panelProcess.ResumeLayout(false);
            this.tlpMainLayout.ResumeLayout(false);
            this.pnlMainContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.FlowLayoutPanel flpVerticalActions;
        private System.Windows.Forms.Button btnUnlockQuotation;
        private System.Windows.Forms.Button btnFixShippingCostType;
        private System.Windows.Forms.Button btnNewWaste;
        private System.Windows.Forms.Button btnNewWasteAdd;
        private System.Windows.Forms.Button btnChangeQuotation;
        private System.Windows.Forms.Button btnDeleteAllBoxes;
        private System.Windows.Forms.Button btnFixShippingLocation;
        private System.Windows.Forms.Button btnFixShippingCost;
        private System.Windows.Forms.Button btnUpdateAddress;
        private System.Windows.Forms.Button btnChangeToNewCustomer;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Panel panelProcess;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblQuotationSource;
        private System.Windows.Forms.TextBox txtQuotationSource;
        private System.Windows.Forms.Label lblQuotationDest;
        private System.Windows.Forms.TextBox txtQuotationDest;
        private System.Windows.Forms.Label lblManifest;
        private System.Windows.Forms.TextBox txtManifest;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;
        private System.Windows.Forms.Panel pnlMainContent;
    }
}
