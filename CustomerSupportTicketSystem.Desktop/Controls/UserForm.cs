using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerSupportTicketSystem.Desktop.DTOs;
using CustomerSupportTicketSystem.Desktop.Helpers;
using CustomerSupportTicketSystem.Desktop.Services;
using CustomerSupportTicketSystem.Desktop.UI;

namespace CustomerSupportTicketSystem.Desktop.Controls;

public partial class UserForm : UserControl
{
    private readonly UserService _userService;
    private readonly int? _userId;
    private readonly Action _onSaveSuccess;
    private readonly Action _onCancel;

    public UserForm(Action onSaveSuccess, Action onCancel, int? userId = null)
    {
        InitializeComponent();
        _userService = new UserService();
        _userId = userId;
        _onSaveSuccess = onSaveSuccess;
        _onCancel = onCancel;

        InitializeForm();
    }

    private async void InitializeForm()
    {
        // Populate Role Dropdown
        cboRole.Items.AddRange(new[] { "User", "Admin" });
        cboRole.SelectedIndex = 0;

        if (_userId.HasValue)
        {
            lblTitle.Text = "Edit User";
            txtUsername.Enabled = false; // Username cannot be changed
            txtPassword.Enabled = false; // Password change is separate
            txtPassword.PlaceholderText = "(Unchanged)";
            
            await LoadUserData(_userId.Value);
        }
        else
        {
            lblTitle.Text = "Create New User";
        }
    }

    private async Task LoadUserData(int userId)
    {
        try
        {
            // We need a GetUserById method in UserService, or just find from list
            // Adding GetUserById to UserService would be better, but we can list all and find one for now if needed.
            // Actually, API has GetUserById based on our implementation plan.
            // Let's assume I added it to UserService or add it now? 
            // I missed adding GetUserById to Client UserService. I'll add it.
            // For now, I'll fetch all and filter or add the method. 
            // Better to add the method to UserService.
            // Wait, I can just use GetAllUsersAsync and filter since list is small.
            // Or add the method. I'll add the method to UserService in next step.
            
            // Assuming the method exists for now to keep code clean
            // var user = await _userService.GetUserByIdAsync(userId);
             
             // WORKAROUND: Fetch all and filter (for speed now)
             var users = await _userService.GetAllUsersAsync();
             var user = users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                txtUsername.Text = user.Username;
                txtFullName.Text = user.FullName;
                txtEmail.Text = user.Email;
                cboRole.SelectedItem = user.Role;
            }
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to load user data: {ex.Message}");
            _onCancel?.Invoke();
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            btnSave.Enabled = false;

            if (_userId.HasValue)
            {
                // Update
                var updateDto = new UpdateUserDto
                {
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Role = cboRole.SelectedItem.ToString()!
                };

                await _userService.UpdateUserAsync(_userId.Value, updateDto);
                FormHelper.ShowSuccess("User updated successfully");
            }
            else
            {
                // Create
                var createDto = new CreateUserDto
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Role = cboRole.SelectedItem.ToString()!
                };

                await _userService.CreateUserAsync(createDto);
                FormHelper.ShowSuccess("User created successfully");
            }

            _onSaveSuccess?.Invoke();
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Operation failed: {ex.Message}");
        }
        finally
        {
            btnSave.Enabled = true;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            FormHelper.ShowError("Username is required");
            return false;
        }

        if (!_userId.HasValue && string.IsNullOrWhiteSpace(txtPassword.Text))
        {
             // Password required only for new users
            FormHelper.ShowError("Password is required for new users");
            return false;
        }
        
        if (_userId.HasValue && !string.IsNullOrEmpty(txtPassword.Text))
        {
            // If editing, password field is disabled anyway
        }

        if (string.IsNullOrWhiteSpace(txtFullName.Text))
        {
            FormHelper.ShowError("Full Name is required");
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
        {
            FormHelper.ShowError("Valid Email is required");
            return false;
        }

        if (cboRole.SelectedItem == null)
        {
            FormHelper.ShowError("Role is required");
            return false;
        }

        return true;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        _onCancel?.Invoke();
    }
}
