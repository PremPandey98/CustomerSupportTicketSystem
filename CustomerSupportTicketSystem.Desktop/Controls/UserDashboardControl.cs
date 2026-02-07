using CustomerSupportTicketSystem.Desktop.Managers;
using CustomerSupportTicketSystem.Desktop.Forms;

namespace CustomerSupportTicketSystem.Desktop.Controls;

public partial class UserDashboardControl : UserControl
{
    public UserDashboardControl()
    {
        InitializeComponent();
        lblWelcome.Text = $"Welcome, {AuthManager.Instance.FullName}";
        this.Resize += UserDashboardControl_Resize;
    }

    private void UserDashboardControl_Resize(object? sender, EventArgs e)
    {
        CenterDashboardControls();
    }

    private void CenterDashboardControls()
    {
        int centerX = this.Width / 2;
        int centerY = this.Height / 2;
        int contentHeight = 250; // Approx height
        int startY = centerY - (contentHeight / 2);

        // Center horizontally and vertically
        if (lblWelcome != null)
        {
            lblWelcome.Location = new Point(centerX - (lblWelcome.Width / 2), startY);
            
            if (btnCreateTicket != null) 
                btnCreateTicket.Location = new Point(centerX - (btnCreateTicket.Width / 2), startY + 60);
            
            if (btnViewTickets != null) 
                btnViewTickets.Location = new Point(centerX - (btnViewTickets.Width / 2), startY + 130);
                
            if (btnLogout != null) 
                btnLogout.Location = new Point(centerX - (btnLogout.Width / 2), startY + 200);
        }
    }

    private void btnCreateTicket_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.NavigateTo<CreateTicketControl>();
    }

    private void btnViewTickets_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.NavigateTo<TicketListControl>();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        AuthManager.Instance.ClearAuthData();
        NavigationManager.Instance.ClearHistory();
        NavigationManager.Instance.NavigateTo<LoginForm>();
    }
}
