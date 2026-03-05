# RdpScopeToggler - Design Specification v2.0

**Project:** RDP Scope Toggler Desktop Application
**Platform:** Windows Desktop (WPF - .NET Framework)
**Design Style:** Apple-inspired Minimalist + Modern Professional
**Status:** Design Specification for Implementation

---

## Table of Contents
1. [Design System](#design-system)
2. [Color Palette](#color-palette)
3. [Typography](#typography)
4. [Spacing & Layout](#spacing--layout)
5. [Icons & Symbols](#icons--symbols)
6. [Components](#components)
7. [Pages & Layouts](#pages--layouts)
8. [Windows & Dialogs](#windows--dialogs)
9. [Interactions](#interactions)
10. [Implementation Notes](#implementation-notes)

---

## Design System

### Design Philosophy
- **Minimalist**: Clean, simple, no unnecessary elements
- **Professional**: Corporate, trustworthy, serious
- **Accessible**: High contrast, clear hierarchy
- **Modern**: Contemporary design trends, smooth transitions
- **Apple-inspired**: Clean lines, whitespace, elegant simplicity

### Grid System
- **Base Unit:** 4px
- **Primary Grid:** 8px, 16px, 24px, 32px increments
- **Component Spacing:** 8px (internal), 16px (between components), 24px (between sections)

---

## Color Palette

### Light Mode
```
Primary Background:     #FFFFFF (White)
Secondary Background:   #F5F5F7 (Off-white)
Tertiary Background:    #EFEFEF (Light gray)

Text - Primary:         #000000 (Black)
Text - Secondary:       #65676B (Medium gray)
Text - Tertiary:        #999999 (Light gray)

Accent - Primary:       #0071E3 (Apple Blue)
Accent - Secondary:     #06C755 (Apple Green)
Accent - Tertiary:      #5856D6 (Purple)

Status - Success:       #34C759 (Green)
Status - Warning:       #FF9500 (Orange)
Status - Danger:        #FF3B30 (Red)
Status - Info:          #0071E3 (Blue)

Border:                 #D2D2D7 (Light gray)
Divider:                #E5E5EA (Lighter gray)
Disabled:               #C7C7CC (Gray)
```

### Dark Mode
```
Primary Background:     #1D1D1F (Dark gray-black)
Secondary Background:   #424245 (Medium dark gray)
Tertiary Background:    #5A5A5E (Slightly lighter)

Text - Primary:         #FFFFFF (White)
Text - Secondary:       #A1A1A6 (Light gray)
Text - Tertiary:        #66666D (Medium gray)

Accent - Primary:       #0A84FF (Bright Apple Blue)
Accent - Secondary:     #30B0C0 (Cyan-green)
Accent - Tertiary:      #5856D6 (Purple)

Status - Success:       #32AE5E (Dark Green)
Status - Warning:       #FF9500 (Orange - same)
Status - Danger:        #FF453A (Red)
Status - Info:          #0A84FF (Blue)

Border:                 #424245 (Dark gray)
Divider:                #2C2C2E (Darker gray)
Disabled:               #555555 (Gray)
```

---

## Typography

### Font Family
- **Primary Font:** SF Pro Display (system font)
- **Fallback:** Segoe UI, -apple-system, BlinkMacSystemFont
- **Monospace:** SF Mono, Courier New (for code/IPs)

### Type Scale

| Role | Size | Weight | Line Height | Letter Spacing | Usage |
|------|------|--------|-------------|----------------|-------|
| **Display** | 34px | 700 | 1.2 | -0.5px | Page titles, main headings |
| **H1** | 28px | 700 | 1.3 | -0.5px | Section titles |
| **H2** | 22px | 600 | 1.3 | -0.3px | Subsection titles |
| **H3** | 18px | 600 | 1.4 | 0px | Card titles, subtitles |
| **Body Large** | 16px | 400 | 1.5 | 0px | Main text, descriptions |
| **Body** | 15px | 400 | 1.5 | 0px | Form labels, list items |
| **Small** | 13px | 400 | 1.4 | 0px | Secondary text, hints |
| **Caption** | 12px | 400 | 1.3 | 0px | Smallest text, timestamps |

---

## Spacing & Layout

### Window Size
- **Default Width:** 1200px (minimum 900px for responsiveness)
- **Default Height:** 800px (minimum 600px)
- **Resizable:** Yes, with minimum constraints

### Padding & Margins
- **Window Padding:** 0px
- **Header Padding:** 16px vertical, 32px horizontal
- **Sidebar Padding:** 20px
- **Content Area Padding:** 32px
- **Card Padding:** 24px
- **Component Padding:** 12-16px (varies by type)

### Spacing Values
- **XS:** 4px (small gaps between tightly coupled elements)
- **S:** 8px (common spacing between elements)
- **M:** 16px (spacing between related groups)
- **L:** 24px (spacing between sections)
- **XL:** 32px (main content area padding)

---

## Icons & Symbols

### Icon Requirements
- **Style:** Tabler Icons (or equivalent quality)
- **Size Variants:** 16px, 20px, 24px, 32px
- **Stroke Width:** 2px (consistent)
- **Stroke Color:** Inherit from text color (dynamic)
- **No Emoji:** Use professional symbol icons only

### Icon List by Page

#### Navigation/Sidebar
- Home: `home` icon
- Access Control: `key` icon
- Whitelist: `list-check` icon
- Local Addresses: `device-desktop` icon
- Settings: `settings` icon

#### Actions
- Add: `plus` icon
- Delete/Remove: `trash` icon
- Edit: `pencil` icon
- Search: `search` icon
- Close: `x` icon
- Settings: `settings` icon
- Help: `help-circle` icon
- Notifications: `bell` icon

#### Status Indicators
- Success/Active: `check-circle` (filled)
- Error/Inactive: `x-circle` (filled)
- Warning/Caution: `alert-circle` (filled)
- Info: `info-circle` (filled)
- Pending: `clock` icon

#### Other
- Schedule/Time: `clock` icon
- Lock/Security: `lock` icon
- Network: `network` icon
- Eye (show/hide): `eye` icon
- Copy: `copy` icon
- Download: `download` icon

---

## Components

### Buttons

#### Primary Button
- **Background:** Accent Primary color
- **Text Color:** White
- **Padding:** 12px vertical, 24px horizontal
- **Border Radius:** 8px
- **Font Size:** 15px, Weight: 600
- **Border:** None
- **Height:** 44px (standard)
- **Hover State:** Opacity 0.9, slight shadow, subtle scale up
- **Disabled State:** Opacity 0.5, cursor not-allowed
- **Icon + Text:** Icon (20px) + 8px gap + Text

#### Secondary Button
- **Background:** Transparent
- **Border:** 1.5px solid, Border color
- **Text Color:** Text Primary
- **Padding:** 12px vertical, 24px horizontal
- **Border Radius:** 8px
- **Font Size:** 15px, Weight: 600
- **Height:** 44px
- **Hover State:** Subtle background color (5% opacity of accent)
- **Active State:** Accent background, white text
- **Disabled State:** Opacity 0.5, cursor not-allowed

#### Tertiary Button
- **Background:** Transparent
- **Border:** None
- **Text Color:** Accent Primary
- **Padding:** 8px vertical, 12px horizontal
- **Border Radius:** 4px
- **Font Size:** 14px, Weight: 500
- **Hover State:** Background 10% opacity of text color
- **Use Case:** Text-only actions, less prominent

#### Small Button
- **All variants apply**, but:
- **Padding:** 8px vertical, 12px horizontal
- **Font Size:** 13px
- **Height:** 32px
- **Icon Size:** 16px

### Input Fields

#### Text Input / Number Input
- **Background:** Primary/Secondary background
- **Border:** 1px solid, Border color (bottom border style)
- **Border Radius:** 8px
- **Padding:** 12px horizontal, 10px vertical
- **Font Size:** 14px
- **Height:** 40px
- **Focus State:** Border color = Accent Primary, subtle shadow
- **Placeholder Color:** Text Secondary (60% opacity)
- **Error State:** Border color = Status Danger, error text below in red
- **Disabled State:** Opacity 0.6, background lighter

#### Select/Dropdown
- **Same as Text Input**
- **Arrow Icon:** Right-aligned, 16px, medium gray
- **Dropdown Width:** Match input width
- **Item Padding:** 12px
- **Item Height:** 40px
- **Hover State:** Background secondary
- **Selected State:** Accent background, white text

#### Date/Time Picker
- **Same input styling as Text Input**
- **Calendar/Time picker:** Floating panel below
- **Panel Background:** Secondary background
- **Panel Border Radius:** 12px
- **Panel Shadow:** 0 10px 40px rgba(0,0,0,0.1)

#### Search Input
- **Icon:** Search icon (left-aligned, 16px)
- **Padding Left:** 36px (icon + gap)
- **Clear Button:** X icon (right side, appears when has text)

#### Checkbox / Toggle Switch
- **Size:** 20px × 20px
- **Border Radius:** 4px (checkbox), 12px (toggle)
- **Checked Background:** Accent Primary
- **Unchecked Background:** Border color
- **Toggle Animation:** 200ms ease
- **Label:** 12px margin from control

### Cards

- **Background:** Secondary background
- **Border Radius:** 12px
- **Padding:** 24px
- **Shadow:** 0 2px 10px rgba(0,0,0,0.05) (light), 0 2px 10px rgba(0,0,0,0.3) (dark)
- **Hover State:** Shadow increases to 0 8px 24px rgba(0,0,0,0.1)
- **Border:** None (pure shadow-based depth)

#### Card Header (optional)
- **Flex layout:** Icon (24px) + Gap (12px) + Content
- **Margin Bottom:** 16px
- **Title:** Font H3
- **Subtitle:** Small font, secondary color

### Lists

#### List Item
- **Background:** Tertiary background (or alt row)
- **Padding:** 12px 16px
- **Border Radius:** 8px
- **Margin Bottom:** 8px
- **Min Height:** 48px
- **Hover State:** Slight background shade change
- **Flex Layout:** Content (flex 1) + Actions (auto)

#### List Item Content
- **Title:** Body font, primary color
- **Subtitle:** Small font, secondary color, margin top 4px

### Indicators / Status Pills

- **Padding:** 8px 12px
- **Border Radius:** 20px (rounded)
- **Font Size:** 13px, Weight: 500
- **Icon (optional):** 16px, left-aligned, gap 4px
- **Colors by status:**
  - Success: Green background + white text
  - Error: Red background + white text
  - Warning: Orange background + white text
  - Info: Blue background + white text

### Dividers

- **Style:** Solid line
- **Height:** 1px
- **Margin:** 20px vertical, 0 horizontal
- **Color:** Divider color

---

## Pages & Layouts

### Layout Structure

```
┌─────────────────────────────────┐
│         Header                  │
├──────┬──────────────────────────┤
│      │                          │
│      │  Content Area            │
│ Side │  (scrollable)            │
│ bar  │                          │
│      │                          │
│      │                          │
└──────┴──────────────────────────┘
```

### Header
- **Height:** 64px
- **Padding:** 0 32px
- **Border Bottom:** 1px solid, Divider color
- **Content:**
  - Left: Page title (Display/H1)
  - Right: Action buttons/icons (optional)
- **Sticky:** Yes (stays at top when scrolling)

### Sidebar (Left Navigation)
- **Width:** 280px
- **Background:** Secondary background
- **Border Right:** 1px solid, Divider color
- **Padding:** 20px
- **Fixed:** Yes (doesn't scroll with content)
- **Content:**
  - App logo/name (24px, bold) at top
  - Navigation items below
  - Optional: Settings/Help at bottom

#### Navigation Items
- **Height:** 40px
- **Padding:** 12px 16px
- **Margin Bottom:** 8px
- **Border Radius:** 8px
- **Font:** 15px, Weight: 500
- **Icon:** 24px (left-aligned)
- **Text:** Margin left 12px from icon
- **Hover State:** Secondary background shade
- **Active State:** Accent background + white text
- **Click Target:** Entire item

### Content Area
- **Padding:** 32px
- **Overflow:** Vertical scroll enabled
- **Background:** Primary background

---

## Pages Details

### 1. **Home Page**

#### Section 1: Status Overview
- **Title:** "📊 Current Status" → "Status Overview" (using icon)
- **Layout:** 4-column grid (or responsive)
- **Items per row:**
  - Desktop: 4 columns
  - Tablet: 2 columns
  - Mobile: 1 column

#### Stat Card
- **Background:** Gradient from secondary to primary (subtle)
- **Center aligned:** Yes
- **Content:**
  - Large number/symbol (28px, bold) - Status indicator
  - Label below (13px, secondary color)
- **Examples:**
  - ✓ (green) - Whitelist Active
  - ✕ (red) - All Access Disabled
  - ⏱ (orange) - Time-based Access
  - ✓ (green) - Local Access Active

#### Section 2: Quick Actions (Grid Layout)
- **Title:** None or "Quick Actions"
- **Grid:** 3 columns (responsive)
- **Each Card contains:**

**Card A: Schedule Access**
- Title: "Schedule Access"
- Subtitle: "Set time window for RDP access"
- Icon: `clock` (24px)
- Content:
  - Label: "Date" → Input field (date picker)
  - Label: "Time" → Input field (time picker)
  - Margin between: 16px
- Button: Primary "Set Schedule" (full width)

**Card B: Access Mode**
- Title: "Access Mode"
- Subtitle: "Choose who can access"
- Icon: `lock` (24px)
- Content:
  - Label: "Access Control"
  - Dropdown with options:
    - All Addresses
    - Whitelist Only
    - Local Computers
    - Local + Whitelist
- Button: Primary "Apply Settings" (full width)

**Card C: Quick Actions**
- Title: "Quick Actions"
- Subtitle: "Immediate controls"
- Icon: `rocket` (24px)
- Content:
  - 2×2 Button grid:
    - Primary: "Open Access"
    - Secondary: "Close Access"
    - Secondary: "Enable All"
    - Secondary: "Disable All"

---

### 2. **Access Control Page**

#### Section: Trusted Addresses
**Card: Trusted Addresses Management**
- Title: "Trusted Addresses"
- Subtitle: "Addresses that always have access"
- Icon: `shield-check` (24px)

**List Items (repeating):**
- Layout: Flex (content + actions)
- Content:
  - Title: IP Address (e.g., "192.168.1.100")
  - Subtitle: Description (e.g., "Office Network")
- Actions:
  - Edit button (secondary, small)
  - Delete button (secondary, small, danger text)

**Add Button:** Primary "Add Trusted Address" (below list)

#### Section: Time-Based Access
**Card: Time Window Control**
- Title: "Time-Based Access"
- Subtitle: "Restrict access to specific hours"
- Icon: `clock-check` (24px)

**Form:**
- Label: "Start Time" → Time input (e.g., 09:00)
- Label: "End Time" → Time input (e.g., 18:00)
- Margin: 16px between
- Button: Primary "Apply Time Window" (full width)

---

### 3. **Whitelist Page**

#### Section: Whitelist Management
**Title:** "Whitelist Management"
**Subtitle:** "Manage addresses allowed to access your system"

**Card: Whitelisted Addresses**
- Header (flex):
  - Left: Title "Whitelisted Addresses" + Count "(Currently 3 addresses)"
  - Right: Primary button "+ Add Address"

**List Items (repeating):**
- Layout: Flex (content + actions)
- Content:
  - Title: IP Address
  - Subtitle: "Added on [Date] • [Status: Active/Inactive]"
- Actions:
  - Button group (flex):
    - Secondary "Edit" (small)
    - Secondary "Remove" (small, danger text)

**Add Button:** Prominent Primary button if list is empty

---

### 4. **Local Addresses Page**

#### Section: Local Network Computers
**Title:** "Local Computers"
**Subtitle:** "Computers on your local network"

**Card: Computer Browser**
- Search Input at top (with search icon)
- Margin Bottom: 20px

**List Items (repeating):**
- Layout: Flex (content + status)
- Content:
  - Title: Computer Name (e.g., "Desktop-PC")
  - Subtitle: "IP Address • Status (Online/Offline)"
- Status:
  - Online: Green dot (●) + 16px size
  - Offline: Red dot (●) + 16px size

---

### 5. **Settings Page**

#### Section: Preferences

**Card 1: Language**
- Icon: `globe` (24px)
- Title: "Language"
- Subtitle: "Choose your language"
- Content:
  - Dropdown: "English", "עברית" (Hebrew)

**Card 2: Theme**
- Icon: `sun` or `moon` (24px)
- Title: "Theme"
- Subtitle: "Choose appearance"
- Content:
  - 2-button group:
    - "☀️ Light Mode" (secondary, can be active)
    - "🌙 Dark Mode" (secondary, can be active)

**Card 3: Default State**
- Icon: `zap` (24px)
- Title: "Default State"
- Subtitle: "On application startup"
- Content:
  - 2-button group:
    - "Enabled" (secondary, can be active)
    - "Disabled" (secondary, can be active)

**Card 4: About**
- Icon: `info-circle` (24px)
- Title: "About"
- Subtitle: "Application information"
- Content:
  - Version: 2.0.0
  - License: MIT
  - Text style: Small font, secondary color

---

## Windows & Dialogs

### Main Window
- **Title:** "RDP Scope Toggler"
- **Icon:** Application icon (32×32 for title bar)
- **Resizable:** Yes (minimum 900×600)
- **Minimize/Maximize/Close:** Standard Windows controls (top right)
- **No custom chrome needed** - use standard Windows window

### Dialog: Add/Edit Address
**Type:** Modal dialog, centered on screen

**Size:** 400px width, 300px height (approximate)

**Content:**
- Title: "Add Trusted Address" or "Edit Address"
- Subtitle: "Enter IP or hostname"
- Margin: 24px

**Form:**
- Label: "Address"
  - Input: Text field (IP or domain)
  - Placeholder: "192.168.1.100 or example.com"
- Label: "Description (optional)"
  - Input: Text field
  - Placeholder: "e.g., Office Network"
- Margin between: 16px

**Buttons (flex, gap 12px, at bottom):**
- Primary: "Save" (flex: 1)
- Secondary: "Cancel" (flex: 1)
- Margin Top: 24px

### Dialog: Confirmation
**Type:** Modal dialog, centered

**Size:** 380px width, 200px height (approximate)

**Content:**
- Icon: Appropriate status icon (32px, centered)
- Title: Confirmation message (H2)
- Message: Description (body text)
- Margin: 24px

**Buttons:**
- Primary: Confirm action (e.g., "Delete")
- Secondary: Cancel (e.g., "Keep It")
- Margin Top: 24px
- Button Layout: Side-by-side or stacked

### Dialog: Loading/Waiting
**Type:** Modal, non-dismissible

**Content:**
- Loading spinner (24px, animated)
- Text: "Loading..." or status message
- Margin: 16px between

---

## Interactions

### Transitions & Animations
- **Page transitions:** 200ms fade
- **Button hover:** 150ms ease
- **Color changes:** 200ms transition
- **Modal open/close:** 300ms scale + fade
- **Toggle switch:** 200ms ease

### Hover States
- **Buttons:** Opacity change + subtle shadow
- **List items:** Background color change
- **Cards:** Shadow elevation increase
- **Navigation items:** Background highlight
- **Input fields:** Border color change

### Focus States
- **Inputs:** Border color = Accent Primary, subtle shadow
- **Buttons:** Outline (2px solid, accent color)
- **Keyboard navigation:** Visible focus ring on all focusable elements

### Disabled States
- **Opacity:** 50-60%
- **Cursor:** `not-allowed`
- **Color:** Gray/disabled color
- **No hover effects**

### Error States
- **Input border:** Status Danger color
- **Error message:** Below input, small font, danger color
- **Icon (optional):** Warning icon next to field

---

## Implementation Notes

### WPF Technology Stack
- **Framework:** .NET Framework 4.8+ or .NET 6+
- **UI Library:** Custom XAML or use:
  - MahApps.Metro (for theme management)
  - ModernWpf (Microsoft's modern design)
  - Tabler Icons (via custom icon font or library)

### Color Implementation
- Use `ResourceDictionary` for colors
- Create separate dictionaries for Light/Dark themes
- Use `DynamicResource` binding for theme switching

### Icon Implementation
- **Option 1:** Use Tabler Icons font file
- **Option 2:** Use Material Design Icons (via Material Design In XAML)
- **Option 3:** Use SVG icons rendered as XAML `Path` elements
- **Recommended:** Tabler Icons (most comprehensive, clean style)

### Responsive Design
- Content grid should be responsive
- Sidebar width can adjust on smaller screens
- Mobile/tablet breakpoints:
  - Desktop: 1200px+
  - Tablet: 768px - 1199px
  - Mobile: < 768px

### Accessibility
- **Color Contrast:** WCAG AA minimum (4.5:1 for text)
- **Focus indicators:** Clearly visible
- **Keyboard navigation:** Full support
- **Icon labels:** All icons should have alt text/tooltip
- **Font sizes:** Minimum 12px for readability

### Performance
- No animations on low-end machines (add setting)
- Lazy load lists if 100+ items
- Cache theme preferences
- Debounce rapid button clicks

### File Organization (XAML Resources)
```
Resources/
  ├── Colors.xaml (Light/Dark color dictionaries)
  ├── Typography.xaml (Font sizes, weights, styles)
  ├── Buttons.xaml (All button styles)
  ├── Inputs.xaml (Input field, dropdown styles)
  ├── Cards.xaml (Card component style)
  ├── Lists.xaml (List item styles)
  ├── Indicators.xaml (Status indicators)
  ├── Icons.xaml (Icon font definitions)
  └── Themes.xaml (Theme resource merges)
```

---

## Color Contrast Reference

### Light Mode Examples
- Black on White: ✅ 21:1 (AAA)
- #0071E3 on White: ✅ 5.3:1 (AA)
- #65676B on White: ✅ 8.5:1 (AAA)

### Dark Mode Examples
- White on #1D1D1F: ✅ 19:1 (AAA)
- #0A84FF on #1D1D1F: ✅ 6.2:1 (AA)
- #A1A1A6 on #1D1D1F: ✅ 8.1:1 (AAA)

---

## Next Steps for Designer

1. **Create high-fidelity mockups** in Figma/Adobe XD based on this spec
2. **Prepare icon assets** in Tabler Icons style (or export from Tabler)
3. **Design custom components** if any deviations needed
4. **Create interactive prototypes** for transitions/animations
5. **Provide design tokens** (colors, spacing, typography) as reference
6. **Create icon reference sheet** showing all icons used

---

**Document Version:** 1.0
**Last Updated:** March 5, 2026
**Status:** Ready for Designer Implementation
