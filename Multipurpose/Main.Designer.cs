namespace Multipurpose
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.navPanel = new System.Windows.Forms.Panel();
            this.panelAdminTools = new System.Windows.Forms.Panel();
            this.btnWindowsUpgrade = new System.Windows.Forms.Button();
            this.btnWindowsSettings = new System.Windows.Forms.Button();
            this.btnOfficeTools = new System.Windows.Forms.Button();
            this.lblAdminTools = new System.Windows.Forms.Label();
            this.panelAkpTools = new System.Windows.Forms.Panel();
            this.btnAkpAppTools = new System.Windows.Forms.Button();
            this.lblAkpTools = new System.Windows.Forms.Label();
            this.panelAdminStatus = new System.Windows.Forms.Panel();
            this.btnRestartAsAdmin = new System.Windows.Forms.Button();
            this.lblAdminWarning = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOpenUserManual = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenDevManual = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.panelAdminTools.SuspendLayout();
            this.panelAkpTools.SuspendLayout();
            this.panelAdminStatus.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.navPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.mainPanel, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1262, 673);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // navPanel
            // 
            this.navPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.navPanel.Controls.Add(this.panelAdminTools);
            this.navPanel.Controls.Add(this.panelAkpTools);
            this.navPanel.Controls.Add(this.panelAdminStatus);
            this.navPanel.Controls.Add(this.logoPanel);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navPanel.Location = new System.Drawing.Point(0, 0);
            this.navPanel.Margin = new System.Windows.Forms.Padding(0);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(250, 673);
            this.navPanel.TabIndex = 0;
            // 
            // panelAdminTools
            // 
            this.panelAdminTools.Controls.Add(this.btnWindowsUpgrade);
            this.panelAdminTools.Controls.Add(this.btnWindowsSettings);
            this.panelAdminTools.Controls.Add(this.btnOfficeTools);
            this.panelAdminTools.Controls.Add(this.lblAdminTools);
            this.panelAdminTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdminTools.Location = new System.Drawing.Point(0, 155);
            this.panelAdminTools.Name = "panelAdminTools";
            this.panelAdminTools.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelAdminTools.Size = new System.Drawing.Size(250, 170);
            this.panelAdminTools.TabIndex = 2;
            // 
            // btnWindowsUpgrade
            // 
            this.btnWindowsUpgrade.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWindowsUpgrade.FlatAppearance.BorderSize = 0;
            this.btnWindowsUpgrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowsUpgrade.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowsUpgrade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWindowsUpgrade.Location = new System.Drawing.Point(0, 120);
            this.btnWindowsUpgrade.Name = "btnWindowsUpgrade";
            this.btnWindowsUpgrade.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnWindowsUpgrade.Size = new System.Drawing.Size(250, 45);
            this.btnWindowsUpgrade.TabIndex = 8;
            this.btnWindowsUpgrade.Text = "      Windows Upgrade";
            this.btnWindowsUpgrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWindowsUpgrade.UseVisualStyleBackColor = true;
            this.btnWindowsUpgrade.Click += new System.EventHandler(this.btnWindowsUpgrade_Click);
            // 
            // btnWindowsSettings
            // 
            this.btnWindowsSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWindowsSettings.FlatAppearance.BorderSize = 0;
            this.btnWindowsSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowsSettings.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowsSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWindowsSettings.Location = new System.Drawing.Point(0, 75);
            this.btnWindowsSettings.Name = "btnWindowsSettings";
            this.btnWindowsSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnWindowsSettings.Size = new System.Drawing.Size(250, 45);
            this.btnWindowsSettings.TabIndex = 7;
            this.btnWindowsSettings.Text = "      Windows Settings";
            this.btnWindowsSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWindowsSettings.UseVisualStyleBackColor = true;
            this.btnWindowsSettings.Click += new System.EventHandler(this.btnWindowsSettings_Click);
            // 
            // btnOfficeTools
            // 
            this.btnOfficeTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOfficeTools.FlatAppearance.BorderSize = 0;
            this.btnOfficeTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOfficeTools.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOfficeTools.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOfficeTools.Location = new System.Drawing.Point(0, 30);
            this.btnOfficeTools.Name = "btnOfficeTools";
            this.btnOfficeTools.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnOfficeTools.Size = new System.Drawing.Size(250, 45);
            this.btnOfficeTools.TabIndex = 6;
            this.btnOfficeTools.Text = "      Office Tools";
            this.btnOfficeTools.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOfficeTools.UseVisualStyleBackColor = true;
            this.btnOfficeTools.Click += new System.EventHandler(this.btnOfficeTools_Click);
            // 
            // lblAdminTools
            // 
            this.lblAdminTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdminTools.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminTools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAdminTools.Location = new System.Drawing.Point(0, 10);
            this.lblAdminTools.Name = "lblAdminTools";
            this.lblAdminTools.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblAdminTools.Size = new System.Drawing.Size(250, 20);
            this.lblAdminTools.TabIndex = 0;
            this.lblAdminTools.Text = "ADMIN TOOLS";
            // 
            // panelAkpTools
            // 
            this.panelAkpTools.Controls.Add(this.btnAkpAppTools);
            this.panelAkpTools.Controls.Add(this.lblAkpTools);
            this.panelAkpTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAkpTools.Location = new System.Drawing.Point(0, 60);
            this.panelAkpTools.Name = "panelAkpTools";
            this.panelAkpTools.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelAkpTools.Size = new System.Drawing.Size(250, 95);
            this.panelAkpTools.TabIndex = 1;
            // 
            // btnAkpAppTools
            // 
            this.btnAkpAppTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAkpAppTools.FlatAppearance.BorderSize = 0;
            this.btnAkpAppTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAkpAppTools.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAkpAppTools.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAkpAppTools.Location = new System.Drawing.Point(0, 30);
            this.btnAkpAppTools.Name = "btnAkpAppTools";
            this.btnAkpAppTools.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAkpAppTools.Size = new System.Drawing.Size(250, 45);
            this.btnAkpAppTools.TabIndex = 1;
            this.btnAkpAppTools.Text = "      AKP App Tools";
            this.btnAkpAppTools.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAkpAppTools.UseVisualStyleBackColor = true;
            this.btnAkpAppTools.Click += new System.EventHandler(this.btnAkpAppTools_Click);
            // 
            // lblAkpTools
            // 
            this.lblAkpTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAkpTools.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAkpTools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAkpTools.Location = new System.Drawing.Point(0, 10);
            this.lblAkpTools.Name = "lblAkpTools";
            this.lblAkpTools.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblAkpTools.Size = new System.Drawing.Size(250, 20);
            this.lblAkpTools.TabIndex = 0;
            this.lblAkpTools.Text = "AKP APP TOOLS";
            // 
            // panelAdminStatus
            // 
            this.panelAdminStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelAdminStatus.Controls.Add(this.btnRestartAsAdmin);
            this.panelAdminStatus.Controls.Add(this.lblAdminWarning);
            this.panelAdminStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAdminStatus.Location = new System.Drawing.Point(0, 573);
            this.panelAdminStatus.Name = "panelAdminStatus";
            this.panelAdminStatus.Size = new System.Drawing.Size(250, 100);
            this.panelAdminStatus.TabIndex = 3;
            this.panelAdminStatus.Visible = false;
            // 
            // btnRestartAsAdmin
            // 
            this.btnRestartAsAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestartAsAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRestartAsAdmin.FlatAppearance.BorderSize = 0;
            this.btnRestartAsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestartAsAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestartAsAdmin.ForeColor = System.Drawing.Color.White;
            this.btnRestartAsAdmin.Location = new System.Drawing.Point(15, 53);
            this.btnRestartAsAdmin.Name = "btnRestartAsAdmin";
            this.btnRestartAsAdmin.Size = new System.Drawing.Size(220, 35);
            this.btnRestartAsAdmin.TabIndex = 1;
            this.btnRestartAsAdmin.Text = "Restart as Administrator";
            this.btnRestartAsAdmin.UseVisualStyleBackColor = false;
            this.btnRestartAsAdmin.Click += new System.EventHandler(this.btnRestartAsAdmin_Click);
            // 
            // lblAdminWarning
            // 
            this.lblAdminWarning.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblAdminWarning.Location = new System.Drawing.Point(12, 9);
            this.lblAdminWarning.Name = "lblAdminWarning";
            this.lblAdminWarning.Size = new System.Drawing.Size(223, 41);
            this.lblAdminWarning.TabIndex = 0;
            this.lblAdminWarning.Text = "Admin Tools are disabled. Please run the application as an administrator.";
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.lblAppName);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 60);
            this.logoPanel.TabIndex = 0;
            // 
            // lblAppName
            // 
            this.lblAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblAppName.Location = new System.Drawing.Point(0, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(250, 60);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "Multipurpose Tools";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(253, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1006, 667);
            this.mainPanel.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion,
            this.toolStripStatusLabel1,
            this.btnHelp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1262, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(65, 17);
            this.lblVersion.Text = "Version: ...";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1136, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenUserManual,
            this.btnOpenDevManual});
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(46, 20);
            this.btnHelp.Text = "คู่มือ";
            // 
            // btnOpenUserManual
            // 
            this.btnOpenUserManual.Name = "btnOpenUserManual";
            this.btnOpenUserManual.Size = new System.Drawing.Size(149, 22);
            this.btnOpenUserManual.Text = "สำหรับผู้ใช้งาน";
            this.btnOpenUserManual.Click += new System.EventHandler(this.btnOpenUserManual_Click);
            // 
            // btnOpenDevManual
            // 
            this.btnOpenDevManual.Name = "btnOpenDevManual";
            this.btnOpenDevManual.Size = new System.Drawing.Size(149, 22);
            this.btnOpenDevManual.Text = "สำหรับนักพัฒนา";
            this.btnOpenDevManual.Click += new System.EventHandler(this.btnOpenDevManual_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Akkhie Multipurpose Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.navPanel.ResumeLayout(false);
            this.panelAdminTools.ResumeLayout(false);
            this.panelAkpTools.ResumeLayout(false);
            this.panelAdminStatus.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnOfficeTools;
        private System.Windows.Forms.Button btnWindowsUpgrade;
        private System.Windows.Forms.Button btnWindowsSettings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.Panel panelAkpTools;
        private System.Windows.Forms.Button btnAkpAppTools;
        private System.Windows.Forms.Label lblAkpTools;
        private System.Windows.Forms.Panel panelAdminTools;
        private System.Windows.Forms.Label lblAdminTools;
        private System.Windows.Forms.Panel panelAdminStatus;
        private System.Windows.Forms.Button btnRestartAsAdmin;
        private System.Windows.Forms.Label lblAdminWarning;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton btnHelp;
        private System.Windows.Forms.ToolStripMenuItem btnOpenUserManual;
        private System.Windows.Forms.ToolStripMenuItem btnOpenDevManual;
    }
}
