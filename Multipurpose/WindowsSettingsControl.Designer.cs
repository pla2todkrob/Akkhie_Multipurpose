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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOdbcPwd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOdbcUid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOdbcDb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOdbcServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOdbcDsnName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateOdbc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tlpLocalization = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetLocalization = new System.Windows.Forms.Button();
            this.grpLangSwitch = new System.Windows.Forms.GroupBox();
            this.radLangSwitchAltShift = new System.Windows.Forms.RadioButton();
            this.radLangSwitchGrave = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tlpFonts = new System.Windows.Forms.TableLayoutPanel();
            this.listViewFonts = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInstallFonts = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tlpShortcuts = new System.Windows.Forms.TableLayoutPanel();
            this.listViewShortcuts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCreateAllShortcuts = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tlpLocalization.SuspendLayout();
            this.grpLangSwitch.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tlpFonts.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tlpShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tlpMain);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtStatus);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.splitContainer1.Size = new System.Drawing.Size(1021, 650);
            this.splitContainer1.SplitterDistance = 460;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.groupBox1, 0, 0);
            this.tlpMain.Controls.Add(this.groupBox2, 1, 0);
            this.tlpMain.Controls.Add(this.groupBox3, 0, 1);
            this.tlpMain.Controls.Add(this.groupBox4, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(10, 10);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1001, 440);
            this.tlpMain.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOdbcPwd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtOdbcUid);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOdbcDb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtOdbcServer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOdbcDsnName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCreateOdbc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(492, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. ตั้งค่า ODBC (จาก App.config)";
            // 
            // txtOdbcPwd
            // 
            this.txtOdbcPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcPwd.Location = new System.Drawing.Point(120, 156);
            this.txtOdbcPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txtOdbcPwd.Name = "txtOdbcPwd";
            this.txtOdbcPwd.PasswordChar = '*';
            this.txtOdbcPwd.Size = new System.Drawing.Size(364, 22);
            this.txtOdbcPwd.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 160);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Password:";
            // 
            // txtOdbcUid
            // 
            this.txtOdbcUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcUid.Location = new System.Drawing.Point(120, 124);
            this.txtOdbcUid.Margin = new System.Windows.Forms.Padding(4);
            this.txtOdbcUid.Name = "txtOdbcUid";
            this.txtOdbcUid.Size = new System.Drawing.Size(364, 22);
            this.txtOdbcUid.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "User ID:";
            // 
            // txtOdbcDb
            // 
            this.txtOdbcDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcDb.Location = new System.Drawing.Point(120, 92);
            this.txtOdbcDb.Margin = new System.Windows.Forms.Padding(4);
            this.txtOdbcDb.Name = "txtOdbcDb";
            this.txtOdbcDb.Size = new System.Drawing.Size(364, 22);
            this.txtOdbcDb.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Database:";
            // 
            // txtOdbcServer
            // 
            this.txtOdbcServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcServer.Location = new System.Drawing.Point(120, 60);
            this.txtOdbcServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtOdbcServer.Name = "txtOdbcServer";
            this.txtOdbcServer.Size = new System.Drawing.Size(364, 22);
            this.txtOdbcServer.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Server:";
            // 
            // txtOdbcDsnName
            // 
            this.txtOdbcDsnName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOdbcDsnName.Location = new System.Drawing.Point(120, 28);
            this.txtOdbcDsnName.Margin = new System.Windows.Forms.Padding(4);
            this.txtOdbcDsnName.Name = "txtOdbcDsnName";
            this.txtOdbcDsnName.Size = new System.Drawing.Size(364, 22);
            this.txtOdbcDsnName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "DSN Name:";
            // 
            // btnCreateOdbc
            // 
            this.btnCreateOdbc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOdbc.Location = new System.Drawing.Point(259, 204);
            this.btnCreateOdbc.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateOdbc.Name = "btnCreateOdbc";
            this.btnCreateOdbc.Size = new System.Drawing.Size(225, 40);
            this.btnCreateOdbc.TabIndex = 4;
            this.btnCreateOdbc.Text = "Test Connection and Create";
            this.btnCreateOdbc.UseVisualStyleBackColor = true;
            this.btnCreateOdbc.Click += new System.EventHandler(this.btnCreateOdbc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tlpLocalization);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(504, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(493, 252);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. ตั้งค่าประเทศและภาษา";
            // 
            // tlpLocalization
            // 
            this.tlpLocalization.ColumnCount = 1;
            this.tlpLocalization.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLocalization.Controls.Add(this.label3, 0, 0);
            this.tlpLocalization.Controls.Add(this.btnSetLocalization, 0, 2);
            this.tlpLocalization.Controls.Add(this.grpLangSwitch, 0, 1);
            this.tlpLocalization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLocalization.Location = new System.Drawing.Point(4, 19);
            this.tlpLocalization.Name = "tlpLocalization";
            this.tlpLocalization.RowCount = 3;
            this.tlpLocalization.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpLocalization.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLocalization.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpLocalization.Size = new System.Drawing.Size(485, 229);
            this.tlpLocalization.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(477, 80);
            this.label3.TabIndex = 0;
            this.label3.Text = "ตั้งค่าระบบให้เหมาะกับประเทศไทย:\r\n- Timezone: Bangkok (UTC+07:00), เปิดปรับเวลาอั" +
    "ตโนมัติ\r\n- Region & Format: Thailand\r\n- Display Language: English (US)\r\n- Keyboa" +
    "rd: English (Primary), Thai";
            // 
            // btnSetLocalization
            // 
            this.btnSetLocalization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetLocalization.Location = new System.Drawing.Point(233, 185);
            this.btnSetLocalization.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetLocalization.Name = "btnSetLocalization";
            this.btnSetLocalization.Size = new System.Drawing.Size(248, 40);
            this.btnSetLocalization.TabIndex = 1;
            this.btnSetLocalization.Text = "Apply Localization Settings";
            this.btnSetLocalization.UseVisualStyleBackColor = true;
            this.btnSetLocalization.Click += new System.EventHandler(this.btnSetLocalization_Click);
            // 
            // grpLangSwitch
            // 
            this.grpLangSwitch.Controls.Add(this.radLangSwitchAltShift);
            this.grpLangSwitch.Controls.Add(this.radLangSwitchGrave);
            this.grpLangSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLangSwitch.Location = new System.Drawing.Point(3, 83);
            this.grpLangSwitch.Name = "grpLangSwitch";
            this.grpLangSwitch.Size = new System.Drawing.Size(479, 95);
            this.grpLangSwitch.TabIndex = 2;
            this.grpLangSwitch.TabStop = false;
            this.grpLangSwitch.Text = "ปุ่มลัดสลับภาษา (Input language hot key)";
            // 
            // radLangSwitchAltShift
            // 
            this.radLangSwitchAltShift.AutoSize = true;
            this.radLangSwitchAltShift.Location = new System.Drawing.Point(9, 58);
            this.radLangSwitchAltShift.Name = "radLangSwitchAltShift";
            this.radLangSwitchAltShift.Size = new System.Drawing.Size(81, 20);
            this.radLangSwitchAltShift.TabIndex = 1;
            this.radLangSwitchAltShift.Text = "Alt + Shift";
            this.radLangSwitchAltShift.UseVisualStyleBackColor = true;
            // 
            // radLangSwitchGrave
            // 
            this.radLangSwitchGrave.AutoSize = true;
            this.radLangSwitchGrave.Checked = true;
            this.radLangSwitchGrave.Location = new System.Drawing.Point(9, 32);
            this.radLangSwitchGrave.Name = "radLangSwitchGrave";
            this.radLangSwitchGrave.Size = new System.Drawing.Size(127, 20);
            this.radLangSwitchGrave.TabIndex = 0;
            this.radLangSwitchGrave.TabStop = true;
            this.radLangSwitchGrave.Text = "Grave Accent (`)";
            this.radLangSwitchGrave.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tlpFonts);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(4, 264);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(492, 172);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. ติดตั้งฟอนต์ (จากโฟลเดอร์ Fonts)";
            // 
            // tlpFonts
            // 
            this.tlpFonts.ColumnCount = 1;
            this.tlpFonts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFonts.Controls.Add(this.listViewFonts, 0, 0);
            this.tlpFonts.Controls.Add(this.btnInstallFonts, 0, 1);
            this.tlpFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFonts.Location = new System.Drawing.Point(4, 19);
            this.tlpFonts.Name = "tlpFonts";
            this.tlpFonts.RowCount = 2;
            this.tlpFonts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFonts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpFonts.Size = new System.Drawing.Size(484, 149);
            this.tlpFonts.TabIndex = 4;
            // 
            // listViewFonts
            // 
            this.listViewFonts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listViewFonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFonts.GridLines = true;
            this.listViewFonts.HideSelection = false;
            this.listViewFonts.Location = new System.Drawing.Point(3, 3);
            this.listViewFonts.Name = "listViewFonts";
            this.listViewFonts.Size = new System.Drawing.Size(478, 95);
            this.listViewFonts.TabIndex = 3;
            this.listViewFonts.UseCompatibleStateImageBehavior = false;
            this.listViewFonts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Font File Name";
            this.columnHeader3.Width = 450;
            // 
            // btnInstallFonts
            // 
            this.btnInstallFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallFonts.Location = new System.Drawing.Point(310, 105);
            this.btnInstallFonts.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstallFonts.Name = "btnInstallFonts";
            this.btnInstallFonts.Size = new System.Drawing.Size(170, 40);
            this.btnInstallFonts.TabIndex = 1;
            this.btnInstallFonts.Text = "ติดตั้งฟอนต์ทั้งหมด";
            this.btnInstallFonts.UseVisualStyleBackColor = true;
            this.btnInstallFonts.Click += new System.EventHandler(this.btnInstallFonts_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tlpShortcuts);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(504, 264);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(493, 172);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. สร้าง Shortcut (จาก shortcuts.json)";
            // 
            // tlpShortcuts
            // 
            this.tlpShortcuts.ColumnCount = 1;
            this.tlpShortcuts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcuts.Controls.Add(this.listViewShortcuts, 0, 0);
            this.tlpShortcuts.Controls.Add(this.btnCreateAllShortcuts, 0, 1);
            this.tlpShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortcuts.Location = new System.Drawing.Point(4, 19);
            this.tlpShortcuts.Name = "tlpShortcuts";
            this.tlpShortcuts.RowCount = 2;
            this.tlpShortcuts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcuts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpShortcuts.Size = new System.Drawing.Size(485, 149);
            this.tlpShortcuts.TabIndex = 10;
            // 
            // listViewShortcuts
            // 
            this.listViewShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewShortcuts.FullRowSelect = true;
            this.listViewShortcuts.GridLines = true;
            this.listViewShortcuts.HideSelection = false;
            this.listViewShortcuts.Location = new System.Drawing.Point(3, 3);
            this.listViewShortcuts.Name = "listViewShortcuts";
            this.listViewShortcuts.Size = new System.Drawing.Size(479, 95);
            this.listViewShortcuts.TabIndex = 0;
            this.listViewShortcuts.UseCompatibleStateImageBehavior = false;
            this.listViewShortcuts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Shortcut Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Target Path";
            this.columnHeader2.Width = 300;
            // 
            // btnCreateAllShortcuts
            // 
            this.btnCreateAllShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAllShortcuts.Location = new System.Drawing.Point(272, 105);
            this.btnCreateAllShortcuts.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateAllShortcuts.Name = "btnCreateAllShortcuts";
            this.btnCreateAllShortcuts.Size = new System.Drawing.Size(209, 40);
            this.btnCreateAllShortcuts.TabIndex = 9;
            this.btnCreateAllShortcuts.Text = "สร้าง Shortcut ทั้งหมด";
            this.btnCreateAllShortcuts.UseVisualStyleBackColor = true;
            this.btnCreateAllShortcuts.Click += new System.EventHandler(this.btnCreateAllShortcuts_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(10, 0);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(1001, 175);
            this.txtStatus.TabIndex = 0;
            // 
            // WindowsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WindowsSettingsControl";
            this.Size = new System.Drawing.Size(1021, 650);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tlpLocalization.ResumeLayout(false);
            this.grpLangSwitch.ResumeLayout(false);
            this.grpLangSwitch.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tlpFonts.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tlpShortcuts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOdbcPwd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOdbcUid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOdbcDb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOdbcServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOdbcDsnName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateOdbc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSetLocalization;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInstallFonts;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCreateAllShortcuts;
        private System.Windows.Forms.ListView listViewShortcuts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewFonts;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TableLayoutPanel tlpFonts;
        private System.Windows.Forms.TableLayoutPanel tlpShortcuts;
        private System.Windows.Forms.TableLayoutPanel tlpLocalization;
        private System.Windows.Forms.GroupBox grpLangSwitch;
        private System.Windows.Forms.RadioButton radLangSwitchAltShift;
        private System.Windows.Forms.RadioButton radLangSwitchGrave;
    }
}
