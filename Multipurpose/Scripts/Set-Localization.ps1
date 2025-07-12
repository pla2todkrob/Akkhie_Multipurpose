# Scripts/Set-Localization.ps1

$ErrorActionPreference = 'Stop'

# --- Step 1: System-Wide Settings ---
Write-Output '--- Step 1/3: Applying System-Wide Settings ---'
Write-Output 'Setting Time Zone...'
Set-TimeZone -Id 'SE Asia Standard Time'
Write-Output 'Configuring Time Sync Service...'
if ((Get-CimInstance -ClassName Win32_ComputerSystem).PartOfDomain) {
    Write-Output '-> Skipping Time Sync on domain-joined machine.'
} else {
    Set-Service -Name w32time -StartupType Automatic; Start-Service -Name w32time
}
Write-Output 'Setting System Locale...'
Set-WinSystemLocale -SystemLocale 'th-TH'
Write-Output 'Setting Home Location...'
Set-WinHomeLocation -GeoId 244
Write-Output 'Setting Regional Format...'
Set-Culture -CultureInfo 'th-TH'
Write-Output 'Setting Display Language and Input Preferences...'
$LangList = New-WinUserLanguageList en-US
$LangList.Add('th-TH')
$LangList[0].InputMethodTips.Clear()
$LangList[0].InputMethodTips.Add('0409:00000409')
$LangList[1].InputMethodTips.Clear()
$LangList[1].InputMethodTips.Add('041e:0000041e')
Set-WinUserLanguageList $LangList -Force
Set-WinUILanguageOverride -Language 'en-US'

# --- Step 2: Default User Settings (for new users) ---
Write-Output '--- Step 2/3: Applying Settings for New Users ---'
$regContent = @"
Windows Registry Editor Version 5.00`r`n
[HKEY_LOCAL_MACHINE\DefaultUser\Control Panel\International]
"sCountry"="Thailand"
"LocaleName"="th-TH"`r`n
[HKEY_LOCAL_MACHINE\DefaultUser\Control Panel\International\Geo]
"Nation"="244"`r`n
[HKEY_LOCAL_MACHINE\DefaultUser\Keyboard Layout\Preload]
"1"="00000409"
"2"="0000041e"`r`n
[HKEY_LOCAL_MACHINE\DefaultUser\Control Panel\International\User Profile]
"Languages"=hex(7):65,00,6e,00,2d,00,55,00,53,00,00,00,74,00,68,00,2d,00,54,00,48,00,00,00,00,00`r`n
[HKEY_LOCAL_MACHINE\DefaultUser\Keyboard Layout\Toggle]
"Language Hotkey"="$($env:LanguageHotkey)"
"Layout Hotkey"="3"
"@
$regFile = Join-Path $env:TEMP 'default_user.reg'
$regContent | Out-File -FilePath $regFile -Encoding Unicode -Force
$regExeHivePath = 'HKLM\DefaultUser'
try {
    Write-Output 'Loading Default User hive...'
    reg load $regExeHivePath 'C:\Users\Default\NTUSER.DAT'
    Write-Output 'Importing settings...'
    reg import $regFile
}
finally {
    if (Test-Path 'HKLM:\DefaultUser') {
        Write-Output 'Unloading Default User hive...'
        reg unload $regExeHivePath
    }
    Remove-Item $regFile -Force -ErrorAction SilentlyContinue
}

# --- Step 3: Existing User Settings ---
Write-Output '--- Step 3/3: Applying Settings for Existing Users ---'
Get-ChildItem 'Registry::HKEY_USERS' | Where-Object { $_.Name -match 'S-1-5-21-' } | ForEach-Object {
    $regHivePath = $_.Name.Replace('HKEY_USERS', 'HKEY_USERS')
    $sid = $_.PSChildName
    try { $userName = (New-Object System.Security.Principal.SecurityIdentifier($sid)).Translate([System.Security.Principal.NTAccount]).Value } catch { $userName = "SID: $sid" }
    Write-Output "Processing user: $userName"
   $regContent = @"
Windows Registry Editor Version 5.00`r`n
[$($regHivePath)\Control Panel\International]
"sCountry"="Thailand"
"LocaleName"="th-TH"`r`n
[$($regHivePath)\Control Panel\International\Geo]
"Nation"="244"`r`n
[$($regHivePath)\Keyboard Layout\Preload]
"1"="00000409"
"2"="0000041e"`r`n
[$($regHivePath)\Control Panel\International\User Profile]
"Languages"=hex(7):65,00,6e,00,2d,00,55,00,53,00,00,00,74,00,68,00,2d,00,54,00,48,00,00,00,00,00`r`n
[$($regHivePath)\Keyboard Layout\Toggle]
"Language Hotkey"="$($env:LanguageHotkey)"
"Layout Hotkey"="3"
"@
    $regFile = Join-Path $env:TEMP "user_$($sid).reg"
    $regContent | Out-File -FilePath $regFile -Encoding Unicode -Force
    reg import $regFile
    Remove-Item $regFile -Force -ErrorAction SilentlyContinue
}

Write-Output "\n--- All Localization Steps Completed ---"
