using CustomerSupportTicketSystem.Desktop.Managers;

namespace CustomerSupportTicketSystem.Desktop.Forms;

public partial class AdminDashboardForm : Form
{
    public AdminDashboardForm()
    {
        InitializeComponent();
        lblWelcome.Text = $"Welcome, {AuthManager.Instance.FullName} (Admin)";
    }

    private void btnViewAllTickets_Click(object sender, EventArgs e)
    {
        var ticketListForm = new TicketListForm();
        this.Hide();
        ticketListForm.FormClosed += (s, args) => this.Show();
        ticketListForm.Show();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        AuthManager.Instance.ClearAuthData();
        NavigationManager.Instance.ClearHistory();
        NavigationManager.Instance.NavigateTo<CustomerSupportTicketSystem.Desktop.Forms.LoginForm>();
    }
}
