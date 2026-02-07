using CustomerSupportTicketSystem.Desktop.DTOs;
using CustomerSupportTicketSystem.Desktop.Helpers;
using CustomerSupportTicketSystem.Desktop.Managers;
using CustomerSupportTicketSystem.Desktop.Services;
using CustomerSupportTicketSystem.Desktop.Controls;

namespace CustomerSupportTicketSystem.Desktop.Forms;

public partial class LoginForm : UserControl
{
    private readonly AuthService _authService;

    public LoginForm()
    {
        InitializeComponent();
        _authService = new AuthService();
        this.Resize += LoginForm_Resize;
    }

    private void LoginForm_Resize(object? sender, EventArgs e)
    {
        CenterLoginControls();
    }

    private void CenterLoginControls()
    {
        if (pnlRight == null) return;

        int centerX = pnlRight.Width / 2;
        int centerY = pnlRight.Height / 2;
        int contentHeight = 300; // Approx height of all controls
        int startY = centerY - (contentHeight / 2);

        // Center horizontally and vertically
        if (lblTitle != null)
        {
            lblTitle.Location = new Point(centerX - (lblTitle.Width / 2), startY);
            
            int offset = 60; // Gap after title
            
            if (lblUsername != null) lblUsername.Location = new Point(centerX - (txtUsername.Width / 2), startY + offset);
            if (txtUsername != null) txtUsername.Location = new Point(centerX - (txtUsername.Width / 2), startY + offset + 20);
            
            offset += 70;
            if (lblPassword != null) lblPassword.Location = new Point(centerX - (txtPassword.Width / 2), startY + offset);
            if (txtPassword != null) txtPassword.Location = new Point(centerX - (txtPassword.Width / 2), startY + offset + 20);
            
            offset += 80;
            if (btnLogin != null) btnLogin.Location = new Point(centerX - (btnLogin.Width / 2), startY + offset);
            
            offset += 55;
            if (lblStatus != null) lblStatus.Location = new Point(centerX - (lblStatus.Width / 2), startY + offset);
        }
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            FormHelper.ShowError("Please enter username");
            txtUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            FormHelper.ShowError("Please enter password");
            txtPassword.Focus();
            return;
        }

        try
        {
            btnLogin.Enabled = false;
            lblStatus.Text = "Logging in...";
            lblStatus.ForeColor = Color.Blue;

            var request = new LoginRequest
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text
            };

            var response = await _authService.LoginAsync(request);

            if (response != null)
            {
                // Store auth data
                AuthManager.Instance.SetAuthData(
                    response.Token,
                    response.UserId,
                    response.Username,
                    response.FullName,
                    response.Email,
                    response.Role
                );

                lblStatus.Text = "Login successful!";
                lblStatus.ForeColor = Color.Green;

                // Navigate to appropriate dashboard using NavigationManager
                if (AuthManager.Instance.IsAdmin)
                {
                    NavigationManager.Instance.NavigateTo<AdminDashboardControl>();
                }
                else
                {
                    NavigationManager.Instance.NavigateTo<UserDashboardControl>();
                }
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "";
            FormHelper.ShowError($"Login failed: {ex.Message}");
            btnLogin.Enabled = true;
        }
    }

    private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            btnLogin_Click(sender, e);
        }
    }
}
