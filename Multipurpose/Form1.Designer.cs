namespace Multipurpose
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonBeforeRestart = new System.Windows.Forms.Button();
            this.buttonAfterRestart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxLicenseKey = new System.Windows.Forms.TextBox();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(776, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "แก้ AKP App";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(776, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Upgrade windows 11 pro";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxStatus);
            this.splitContainer1.Size = new System.Drawing.Size(770, 529);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonBeforeRestart);
            this.groupBox2.Controls.Add(this.buttonAfterRestart);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // buttonBeforeRestart
            // 
            this.buttonBeforeRestart.AutoSize = true;
            this.buttonBeforeRestart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBeforeRestart.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonBeforeRestart.Location = new System.Drawing.Point(563, 16);
            this.buttonBeforeRestart.Name = "buttonBeforeRestart";
            this.buttonBeforeRestart.Size = new System.Drawing.Size(105, 53);
            this.buttonBeforeRestart.TabIndex = 0;
            this.buttonBeforeRestart.Text = "1. ล้าง License เก่า";
            this.buttonBeforeRestart.UseVisualStyleBackColor = true;
            this.buttonBeforeRestart.Click += new System.EventHandler(this.buttonBeforeRestart_Click);
            // 
            // buttonAfterRestart
            // 
            this.buttonAfterRestart.AutoSize = true;
            this.buttonAfterRestart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAfterRestart.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAfterRestart.Location = new System.Drawing.Point(668, 16);
            this.buttonAfterRestart.Name = "buttonAfterRestart";
            this.buttonAfterRestart.Size = new System.Drawing.Size(99, 53);
            this.buttonAfterRestart.TabIndex = 1;
            this.buttonAfterRestart.Text = "2. ติดตั้ง Upgrade";
            this.buttonAfterRestart.UseVisualStyleBackColor = true;
            this.buttonAfterRestart.Click += new System.EventHandler(this.buttonAfterRestart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.textBoxLicenseKey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "License key";
            // 
            // textBoxLicenseKey
            // 
            this.textBoxLicenseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLicenseKey.Location = new System.Drawing.Point(3, 16);
            this.textBoxLicenseKey.Name = "textBoxLicenseKey";
            this.textBoxLicenseKey.Size = new System.Drawing.Size(764, 20);
            this.textBoxLicenseKey.TabIndex = 0;
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(770, 406);
            this.listBoxStatus.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ตั้งค่า Windows";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxLicenseKey;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.Button buttonAfterRestart;
        private System.Windows.Forms.Button buttonBeforeRestart;
    }
}

