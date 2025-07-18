﻿namespace Multipurpose
{
    partial class UpdateSetApp
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabTroubleshooter = new System.Windows.Forms.TabPage();
            this.troubleshooterControl1 = new Multipurpose.TroubleshooterControl();
            this.tabShippingCost = new System.Windows.Forms.TabPage();
            this.shippingCostControl1 = new Multipurpose.ShippingCostControl();
            this.tlpMain.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabTroubleshooter.SuspendLayout();
            this.tabShippingCost.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.White;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.headerPanel, 0, 0);
            this.tlpMain.Controls.Add(this.tabMain, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10);
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(958, 631);
            this.tlpMain.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(13, 13);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(932, 44);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Update && Settings";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabTroubleshooter);
            this.tabMain.Controls.Add(this.tabShippingCost);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(13, 63);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(932, 555);
            this.tabMain.TabIndex = 1;
            // 
            // tabTroubleshooter
            // 
            this.tabTroubleshooter.Controls.Add(this.troubleshooterControl1);
            this.tabTroubleshooter.Location = new System.Drawing.Point(4, 26);
            this.tabTroubleshooter.Name = "tabTroubleshooter";
            this.tabTroubleshooter.Padding = new System.Windows.Forms.Padding(3);
            this.tabTroubleshooter.Size = new System.Drawing.Size(924, 525);
            this.tabTroubleshooter.TabIndex = 0;
            this.tabTroubleshooter.Text = "เครื่องมือแก้ไขปัญหา";
            this.tabTroubleshooter.UseVisualStyleBackColor = true;
            // 
            // troubleshooterControl1
            // 
            this.troubleshooterControl1.BackColor = System.Drawing.Color.White;
            this.troubleshooterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.troubleshooterControl1.Location = new System.Drawing.Point(3, 3);
            this.troubleshooterControl1.Name = "troubleshooterControl1";
            this.troubleshooterControl1.Size = new System.Drawing.Size(918, 519);
            this.troubleshooterControl1.TabIndex = 0;
            // 
            // tabShippingCost
            // 
            this.tabShippingCost.Controls.Add(this.shippingCostControl1);
            this.tabShippingCost.Location = new System.Drawing.Point(4, 26);
            this.tabShippingCost.Name = "tabShippingCost";
            this.tabShippingCost.Padding = new System.Windows.Forms.Padding(3);
            this.tabShippingCost.Size = new System.Drawing.Size(924, 525);
            this.tabShippingCost.TabIndex = 1;
            this.tabShippingCost.Text = "จัดการค่าขนส่ง";
            this.tabShippingCost.UseVisualStyleBackColor = true;
            // 
            // shippingCostControl1
            // 
            this.shippingCostControl1.BackColor = System.Drawing.Color.White;
            this.shippingCostControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shippingCostControl1.Location = new System.Drawing.Point(3, 3);
            this.shippingCostControl1.Name = "shippingCostControl1";
            this.shippingCostControl1.Size = new System.Drawing.Size(918, 519);
            this.shippingCostControl1.TabIndex = 0;
            // 
            // UpdateSetApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "UpdateSetApp";
            this.Size = new System.Drawing.Size(958, 631);
            this.tlpMain.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabTroubleshooter.ResumeLayout(false);
            this.tabShippingCost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabTroubleshooter;
        private TroubleshooterControl troubleshooterControl1;
        private System.Windows.Forms.TabPage tabShippingCost;
        private ShippingCostControl shippingCostControl1;
    }
}
