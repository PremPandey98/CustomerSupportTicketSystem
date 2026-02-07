using CustomerSupportTicketSystem.Desktop.Managers;
using CustomerSupportTicketSystem.Desktop.Forms;

namespace CustomerSupportTicketSystem.Desktop.Controls;

public partial class AdminDashboardControl : UserControl
{
    public AdminDashboardControl()
    {
        InitializeComponent();
        lblWelcome.Text = $"Welcome, {AuthManager.Instance.FullName} (Admin)";
        this.Resize += AdminDashboardControl_Resize;
    }

    private void AdminDashboardControl_Resize(object? sender, EventArgs e)
    {
        CenterDashboardControls();
    }

    private void btnViewAllTickets_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.NavigateTo<TicketListControl>();
    }

    private void btnManageUsers_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.NavigateTo<UserListControl>();
    }

    private void CenterDashboardControls()
    {
        int centerX = this.Width / 2;
        int centerY = this.Height / 2;
        int contentHeight = 270; // Increased height for new button
        int startY = centerY - (contentHeight / 2);

        // Center horizontally and vertically
        if (lblWelcome != null)
        {
            lblWelcome.Location = new Point(centerX - (lblWelcome.Width / 2), startY);
            
            if (btnViewAllTickets != null) 
                btnViewAllTickets.Location = new Point(centerX - (btnViewAllTickets.Width / 2), startY + 60);

            if (btnManageUsers != null)
                btnManageUsers.Location = new Point(centerX - (btnManageUsers.Width / 2), startY + 120);
            
            if (btnLogout != null) 
                btnLogout.Location = new Point(centerX - (btnLogout.Width / 2), startY + 190);
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        AuthManager.Instance.ClearAuthData();
        NavigationManager.Instance.ClearHistory();
        NavigationManager.Instance.NavigateTo<LoginForm>();
    }
}
