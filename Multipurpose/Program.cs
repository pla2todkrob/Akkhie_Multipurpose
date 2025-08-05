using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"เกิดข้อผิดพลาดที่ไม่คาดคิด: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // คุณสามารถเพิ่มโค้ดบันทึก Error ลงไฟล์ได้ที่นี่
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"เกิดข้อผิดพลาดร้ายแรง: {(e.ExceptionObject as Exception).Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // คุณสามารถเพิ่มโค้ดบันทึก Error ลงไฟล์ได้ที่นี่
        }
    }
}
