#define MyAppName "RdpScopeToggler"
#define MyAppVersion "2.1.0"
#define MyAppPublisher "RdpScopeToggler"
#define MyAppExeName "RdpScopeToggler.exe"
#define BuildDir "..\bin\Release\net8.0-windows10.0.19041.0"

[Setup]
AppId={{A1B2C3D4-E5F6-7890-ABCD-EF1234567890}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=Output
OutputBaseFilename=RdpScopeToggler-Setup-v{#MyAppVersion}
SetupIconFile=..\Assets\remote-desktop.ico
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
; The app itself requires admin, so the installer must too
PrivilegesRequired=admin
; Minimum Windows 10
MinVersion=10.0.19041
; Architecture
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop shortcut"; GroupDescription: "Additional icons:"
Name: "startupicon"; Description: "Launch on Windows &startup"; GroupDescription: "Additional icons:"; Flags: unchecked

[Files]
; Main EXE and DLLs
Source: "{#BuildDir}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\RdpScopeToggler.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\RdpScopeToggler.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\RdpScopeToggler.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion

; Dependencies
Source: "{#BuildDir}\MaterialDesignColors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\MaterialDesignThemes.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Configuration.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Configuration.Binder.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Configuration.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.DependencyInjection.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.DependencyInjection.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Diagnostics.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Diagnostics.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Http.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Logging.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Logging.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Options.ConfigurationExtensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Options.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Extensions.Primitives.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Toolkit.Uwp.Notifications.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Windows.SDK.NET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Microsoft.Xaml.Behaviors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Prism.Container.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Prism.Container.Unity.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Prism.Events.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Prism.Unity.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Prism.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Prism.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\System.Diagnostics.DiagnosticSource.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\System.ServiceProcess.ServiceController.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Unity.Abstractions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Unity.Container.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\WinRT.Runtime.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Xceed.Wpf.AvalonDock.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Xceed.Wpf.AvalonDock.Themes.Aero.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Xceed.Wpf.AvalonDock.Themes.Metro.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Xceed.Wpf.AvalonDock.Themes.VS2010.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#BuildDir}\Xceed.Wpf.Toolkit.dll"; DestDir: "{app}"; Flags: ignoreversion

; Assets folder (icon, images)
Source: "{#BuildDir}\Assets\*"; DestDir: "{app}\Assets"; Flags: ignoreversion recursesubdirs createallsubdirs

; Locale folders
Source: "{#BuildDir}\cs-CZ\*"; DestDir: "{app}\cs-CZ"; Flags: ignoreversion recursesubdirs
Source: "{#BuildDir}\ja-JP\*"; DestDir: "{app}\ja-JP"; Flags: ignoreversion recursesubdirs
Source: "{#BuildDir}\pt-BR\*"; DestDir: "{app}\pt-BR"; Flags: ignoreversion recursesubdirs
Source: "{#BuildDir}\zh-Hans\*"; DestDir: "{app}\zh-Hans"; Flags: ignoreversion recursesubdirs
Source: "{#BuildDir}\runtimes\*"; DestDir: "{app}\runtimes"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Assets\remote-desktop.ico"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\Assets\remote-desktop.ico"; Tasks: desktopicon

[Registry]
; Startup on Windows login
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueType: string; ValueName: "{#MyAppName}"; ValueData: """{app}\{#MyAppExeName}"""; Flags: uninsdeletevalue; Tasks: startupicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: nowait postinstall skipifsilent runascurrentuser

[UninstallRun]
; Stop the service before uninstall
Filename: "sc.exe"; Parameters: "stop RdpScopeService"; Flags: runhidden waituntilterminated; RunOnceId: "StopService"
Filename: "sc.exe"; Parameters: "delete RdpScopeService"; Flags: runhidden waituntilterminated; RunOnceId: "DeleteService"

[UninstallDelete]
; Remove app data folder
Type: filesandordirs; Name: "{commonappdata}\RdpScopeToggler"
