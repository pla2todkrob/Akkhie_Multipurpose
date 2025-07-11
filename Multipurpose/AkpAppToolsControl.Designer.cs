namespace Multipurpose
{
    partial class AkpAppToolsControl
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
            this.troubleshooterControl1 = new Multipurpose.TroubleshooterControl();
            this.tabShippingCost = new System.Windows.Forms.TabPage();
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
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(800, 600);
            this.tabMain.TabIndex = 0;
            // 
            // tabTroubleshooter
            // 
            this.tabTroubleshooter.Controls.Add(this.troubleshooterControl1);
            this.tabTroubleshooter.Location = new System.Drawing.Point(4, 26);
            this.tabTroubleshooter.Name = "tabTroubleshooter";
            this.tabTroubleshooter.Padding = new System.Windows.Forms.Padding(3);
            this.tabTroubleshooter.Size = new System.Drawing.Size(792, 570);
            this.tabTroubleshooter.TabIndex = 0;
            this.tabTroubleshooter.Text = "Troubleshooter";
            this.tabTroubleshooter.UseVisualStyleBackColor = true;
            // 
            // troubleshooterControl1
            // 
            this.troubleshooterControl1.BackColor = System.Drawing.Color.White;
            this.troubleshooterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.troubleshooterControl1.Location = new System.Drawing.Point(3, 3);
            this.troubleshooterControl1.Name = "troubleshooterControl1";
            this.troubleshooterControl1.Size = new System.Drawing.Size(786, 564);
            this.troubleshooterControl1.TabIndex = 0;
            // 
            // tabShippingCost
            // 
            this.tabShippingCost.Controls.Add(this.shippingCostControl1);
            this.tabShippingCost.Location = new System.Drawing.Point(4, 26);
            this.tabShippingCost.Name = "tabShippingCost";
            this.tabShippingCost.Padding = new System.Windows.Forms.Padding(3);
            this.tabShippingCost.Size = new System.Drawing.Size(792, 570);
            this.tabShippingCost.TabIndex = 1;
            this.tabShippingCost.Text = "Shipping Cost";
            this.tabShippingCost.UseVisualStyleBackColor = true;
            // 
            // shippingCostControl1
            // 
            this.shippingCostControl1.BackColor = System.Drawing.Color.White;
            this.shippingCostControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shippingCostControl1.Location = new System.Drawing.Point(3, 3);
            this.shippingCostControl1.Name = "shippingCostControl1";
            this.shippingCostControl1.Size = new System.Drawing.Size(786, 564);
            this.shippingCostControl1.TabIndex = 0;
            // 
            // AkpAppToolsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Name = "AkpAppToolsControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabMain.ResumeLayout(false);
            this.tabTroubleshooter.ResumeLayout(false);
            this.tabShippingCost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabTroubleshooter;
        private TroubleshooterControl troubleshooterControl1;
        private System.Windows.Forms.TabPage tabShippingCost;
        private ShippingCostControl shippingCostControl1;
    }
}
