using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerSupportTicketSystem.Desktop.DTOs;
using CustomerSupportTicketSystem.Desktop.Helpers;
using CustomerSupportTicketSystem.Desktop.Managers;
using CustomerSupportTicketSystem.Desktop.Services;
using CustomerSupportTicketSystem.Desktop.UI;

namespace CustomerSupportTicketSystem.Desktop.Controls;

public partial class UserListControl : UserControl
{
    private readonly UserService _userService;
    private List<UserDto> _users = new();

    public UserListControl()
    {
        InitializeComponent();
        _userService = new UserService();
        InitializeControl();
    }

    private void InitializeControl()
    {
        // Customize Grid
        dgvUsers.AutoGenerateColumns = false;
        
        // Add columns programmatically or in designer. 
        // Doing it here covers both bases if designer file misses it.
        SetupGridColumns();
    }

    private void SetupGridColumns()
    {
        dgvUsers.Columns.Clear();

        dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "UserId",
            HeaderText = "ID",
            Visible = false
        });

        dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Username",
            HeaderText = "Username",
            Width = 120
        });

        dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "FullName",
            HeaderText = "Full Name",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });

        dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Email",
            HeaderText = "Email",
            Width = 180
        });

        dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Role",
            HeaderText = "Role",
            Width = 80
        });

        dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn
        {
            DataPropertyName = "IsActive",
            HeaderText = "Active",
            Width = 60
        });
    }

    private async void UserListControl_Load(object sender, EventArgs e)
    {
        await LoadUsers();
    }

    private async Task LoadUsers()
    {
        try
        {
            _users = await _userService.GetAllUsersAsync();
            dgvUsers.DataSource = _users;
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to load users: {ex.Message}");
        }
    }

    private void btnAddUser_Click(object sender, EventArgs e)
    {
        // Navigate to UserForm
        // We can use NavigationManager to switch to a UserForm control
        // But UserForm is a UserControl, so we can wrap it or use it directly.
        // Let's instantiate UserForm and navigate to it via NavigationManager if it supports generic/instance.
        // NavigationManager supports generics <T>.
        // Since UserForm needs constructor arguments (callbacks), we might need to adjust NavigationManager 
        // or just add UserForm to Controls collection manually here (like a modal on top).
        // OR, better: Add a method to NavigationManager to navigate to an INSTANCE.
        // Checking NavigationManager... likely only supports types.
        
        // Alternative: Show UserForm as a "modal" overlay within this control or MainContainer.
        // For simplicity and consistency, let's modify NavigationManager to support instance navigation 
        // OR just replace content of MainContainer manually? No, accessing MainContainer is hard.
        
        // Let's check NavigationManager capabilities.
        // If not supported, I'll use a specific approach:
        // Create a 'CreateUserControl' wrapper or just handle it here by hiding dgv and showing form.
        // Let's try handling it within this control for "modal" feel, or just adding to parent.
        
        // Actually, simplest is to just Add the UserForm to this control's Controls collection and bring to front,
        // acting like a page swap.
        
        ShowUserForm(null);
    }

    private void ShowUserForm(int? userId)
    {
        UserForm? form = null;
        form = new UserForm(
            onSaveSuccess: async () => 
            {
                if (form != null)
                {
                    this.Controls.Remove(form);
                    form.Dispose();
                }
                pnlList.Visible = true;
                pnlList.BringToFront(); // Ensure list is on top
                await LoadUsers(); // Refresh
            },
            onCancel: () => 
            {
               if (form != null)
               {
                   this.Controls.Remove(form);
                   form.Dispose();
               }
               pnlList.Visible = true;
               pnlList.BringToFront();
            },
            userId: userId
        );
        
        form.Dock = DockStyle.Fill;
        pnlList.Visible = false;
        this.Controls.Add(form);
        form.BringToFront();
    }

    private void btnEditUser_Click(object sender, EventArgs e)
    {
        var user = GetSelectedUser();
        if (user == null) return;

        ShowUserForm(user.UserId);
    }

    private async void btnDeleteUser_Click(object sender, EventArgs e)
    {
        var user = GetSelectedUser();
        if (user == null) return;

        if (MessageBox.Show($"Are you sure you want to delete user '{user.Username}'?", "Confirm Delete", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            try
            {
                await _userService.DeleteUserAsync(user.UserId);
                FormHelper.ShowSuccess("User deleted successfully.");
                await LoadUsers();
            }
            catch (Exception ex)
            {
                FormHelper.ShowError($"Failed to delete user: {ex.Message}");
            }
        }
    }

    private async void btnToggleStatus_Click(object sender, EventArgs e)
    {
        var user = GetSelectedUser();
        if (user == null) return;

        var newStatus = !user.IsActive;
        // Don't disable yourself if you're the current admin? 
        // API might allow it, but let's warn or prevent if userId matches current user.
        if (user.UserId == AuthManager.Instance.UserId)
        {
             FormHelper.ShowError("You cannot block your own account.");
             return;
        }

        try
        {
            await _userService.ChangeUserStatusAsync(user.UserId, newStatus);
            FormHelper.ShowSuccess($"User {(newStatus ? "unblocked" : "blocked")} successfully.");
            await LoadUsers();
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to change status: {ex.Message}");
        }
    }

    private async void btnResetPassword_Click(object sender, EventArgs e)
    {
        var user = GetSelectedUser();
        if (user == null) return;

        // Show dialog to enter new password
        string newPassword = PromptForPassword($"Reset Password for '{user.Username}'");
        
        if (string.IsNullOrEmpty(newPassword))
        {
            // User cancelled or entered empty password
            return;
        }

        if (MessageBox.Show($"Reset password for '{user.Username}'?", "Confirm Reset",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
             try
             {
                 await _userService.ResetPasswordAsync(user.UserId, newPassword);
                 FormHelper.ShowSuccess("Password reset successfully.");
             }
             catch (Exception ex)
             {
                 FormHelper.ShowError($"Failed to reset password: {ex.Message}");
             }
        }
    }

    private string? PromptForPassword(string title)
    {
        using (var form = new Form())
        {
            form.Text = title;
            form.Width = 400;
            form.Height = 200;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            var lblPassword = new Label() { Left = 20, Top = 20, Text = "New Password (min 6 characters):" , Width = 340};
            var txtPassword = new ModernTextBox() 
            { 
                Left = 20, 
                Top = 50, 
                Width = 340, 
                PasswordChar = '*',
                BorderRadius = 5,
                Padding = new Padding(10, 7, 10, 7)
            };
            
            var btnOk = new ModernButton() 
            { 
                Text = "OK", 
                Left = 200, 
                Width = 80, 
                Top = 110, 
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                BorderRadius = 5
            };
            
            var btnCancel = new ModernButton() 
            { 
                Text = "Cancel", 
                Left = 290, 
                Width = 80, 
                Top = 110, 
                DialogResult = DialogResult.Cancel,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                BorderRadius = 5
            };

            btnOk.Click += (sender, e) => 
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Invalid Password", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    form.DialogResult = DialogResult.None;
                }
            };

            form.Controls.Add(lblPassword);
            form.Controls.Add(txtPassword);
            form.Controls.Add(btnOk);
            form.Controls.Add(btnCancel);
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            return form.ShowDialog() == DialogResult.OK ? txtPassword.Text : null;
        }
    }

    private UserDto? GetSelectedUser()
    {
        if (dgvUsers.SelectedRows.Count == 0)
        {
             FormHelper.ShowError("Please select a user.");
             return null;
        }
        return dgvUsers.SelectedRows[0].DataBoundItem as UserDto;
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.GoBack();
    }
}
