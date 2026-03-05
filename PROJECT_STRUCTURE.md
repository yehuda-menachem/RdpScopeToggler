# RdpScopeToggler Project Structure

## 📁 Root Directory Organization

```
RdpScopeToggler/
├── App.xaml                          # Application entry point XAML
├── App.xaml.cs                       # Application code-behind
├── RdpScopeToggler.sln              # Solution file
├── RdpScopeToggler.csproj           # Project file
├── app.manifest                      # Windows manifest for permissions
├── README.md                         # Main documentation
├── LICENSE                           # MIT License
│
├── docs/                             # Documentation folder
│   ├── DESIGN_AUDIT.md               # Design consistency analysis
│   ├── DESIGN_SPECIFICATION.md       # Complete design system spec
│   ├── IMPLEMENTATION_PROGRESS.md    # Implementation tracking
│   └── PHASE_2_SUMMARY.md            # Phase 2 completion details
│
├── UI/                               # UI Design Reference Files
│   ├── mockup.html                   # Interactive design mockup
│   ├── home.txt                      # Home page design
│   ├── settings.txt                  # Settings page design
│   ├── access control.txt            # Access control page design
│   ├── whitelist.txt                 # Whitelist page design
│   ├── local computers.txt           # Local addresses page design
│   ├── login.txt                     # Login dialog design
│   ├── dialog-add-address.txt        # Add address dialog design
│   └── dialog-confirmation.txt       # Confirmation dialog designs
│
├── Assets/                           # Application assets
│   ├── remote-desktop.ico            # Application icon
│   ├── remote-desktop.png            # Icon image
│   └── Deployment/                   # Deployment files
│
├── Resources/                        # XAML Resources
│   ├── Colors.xaml                   # Light/Dark theme colors
│   ├── ButtonsModern.xaml            # Modern button styles
│   ├── Buttons.xaml                  # Legacy button styles
│   ├── Styles.xaml                   # Application styles
│   └── ToggleSwitchStyles.xaml       # Toggle switch styles
│
├── Views/                            # XAML Views (UI Pages)
│   ├── MainWindow.xaml               # Main application window (REDESIGNED)
│   ├── HomeUserControl.xaml          # Home page (REDESIGNED)
│   ├── SettingsUserControl.xaml      # Settings page (REDESIGNED)
│   ├── AccessControlUserControl.xaml # Access Control page
│   ├── WhitelistUserControl.xaml     # Whitelist page
│   ├── LocalAddressesUserControl.xaml # Local Addresses page
│   ├── IndicatorsUserControl.xaml    # Status indicators
│   └── AnyClockUserControl.xaml      # Timer control
│
├── ViewModels/                       # MVVM ViewModel classes
│   ├── MainWindowViewModel.cs
│   ├── HomeViewModel.cs
│   ├── SettingsViewModel.cs
│   └── [Other ViewModels]
│
├── Models/                           # Data Models
│   ├── Dialogs.cs
│   ├── ServiceMessage.cs
│   └── [Other Models]
│
├── Services/                         # Business Logic Services
│   ├── PipeClientService/            # Named Pipes communication
│   ├── ServiceExtractor/             # Service management
│   └── [Other Services]
│
├── Converters/                       # XAML Value Converters
│   ├── EnumToBoolConverter.cs
│   ├── StringToBoolConverter.cs
│   └── [Other Converters]
│
├── Helpers/                          # Helper Classes
│   └── [Helper utilities]
│
├── Managers/                         # Application Managers
│   └── [State and resource managers]
│
├── Enums/                            # Enumeration definitions
│   └── [Enum types]
│
├── Properties/                       # Project properties
│   ├── AssemblyInfo.cs
│   ├── Settings.settings
│   └── Resources.resx
│
├── bin/                              # Build output (Debug & Release)
├── obj/                              # Build intermediate files
│
└── .gitignore                        # Git ignore rules
```

## 🎯 Key Folders Explained

### **docs/**
Documentation and specifications:
- Design system specifications
- Implementation progress tracking
- Phase summaries

### **UI/**
Design reference files for developers:
- HTML mockups for design reference
- Design files for each page
- Dialog designs

### **Views/**
Contains all XAML UI pages:
- `MainWindow.xaml` - Main application shell (1200x800 layout)
- `HomeUserControl.xaml` - Home/Dashboard page with cards
- `SettingsUserControl.xaml` - Preferences page
- `AccessControlUserControl.xaml` - Access control management
- `WhitelistUserControl.xaml` - Whitelist management
- `LocalAddressesUserControl.xaml` - Local network browser

### **Resources/**
Shared XAML resources:
- **Colors.xaml** - Light/Dark mode color system
- **ButtonsModern.xaml** - Modern button styles
- **Styles.xaml** - Component styles

### **Services/**
Business logic and external communication:
- RDP service communication
- Windows service integration
- Configuration management

## 📊 Build Output

After building:
- **bin/Debug/** - Debug build output
- **bin/Release/** - Release build output (122 MB)

## ✨ Current Status

✅ **Phase 2 Complete**
- Modern design system implemented
- Home page redesigned with cards
- Settings page redesigned
- Color system with light/dark support
- Modern button styles created

📋 **Phase 3 Ready**
- Access Control page (design ready)
- Whitelist page (design ready)
- Local Addresses page (design ready)
- Theme toggle logic (to be implemented)
- Dialog templates (to be created)

---

*This structure is clean, organized, and follows WPF best practices.*
