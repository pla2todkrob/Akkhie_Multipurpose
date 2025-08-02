# Akkhie Multipurpose Tool

โปรแกรมเครื่องมืออเนกประสงค์ (In-house Tool) สำหรับฝ่าย IT Support และผู้ดูแลระบบ พัฒนาด้วย C# Windows Forms เพื่อรวบรวมเครื่องมือที่ใช้งานบ่อยๆ และสคริปต์สำหรับแก้ปัญหาเฉพาะทางไว้ในที่เดียว ช่วยลดขั้นตอนการทำงานที่ซ้ำซ้อนและเพิ่มความรวดเร็วในการดูแลรักษาระบบ

## ✨ คุณสมบัติหลัก (Features)

โปรแกรมถูกแบ่งออกเป็นส่วนต่างๆ ผ่านแท็บเมนู ดังนี้:

### 1. Windows Tools

- **Activate Windows**: เปิดใช้งาน Windows โดยอ่าน License Key จากไฟล์ `Licenses/LicenseWindows.csv` แล้วเรียกใช้คำสั่ง `slmgr.vbs`
- **Upgrade Windows**: อัปเกรดรุ่นของ Windows (เช่น จาก Home เป็น Pro) โดยใช้ Generic Key
- **Set Localization**: ตั้งค่ารูปแบบวันที่, เวลา และตัวเลขของเครื่องให้เป็น th-TH (ไทย) ผ่าน PowerShell Script

### 2. Office Tools

- **Activate Office**: เปิดใช้งาน Microsoft Office ด้วย Key จากไฟล์ `Licenses/LicenseOffice.csv`
- **Remove License**: ล้าง License Key ของ Office ที่ติดตั้งอยู่บนเครื่อง
- **Install Office**: ติดตั้ง Microsoft Office ผ่าน Office Deployment Tool (ODT) ทำให้สามารถเลือกเวอร์ชัน, แอปพลิเคชัน และช่องทางการอัปเดตที่ต้องการได้

### 3. Troubleshooter

เครื่องมือสำหรับแก้ไขปัญหาเฉพาะทางที่เกิดขึ้นบ่อยๆ ระบบถูกออกแบบให้มีความยืดหยุ่นสูง สามารถเพิ่มเครื่องมือใหม่ๆ ได้ง่าย

- **Dynamic Loading**: โปรแกรมจะโหลดเครื่องมือทั้งหมดที่อยู่ในโฟลเดอร์ `/Tools` โดยอัตโนมัติ
- **ตัวอย่างเครื่องมือ**: UnlockQuotationTool, FixShippingCostTool, UpdateAddressTool เป็นต้น (เนื่องจากเป็นเครื่องมือเฉพาะทางสำหรับงานของคุณก้องที่ต้องเชื่อมต่อกับระบบ ERP และฐานข้อมูล MSSQL)

### 4. Shipping Cost Calculator

โปรแกรมคำนวณค่าขนส่งพัสดุอย่างง่าย โดยอิงจากน้ำหนัก, ประเภทการจัดส่ง, และจังหวัดปลายทาง

## 🛠️ สถาปัตยกรรมและเทคโนโลยี (Tech Stack & Architecture)

### เทคโนโลยี
- **ภาษา**: C#
- **เฟรมเวิร์ก**: .NET Framework
- **แพลตฟอร์ม**: Windows Forms
- **ฐานข้อมูล (สำหรับ Troubleshooter)**: MSSQL

### การออกแบบ
- **Modular Design**: ใช้ UserControl ในการแบ่งหน้าจอและฟังก์ชันการทำงานออกจากกัน
- **Strategy Pattern (ประยุกต์)**: ใช้ Interface (`ITroubleshooterTool`) เพื่อกำหนดโครงสร้างของเครื่องมือแก้ปัญหา ทำให้สามารถเพิ่มเครื่องมือใหม่ได้โดยไม่ต้องแก้ไขโค้ดหลัก

## 📂 โครงสร้างโปรเจกต์ (Project Structure)

```
/Multipurpose
│
├── Licenses/             # โฟลเดอร์เก็บไฟล์ License Key (.csv)
│   ├── LicenseOffice.csv
│   └── LicenseWindows.csv
│
├── Scripts/              # โฟลเดอร์เก็บสคริปต์ต่างๆ
│   └── Set-Localization.ps1
│
├── Tools/                # โฟลเดอร์เก็บคลาสเครื่องมือแก้ปัญหา
│   ├── ITroubleshooterTool.cs  (Interface หลัก)
│   ├── ChangeQuotationTool.cs
│   └── ... (เครื่องมืออื่นๆ)
│
├── Form1.cs              # ฟอร์มหลักของโปรแกรม
├── TroubleshooterControl.cs  # UserControl สำหรับจัดการและแสดงเครื่องมือ
└── ... (ไฟล์อื่นๆ ของโปรเจกต์)
```

## 🚀 วิธีการเพิ่มเครื่องมือแก้ปัญหา (How to Add a New Tool)

ส่วน Troubleshooter ถูกออกแบบมาให้ง่ายต่อการเพิ่มเติมเครื่องมือใหม่ๆ ทำตามขั้นตอนดังนี้:

### 1. สร้างคลาสใหม่
ในโฟลเดอร์ `Multipurpose/Tools/`

### 2. Implement Interface
ให้คลาสใหม่ของคุณ implement `ITroubleshooterTool`

```csharp
public class MyNewAwesomeTool : ITroubleshooterTool
{
    // ...
}
```

### 3. กำหนดคุณสมบัติ
- **Name**: ชื่อของเครื่องมือที่จะแสดงใน List
- **Description**: คำอธิบายการทำงานของเครื่องมือ

```csharp
public string Name => "My New Awesome Tool";
public string Description => "This tool does something awesome.";
```

### 4. เขียนโค้ดหลักในเมธอด Run()
- เมธอดนี้จะถูกเรียกใช้งานเมื่อผู้ใช้กดปุ่ม "Run"
- คุณสามารถใช้ `logCallback` เพื่อส่งข้อความกลับไปแสดงผลบนหน้าจอโปรแกรมได้

```csharp
public void Run(Action<string> logCallback)
{
    logCallback("Starting my new awesome tool...");
    // --- Your logic goes here ---
    // ตัวอย่าง: การเรียกใช้ Helper
    // string inputValue = ToolHelpers.ShowInputDialog("Please enter value:");
    // ToolHelpers.ExecuteCommand("some_command.exe");
    logCallback("Tool finished successfully!");
}
```

### 5. Build โปรเจกต์
เครื่องมือใหม่ของคุณจะปรากฏในรายการของแท็บ Troubleshooter โดยอัตโนมัติ

## 💡 ข้อเสนอแนะเพื่อการพัฒนาต่อ (Recommendations)

- **[Security]** เข้ารหัสไฟล์ License Key เพื่อเพิ่มความปลอดภัย
- **[Configuration]** ย้าย Connection String ของฐานข้อมูลไปไว้ใน App.config และทำการเข้ารหัส
- **[UX]** เพิ่ม Progress Bar หรือสถานะการทำงานสำหรับ Task ที่ใช้เวลานาน เช่น การติดตั้ง Office
- **[Maintainability]** เพิ่ม Code Comment ในส่วนของ Logic ที่ซับซ้อนในเครื่องมือแต่ละตัว เพื่อให้ง่ายต่อการดูแลรักษาในอนาคต