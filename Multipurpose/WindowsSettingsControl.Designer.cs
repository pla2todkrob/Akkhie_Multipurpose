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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gboxOdbc.SuspendLayout();
            this.gboxLocalization.SuspendLayout();
            this.gboxFonts.SuspendLayout();
            this.gboxShortcuts.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.gboxOdbc.Location = new System.Drawing.Point(4, 4);
            this.gboxOdbc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxOdbc.Name = "gboxOdbc";
            this.gboxOdbc.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxOdbc.Size = new System.Drawing.Size(520, 238);
            this.gboxOdbc.TabIndex = 0;
            this.gboxOdbc.TabStop = false;
            this.gboxOdbc.Text = "ODBC Settings";
            // 
            // btnCreateOdbc
            // 
            this.btnCreateOdbc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOdbc.Location = new System.Drawing.Point(309, 196);
            this.btnCreateOdbc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateOdbc.Name = "btnCreateOdbc";
            this.btnCreateOdbc.Size = new System.Drawing.Size(188, 28);
            this.btnCreateOdbc.TabIndex = 10;
            this.btnCreateOdbc.Text = "Create ODBC DSN";
            this.btnCreateOdbc.UseVisualStyleBackColor = true;
            this.btnCreateOdbc.Click += new System.EventHandler(this.btnCreateOdbc_Click);
            // 
            // txtOdbcPwd
            // 
            this.txtOdbcPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcPwd.Location = new System.Drawing.Point(392, 71);
            this.txtOdbcPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOdbcPwd.Name = "txtOdbcPwd";
            this.txtOdbcPwd.PasswordChar = '*';
            this.txtOdbcPwd.Size = new System.Drawing.Size(104, 22);
            this.txtOdbcPwd.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // txtOdbcUid
            // 
            this.txtOdbcUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcUid.Location = new System.Drawing.Point(392, 39);
            this.txtOdbcUid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOdbcUid.Name = "txtOdbcUid";
            this.txtOdbcUid.Size = new System.Drawing.Size(104, 22);
            this.txtOdbcUid.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "User ID:";
            // 
            // txtOdbcDb
            // 
            this.txtOdbcDb.Location = new System.Drawing.Point(113, 103);
            this.txtOdbcDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOdbcDb.Name = "txtOdbcDb";
            this.txtOdbcDb.Size = new System.Drawing.Size(169, 22);
            this.txtOdbcDb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Database:";
            // 
            // txtOdbcServer
            // 
            this.txtOdbcServer.Location = new System.Drawing.Point(113, 71);
            this.txtOdbcServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOdbcServer.Name = "txtOdbcServer";
            this.txtOdbcServer.Size = new System.Drawing.Size(169, 22);
            this.txtOdbcServer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server:";
            // 
            // txtOdbcDsnName
            // 
            this.txtOdbcDsnName.Location = new System.Drawing.Point(113, 39);
            this.txtOdbcDsnName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOdbcDsnName.Name = "txtOdbcDsnName";
            this.txtOdbcDsnName.Size = new System.Drawing.Size(169, 22);
            this.txtOdbcDsnName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DSN Name:";
            // 
            // gboxLocalization
            // 
            this.gboxLocalization.Controls.Add(this.btnSetLocalization);
            this.gboxLocalization.Controls.Add(this.radLangSwitchAltShift);
            this.gboxLocalization.Controls.Add(this.radLangSwitchGrave);
            this.gboxLocalization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxLocalization.Location = new System.Drawing.Point(532, 4);
            this.gboxLocalization.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxLocalization.Name = "gboxLocalization";
            this.gboxLocalization.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxLocalization.Size = new System.Drawing.Size(521, 238);
            this.gboxLocalization.TabIndex = 1;
            this.gboxLocalization.TabStop = false;
            this.gboxLocalization.Text = "Localization Settings";
            // 
            // btnSetLocalization
            // 
            this.btnSetLocalization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetLocalization.Location = new System.Drawing.Point(23, 196);
            this.btnSetLocalization.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetLocalization.Name = "btnSetLocalization";
            this.btnSetLocalization.Size = new System.Drawing.Size(243, 28);
            this.btnSetLocalization.TabIndex = 2;
            this.btnSetLocalization.Text = "Set All Localization";
            this.btnSetLocalization.UseVisualStyleBackColor = true;
            this.btnSetLocalization.Click += new System.EventHandler(this.btnSetLocalization_Click);
            // 
            // radLangSwitchAltShift
            // 
            this.radLangSwitchAltShift.AutoSize = true;
            this.radLangSwitchAltShift.Location = new System.Drawing.Point(23, 71);
            this.radLangSwitchAltShift.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radLangSwitchAltShift.Name = "radLangSwitchAltShift";
            this.radLangSwitchAltShift.Size = new System.Drawing.Size(127, 20);
            this.radLangSwitchAltShift.TabIndex = 1;
            this.radLangSwitchAltShift.Text = "Hotkey: Alt + Shift";
            this.radLangSwitchAltShift.UseVisualStyleBackColor = true;
            // 
            // radLangSwitchGrave
            // 
            this.radLangSwitchGrave.AutoSize = true;
            this.radLangSwitchGrave.Checked = true;
            this.radLangSwitchGrave.Location = new System.Drawing.Point(23, 39);
            this.radLangSwitchGrave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radLangSwitchGrave.Name = "radLangSwitchGrave";
            this.radLangSwitchGrave.Size = new System.Drawing.Size(175, 20);
            this.radLangSwitchGrave.TabIndex = 0;
            this.radLangSwitchGrave.TabStop = true;
            this.radLangSwitchGrave.Text = "Hotkey: Grave Accent (~)";
            this.radLangSwitchGrave.UseVisualStyleBackColor = true;
            // 
            // gboxFonts
            // 
            this.gboxFonts.Controls.Add(this.btnInstallFonts);
            this.gboxFonts.Controls.Add(this.listViewFonts);
            this.gboxFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxFonts.Location = new System.Drawing.Point(4, 250);
            this.gboxFonts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxFonts.Name = "gboxFonts";
            this.gboxFonts.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxFonts.Size = new System.Drawing.Size(520, 238);
            this.gboxFonts.TabIndex = 2;
            this.gboxFonts.TabStop = false;
            this.gboxFonts.Text = "Font Management";
            // 
            // btnInstallFonts
            // 
            this.btnInstallFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInstallFonts.Location = new System.Drawing.Point(8, 197);
            this.btnInstallFonts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInstallFonts.Name = "btnInstallFonts";
            this.btnInstallFonts.Size = new System.Drawing.Size(161, 28);
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
            this.listViewFonts.Location = new System.Drawing.Point(8, 23);
            this.listViewFonts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewFonts.Name = "listViewFonts";
            this.listViewFonts.Size = new System.Drawing.Size(503, 165);
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
            this.gboxShortcuts.Location = new System.Drawing.Point(532, 250);
            this.gboxShortcuts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxShortcuts.Name = "gboxShortcuts";
            this.gboxShortcuts.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gboxShortcuts.Size = new System.Drawing.Size(521, 238);
            this.gboxShortcuts.TabIndex = 3;
            this.gboxShortcuts.TabStop = false;
            this.gboxShortcuts.Text = "Desktop Shortcuts";
            // 
            // btnCreateAllShortcuts
            // 
            this.btnCreateAllShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateAllShortcuts.Location = new System.Drawing.Point(8, 197);
            this.btnCreateAllShortcuts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateAllShortcuts.Name = "btnCreateAllShortcuts";
            this.btnCreateAllShortcuts.Size = new System.Drawing.Size(161, 28);
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
            this.listViewShortcuts.Location = new System.Drawing.Point(8, 23);
            this.listViewShortcuts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewShortcuts.Name = "listViewShortcuts";
            this.listViewShortcuts.Size = new System.Drawing.Size(504, 165);
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
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.Lime;
            this.txtStatus.Location = new System.Drawing.Point(0, 20);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(1057, 276);
            this.txtStatus.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Status / Log:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gboxOdbc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gboxLocalization, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gboxFonts, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gboxShortcuts, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1057, 492);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 793);
            this.splitContainer1.SplitterDistance = 492;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // WindowsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WindowsSettingsControl";
            this.Size = new System.Drawing.Size(1057, 793);
            this.gboxOdbc.ResumeLayout(false);
            this.gboxOdbc.PerformLayout();
            this.gboxLocalization.ResumeLayout(false);
            this.gboxLocalization.PerformLayout();
            this.gboxFonts.ResumeLayout(false);
            this.gboxShortcuts.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
