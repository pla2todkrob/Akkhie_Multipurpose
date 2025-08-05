using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace Multipurpose
{
    public partial class Form1 : Form
    {
        private UserControl currentControl = null;
        private Button currentButton = null;
        private readonly Color activeColor = Color.FromArgb(224, 231, 255);
        private readonly Color inactiveColor = Color.FromArgb(240, 242, 245);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1024, 768);

            SetVersionNumber(); // Call the method to set version
            CheckAdministratorPrivileges();
            btnAkpAppTools.PerformClick();
        }

        /// <summary>
        /// Sets the version label text based on whether the application is network deployed.
        /// </summary>
        private void SetVersionNumber()
        {
            try
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    // If deployed via ClickOnce, use the publish version.
                    lblVersion.Text = $"Version: {ApplicationDeployment.CurrentDeployment.CurrentVersion}";
                }
                else
                {
                    // If running from Visual Studio (debug), use the assembly version.
                    var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
                    lblVersion.Text = $"Version: {assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build} (Dev)";
                }
            }
            catch (Exception)
            {
                // Fallback if version info cannot be read.
                lblVersion.Text = "Version: N/A";
            }
        }

        /// <summary>
        /// Handles the click event for the "User Manual" menu item.
        /// </summary>
        private void btnOpenUserManual_Click(object sender, EventArgs e)
        {
            OpenFileFromDocumentFolder("คู่มือสำหรับผู้ใช้งาน.pdf");
        }

        /// <summary>
        /// Handles the click event for the "Developer Manual" menu item.
        /// </summary>
        private void btnOpenDevManual_Click(object sender, EventArgs e)
        {
            OpenFileFromDocumentFolder("คู่มือสำหรับนักพัฒนา.pdf");
        }

        /// <summary>
        /// A helper method to open a specified file from the "Document" subfolder.
        /// </summary>
        /// <param name="fileName">The name of the file to open.</param>
        private void OpenFileFromDocumentFolder(string fileName)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(baseDirectory, "Document", fileName);

                if (File.Exists(filePath))
                {
                    Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show($"ไม่พบไฟล์คู่มือที่: {filePath}", "ไม่พบไฟล์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถเปิดไฟล์ได้: {ex.Message}", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Original Methods (No changes needed below this line)

        private void CheckAdministratorPrivileges()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

                panelAdminTools.Enabled = isAdmin;
                panelAdminStatus.Visible = !isAdmin;
            }
        }

        private void ShowUserControl(UserControl controlToShow, object sender)
        {
            if (currentControl != null)
            {
                mainPanel.Controls.Remove(currentControl);
                currentControl.Dispose();
            }

            currentControl = controlToShow;
            currentControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(currentControl);

            UpdateButtonSelection(sender as Button);
        }

        private void UpdateButtonSelection(Button selectedButton)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = inactiveColor;
            }

            if (selectedButton != null)
            {
                selectedButton.BackColor = activeColor;
                currentButton = selectedButton;
            }
        }

        private void btnAkpAppTools_Click(object sender, EventArgs e)
        {
            ShowUserControl(new AkpAppToolsControl(), sender);
        }

        private void btnOfficeTools_Click(object sender, EventArgs e)
        {
            ShowUserControl(new OfficeToolsControl(), sender);
        }

        private void btnWindowsSettings_Click(object sender, EventArgs e)
        {
            ShowUserControl(new WindowsSettingsControl(), sender);
        }

        private void btnWindowsUpgrade_Click(object sender, EventArgs e)
        {
            ShowUserControl(new WindowsUpgradeControl(), sender);
        }

        private void btnRestartAsAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };
                Process.Start(startInfo);
                Application.Exit();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("The operation was cancelled by the user.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to restart the application with admin rights.\n\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
