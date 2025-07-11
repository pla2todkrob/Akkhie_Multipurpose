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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.gboxOdbc = new System.Windows.Forms.GroupBox();
            this.btnCreateOdbc = new System.Windows.Forms.Button();
            this.txtOdbcPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOdbcUid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOdbcDb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOdbcServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOdbcDsnName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxLocalization = new System.Windows.Forms.GroupBox();
            this.btnSetLocalization = new System.Windows.Forms.Button();
            this.radLangSwitchAltShift = new System.Windows.Forms.RadioButton();
            this.radLangSwitchGrave = new System.Windows.Forms.RadioButton();
            this.gboxFonts = new System.Windows.Forms.GroupBox();
            this.btnInstallFonts = new System.Windows.Forms.Button();
            this.listViewFonts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gboxShortcuts = new System.Windows.Forms.GroupBox();
            this.btnCreateAllShortcuts = new System.Windows.Forms.Button();
            this.listViewShortcuts = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.logPanel = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.gboxOdbc.SuspendLayout();
            this.gboxLocalization.SuspendLayout();
            this.gboxFonts.SuspendLayout();
            this.gboxShortcuts.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.headerPanel, 0, 0);
            this.tlpMain.Controls.Add(this.tlpContent, 0, 1);
            this.tlpMain.Controls.Add(this.logPanel, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.Size = new System.Drawing.Size(884, 661);
            this.tlpMain.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(13, 13);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(858, 44);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Windows Settings && Setup";
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 2;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.Controls.Add(this.gboxOdbc, 0, 0);
            this.tlpContent.Controls.Add(this.gboxLocalization, 1, 0);
            this.tlpContent.Controls.Add(this.gboxFonts, 0, 1);
            this.tlpContent.Controls.Add(this.gboxShortcuts, 1, 1);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(13, 63);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 2;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContent.Size = new System.Drawing.Size(858, 348);
            this.tlpContent.TabIndex = 1;
            // 
            // gboxOdbc
            // 
            this.gboxOdbc.Controls.Add(this.btnCreateOdbc);
            this.gboxOdbc.Controls.Add(this.txtOdbcPwd);
            this.gboxOdbc.Controls.Add(this.label5);
            this.gboxOdbc.Controls.Add(this.txtOdbcUid);
            this.gboxOdbc.Controls.Add(this.label4);
            this.gboxOdbc.Controls.Add(this.txtOdbcDb);
            this.gboxOdbc.Controls.Add(this.label3);
            this.gboxOdbc.Controls.Add(this.txtOdbcServer);
            this.gboxOdbc.Controls.Add(this.label2);
            this.gboxOdbc.Controls.Add(this.txtOdbcDsnName);
            this.gboxOdbc.Controls.Add(this.label1);
            this.gboxOdbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxOdbc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxOdbc.Location = new System.Drawing.Point(3, 3);
            this.gboxOdbc.Name = "gboxOdbc";
            this.gboxOdbc.Size = new System.Drawing.Size(423, 168);
            this.gboxOdbc.TabIndex = 0;
            this.gboxOdbc.TabStop = false;
            this.gboxOdbc.Text = "ODBC Settings";
            // 
            // btnCreateOdbc
            // 
            this.btnCreateOdbc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOdbc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOdbc.Location = new System.Drawing.Point(267, 127);
            this.btnCreateOdbc.Name = "btnCreateOdbc";
            this.btnCreateOdbc.Size = new System.Drawing.Size(150, 35);
            this.btnCreateOdbc.TabIndex = 10;
            this.btnCreateOdbc.Text = "Create ODBC DSN";
            this.btnCreateOdbc.UseVisualStyleBackColor = true;
            this.btnCreateOdbc.Click += new System.EventHandler(this.btnCreateOdbc_Click);
            // 
            // txtOdbcPwd
            // 
            this.txtOdbcPwd.Location = new System.Drawing.Point(99, 125);
            this.txtOdbcPwd.Name = "txtOdbcPwd";
            this.txtOdbcPwd.PasswordChar = '●';
            this.txtOdbcPwd.Size = new System.Drawing.Size(156, 25);
            this.txtOdbcPwd.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // txtOdbcUid
            // 
            this.txtOdbcUid.Location = new System.Drawing.Point(99, 94);
            this.txtOdbcUid.Name = "txtOdbcUid";
            this.txtOdbcUid.Size = new System.Drawing.Size(156, 25);
            this.txtOdbcUid.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "User ID:";
            // 
            // txtOdbcDb
            // 
            this.txtOdbcDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcDb.Location = new System.Drawing.Point(267, 63);
            this.txtOdbcDb.Name = "txtOdbcDb";
            this.txtOdbcDb.Size = new System.Drawing.Size(150, 25);
            this.txtOdbcDb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Database:";
            // 
            // txtOdbcServer
            // 
            this.txtOdbcServer.Location = new System.Drawing.Point(99, 63);
            this.txtOdbcServer.Name = "txtOdbcServer";
            this.txtOdbcServer.Size = new System.Drawing.Size(156, 25);
            this.txtOdbcServer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server:";
            // 
            // txtOdbcDsnName
            // 
            this.txtOdbcDsnName.Location = new System.Drawing.Point(99, 32);
            this.txtOdbcDsnName.Name = "txtOdbcDsnName";
            this.txtOdbcDsnName.Size = new System.Drawing.Size(156, 25);
            this.txtOdbcDsnName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DSN Name:";
            // 
            // gboxLocalization
            // 
            this.gboxLocalization.Controls.Add(this.btnSetLocalization);
            this.gboxLocalization.Controls.Add(this.radLangSwitchAltShift);
            this.gboxLocalization.Controls.Add(this.radLangSwitchGrave);
            this.gboxLocalization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxLocalization.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxLocalization.Location = new System.Drawing.Point(432, 3);
            this.gboxLocalization.Name = "gboxLocalization";
            this.gboxLocalization.Size = new System.Drawing.Size(423, 168);
            this.gboxLocalization.TabIndex = 1;
            this.gboxLocalization.TabStop = false;
            this.gboxLocalization.Text = "Localization Settings";
            // 
            // btnSetLocalization
            // 
            this.btnSetLocalization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetLocalization.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetLocalization.Location = new System.Drawing.Point(267, 127);
            this.btnSetLocalization.Name = "btnSetLocalization";
            this.btnSetLocalization.Size = new System.Drawing.Size(150, 35);
            this.btnSetLocalization.TabIndex = 2;
            this.btnSetLocalization.Text = "Set All Localization";
            this.btnSetLocalization.UseVisualStyleBackColor = true;
            this.btnSetLocalization.Click += new System.EventHandler(this.btnSetLocalization_Click);
            // 
            // radLangSwitchAltShift
            // 
            this.radLangSwitchAltShift.AutoSize = true;
            this.radLangSwitchAltShift.Location = new System.Drawing.Point(17, 63);
            this.radLangSwitchAltShift.Name = "radLangSwitchAltShift";
            this.radLangSwitchAltShift.Size = new System.Drawing.Size(130, 21);
            this.radLangSwitchAltShift.TabIndex = 1;
            this.radLangSwitchAltShift.Text = "Hotkey: Alt + Shift";
            this.radLangSwitchAltShift.UseVisualStyleBackColor = true;
            // 
            // radLangSwitchGrave
            // 
            this.radLangSwitchGrave.AutoSize = true;
            this.radLangSwitchGrave.Checked = true;
            this.radLangSwitchGrave.Location = new System.Drawing.Point(17, 32);
            this.radLangSwitchGrave.Name = "radLangSwitchGrave";
            this.radLangSwitchGrave.Size = new System.Drawing.Size(183, 21);
            this.radLangSwitchGrave.TabIndex = 0;
            this.radLangSwitchGrave.TabStop = true;
            this.radLangSwitchGrave.Text = "Hotkey: Grave Accent ( ~ )";
            this.radLangSwitchGrave.UseVisualStyleBackColor = true;
            // 
            // gboxFonts
            // 
            this.gboxFonts.Controls.Add(this.btnInstallFonts);
            this.gboxFonts.Controls.Add(this.listViewFonts);
            this.gboxFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxFonts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxFonts.Location = new System.Drawing.Point(3, 177);
            this.gboxFonts.Name = "gboxFonts";
            this.gboxFonts.Size = new System.Drawing.Size(423, 168);
            this.gboxFonts.TabIndex = 2;
            this.gboxFonts.TabStop = false;
            this.gboxFonts.Text = "Font Management";
            // 
            // btnInstallFonts
            // 
            this.btnInstallFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallFonts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallFonts.Location = new System.Drawing.Point(267, 127);
            this.btnInstallFonts.Name = "btnInstallFonts";
            this.btnInstallFonts.Size = new System.Drawing.Size(150, 35);
            this.btnInstallFonts.TabIndex = 1;
            this.btnInstallFonts.Text = "Install All Fonts";
            this.btnInstallFonts.UseVisualStyleBackColor = true;
            this.btnInstallFonts.Click += new System.EventHandler(this.btnInstallFonts_Click);
            // 
            // listViewFonts
            // 
            this.listViewFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFonts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewFonts.HideSelection = false;
            this.listViewFonts.Location = new System.Drawing.Point(6, 24);
            this.listViewFonts.Name = "listViewFonts";
            this.listViewFonts.Size = new System.Drawing.Size(411, 97);
            this.listViewFonts.TabIndex = 0;
            this.listViewFonts.UseCompatibleStateImageBehavior = false;
            this.listViewFonts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Font File Name";
            this.columnHeader1.Width = 350;
            // 
            // gboxShortcuts
            // 
            this.gboxShortcuts.Controls.Add(this.btnCreateAllShortcuts);
            this.gboxShortcuts.Controls.Add(this.listViewShortcuts);
            this.gboxShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxShortcuts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxShortcuts.Location = new System.Drawing.Point(432, 177);
            this.gboxShortcuts.Name = "gboxShortcuts";
            this.gboxShortcuts.Size = new System.Drawing.Size(423, 168);
            this.gboxShortcuts.TabIndex = 3;
            this.gboxShortcuts.TabStop = false;
            this.gboxShortcuts.Text = "Desktop Shortcuts";
            // 
            // btnCreateAllShortcuts
            // 
            this.btnCreateAllShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAllShortcuts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAllShortcuts.Location = new System.Drawing.Point(267, 127);
            this.btnCreateAllShortcuts.Name = "btnCreateAllShortcuts";
            this.btnCreateAllShortcuts.Size = new System.Drawing.Size(150, 35);
            this.btnCreateAllShortcuts.TabIndex = 1;
            this.btnCreateAllShortcuts.Text = "Create All Shortcuts";
            this.btnCreateAllShortcuts.UseVisualStyleBackColor = true;
            this.btnCreateAllShortcuts.Click += new System.EventHandler(this.btnCreateAllShortcuts_Click);
            // 
            // listViewShortcuts
            // 
            this.listViewShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colTarget});
            this.listViewShortcuts.HideSelection = false;
            this.listViewShortcuts.Location = new System.Drawing.Point(6, 24);
            this.listViewShortcuts.Name = "listViewShortcuts";
            this.listViewShortcuts.Size = new System.Drawing.Size(411, 97);
            this.listViewShortcuts.TabIndex = 0;
            this.listViewShortcuts.UseCompatibleStateImageBehavior = false;
            this.listViewShortcuts.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Shortcut Name";
            this.colName.Width = 150;
            // 
            // colTarget
            // 
            this.colTarget.Text = "Target Path";
            this.colTarget.Width = 200;
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.txtStatus);
            this.logPanel.Controls.Add(this.label6);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(13, 417);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(858, 231);
            this.logPanel.TabIndex = 2;
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
            this.txtStatus.Size = new System.Drawing.Size(858, 211);
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
            // WindowsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpMain);
            this.Name = "WindowsSettingsControl";
            this.Size = new System.Drawing.Size(884, 661);
            this.tlpMain.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.gboxOdbc.ResumeLayout(false);
            this.gboxOdbc.PerformLayout();
            this.gboxLocalization.ResumeLayout(false);
            this.gboxLocalization.PerformLayout();
            this.gboxFonts.ResumeLayout(false);
            this.gboxShortcuts.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.GroupBox gboxOdbc;
        private System.Windows.Forms.Button btnCreateOdbc;
        private System.Windows.Forms.TextBox txtOdbcPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOdbcUid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOdbcDb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOdbcServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOdbcDsnName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxLocalization;
        private System.Windows.Forms.Button btnSetLocalization;
        private System.Windows.Forms.RadioButton radLangSwitchAltShift;
        private System.Windows.Forms.RadioButton radLangSwitchGrave;
        private System.Windows.Forms.GroupBox gboxFonts;
        private System.Windows.Forms.Button btnInstallFonts;
        private System.Windows.Forms.ListView listViewFonts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox gboxShortcuts;
        private System.Windows.Forms.Button btnCreateAllShortcuts;
        private System.Windows.Forms.ListView listViewShortcuts;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colTarget;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label6;
    }
}
