namespace Multipurpose
{
    partial class WindowsUpgradeControl
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
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentEdition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.btnRefreshStatus = new System.Windows.Forms.Button();
            this.grpTarget = new System.Windows.Forms.GroupBox();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.grpProcess = new System.Windows.Forms.GroupBox();
            this.lblProcessDescription = new System.Windows.Forms.Label();
            this.btnStartProcess = new System.Windows.Forms.Button();
            this.logPanel = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            this.grpTarget.SuspendLayout();
            this.grpProcess.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.headerPanel, 0, 0);
            this.tlpMain.Controls.Add(this.grpStatus, 0, 1);
            this.tlpMain.Controls.Add(this.grpTarget, 0, 2);
            this.tlpMain.Controls.Add(this.grpProcess, 0, 3);
            this.tlpMain.Controls.Add(this.logPanel, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(784, 561);
            this.tlpMain.TabIndex = 1;
            // 
            // headerPanel
            // 
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
            this.lblTitle.Size = new System.Drawing.Size(288, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Windows Upgrade && Activation";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.tlpStatus);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.Location = new System.Drawing.Point(13, 63);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(758, 85);
            this.grpStatus.TabIndex = 1;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "สถานะปัจจุบันของเครื่อง";
            // 
            // tlpStatus
            // 
            this.tlpStatus.ColumnCount = 3;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpStatus.Controls.Add(this.lblCurrentEdition, 1, 0);
            this.tlpStatus.Controls.Add(this.label1, 0, 0);
            this.tlpStatus.Controls.Add(this.label3, 0, 1);
            this.tlpStatus.Controls.Add(this.lblCurrentStatus, 1, 1);
            this.tlpStatus.Controls.Add(this.btnRefreshStatus, 2, 0);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(3, 21);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 2;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.Size = new System.Drawing.Size(752, 61);
            this.tlpStatus.TabIndex = 0;
            // 
            // lblCurrentEdition
            // 
            this.lblCurrentEdition.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentEdition.AutoSize = true;
            this.lblCurrentEdition.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentEdition.Location = new System.Drawing.Point(125, 6);
            this.lblCurrentEdition.Name = "lblCurrentEdition";
            this.lblCurrentEdition.Size = new System.Drawing.Size(63, 17);
            this.lblCurrentEdition.TabIndex = 1;
            this.lblCurrentEdition.Text = "Unknown";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows Edition:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "สถานะ Activate:";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.Location = new System.Drawing.Point(125, 37);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(63, 17);
            this.lblCurrentStatus.TabIndex = 3;
            this.lblCurrentStatus.Text = "Unknown";
            // 
            // btnRefreshStatus
            // 
            this.btnRefreshStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshStatus.Location = new System.Drawing.Point(649, 3);
            this.btnRefreshStatus.Name = "btnRefreshStatus";
            this.tlpStatus.SetRowSpan(this.btnRefreshStatus, 2);
            this.btnRefreshStatus.Size = new System.Drawing.Size(100, 40);
            this.btnRefreshStatus.TabIndex = 4;
            this.btnRefreshStatus.Text = "Refresh";
            this.btnRefreshStatus.UseVisualStyleBackColor = true;
            this.btnRefreshStatus.Click += new System.EventHandler(this.btnRefreshStatus_Click);
            // 
            // grpTarget
            // 
            this.grpTarget.Controls.Add(this.cboProducts);
            this.grpTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarget.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTarget.Location = new System.Drawing.Point(13, 154);
            this.grpTarget.Name = "grpTarget";
            this.grpTarget.Size = new System.Drawing.Size(758, 65);
            this.grpTarget.TabIndex = 2;
            this.grpTarget.TabStop = false;
            this.grpTarget.Text = "ผลิตภัณฑ์เป้าหมาย (Target Product)";
            // 
            // cboProducts
            // 
            this.cboProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(6, 24);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(746, 25);
            this.cboProducts.TabIndex = 0;
            this.cboProducts.SelectedIndexChanged += new System.EventHandler(this.cboProducts_SelectedIndexChanged);
            // 
            // grpProcess
            // 
            this.grpProcess.Controls.Add(this.lblProcessDescription);
            this.grpProcess.Controls.Add(this.btnStartProcess);
            this.grpProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcess.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProcess.Location = new System.Drawing.Point(13, 225);
            this.grpProcess.Name = "grpProcess";
            this.grpProcess.Size = new System.Drawing.Size(758, 110);
            this.grpProcess.TabIndex = 3;
            this.grpProcess.TabStop = false;
            this.grpProcess.Text = "ขั้นตอนดำเนินการ";
            // 
            // lblProcessDescription
            // 
            this.lblProcessDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcessDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessDescription.Location = new System.Drawing.Point(6, 21);
            this.lblProcessDescription.Name = "lblProcessDescription";
            this.lblProcessDescription.Size = new System.Drawing.Size(565, 86);
            this.lblProcessDescription.TabIndex = 0;
            this.lblProcessDescription.Text = "เลือกผลิตภัณฑ์เป้าหมายเพื่อดูขั้นตอนต่อไป";
            // 
            // btnStartProcess
            // 
            this.btnStartProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartProcess.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnStartProcess.Location = new System.Drawing.Point(577, 49);
            this.btnStartProcess.Name = "btnStartProcess";
            this.btnStartProcess.Size = new System.Drawing.Size(175, 55);
            this.btnStartProcess.TabIndex = 1;
            this.btnStartProcess.Text = "เริ่มดำเนินการ";
            this.btnStartProcess.UseVisualStyleBackColor = true;
            this.btnStartProcess.Click += new System.EventHandler(this.btnStartProcess_Click);
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.txtStatus);
            this.logPanel.Controls.Add(this.label6);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(13, 341);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(758, 207);
            this.logPanel.TabIndex = 4;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtStatus.Location = new System.Drawing.Point(0, 20);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(758, 187);
            this.txtStatus.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Status / Log:";
            // 
            // WindowsUpgradeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpMain);
            this.Name = "WindowsUpgradeControl";
            this.Size = new System.Drawing.Size(784, 561);
            this.Load += new System.EventHandler(this.WindowsUpgradeControl_Load);
            this.tlpMain.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.tlpStatus.ResumeLayout(false);
            this.tlpStatus.PerformLayout();
            this.grpTarget.ResumeLayout(false);
            this.grpProcess.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentEdition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Button btnRefreshStatus;
        private System.Windows.Forms.GroupBox grpTarget;
        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.GroupBox grpProcess;
        private System.Windows.Forms.Label lblProcessDescription;
        private System.Windows.Forms.Button btnStartProcess;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label6;
    }
}
