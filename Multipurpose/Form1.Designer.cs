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
            this.windowsSettingsControl1 = new Multipurpose.WindowsSettingsControl();
            this.windowsUpgradeControl1 = new Multipurpose.WindowsUpgradeControl();
            this.officeToolsControl1 = new Multipurpose.OfficeToolsControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowsSettingsControl1
            // 
            this.windowsSettingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsSettingsControl1.Location = new System.Drawing.Point(0, 0);
            this.windowsSettingsControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.windowsSettingsControl1.Name = "windowsSettingsControl1";
            this.windowsSettingsControl1.Size = new System.Drawing.Size(776, 535);
            this.windowsSettingsControl1.TabIndex = 0;
            // 
            // windowsUpgradeControl1
            // 
            this.windowsUpgradeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsUpgradeControl1.Location = new System.Drawing.Point(3, 3);
            this.windowsUpgradeControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.windowsUpgradeControl1.Name = "windowsUpgradeControl1";
            this.windowsUpgradeControl1.Size = new System.Drawing.Size(770, 529);
            this.windowsUpgradeControl1.TabIndex = 0;
            // 
            // officeToolsControl1
            // 
            this.officeToolsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.officeToolsControl1.Location = new System.Drawing.Point(2, 2);
            this.officeToolsControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.officeToolsControl1.Name = "officeToolsControl1";
            this.officeToolsControl1.Size = new System.Drawing.Size(772, 531);
            this.officeToolsControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
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
            this.tabPage2.Controls.Add(this.windowsUpgradeControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(776, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Upgrade Windows";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.windowsSettingsControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ตั้งค่า Windows";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.officeToolsControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Size = new System.Drawing.Size(776, 535);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Activate Office";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Akkhie Multipurpose Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private WindowsSettingsControl windowsSettingsControl1;
        private WindowsUpgradeControl windowsUpgradeControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private OfficeToolsControl officeToolsControl1;
    }
}
