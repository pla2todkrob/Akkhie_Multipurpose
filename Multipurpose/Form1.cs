using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multipurpose
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ฟังก์ชันสำหรับรันคำสั่ง CMD และแสดงผลลัพธ์ใน ListBox แบบ Asynchronous
        private async Task RunCmdCommand(string command, string arguments = "")
        {
            try
            {
                // ตรวจสอบว่าโปรแกรมถูกรันในฐานะ Administrator หรือไม่
                if (!IsAdministrator())
                {
                    MessageBox.Show("โปรดรันโปรแกรมในฐานะ Administrator", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit(); // ปิดโปรแกรมหากไม่ใช่ Administrator
                    return;
                }

                // การอัปเดต UI จาก Background Thread ต้องใช้ Invoke
                Invoke((MethodInvoker)delegate
                {
                    listBoxStatus.Items.Add($"รันคำสั่ง: {command} {arguments}");
                    listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1; // เลื่อนไปบรรทัดสุดท้าย
                });

                // ย้ายการรัน Process ไปยัง Background Thread
                await Task.Run(async () => // async delegate for Task.Run
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/C {command} {arguments}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true // ไม่แสดงหน้าต่าง CMD
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        process.Start();

                        // อ่าน Output จาก CMD แบบ Asynchronous
                        string output = await process.StandardOutput.ReadToEndAsync();
                        string error = await process.StandardError.ReadToEndAsync();

                        process.WaitForExit();

                        // แสดงผลลัพธ์ใน ListBox (ต้อง Invoke กลับไปที่ UI Thread)
                        Invoke((MethodInvoker)delegate
                        {
                            if (!string.IsNullOrEmpty(output))
                            {
                                foreach (string line in output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    listBoxStatus.Items.Add($"> {line}");
                                }
                            }
                            if (!string.IsNullOrEmpty(error))
                            {
                                foreach (string line in error.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    listBoxStatus.Items.Add($"ข้อผิดพลาด: {line}");
                                }
                            }
                            listBoxStatus.Items.Add("------------------------------------");
                            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1; // เลื่อนไปบรรทัดสุดท้าย
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                Invoke((MethodInvoker)delegate
                {
                    listBoxStatus.Items.Add($"เกิดข้อผิดพลาด: {ex.Message}");
                    listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
                });
            }
        }

        // ฟังก์ชันตรวจสอบว่าโปรแกรมรันในฐานะ Administrator หรือไม่
        private bool IsAdministrator()
        {
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        // ฟังก์ชันสำหรับเรียกใช้งานเมื่อคลิกปุ่ม "ก่อน Restart" (เปลี่ยนเป็น async void)
        private async void buttonBeforeRestart_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- เริ่มต้นการเตรียมการและเปลี่ยน Edition ---");
            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;

            // 1. ถอนคีย์เก่าออก
            await RunCmdCommand("slmgr", "/upk");
            await RunCmdCommand("slmgr", "/cpky");

            // 2. เตรียมการเปลี่ยน Editions
            // ใช้แค่ sc config ก็เพียงพอ เพราะ net start จะ error ถ้า service รันอยู่แล้ว
            await RunCmdCommand("sc config LicenseManager start=auto");
            await RunCmdCommand("sc config wuauserv start=auto");
            // หากต้องการให้แน่ใจว่า Service เริ่มทำงานจริงๆ และไม่สนใจ Error ที่ Service รันอยู่แล้ว
            // await RunCmdCommand("net start LicenseManager || true");
            // await RunCmdCommand("net start wuauserv || true");

            // 3. เปลี่ยน Editions ด้วย Windows 10/11 Generic key
            // ใช้ Path เต็มสำหรับ changepk.exe
            listBoxStatus.Items.Add("กำลังเปลี่ยน Editions ด้วย Generic Key... เครื่องอาจจะ Restart.");
            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
            await RunCmdCommand("changepk.exe", "/productkey VK7JG-NPHTM-C97JM-9MPGT-3V66T");

            listBoxStatus.Items.Add("--- กระบวนการก่อน Restart เสร็จสิ้น (เครื่องอาจจะ Restart ไปแล้ว) ---");
            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
        }

        // ฟังก์ชันสำหรับเรียกใช้งานเมื่อคลิกปุ่ม "หลัง Restart" (เปลี่ยนเป็น async void)
        private async void buttonAfterRestart_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
            listBoxStatus.Items.Add("--- เริ่มต้นการลงทะเบียน Windows ด้วย License ใหม่ ---");
            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;

            string licenseKey = textBoxLicenseKey.Text.Trim();

            if (string.IsNullOrEmpty(licenseKey) || licenseKey.Length != 29 || licenseKey.Split('-').Length != 5)
            {
                MessageBox.Show("กรุณากรอก License Key ให้ถูกต้อง (เช่น XXXXX-XXXXX-XXXXX-XXXXX-XXXXX)", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. ลงทะเบียน Windows ด้วย License ใหม่
            await RunCmdCommand("slmgr", $"/ipk {licenseKey}");
            await RunCmdCommand("slmgr", "/ato");
            await RunCmdCommand("slmgr", "/xpr");
            await RunCmdCommand("slmgr", "/dli");

            listBoxStatus.Items.Add("--- กระบวนการหลัง Restart และลงทะเบียนเสร็จสิ้น ---");
            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
        }
    }
}
