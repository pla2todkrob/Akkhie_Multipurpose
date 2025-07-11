namespace Multipurpose
{
    partial class OfficeToolsControl
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
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.statusTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentStatusValue = new System.Windows.Forms.Label();
            this.lblCurrentStatusLabel = new System.Windows.Forms.Label();
            this.lblCurrentProductNameValue = new System.Windows.Forms.Label();
            this.lblCurrentProductNameLabel = new System.Windows.Forms.Label();
            this.btnRefreshStatus = new System.Windows.Forms.Button();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.actionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cboOfficeProducts = new System.Windows.Forms.ComboBox();
            this.lblSelectProduct = new System.Windows.Forms.Label();
            this.btnActivateOffice = new System.Windows.Forms.Button();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.mainTableLayoutPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.statusTableLayoutPanel.SuspendLayout();
            this.actionsGroupBox.SuspendLayout();
            this.actionsTableLayoutPanel.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.headerPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.statusGroupBox, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.actionsGroupBox, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.logGroupBox, 0, 3);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainTableLayoutPanel.RowCount = 4;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(758, 533);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(13, 13);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(732, 44);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(131, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Office Tools";
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.AutoSize = true;
            this.statusGroupBox.Controls.Add(this.statusTableLayoutPanel);
            this.statusGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusGroupBox.Location = new System.Drawing.Point(13, 63);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.statusGroupBox.Size = new System.Drawing.Size(732, 102);
            this.statusGroupBox.TabIndex = 1;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Current Status";
            // 
            // statusTableLayoutPanel
            // 
            this.statusTableLayoutPanel.ColumnCount = 3;
            this.statusTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.statusTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statusTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.statusTableLayoutPanel.Controls.Add(this.lblCurrentStatusValue, 1, 1);
            this.statusTableLayoutPanel.Controls.Add(this.lblCurrentStatusLabel, 0, 1);
            this.statusTableLayoutPanel.Controls.Add(this.lblCurrentProductNameValue, 1, 0);
            this.statusTableLayoutPanel.Controls.Add(this.lblCurrentProductNameLabel, 0, 0);
            this.statusTableLayoutPanel.Controls.Add(this.btnRefreshStatus, 2, 0);
            this.statusTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusTableLayoutPanel.Location = new System.Drawing.Point(3, 21);
            this.statusTableLayoutPanel.Name = "statusTableLayoutPanel";
            this.statusTableLayoutPanel.RowCount = 2;
            this.statusTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statusTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statusTableLayoutPanel.Size = new System.Drawing.Size(726, 70);
            this.statusTableLayoutPanel.TabIndex = 0;
            // 
            // lblCurrentStatusValue
            // 
            this.lblCurrentStatusValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentStatusValue.AutoSize = true;
            this.lblCurrentStatusValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatusValue.Location = new System.Drawing.Point(105, 44);
            this.lblCurrentStatusValue.Name = "lblCurrentStatusValue";
            this.lblCurrentStatusValue.Size = new System.Drawing.Size(60, 17);
            this.lblCurrentStatusValue.TabIndex = 3;
            this.lblCurrentStatusValue.Text = "Loading...";
            // 
            // lblCurrentStatusLabel
            // 
            this.lblCurrentStatusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentStatusLabel.AutoSize = true;
            this.lblCurrentStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatusLabel.Location = new System.Drawing.Point(3, 44);
            this.lblCurrentStatusLabel.Name = "lblCurrentStatusLabel";
            this.lblCurrentStatusLabel.Size = new System.Drawing.Size(96, 17);
            this.lblCurrentStatusLabel.TabIndex = 2;
            this.lblCurrentStatusLabel.Text = "License Status:";
            // 
            // lblCurrentProductNameValue
            // 
            this.lblCurrentProductNameValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentProductNameValue.AutoSize = true;
            this.lblCurrentProductNameValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentProductNameValue.Location = new System.Drawing.Point(105, 9);
            this.lblCurrentProductNameValue.Name = "lblCurrentProductNameValue";
            this.lblCurrentProductNameValue.Size = new System.Drawing.Size(60, 17);
            this.lblCurrentProductNameValue.TabIndex = 1;
            this.lblCurrentProductNameValue.Text = "Loading...";
            // 
            // lblCurrentProductNameLabel
            // 
            this.lblCurrentProductNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentProductNameLabel.AutoSize = true;
            this.lblCurrentProductNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentProductNameLabel.Location = new System.Drawing.Point(3, 9);
            this.lblCurrentProductNameLabel.Name = "lblCurrentProductNameLabel";
            this.lblCurrentProductNameLabel.Size = new System.Drawing.Size(96, 17);
            this.lblCurrentProductNameLabel.TabIndex = 0;
            this.lblCurrentProductNameLabel.Text = "Product Name:";
            // 
            // btnRefreshStatus
            // 
            this.btnRefreshStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshStatus.Location = new System.Drawing.Point(623, 3);
            this.btnRefreshStatus.Name = "btnRefreshStatus";
            this.statusTableLayoutPanel.SetRowSpan(this.btnRefreshStatus, 2);
            this.btnRefreshStatus.Size = new System.Drawing.Size(100, 35);
            this.btnRefreshStatus.TabIndex = 4;
            this.btnRefreshStatus.Text = "Refresh";
            this.btnRefreshStatus.UseVisualStyleBackColor = true;
            this.btnRefreshStatus.Click += new System.EventHandler(this.btnRefreshStatus_Click);
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.AutoSize = true;
            this.actionsGroupBox.Controls.Add(this.actionsTableLayoutPanel);
            this.actionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionsGroupBox.Location = new System.Drawing.Point(13, 171);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(732, 76);
            this.actionsGroupBox.TabIndex = 2;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Actions";
            // 
            // actionsTableLayoutPanel
            // 
            this.actionsTableLayoutPanel.AutoSize = true;
            this.actionsTableLayoutPanel.ColumnCount = 3;
            this.actionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.actionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.actionsTableLayoutPanel.Controls.Add(this.cboOfficeProducts, 1, 0);
            this.actionsTableLayoutPanel.Controls.Add(this.lblSelectProduct, 0, 0);
            this.actionsTableLayoutPanel.Controls.Add(this.btnActivateOffice, 2, 0);
            this.actionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsTableLayoutPanel.Location = new System.Drawing.Point(3, 21);
            this.actionsTableLayoutPanel.Name = "actionsTableLayoutPanel";
            this.actionsTableLayoutPanel.RowCount = 1;
            this.actionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionsTableLayoutPanel.Size = new System.Drawing.Size(726, 52);
            this.actionsTableLayoutPanel.TabIndex = 0;
            // 
            // cboOfficeProducts
            // 
            this.cboOfficeProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOfficeProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOfficeProducts.FormattingEnabled = true;
            this.cboOfficeProducts.Location = new System.Drawing.Point(105, 13);
            this.cboOfficeProducts.Name = "cboOfficeProducts";
            this.cboOfficeProducts.Size = new System.Drawing.Size(512, 25);
            this.cboOfficeProducts.TabIndex = 1;
            // 
            // lblSelectProduct
            // 
            this.lblSelectProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSelectProduct.AutoSize = true;
            this.lblSelectProduct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectProduct.Location = new System.Drawing.Point(3, 17);
            this.lblSelectProduct.Name = "lblSelectProduct";
            this.lblSelectProduct.Size = new System.Drawing.Size(96, 17);
            this.lblSelectProduct.TabIndex = 0;
            this.lblSelectProduct.Text = "Select Product:";
            // 
            // btnActivateOffice
            // 
            this.btnActivateOffice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActivateOffice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivateOffice.Location = new System.Drawing.Point(623, 8);
            this.btnActivateOffice.Name = "btnActivateOffice";
            this.btnActivateOffice.Size = new System.Drawing.Size(100, 35);
            this.btnActivateOffice.TabIndex = 2;
            this.btnActivateOffice.Text = "Activate";
            this.btnActivateOffice.UseVisualStyleBackColor = true;
            this.btnActivateOffice.Click += new System.EventHandler(this.btnActivateOffice_Click);
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.txtStatus);
            this.logGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logGroupBox.Location = new System.Drawing.Point(13, 253);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(732, 267);
            this.logGroupBox.TabIndex = 3;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtStatus.Location = new System.Drawing.Point(3, 21);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(726, 243);
            this.txtStatus.TabIndex = 0;
            // 
            // OfficeToolsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "OfficeToolsControl";
            this.Size = new System.Drawing.Size(758, 533);
            this.Load += new System.EventHandler(this.OfficeToolsControl_Load);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.statusTableLayoutPanel.ResumeLayout(false);
            this.statusTableLayoutPanel.PerformLayout();
            this.actionsGroupBox.ResumeLayout(false);
            this.actionsGroupBox.PerformLayout();
            this.actionsTableLayoutPanel.ResumeLayout(false);
            this.actionsTableLayoutPanel.PerformLayout();
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TableLayoutPanel statusTableLayoutPanel;
        private System.Windows.Forms.Label lblCurrentProductNameLabel;
        private System.Windows.Forms.Label lblCurrentStatusValue;
        private System.Windows.Forms.Label lblCurrentStatusLabel;
        private System.Windows.Forms.Label lblCurrentProductNameValue;
        private System.Windows.Forms.Button btnRefreshStatus;
        private System.Windows.Forms.TableLayoutPanel actionsTableLayoutPanel;
        private System.Windows.Forms.ComboBox cboOfficeProducts;
        private System.Windows.Forms.Label lblSelectProduct;
        private System.Windows.Forms.Button btnActivateOffice;
    }
}
