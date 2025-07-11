using System;
using System.Diagnostics;
using System.Drawing;
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
            this.MinimumSize = new Size(800, 600);

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"Version: {version.Major}.{version.Minor}.{version.Build}";

            CheckAdministratorPrivileges();

            // Set the default view to AKP App Tools
            btnAkpAppTools.PerformClick();
        }

        /// <summary>
        /// Checks if the application is running with administrator privileges
        /// and adjusts the UI accordingly.
        /// </summary>
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

        /// <summary>
        /// A generic function to switch the displayed UserControl in the main panel.
        /// </summary>
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

        /// <summary>
        /// Updates the visual state of the navigation buttons to indicate the active selection.
        /// </summary>
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

        #region Navigation Button Click Events

        // Group 1: AKP App Tools
        private void btnAkpAppTools_Click(object sender, EventArgs e)
        {
            ShowUserControl(new AkpAppToolsControl(), sender);
        }

        // Group 2: Admin Tools
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

        /// <summary>
        /// Restarts the application with administrator privileges.
        /// </summary>
        private void btnRestartAsAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Verb = "runas" // This requests elevation
                };
                Process.Start(startInfo);
                Application.Exit();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // User clicked "No" on the UAC prompt.
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
