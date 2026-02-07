using CustomerSupportTicketSystem.Desktop.Managers;

namespace CustomerSupportTicketSystem.Desktop.Forms;

public partial class UserDashboardForm : Form
{
    public UserDashboardForm()
    {
        InitializeComponent();
        lblWelcome.Text = $"Welcome, {AuthManager.Instance.FullName}";
    }

    private void btnCreateTicket_Click(object sender, EventArgs e)
    {
        var createForm = new CreateTicketForm();
        this.Hide();
        createForm.FormClosed += (s, args) => this.Show();
        createForm.Show();
    }

    private void btnViewTickets_Click(object sender, EventArgs e)
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
