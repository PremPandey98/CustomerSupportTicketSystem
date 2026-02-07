using CustomerSupportTicketSystem.Desktop.DTOs;
using CustomerSupportTicketSystem.Desktop.Helpers;
using CustomerSupportTicketSystem.Desktop.Managers;
using CustomerSupportTicketSystem.Desktop.Services;

namespace CustomerSupportTicketSystem.Desktop.Controls;

public partial class TicketListControl : UserControl
{
    private readonly TicketService _ticketService;
    private List<TicketListItemDto> _tickets = new();

    public TicketListControl()
    {
        InitializeComponent();
        _ticketService = new TicketService();
        
        // Hide Create button if admin (admin creates from admin dashboard if needed)
        if (AuthManager.Instance.IsAdmin)
        {
            btnCreateTicket.Visible = false;
        }
    }

    private async void TicketListControl_Load(object sender, EventArgs e)
    {
        await LoadTickets();
    }

    private async Task LoadTickets()
    {
        try
        {
            dgvTickets.DataSource = null;
            lblStatus.Text = "Loading tickets...";
            lblStatus.ForeColor = Color.Blue;

            _tickets = await _ticketService.GetTicketsAsync() ?? new List<TicketListItemDto>();
            
            dgvTickets.DataSource = _tickets;
            ConfigureGrid();
            
            lblStatus.Text = $"Loaded {_tickets.Count} ticket(s)";
            lblStatus.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error loading tickets";
            lblStatus.ForeColor = Color.Red;
            FormHelper.ShowError($"Failed to load tickets: {ex.Message}");
        }
    }

    private void ConfigureGrid()
    {
        dgvTickets.ReadOnly = true;
        dgvTickets.AllowUserToAddRows = false;
        dgvTickets.AllowUserToDeleteRows = false;
        dgvTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTickets.MultiSelect = false;
        dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Hide TicketId column
        if (dgvTickets.Columns["TicketId"] != null)
            dgvTickets.Columns["TicketId"].Visible = false;

        // Set column headers and width
        if (dgvTickets.Columns["TicketNumber"] != null)
        {
            dgvTickets.Columns["TicketNumber"].HeaderText = "Ticket #";
            dgvTickets.Columns["TicketNumber"].FillWeight = 80;
        }

        if (dgvTickets.Columns["Subject"] != null)
        {
            dgvTickets.Columns["Subject"].HeaderText = "Subject";
            dgvTickets.Columns["Subject"].FillWeight = 150;
        }

        if (dgvTickets.Columns["Priority"] != null)
        {
            dgvTickets.Columns["Priority"].HeaderText = "Priority";
            dgvTickets.Columns["Priority"].FillWeight = 60;
        }

        if (dgvTickets.Columns["Status"] != null)
        {
            dgvTickets.Columns["Status"].HeaderText = "Status";
            dgvTickets.Columns["Status"].FillWeight = 80;
        }

        if (dgvTickets.Columns["CreatedDate"] != null)
        {
            dgvTickets.Columns["CreatedDate"].HeaderText = "Created Date";
            dgvTickets.Columns["CreatedDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dgvTickets.Columns["CreatedDate"].FillWeight = 100;
        }

        if (dgvTickets.Columns["AssignedTo"] != null)
        {
            dgvTickets.Columns["AssignedTo"].HeaderText = "Assigned To";
            dgvTickets.Columns["AssignedTo"].FillWeight = 100;
        }

        if (dgvTickets.Columns["CreatedBy"] != null)
        {
            dgvTickets.Columns["CreatedBy"].HeaderText = "Created By";
            dgvTickets.Columns["CreatedBy"].FillWeight = 100;
        }
    }

    private void btnViewDetails_Click(object sender, EventArgs e)
    {
        if (dgvTickets.SelectedRows.Count == 0)
        {
            FormHelper.ShowError("Please select a ticket to view");
            return;
        }

        var selectedTicket = (TicketListItemDto)dgvTickets.SelectedRows[0].DataBoundItem;
        NavigationManager.Instance.NavigateTo<TicketDetailsControl>(selectedTicket.TicketId);
    }

    private void dgvTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnViewDetails_Click(sender, e);
        }
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await LoadTickets();
    }

    private void btnCreateTicket_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.NavigateTo<CreateTicketControl>();
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.GoBack();
    }

    public async Task RefreshList()
    {
        await LoadTickets();
    }
}
