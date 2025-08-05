namespace Multipurpose
{
    partial class WindowsSettingsControl
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
            this.components = new System.ComponentModel.Container();
            this.grpOdbc = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelOdbc = new System.Windows.Forms.TableLayoutPanel();
            this.lblOdbcDsnName = new System.Windows.Forms.Label();
            this.txtOdbcDsnName = new System.Windows.Forms.TextBox();
            this.lblOdbcServer = new System.Windows.Forms.Label();
            this.txtOdbcServer = new System.Windows.Forms.TextBox();
            this.lblOdbcDb = new System.Windows.Forms.Label();
            this.txtOdbcDb = new System.Windows.Forms.TextBox();
            this.lblOdbcUid = new System.Windows.Forms.Label();
            this.txtOdbcUid = new System.Windows.Forms.TextBox();
            this.lblOdbcPwd = new System.Windows.Forms.Label();
            this.txtOdbcPwd = new System.Windows.Forms.TextBox();
            this.btnCreateOdbc = new System.Windows.Forms.Button();
            this.grpLocalization = new System.Windows.Forms.GroupBox();
            this.lblLocalizationInfo = new System.Windows.Forms.Label();
            this.radLangSwitchAltShift = new System.Windows.Forms.RadioButton();
            this.radLangSwitchGrave = new System.Windows.Forms.RadioButton();
            this.btnSetLocalization = new System.Windows.Forms.Button();
            this.grpFonts = new System.Windows.Forms.GroupBox();
            this.listViewFonts = new System.Windows.Forms.ListView();
            this.btnInstallFonts = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.grpOdbc.SuspendLayout();
            this.tableLayoutPanelOdbc.SuspendLayout();
            this.grpLocalization.SuspendLayout();
            this.grpFonts.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOdbc
            // 
            this.grpOdbc.Controls.Add(this.tableLayoutPanelOdbc);
            this.grpOdbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOdbc.Location = new System.Drawing.Point(3, 3);
            this.grpOdbc.Name = "grpOdbc";
            this.grpOdbc.Padding = new System.Windows.Forms.Padding(10);
            this.mainTableLayoutPanel.SetRowSpan(this.grpOdbc, 2);
            this.grpOdbc.Size = new System.Drawing.Size(479, 224);
            this.grpOdbc.TabIndex = 0;
            this.grpOdbc.TabStop = false;
            this.grpOdbc.Text = "ODBC Settings (System DSN)";
            // 
            // tableLayoutPanelOdbc
            // 
            this.tableLayoutPanelOdbc.ColumnCount = 2;
            this.tableLayoutPanelOdbc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOdbc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOdbc.Controls.Add(this.lblOdbcDsnName, 0, 0);
            this.tableLayoutPanelOdbc.Controls.Add(this.txtOdbcDsnName, 1, 0);
            this.tableLayoutPanelOdbc.Controls.Add(this.lblOdbcServer, 0, 1);
            this.tableLayoutPanelOdbc.Controls.Add(this.txtOdbcServer, 1, 1);
            this.tableLayoutPanelOdbc.Controls.Add(this.lblOdbcDb, 0, 2);
            this.tableLayoutPanelOdbc.Controls.Add(this.txtOdbcDb, 1, 2);
            this.tableLayoutPanelOdbc.Controls.Add(this.lblOdbcUid, 0, 3);
            this.tableLayoutPanelOdbc.Controls.Add(this.txtOdbcUid, 1, 3);
            this.tableLayoutPanelOdbc.Controls.Add(this.lblOdbcPwd, 0, 4);
            this.tableLayoutPanelOdbc.Controls.Add(this.txtOdbcPwd, 1, 4);
            this.tableLayoutPanelOdbc.Controls.Add(this.btnCreateOdbc, 1, 5);
            this.tableLayoutPanelOdbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOdbc.Location = new System.Drawing.Point(10, 25);
            this.tableLayoutPanelOdbc.Name = "tableLayoutPanelOdbc";
            this.tableLayoutPanelOdbc.RowCount = 6;
            this.tableLayoutPanelOdbc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOdbc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOdbc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOdbc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOdbc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOdbc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOdbc.Size = new System.Drawing.Size(459, 189);
            this.tableLayoutPanelOdbc.TabIndex = 0;
            // 
            // lblOdbcDsnName
            // 
            this.lblOdbcDsnName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOdbcDsnName.AutoSize = true;
            this.lblOdbcDsnName.Location = new System.Drawing.Point(3, 7);
            this.lblOdbcDsnName.Name = "lblOdbcDsnName";
            this.lblOdbcDsnName.Size = new System.Drawing.Size(78, 16);
            this.lblOdbcDsnName.TabIndex = 0;
            this.lblOdbcDsnName.Text = "DSN Name:";
            // 
            // txtOdbcDsnName
            // 
            this.txtOdbcDsnName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcDsnName.Location = new System.Drawing.Point(87, 4);
            this.txtOdbcDsnName.Name = "txtOdbcDsnName";
            this.txtOdbcDsnName.Size = new System.Drawing.Size(369, 22);
            this.txtOdbcDsnName.TabIndex = 1;
            // 
            // lblOdbcServer
            // 
            this.lblOdbcServer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOdbcServer.AutoSize = true;
            this.lblOdbcServer.Location = new System.Drawing.Point(32, 37);
            this.lblOdbcServer.Name = "lblOdbcServer";
            this.lblOdbcServer.Size = new System.Drawing.Size(49, 16);
            this.lblOdbcServer.TabIndex = 2;
            this.lblOdbcServer.Text = "Server:";
            // 
            // txtOdbcServer
            // 
            this.txtOdbcServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcServer.Location = new System.Drawing.Point(87, 34);
            this.txtOdbcServer.Name = "txtOdbcServer";
            this.txtOdbcServer.Size = new System.Drawing.Size(369, 22);
            this.txtOdbcServer.TabIndex = 3;
            // 
            // lblOdbcDb
            // 
            this.lblOdbcDb.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOdbcDb.AutoSize = true;
            this.lblOdbcDb.Location = new System.Drawing.Point(13, 67);
            this.lblOdbcDb.Name = "lblOdbcDb";
            this.lblOdbcDb.Size = new System.Drawing.Size(68, 16);
            this.lblOdbcDb.TabIndex = 4;
            this.lblOdbcDb.Text = "Database:";
            // 
            // txtOdbcDb
            // 
            this.txtOdbcDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcDb.Location = new System.Drawing.Point(87, 64);
            this.txtOdbcDb.Name = "txtOdbcDb";
            this.txtOdbcDb.Size = new System.Drawing.Size(369, 22);
            this.txtOdbcDb.TabIndex = 5;
            // 
            // lblOdbcUid
            // 
            this.lblOdbcUid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOdbcUid.AutoSize = true;
            this.lblOdbcUid.Location = new System.Drawing.Point(48, 97);
            this.lblOdbcUid.Name = "lblOdbcUid";
            this.lblOdbcUid.Size = new System.Drawing.Size(33, 16);
            this.lblOdbcUid.TabIndex = 6;
            this.lblOdbcUid.Text = "UID:";
            // 
            // txtOdbcUid
            // 
            this.txtOdbcUid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcUid.Location = new System.Drawing.Point(87, 94);
            this.txtOdbcUid.Name = "txtOdbcUid";
            this.txtOdbcUid.Size = new System.Drawing.Size(369, 22);
            this.txtOdbcUid.TabIndex = 7;
            // 
            // lblOdbcPwd
            // 
            this.lblOdbcPwd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOdbcPwd.AutoSize = true;
            this.lblOdbcPwd.Location = new System.Drawing.Point(41, 127);
            this.lblOdbcPwd.Name = "lblOdbcPwd";
            this.lblOdbcPwd.Size = new System.Drawing.Size(40, 16);
            this.lblOdbcPwd.TabIndex = 8;
            this.lblOdbcPwd.Text = "PWD:";
            // 
            // txtOdbcPwd
            // 
            this.txtOdbcPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcPwd.Location = new System.Drawing.Point(87, 124);
            this.txtOdbcPwd.Name = "txtOdbcPwd";
            this.txtOdbcPwd.PasswordChar = '*';
            this.txtOdbcPwd.Size = new System.Drawing.Size(369, 22);
            this.txtOdbcPwd.TabIndex = 9;
            // 
            // btnCreateOdbc
            // 
            this.btnCreateOdbc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreateOdbc.Location = new System.Drawing.Point(281, 154);
            this.btnCreateOdbc.Name = "btnCreateOdbc";
            this.btnCreateOdbc.Size = new System.Drawing.Size(175, 29);
            this.btnCreateOdbc.TabIndex = 10;
            this.btnCreateOdbc.Text = "Create / Update DSN";
            this.btnCreateOdbc.UseVisualStyleBackColor = true;
            this.btnCreateOdbc.Click += new System.EventHandler(this.btnCreateOdbc_Click);
            // 
            // grpLocalization
            // 
            this.grpLocalization.Controls.Add(this.lblLocalizationInfo);
            this.grpLocalization.Controls.Add(this.radLangSwitchAltShift);
            this.grpLocalization.Controls.Add(this.radLangSwitchGrave);
            this.grpLocalization.Controls.Add(this.btnSetLocalization);
            this.grpLocalization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLocalization.Location = new System.Drawing.Point(3, 233);
            this.grpLocalization.Name = "grpLocalization";
            this.grpLocalization.Size = new System.Drawing.Size(479, 104);
            this.grpLocalization.TabIndex = 1;
            this.grpLocalization.TabStop = false;
            this.grpLocalization.Text = "Localization (TH/EN)";
            // 
            // lblLocalizationInfo
            // 
            this.lblLocalizationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalizationInfo.Location = new System.Drawing.Point(17, 22);
            this.lblLocalizationInfo.Name = "lblLocalizationInfo";
            this.lblLocalizationInfo.Size = new System.Drawing.Size(271, 41);
            this.lblLocalizationInfo.TabIndex = 3;
            this.lblLocalizationInfo.Text = "ตั้งค่า Region, Time Zone, Keyboard Layouts (EN/TH) และปุ่มสลับภาษาให้เป็นมาตรฐาน" +
    "ประเทศไทย";
            // 
            // radLangSwitchAltShift
            // 
            this.radLangSwitchAltShift.AutoSize = true;
            this.radLangSwitchAltShift.Location = new System.Drawing.Point(130, 71);
            this.radLangSwitchAltShift.Name = "radLangSwitchAltShift";
            this.radLangSwitchAltShift.Size = new System.Drawing.Size(117, 20);
            this.radLangSwitchAltShift.TabIndex = 1;
            this.radLangSwitchAltShift.Text = "Alt + Shift (ปกติ)";
            this.radLangSwitchAltShift.UseVisualStyleBackColor = true;
            // 
            // radLangSwitchGrave
            // 
            this.radLangSwitchGrave.AutoSize = true;
            this.radLangSwitchGrave.Checked = true;
            this.radLangSwitchGrave.Location = new System.Drawing.Point(20, 71);
            this.radLangSwitchGrave.Name = "radLangSwitchGrave";
            this.radLangSwitchGrave.Size = new System.Drawing.Size(100, 20);
            this.radLangSwitchGrave.TabIndex = 0;
            this.radLangSwitchGrave.TabStop = true;
            this.radLangSwitchGrave.Text = "~ (ตัวหนอน)";
            this.radLangSwitchGrave.UseVisualStyleBackColor = true;
            // 
            // btnSetLocalization
            // 
            this.btnSetLocalization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetLocalization.Location = new System.Drawing.Point(294, 33);
            this.btnSetLocalization.Name = "btnSetLocalization";
            this.btnSetLocalization.Size = new System.Drawing.Size(175, 48);
            this.btnSetLocalization.TabIndex = 2;
            this.btnSetLocalization.Text = "Apply Localization";
            this.btnSetLocalization.UseVisualStyleBackColor = true;
            this.btnSetLocalization.Click += new System.EventHandler(this.btnSetLocalization_Click);
            // 
            // grpFonts
            // 
            this.grpFonts.Controls.Add(this.listViewFonts);
            this.grpFonts.Controls.Add(this.btnInstallFonts);
            this.grpFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFonts.Location = new System.Drawing.Point(488, 3);
            this.grpFonts.Name = "grpFonts";
            this.mainTableLayoutPanel.SetRowSpan(this.grpFonts, 2);
            this.grpFonts.Size = new System.Drawing.Size(480, 224);
            this.grpFonts.TabIndex = 2;
            this.grpFonts.TabStop = false;
            this.grpFonts.Text = "Install Fonts";
            // 
            // listViewFonts
            // 
            this.listViewFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFonts.HideSelection = false;
            this.listViewFonts.Location = new System.Drawing.Point(15, 25);
            this.listViewFonts.Name = "listViewFonts";
            this.listViewFonts.Size = new System.Drawing.Size(275, 184);
            this.listViewFonts.TabIndex = 0;
            this.listViewFonts.UseCompatibleStateImageBehavior = false;
            this.listViewFonts.View = System.Windows.Forms.View.List;
            // 
            // btnInstallFonts
            // 
            this.btnInstallFonts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallFonts.Location = new System.Drawing.Point(296, 25);
            this.btnInstallFonts.Name = "btnInstallFonts";
            this.btnInstallFonts.Size = new System.Drawing.Size(175, 184);
            this.btnInstallFonts.TabIndex = 1;
            this.btnInstallFonts.Text = "Install All Fonts";
            this.btnInstallFonts.UseVisualStyleBackColor = true;
            this.btnInstallFonts.Click += new System.EventHandler(this.btnInstallFonts_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.InfoText;
            this.mainTableLayoutPanel.SetColumnSpan(this.txtStatus, 2);
            this.txtStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtStatus.Location = new System.Drawing.Point(3, 343);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(965, 224);
            this.txtStatus.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(863, 573);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.btnCancel, "Cancel any running operation");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainTableLayoutPanel.Controls.Add(this.grpOdbc, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.grpFonts, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.grpLocalization, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.txtStatus, 0, 3);
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 4;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(971, 570);
            this.mainTableLayoutPanel.TabIndex = 6;
            // 
            // WindowsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.btnCancel);
            this.Name = "WindowsSettingsControl";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(995, 595);
            this.grpOdbc.ResumeLayout(false);
            this.tableLayoutPanelOdbc.ResumeLayout(false);
            this.tableLayoutPanelOdbc.PerformLayout();
            this.grpLocalization.ResumeLayout(false);
            this.grpLocalization.PerformLayout();
            this.grpFonts.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOdbc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOdbc;
        private System.Windows.Forms.Label lblOdbcDsnName;
        private System.Windows.Forms.TextBox txtOdbcDsnName;
        private System.Windows.Forms.Label lblOdbcServer;
        private System.Windows.Forms.TextBox txtOdbcServer;
        private System.Windows.Forms.Label lblOdbcDb;
        private System.Windows.Forms.TextBox txtOdbcDb;
        private System.Windows.Forms.Label lblOdbcUid;
        private System.Windows.Forms.TextBox txtOdbcUid;
        private System.Windows.Forms.Label lblOdbcPwd;
        private System.Windows.Forms.TextBox txtOdbcPwd;
        private System.Windows.Forms.Button btnCreateOdbc;
        private System.Windows.Forms.GroupBox grpLocalization;
        private System.Windows.Forms.RadioButton radLangSwitchAltShift;
        private System.Windows.Forms.RadioButton radLangSwitchGrave;
        private System.Windows.Forms.Button btnSetLocalization;
        private System.Windows.Forms.GroupBox grpFonts;
        private System.Windows.Forms.ListView listViewFonts;
        private System.Windows.Forms.Button btnInstallFonts;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblLocalizationInfo;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
    }
}
