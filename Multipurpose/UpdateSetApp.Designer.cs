namespace Multipurpose
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabTroubleshooter = new System.Windows.Forms.TabPage();
            this.tabShippingCost = new System.Windows.Forms.TabPage();
            this.troubleshooterControl1 = new Multipurpose.TroubleshooterControl();
            this.shippingCostControl1 = new Multipurpose.ShippingCostControl();
            this.tabMain.SuspendLayout();
            this.tabTroubleshooter.SuspendLayout();
            this.tabShippingCost.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabTroubleshooter);
            this.tabMain.Controls.Add(this.tabShippingCost);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(958, 631);
            this.tabMain.TabIndex = 0;
            // 
            // tabTroubleshooter
            // 
            this.tabTroubleshooter.Controls.Add(this.troubleshooterControl1);
            this.tabTroubleshooter.Location = new System.Drawing.Point(4, 25);
            this.tabTroubleshooter.Name = "tabTroubleshooter";
            this.tabTroubleshooter.Padding = new System.Windows.Forms.Padding(3);
            this.tabTroubleshooter.Size = new System.Drawing.Size(950, 602);
            this.tabTroubleshooter.TabIndex = 0;
            this.tabTroubleshooter.Text = "เครื่องมือแก้ไขปัญหา";
            this.tabTroubleshooter.UseVisualStyleBackColor = true;
            // 
            // tabShippingCost
            // 
            this.tabShippingCost.Controls.Add(this.shippingCostControl1);
            this.tabShippingCost.Location = new System.Drawing.Point(4, 25);
            this.tabShippingCost.Name = "tabShippingCost";
            this.tabShippingCost.Padding = new System.Windows.Forms.Padding(3);
            this.tabShippingCost.Size = new System.Drawing.Size(950, 602);
            this.tabShippingCost.TabIndex = 1;
            this.tabShippingCost.Text = "จัดการค่าขนส่ง";
            this.tabShippingCost.UseVisualStyleBackColor = true;
            // 
            // troubleshooterControl1
            // 
            this.troubleshooterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.troubleshooterControl1.Location = new System.Drawing.Point(3, 3);
            this.troubleshooterControl1.Name = "troubleshooterControl1";
            this.troubleshooterControl1.Size = new System.Drawing.Size(944, 596);
            this.troubleshooterControl1.TabIndex = 0;
            // 
            // shippingCostControl1
            // 
            this.shippingCostControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shippingCostControl1.Location = new System.Drawing.Point(3, 3);
            this.shippingCostControl1.Name = "shippingCostControl1";
            this.shippingCostControl1.Size = new System.Drawing.Size(944, 596);
            this.shippingCostControl1.TabIndex = 0;
            // 
            // UpdateSetApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Name = "UpdateSetApp";
            this.Size = new System.Drawing.Size(958, 631);
            this.tabMain.ResumeLayout(false);
            this.tabTroubleshooter.ResumeLayout(false);
            this.tabShippingCost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabTroubleshooter;
        private System.Windows.Forms.TabPage tabShippingCost;
        private TroubleshooterControl troubleshooterControl1;
        private ShippingCostControl shippingCostControl1;
    }
}
