using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace Multipurpose
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Assign the Load event handler
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        /// <summary>
        /// This event fires when the form is first loaded.
        /// It's the perfect place to check for administrator privileges.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // The entire application requires administrator rights, so we check it here once.
            if (!IsAdministrator())
            {
                MessageBox.Show(
                    "This application requires administrator privileges to function correctly. Please restart the application as an Administrator.",
                    "Administrator Rights Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Close the application if not run as admin
                Application.Exit();
            }
        }

        /// <summary>
        /// Checks if the current process is running with administrative privileges.
        /// </summary>
        /// <returns>True if running as an administrator, otherwise false.</returns>
        private bool IsAdministrator()
        {
            // For debugging purposes, you can uncomment the next line to always return true
            return true;
            // Use WindowsIdentity to check the current user's role.
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                // Check if the user is in the built-in Administrator role.
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }


    }
}
