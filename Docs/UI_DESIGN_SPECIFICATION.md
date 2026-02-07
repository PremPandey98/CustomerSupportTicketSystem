# Customer Support Ticket System - UI Design Specification

## Project Overview
Windows Forms desktop application for customer support ticket management with role-based access (User and Admin).

---

## Design System

### Colors
- **Primary Action**: Blue `#0078D7` (RGB: 0, 120, 215)
- **Secondary Action**: Gray `#808080` (RGB: 128, 128, 128)
- **Background**: White `#FFFFFF`
- **Text**: Black `#000000`
- **Error/Warning**: Red icon with white text on error dialogs

### Typography
- **Font Family**: Segoe UI (system default)
- **Title Size**: 14pt Bold
- **Section Headers**: 12pt Bold
- **Labels**: 9pt Bold
- **Body Text**: 9pt Regular
- **Button Text**: 9pt Regular

### Form Specifications
- **Border Style**: FixedDialog (non-resizable)
- **Start Position**: CenterParent or CenterScreen
- **MaximizeBox**: False (no maximize button)

---

## Form Structure Overview

```
Application Entry Point: LoginForm
                    ↓
        ┌───────────┴───────────┐
        ↓                       ↓
  UserDashboard           AdminDashboard
        ↓                       ↓
        └───────────┬───────────┘
                    ↓
            ┌───────┴────────┐
            ↓                ↓
      CreateTicket      TicketList
                            ↓
                      TicketDetails
```

---

## 1. LoginForm

**Dimensions**: 400px × 250px

### Layout
```
┌─────────────────────────────────────┐
│                                     │
│  Customer Support System            │ ← Title (14pt Bold)
│                                     │
│  Username:                          │ ← Label (9pt Bold)
│  [___________________________]      │ ← TextBox
│                                     │
│  Password:                          │ ← Label (9pt Bold)
│  [___________________________]      │ ← TextBox (PasswordChar: •)
│                                     │
│         [ Login ]                   │ ← Button (Primary Blue)
│                                     │
│  Status message here...             │ ← Status Label (gray text)
│                                     │
└─────────────────────────────────────┘
```

### Controls
- **lblTitle**: "Customer Support System" - centered, bold
- **lblUsername**: "Username:" - left-aligned
- **txtUsername**: Single-line textbox
- **lblPassword**: "Password:" - left-aligned
- **txtPassword**: Single-line textbox with password masking
- **btnLogin**: "Login" button - blue background, white text, 100px wide
- **lblStatus**: Status messages - gray color when empty

### Behavior
- On successful login → Navigate to UserDashboard or AdminDashboard based on role
- On error → Display error message in status label

---

## 2. UserDashboardForm

**Dimensions**: 500px × 350px

### Layout
```
┌─────────────────────────────────────────┐
│                                         │
│  User Dashboard                         │ ← Title (14pt Bold)
│                                         │
│  Welcome, [User Full Name]!             │ ← Subtitle (9pt)
│                                         │
│                                         │
│     ┌─────────────────────────┐        │
│     │   Create New Ticket     │        │ ← Button 1
│     └─────────────────────────┘        │
│                                         │
│     ┌─────────────────────────┐        │
│     │   View My Tickets       │        │ ← Button 2
│     └─────────────────────────┘        │
│                                         │
│     ┌─────────────────────────┐        │
│     │       Logout            │        │ ← Button 3 (Gray)
│     └─────────────────────────┘        │
│                                         │
└─────────────────────────────────────────┘
```

### Controls
- **lblTitle**: "User Dashboard" - centered
- **lblWelcome**: "Welcome, [name]!" - shows logged-in user
- **btnCreateTicket**: Blue button, 250px wide × 45px tall
- **btnViewTickets**: Blue button, 250px wide × 45px tall
- **btnLogout**: Gray button, 250px wide × 45px tall

### Navigation
- Create New Ticket → Opens CreateTicketForm
- View My Tickets → Opens TicketListForm (filtered to user's tickets)
- Logout → Returns to LoginForm

---

## 3. AdminDashboardForm

**Dimensions**: 500px × 350px

### Layout
```
┌─────────────────────────────────────────┐
│                                         │
│  Admin Dashboard                        │ ← Title (14pt Bold)
│                                         │
│  Welcome, [Admin Name] - Administrator  │ ← Subtitle
│                                         │
│                                         │
│     ┌─────────────────────────┐        │
│     │   View All Tickets      │        │ ← Button 1
│     └─────────────────────────┘        │
│                                         │
│     ┌─────────────────────────┐        │
│     │       Logout            │        │ ← Button 2 (Gray)
│     └─────────────────────────┘        │
│                                         │
└─────────────────────────────────────────┘
```

### Controls
- **lblTitle**: "Admin Dashboard" - centered
- **lblWelcome**: Shows admin name with "Administrator" designation
- **btnViewAllTickets**: Blue button, 250px wide × 45px tall
- **btnLogout**: Gray button, 250px wide × 45px tall

### Navigation
- View All Tickets → Opens TicketListForm (shows all tickets in system)
- Logout → Returns to LoginForm

---

## 4. CreateTicketForm

**Dimensions**: 600px × 450px

### Layout
```
┌───────────────────────────────────────────────┐
│                                               │
│  Create New Ticket                            │ ← Title
│                                               │
│  Subject: *                                   │ ← Label
│  [_________________________________________]  │ ← TextBox
│                                               │
│  Description: *                               │ ← Label
│  ┌───────────────────────────────────────┐  │
│  │                                       │  │ ← Multiline TextBox
│  │                                       │  │   (200px height)
│  │                                       │  │
│  └───────────────────────────────────────┘  │
│                                               │
│  Priority: *                                  │ ← Label
│  [Low ▼        ]                             │ ← ComboBox (Low/Medium/High)
│                                               │
│                                               │
│  [ Submit ]  [ Cancel ]                       │ ← Buttons
│                                               │
└───────────────────────────────────────────────┘
```

### Controls
- **lblTitle**: "Create New Ticket"
- **lblSubject**: "Subject: *" (asterisk indicates required)
- **txtSubject**: Single-line textbox, 450px wide
- **lblDescription**: "Description: *"
- **txtDescription**: Multiline textbox with scrollbar, 450px wide × 200px tall
- **lblPriority**: "Priority: *"
- **cboPriority**: Dropdown with values: Low, Medium, High
- **btnSubmit**: Blue button "Submit"
- **btnCancel**: Gray button "Cancel"

### Validation
- All fields are required
- Show error message if any field is empty

---

## 5. TicketListForm

**Dimensions**: 900px × 600px

### Layout
```
┌─────────────────────────────────────────────────────────────────┐
│                                                                 │
│  My Tickets / All Tickets (Admin)            ← Title           │
│                                                                 │
│  ┌─────────────────────────────────────────────────────────┐   │
│  │ Ticket# │ Subject │ Priority │ Status │ Date │ Assigned │  │ ← DataGridView
│  ├─────────────────────────────────────────────────────────┤   │   Headers
│  │ T00001  │ Login.. │ High     │ Open   │ ... │ John     │  │
│  │ T00002  │ Payment │ Medium   │ In Pr..│ ... │ Admin    │  │
│  │ T00003  │ Report  │ Low      │ Closed │ ... │ None     │  │
│  │         │         │          │        │     │          │  │
│  │         │         │          │        │     │          │  │
│  └─────────────────────────────────────────────────────────┘   │
│                                                                 │
│  [ View Details ] [ Refresh ] [ Create Ticket ] [ Close ]      │
│                                                                 │
│  Showing X tickets                                              │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
```

### Controls
- **lblTitle**: "My Tickets" (User) or "All Tickets" (Admin)
- **dgvTickets**: DataGridView with columns:
  - **TicketNumber**: Auto-width
  - **Subject**: 250px
  - **Priority**: 100px
  - **Status**: 100px
  - **CreatedDate**: 120px (formatted as short date)
  - **AssignedTo**: 120px (admin name or "Unassigned")
  - **CreatedBy**: 120px (visible only to admins)
- **btnViewDetails**: Blue button
- **btnRefresh**: Blue button
- **btnCreateTicket**: Blue button (visible only for Users)
- **btnClose**: Gray button
- **lblStatus**: Shows count of tickets

### Behavior
- Double-click a row → Opens TicketDetailsForm
- Select row + Click "View Details" → Opens TicketDetailsForm
- DataGridView is read-only with full row selection

---

## 6. TicketDetailsForm

**Dimensions**: 1000px × 850px

### Layout
```
┌────────────────────────────────────────────────────────────────────────┐
│  Ticket Details                                                        │
│                                                                        │
│  ┌──── Ticket Information ─────────────────────────────────────┐      │
│  │  Ticket Number: T00001             Priority: High           │      │
│  │  Subject: Cannot login to account                           │      │
│  │  Description:                                               │      │
│  │  ┌────────────────────────────────────────────────────────┐ │      │
│  │  │ I am unable to login...                                │ │      │
│  │  │ (Read-only multiline)                                  │ │      │
│  │  └────────────────────────────────────────────────────────┘ │      │
│  │  Status: Open                  Created: 2026-02-05 10:30 AM │      │
│  │  Assigned To: John Admin       Created By: Jane User        │      │
│  └─────────────────────────────────────────────────────────────┘      │
│                                                                        │
│  ┌──── Comments ────────────────────────────────────────────────┐     │
│  │  ┌──────────────────────────────────────────────────────┐   │     │
│  │  │ Date | User | Comment | Internal                    │   │ ← Grid│
│  │  ├──────────────────────────────────────────────────────┤   │     │
│  │  │ 2/5  │ Jane │ Please help...│ No                     │   │     │
│  │  └──────────────────────────────────────────────────────┘   │     │
│  │                                                              │     │
│  │  Add Comment:                                                │     │
│  │  [____________________________________________]               │     │
│  │  [✓] Internal Comment (Admin only)                          │     │
│  │                                   [Add Comment]              │     │
│  └──────────────────────────────────────────────────────────────┘     │
│                                                                        │
│  ┌──── Status History ─────────────────────────────────────────┐      │
│  │  ┌──────────────────────────────────────────────────────┐   │      │
│  │  │ Date | Old Status | New Status | Changed By | Comment│  │      │
│  │  ├──────────────────────────────────────────────────────┤   │      │
│  │  │ 2/5  │ Open       │ In Progress│ Admin      │ Work..│   │      │
│  │  └──────────────────────────────────────────────────────┘   │      │
│  └──────────────────────────────────────────────────────────────┘      │
│                                                                        │
│  ┌──── Admin Actions (Admin Only) ──────────┐                         │
│  │  Assign To:                               │                         │
│  │  [Select Admin ▼   ] [Assign]            │                         │
│  │                                           │                         │
│  │  Change Status:                           │                         │
│  │  [Select Status ▼  ]                      │                         │
│  │  Comment (optional):                      │                         │
│  │  ┌──────────────────────────────────┐    │                         │
│  │  │                                  │    │                         │
│  │  └──────────────────────────────────┘    │                         │
│  │  [Update Status]                          │                         │
│  └───────────────────────────────────────────┘                         │
│                                                                        │
│                                                         [Close]        │
└────────────────────────────────────────────────────────────────────────┘
```

### Sections

#### A. Ticket Information (Group Box)
- All fields are **read-only** labels
- **Ticket Number**: Auto-generated format (T00001)
- **Subject**: Full text
- **Description**: Multiline, scrollable, 80px height
- **Priority**: Low/Medium/High
- **Status**: Open/In Progress/Closed
- **Created Date**: DateTime formatted
- **Assigned To**: Admin name or "Unassigned"
- **Created By**: User who created the ticket

#### B. Comments Section (Group Box)
- **dgvComments**: DataGridView showing:
  - Date/Time
  - User name
  - Comment text
  - IsInternal (Yes/No) - Internal comments only visible to admins
- **txtComment**: Multiline textbox for new comment (40px height)
- **chkIsInternal**: Checkbox "Internal Comment" (visible only to admins)
- **btnAddComment**: Blue button "Add Comment"
- Disabled if ticket status is "Closed"

#### C. Status History (Group Box)
- **dgvHistory**: DataGridView showing:
  - Changed Date/Time
  - Old Status
  - New Status
  - Changed By (admin name)
  - Comment (if any was added during status change)
- Read-only, chronological order

#### D. Admin Actions Panel (Group Box - Admin Only)
- **Visible only when logged-in user is Admin**
- **cboAssignTo**: Dropdown populated with all admins
- **btnAssignTicket**: Blue button "Assign"
- **cboStatus**: Dropdown with: Open, In Progress, Closed
- **txtStatusComment**: Multiline textbox (80px height) for optional note
- **btnUpdateStatus**: Blue button "Update Status"

#### E. Form Actions
- **btnClose**: Gray button "Close" - bottom right

---

## User Flows

### User Journey
1. **Login** → Enter credentials → Click Login
2. **User Dashboard** → See welcome message and options
3. **Create Ticket** → Fill form → Submit
4. **View Tickets** → See list of own tickets only
5. **View Details** → Read ticket info, add comments
6. **Logout** → Return to login

### Admin Journey
1. **Login** → Enter admin credentials → Click Login
2. **Admin Dashboard** → See admin welcome and options
3. **View All Tickets** → See complete ticket list
4. **View Details** → 
   - Read ticket info
   - Assign to another admin
   - Change status (Open → In Progress → Closed)
   - Add internal comments (not visible to users)
   - Add public comments
5. **Logout** → Return to login

---

## Dialog Messages

### Message Boxes Used
All use standard Windows MessageBox:
- **Information**: `MessageBoxIcon.Information` - blue (i) icon
- **Warning**: `MessageBoxIcon.Warning` - yellow (!) icon
- **Error**: `MessageBoxIcon.Error` - red (X) icon
- **Question**: `MessageBoxIcon.Question` - blue (?) icon

### Common Messages
- **Success**: "Ticket created successfully!"
- **Error**: "Login failed: Invalid username or password"
- **Validation**: "Please fill in all required fields"
- **Confirmation**: "Are you sure you want to update the status?"

---

## Accessibility & UX

### Tab Order
- All forms have logical tab order (top to bottom, left to right)
- Tab stops on all interactive controls
- No tab stop on read-only labels

### Keyboard Shortcuts
- **Enter**: Submit/OK on focused button
- **Escape**: Cancel/Close (where applicable)
- **Tab**: Navigate between fields

### Visual Feedback
- Buttons change appearance on hover
- Disabled controls appear grayed out
- Required fields marked with asterisk (*)
- Status messages use different colors (error = red, success = green)

---

## Technical Notes

### Form Types
- All forms inherit from `System.Windows.Forms.Form`
- Standard Windows Forms controls (no custom controls)
- .NET 8.0 Windows Forms application

### Data Binding
- DataGridViews use manual data binding from DTO lists
- No automatic data binding to database
- All data comes from API calls

### Form Lifetime
- Forms are created new each time (not singleton)
- Parent forms remain open when child forms open
- Closing parent form closes all child forms

---

## Design Recommendations for UI Designer

1. **Consistency**: Maintain consistent spacing (20px margins, 15px between controls)
2. **Button Sizing**: Primary action buttons should be 100-120px wide, 30-35px tall
3. **Color Scheme**: Keep it professional - blue for primary, gray for secondary
4. **Typography**: Use Segoe UI throughout for Windows consistency
5. **White Space**: Don't crowd controls - leave breathing room
6. **Icons**: Consider adding icons to buttons for better visual hierarchy
7. **Responsive Labels**: Ensure labels auto-resize for long text
8. **Grid Styling**: Use alternating row colors in grids for readability

---

## Form Count Summary
- **6 Total Forms**
  - 1 Login Form
  - 2 Dashboard Forms (User & Admin)
  - 1 Create Ticket Form
  - 1 Ticket List Form
  - 1 Ticket Details Form

All forms are modal or main application windows - no floating toolbars or panels.
