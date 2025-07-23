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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.radLangSwitchAltShift = new System.Windows.Forms.RadioButton();
            this.radLangSwitchGrave = new System.Windows.Forms.RadioButton();
            this.btnSetLocalization = new System.Windows.Forms.Button();
            this.grpFonts = new System.Windows.Forms.GroupBox();
            this.listViewFonts = new System.Windows.Forms.ListView();
            this.btnInstallFonts = new System.Windows.Forms.Button();
            this.grpShortcuts = new System.Windows.Forms.GroupBox();
            this.listViewShortcuts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCreateAllShortcuts = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpOdbc.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpLocalization.SuspendLayout();
            this.grpFonts.SuspendLayout();
            this.grpShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOdbc
            // 
            this.grpOdbc.Controls.Add(this.tableLayoutPanel1);
            this.grpOdbc.Location = new System.Drawing.Point(15, 15);
            this.grpOdbc.Name = "grpOdbc";
            this.grpOdbc.Padding = new System.Windows.Forms.Padding(10);
            this.grpOdbc.Size = new System.Drawing.Size(460, 220);
            this.grpOdbc.TabIndex = 0;
            this.grpOdbc.TabStop = false;
            this.grpOdbc.Text = "ODBC Settings (System DSN)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblOdbcDsnName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOdbcDsnName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOdbcServer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOdbcServer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblOdbcDb, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOdbcDb, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOdbcUid, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOdbcUid, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblOdbcPwd, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtOdbcPwd, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCreateOdbc, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 185);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.txtOdbcDsnName.Size = new System.Drawing.Size(350, 22);
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
            this.txtOdbcServer.Size = new System.Drawing.Size(350, 22);
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
            this.txtOdbcDb.Size = new System.Drawing.Size(350, 22);
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
            this.txtOdbcUid.Size = new System.Drawing.Size(350, 22);
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
            this.txtOdbcPwd.Size = new System.Drawing.Size(350, 22);
            this.txtOdbcPwd.TabIndex = 9;
            // 
            // btnCreateOdbc
            // 
            this.btnCreateOdbc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreateOdbc.Location = new System.Drawing.Point(262, 153);
            this.btnCreateOdbc.Name = "btnCreateOdbc";
            this.btnCreateOdbc.Size = new System.Drawing.Size(175, 29);
            this.btnCreateOdbc.TabIndex = 10;
            this.btnCreateOdbc.Text = "Create / Update DSN";
            this.btnCreateOdbc.UseVisualStyleBackColor = true;
            this.btnCreateOdbc.Click += new System.EventHandler(this.btnCreateOdbc_Click);
            // 
            // grpLocalization
            // 
            this.grpLocalization.Controls.Add(this.radLangSwitchAltShift);
            this.grpLocalization.Controls.Add(this.radLangSwitchGrave);
            this.grpLocalization.Controls.Add(this.btnSetLocalization);
            this.grpLocalization.Location = new System.Drawing.Point(15, 241);
            this.grpLocalization.Name = "grpLocalization";
            this.grpLocalization.Size = new System.Drawing.Size(460, 70);
            this.grpLocalization.TabIndex = 1;
            this.grpLocalization.TabStop = false;
            this.grpLocalization.Text = "Localization (TH/EN)";
            // 
            // radLangSwitchAltShift
            // 
            this.radLangSwitchAltShift.AutoSize = true;
            this.radLangSwitchAltShift.Location = new System.Drawing.Point(130, 32);
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
            this.radLangSwitchGrave.Location = new System.Drawing.Point(20, 32);
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
            this.btnSetLocalization.Location = new System.Drawing.Point(275, 26);
            this.btnSetLocalization.Name = "btnSetLocalization";
            this.btnSetLocalization.Size = new System.Drawing.Size(175, 30);
            this.btnSetLocalization.TabIndex = 2;
            this.btnSetLocalization.Text = "Apply Localization";
            this.btnSetLocalization.UseVisualStyleBackColor = true;
            this.btnSetLocalization.Click += new System.EventHandler(this.btnSetLocalization_Click);
            // 
            // grpFonts
            // 
            this.grpFonts.Controls.Add(this.listViewFonts);
            this.grpFonts.Controls.Add(this.btnInstallFonts);
            this.grpFonts.Location = new System.Drawing.Point(490, 15);
            this.grpFonts.Name = "grpFonts";
            this.grpFonts.Size = new System.Drawing.Size(470, 145);
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
            this.listViewFonts.Size = new System.Drawing.Size(260, 105);
            this.listViewFonts.TabIndex = 0;
            this.listViewFonts.UseCompatibleStateImageBehavior = false;
            this.listViewFonts.View = System.Windows.Forms.View.List;
            // 
            // btnInstallFonts
            // 
            this.btnInstallFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallFonts.Location = new System.Drawing.Point(285, 25);
            this.btnInstallFonts.Name = "btnInstallFonts";
            this.btnInstallFonts.Size = new System.Drawing.Size(175, 30);
            this.btnInstallFonts.TabIndex = 1;
            this.btnInstallFonts.Text = "Install All Fonts";
            this.btnInstallFonts.UseVisualStyleBackColor = true;
            this.btnInstallFonts.Click += new System.EventHandler(this.btnInstallFonts_Click);
            // 
            // grpShortcuts
            // 
            this.grpShortcuts.Controls.Add(this.listViewShortcuts);
            this.grpShortcuts.Controls.Add(this.btnCreateAllShortcuts);
            this.grpShortcuts.Location = new System.Drawing.Point(490, 166);
            this.grpShortcuts.Name = "grpShortcuts";
            this.grpShortcuts.Size = new System.Drawing.Size(470, 145);
            this.grpShortcuts.TabIndex = 3;
            this.grpShortcuts.TabStop = false;
            this.grpShortcuts.Text = "Create Shortcuts (Public Desktop)";
            // 
            // listViewShortcuts
            // 
            this.listViewShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewShortcuts.HideSelection = false;
            this.listViewShortcuts.Location = new System.Drawing.Point(15, 25);
            this.listViewShortcuts.Name = "listViewShortcuts";
            this.listViewShortcuts.Size = new System.Drawing.Size(260, 105);
            this.listViewShortcuts.TabIndex = 0;
            this.listViewShortcuts.UseCompatibleStateImageBehavior = false;
            this.listViewShortcuts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Target";
            this.columnHeader2.Width = 150;
            // 
            // btnCreateAllShortcuts
            // 
            this.btnCreateAllShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAllShortcuts.Location = new System.Drawing.Point(285, 25);
            this.btnCreateAllShortcuts.Name = "btnCreateAllShortcuts";
            this.btnCreateAllShortcuts.Size = new System.Drawing.Size(175, 30);
            this.btnCreateAllShortcuts.TabIndex = 1;
            this.btnCreateAllShortcuts.Text = "Create All Shortcuts";
            this.btnCreateAllShortcuts.UseVisualStyleBackColor = true;
            this.btnCreateAllShortcuts.Click += new System.EventHandler(this.btnCreateAllShortcuts_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtStatus.Location = new System.Drawing.Point(15, 325);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(945, 241);
            this.txtStatus.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(865, 572);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.btnCancel, "Cancel any running operation");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WindowsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.grpShortcuts);
            this.Controls.Add(this.grpFonts);
            this.Controls.Add(this.grpLocalization);
            this.Controls.Add(this.grpOdbc);
            this.Name = "WindowsSettingsControl";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(975, 615);
            this.grpOdbc.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpLocalization.ResumeLayout(false);
            this.grpLocalization.PerformLayout();
            this.grpFonts.ResumeLayout(false);
            this.grpShortcuts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOdbc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.GroupBox grpShortcuts;
        private System.Windows.Forms.ListView listViewShortcuts;
        private System.Windows.Forms.Button btnCreateAllShortcuts;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
