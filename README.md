Akkhie Multipurpose - โปรแกรมเครื่องมืออเนกประสงค์Akkhie Multipurpose คือแอปพลิเคชัน Desktop สำหรับ Windows ที่รวบรวมเครื่องมืออำนวยความสะดวกสำหรับฝ่าย IT และเครื่องมือแก้ปัญหา (Troubleshooter) สำหรับระบบงานภายในองค์กรไว้ในโปรแกรมเดียว ช่วยลดความซับซ้อนและเพิ่มความรวดเร็วในการทำงาน✨ ฟีเจอร์หลัก (Features)เครื่องมือแก้ปัญหา (Troubleshooter):ระบบที่ยืดหยุ่น สามารถเพิ่มเครื่องมือใหม่ๆ ได้โดยไม่ต้องแก้ไขโค้ดหน้า UIรวมเครื่องมือสำหรับแก้ไขข้อมูลในระบบงานหลัก เช่น ปลดล็อกใบเสนอราคา, แก้ไขข้อมูลลูกค้า, อัปเดตที่อยู่, แก้ไขค่าขนส่ง และอื่นๆจัดการ Windows & Office:เครื่องมือช่วยติดตั้ง License Key สำหรับ Windows และ Microsoft Officeเครื่องมือตั้งค่าพื้นฐานของ Windowsเครื่องมือสำหรับแอปพลิเคชันภายใน (AKP Apps):รวมเครื่องมือเฉพาะทางสำหรับจัดการแอปพลิเคชันของบริษัทเครื่องมือคำนวณค่าขนส่ง:หน้าจอสำหรับคำนวณค่าขนส่งตามเงื่อนไขต่างๆทางลัด (Shortcuts):เข้าถึงโปรแกรมหรือโฟลเดอร์ที่ใช้งานบ่อยได้อย่างรวดเร็วผ่านไฟล์ shortcuts.json🛠️ เทคโนโลยีที่ใช้ (Tech Stack)ภาษา: C#UI Framework: Windows Forms (.NET Framework)ฐานข้อมูล: Microsoft SQL ServerLibraries:Newtonsoft.Json: สำหรับจัดการไฟล์ JSONCsvHelper: สำหรับอ่านไฟล์ CSVMicrosoft.Data.SqlClient: สำหรับเชื่อมต่อฐานข้อมูล SQL Server🚀 การติดตั้งและใช้งาน (Getting Started)ทำตามขั้นตอนต่อไปนี้เพื่อตั้งค่าโปรเจกสำหรับการพัฒนาสิ่งที่ต้องมี (Prerequisites)Visual Studio 2019 หรือใหม่กว่า.NET Framework (เวอร์ชันที่ระบุในโปรเจก)การเข้าถึง Microsoft SQL Serverขั้นตอนการติดตั้ง (Installation)Clone a repository:git clone https://your-repository-url/Akkhie_Multipurpose.git
เปิด Solution:เปิดไฟล์ Multipurpose.sln ด้วย Visual StudioRestore NuGet Packages:คลิกขวาที่ Solution ในหน้า Solution Explorer แล้วเลือก Restore NuGet Packagesตั้งค่า Connection String:เปิดไฟล์ Multipurpose/App.config และแก้ไข connectionStrings ให้ชี้ไปยังฐานข้อมูลของคุณ<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;User ID=YOUR_USER;Password=YOUR_PASSWORD;Integrated Security=False;" 
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
Build และ Run:กด F5 หรือปุ่ม Start ใน Visual Studio เพื่อ Build และรันโปรแกรม🏗️ สถาปัตยกรรม (Architecture)โปรแกรมถูกออกแบบมาให้ง่ายต่อการบำรุงรักษาและขยายความสามารถ โดยมีหัวใจหลักคือ ITroubleshooterTool Interfaceเครื่องมือแก้ปัญหาแต่ละตัวจะเป็น Class ที่ implement ITroubleshooterTool ทำให้ TroubleshooterControl สามารถใช้ Reflection ในการค้นหาและแสดงรายการเครื่องมือทั้งหมดที่มีในโปรเจกได้โดยอัตโนมัติเมื่อโปรแกรมเริ่มทำงาน🧩 การเพิ่มเครื่องมือ Troubleshooter ใหม่คุณสามารถเพิ่มเครื่องมือแก้ปัญหาใหม่ได้อย่างง่ายดาย:ในโฟลเดอร์ Tools สร้าง C# Class ใหม่ให้ Class ใหม่ของคุณ implement ITroubleshooterToolกำหนด ToolName, ToolDescription และเขียน Logic การทำงานในเมธอด Execute()ตัวอย่าง:namespace Multipurpose.Tools
{
    public class MyNewTool : ITroubleshooterTool
    {
        public string ToolName => "เครื่องมือใหม่ของฉัน";
        public string ToolDescription => "คำอธิบายการทำงานของเครื่องมือใหม่";

        public bool Execute(string connectionString, object[] parameters)
        {
            // ... เขียนโค้ดการทำงานของเครื่องมือที่นี่ ...
            // สามารถใช้ connectionString เพื่อเชื่อมต่อฐานข้อมูลได้เลย
            return true; // คืนค่า true หากสำเร็จ
        }
    }
}
เพียงเท่านี้! เมื่อรันโปรแกรมอีกครั้ง เครื่องมือใหม่ของคุณจะปรากฏในรายการให้เลือกใช้งานทันที📄 สิทธิ์การใช้งาน (License)[ระบุประเภทของ License ที่นี่ เช่น MIT, GPL, หรือ Proprietary]
