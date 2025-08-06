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
    public partial class Main : Form
    {
        private UserControl currentControl = null;
        private Button currentButton = null;

        // --- UI Improvement: Define modern colors ---
        private readonly Color activeColor = Color.FromArgb(224, 231, 255); // A modern blue for selection
        private readonly Color inactiveColor = Color.FromArgb(248, 250, 252); // A very light gray for the nav background

        public Main()
        {
            InitializeComponent();
            // --- UI Improvement: Set modern font for the entire form ---
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            navPanel.BackColor = inactiveColor; // Apply the new nav panel color

            // --- Logic Fix & UI Improvement: Consolidated version and admin check ---
            SetVersionAndAdminStatus();

            // Set initial view
            btnAkpAppTools.PerformClick();
        }

        /// <summary>
        /// --- REVISED METHOD ---
        /// Sets the version label text consistently from the Assembly.
        /// Also checks for Administrator privileges and updates the UI accordingly.
        /// </summary>
        private void SetVersionAndAdminStatus()
        {
            // 1. Get version from Assembly - this is now the single source of truth.
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string versionText = $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";

            // 2. Check for Administrator privileges.
            bool isAdmin;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            // 3. Update UI based on admin status.
            panelAdminTools.Enabled = isAdmin;
            panelAdminStatus.Visible = !isAdmin;

            if (isAdmin)
            {
                lblVersion.Text = $"Version: {versionText} (Administrator)";
                // --- UI Improvement: Visual cue for admin mode on status bar ---
                statusStrip1.BackColor = Color.FromArgb(217, 249, 217); // A light green color
            }
            else
            {
                // If not admin, show the base version text.
                lblVersion.Text = $"Version: {versionText}";
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

        #region UI Control Methods

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
                currentButton.BackColor = inactiveColor; // Revert to inactive color
            }

            if (selectedButton != null)
            {
                selectedButton.BackColor = activeColor; // Set active color
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
                // The user cancelled the UAC prompt. No action needed.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to restart the application with admin rights.\n\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
