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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOdbcServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOdbcDsnName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateOdbc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetLocalization = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInstallFonts = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtShortcutTarget = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShortcutName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreateShortcut = new System.Windows.Forms.Button();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOdbcServer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOdbcDsnName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCreateOdbc);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(500, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. ตั้งค่า ODBC (System DSN for SQL Server)";
            // 
            // txtOdbcServer
            // 
            this.txtOdbcServer.Location = new System.Drawing.Point(120, 60);
            this.txtOdbcServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtOdbcServer.Name = "txtOdbcServer";
            this.txtOdbcServer.Size = new System.Drawing.Size(360, 22);
            this.txtOdbcServer.TabIndex = 3;
            this.txtOdbcServer.Text = ".\\SQLEXPRESS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server:";
            // 
            // txtOdbcDsnName
            // 
            this.txtOdbcDsnName.Location = new System.Drawing.Point(120, 28);
            this.txtOdbcDsnName.Margin = new System.Windows.Forms.Padding(4);
            this.txtOdbcDsnName.Name = "txtOdbcDsnName";
            this.txtOdbcDsnName.Size = new System.Drawing.Size(360, 22);
            this.txtOdbcDsnName.TabIndex = 1;
            this.txtOdbcDsnName.Text = "MyWebAppDSN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DSN Name:";
            // 
            // btnCreateOdbc
            // 
            this.btnCreateOdbc.Location = new System.Drawing.Point(350, 95);
            this.btnCreateOdbc.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateOdbc.Name = "btnCreateOdbc";
            this.btnCreateOdbc.Size = new System.Drawing.Size(130, 40);
            this.btnCreateOdbc.TabIndex = 4;
            this.btnCreateOdbc.Text = "สร้าง DSN";
            this.btnCreateOdbc.UseVisualStyleBackColor = true;
            this.btnCreateOdbc.Click += new System.EventHandler(this.btnCreateOdbc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetLocalization);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(512, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(500, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. ตั้งค่าประเทศและภาษา";
            // 
            // btnSetLocalization
            // 
            this.btnSetLocalization.Location = new System.Drawing.Point(220, 95);
            this.btnSetLocalization.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetLocalization.Name = "btnSetLocalization";
            this.btnSetLocalization.Size = new System.Drawing.Size(260, 40);
            this.btnSetLocalization.TabIndex = 1;
            this.btnSetLocalization.Text = "ตั้งค่าเป็นไทยทั้งหมด (ต้อง Restart)";
            this.btnSetLocalization.UseVisualStyleBackColor = true;
            this.btnSetLocalization.Click += new System.EventHandler(this.btnSetLocalization_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(480, 50);
            this.label3.TabIndex = 0;
            this.label3.Text = "ตั้งค่า Timezone, Region เป็น Bangkok, Thailand เพิ่มคีย์บอร์ดไทย และตั้งค่าปุ่ม `" +
    " เป็นตัวสลับภาษา";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnInstallFonts);
            this.groupBox3.Location = new System.Drawing.Point(4, 162);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(500, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. ติดตั้งฟอนต์";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(480, 50);
            this.label4.TabIndex = 2;
            this.label4.Text = "โปรแกรมจะค้นหาไฟล์ .ttf และ .otf จากโฟลเดอร์ชื่อ \'Fonts\' ที่อยู่ในระดับเดียวกับไฟ" +
    "ล์ exe ของโปรแกรมนี้";
            // 
            // btnInstallFonts
            // 
            this.btnInstallFonts.Location = new System.Drawing.Point(350, 95);
            this.btnInstallFonts.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstallFonts.Name = "btnInstallFonts";
            this.btnInstallFonts.Size = new System.Drawing.Size(130, 40);
            this.btnInstallFonts.TabIndex = 1;
            this.btnInstallFonts.Text = "ติดตั้งฟอนต์";
            this.btnInstallFonts.UseVisualStyleBackColor = true;
            this.btnInstallFonts.Click += new System.EventHandler(this.btnInstallFonts_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtShortcutTarget);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtShortcutName);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnCreateShortcut);
            this.groupBox4.Location = new System.Drawing.Point(512, 162);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(500, 150);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. สร้าง Shortcut บน Desktop";
            // 
            // txtShortcutTarget
            // 
            this.txtShortcutTarget.Location = new System.Drawing.Point(120, 60);
            this.txtShortcutTarget.Margin = new System.Windows.Forms.Padding(4);
            this.txtShortcutTarget.Name = "txtShortcutTarget";
            this.txtShortcutTarget.Size = new System.Drawing.Size(360, 22);
            this.txtShortcutTarget.TabIndex = 8;
            this.txtShortcutTarget.Text = "https://www.google.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Target Path:";
            // 
            // txtShortcutName
            // 
            this.txtShortcutName.Location = new System.Drawing.Point(120, 28);
            this.txtShortcutName.Margin = new System.Windows.Forms.Padding(4);
            this.txtShortcutName.Name = "txtShortcutName";
            this.txtShortcutName.Size = new System.Drawing.Size(360, 22);
            this.txtShortcutName.TabIndex = 6;
            this.txtShortcutName.Text = "Google";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Shortcut Name:";
            // 
            // btnCreateShortcut
            // 
            this.btnCreateShortcut.Location = new System.Drawing.Point(350, 95);
            this.btnCreateShortcut.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateShortcut.Name = "btnCreateShortcut";
            this.btnCreateShortcut.Size = new System.Drawing.Size(130, 40);
            this.btnCreateShortcut.TabIndex = 9;
            this.btnCreateShortcut.Text = "สร้าง Shortcut";
            this.btnCreateShortcut.UseVisualStyleBackColor = true;
            this.btnCreateShortcut.Click += new System.EventHandler(this.btnCreateShortcut_Click);
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 16;
            this.listBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.listBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(1021, 322);
            this.listBoxStatus.TabIndex = 0;
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
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxStatus);
            this.splitContainer1.Size = new System.Drawing.Size(1021, 650);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1021, 323);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // WindowsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WindowsSettingsControl";
            this.Size = new System.Drawing.Size(1021, 650);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreateOdbc;
        private System.Windows.Forms.TextBox txtOdbcDsnName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOdbcServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSetLocalization;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInstallFonts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCreateShortcut;
        private System.Windows.Forms.TextBox txtShortcutTarget;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShortcutName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
