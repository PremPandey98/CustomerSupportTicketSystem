using CustomerSupportTicketSystem.Desktop.DTOs;
using CustomerSupportTicketSystem.Desktop.Helpers;
using CustomerSupportTicketSystem.Desktop.Managers;
using CustomerSupportTicketSystem.Desktop.Services;

namespace CustomerSupportTicketSystem.Desktop.Controls;

public partial class TicketDetailsControl : UserControl
{
    private readonly TicketService _ticketService;
    private readonly int _ticketId;
    private TicketDetailsDto? _ticketDetails;
    private List<UserListItemDto>? _adminUsers;

    public TicketDetailsControl(int ticketId)
    {
        InitializeComponent();
        _ticketService = new TicketService();
        _ticketId = ticketId;
    }

    private async void TicketDetailsControl_Load(object sender, EventArgs e)
    {
        await LoadTicketDetails();
        
        // Show/hide admin controls based on role
        grpAdminActions.Visible = AuthManager.Instance.IsAdmin;
        
        if (AuthManager.Instance.IsAdmin)
        {
            await LoadAdminUsers();
        }
        else
        {
            // Hide internal comment option for non-admins
            chkIsInternal.Visible = false;
        }
    }

    private async Task LoadTicketDetails()
    {
        try
        {
            _ticketDetails = await _ticketService.GetTicketDetailsAsync(_ticketId);
            
            if (_ticketDetails != null)
            {
                DisplayTicketDetails(_ticketDetails);
            }
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to load ticket details: {ex.Message}");
            NavigationManager.Instance.GoBack();
        }
    }

    private void DisplayTicketDetails(TicketDetailsDto ticket)
    {
        lblTicketNumberValue.Text = ticket.TicketNumber;
        lblSubjectValue.Text = ticket.Subject;
        txtDescription.Text = ticket.Description;
        lblPriorityValue.Text = ticket.Priority;
        lblStatusValue.Text = ticket.Status;
        lblCreatedDateValue.Text = ticket.CreatedDate.ToString("yyyy-MM-dd HH:mm");
        lblCreatedByValue.Text = ticket.CreatedBy;
        lblAssignedToValue.Text = ticket.AssignedTo ?? "Not assigned";

        // Load comments
        dgvComments.DataSource = ticket.Comments;
        ConfigureCommentsGrid();

        // Load history
        dgvHistory.DataSource = ticket.History;
        ConfigureHistoryGrid();

        // Disable comment adding if ticket is closed
        if (ticket.Status == "Closed")
        {
            txtComment.Enabled = false;
            btnAddComment.Enabled = false;
            chkIsInternal.Enabled = false;
        }
    }

    private void ConfigureCommentsGrid()
    {
        dgvComments.ReadOnly = true;
        dgvComments.AllowUserToAddRows = false;
        dgvComments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        if (dgvComments.Columns["CommentId"] != null)
            dgvComments.Columns["CommentId"].Visible = false;

        if (dgvComments.Columns["CreatedDate"] != null)
        {
            dgvComments.Columns["CreatedDate"].HeaderText = "Date";
            dgvComments.Columns["CreatedDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dgvComments.Columns["CreatedDate"].FillWeight = 70;
        }

        if (dgvComments.Columns["CreatedBy"] != null)
        {
            dgvComments.Columns["CreatedBy"].HeaderText = "By";
            dgvComments.Columns["CreatedBy"].FillWeight = 60;
        }

        if (dgvComments.Columns["CommentText"] != null)
        {
            dgvComments.Columns["CommentText"].HeaderText = "Comment";
            dgvComments.Columns["CommentText"].FillWeight = 150;
        }

        if (dgvComments.Columns["IsInternal"] != null)
        {
            dgvComments.Columns["IsInternal"].HeaderText = "Internal";
            dgvComments.Columns["IsInternal"].FillWeight = 40;
            // Hide column for non-admins
            dgvComments.Columns["IsInternal"].Visible = AuthManager.Instance.IsAdmin;
        }
    }

    private void ConfigureHistoryGrid()
    {
        dgvHistory.ReadOnly = true;
        dgvHistory.AllowUserToAddRows = false;
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        if (dgvHistory.Columns["HistoryId"] != null)
            dgvHistory.Columns["HistoryId"].Visible = false;

        if (dgvHistory.Columns["ChangedDate"] != null)
        {
            dgvHistory.Columns["ChangedDate"].HeaderText = "Date";
            dgvHistory.Columns["ChangedDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dgvHistory.Columns["ChangedDate"].FillWeight = 70;
        }

        if (dgvHistory.Columns["ChangedBy"] != null)
        {
            dgvHistory.Columns["ChangedBy"].HeaderText = "Changed By";
            dgvHistory.Columns["ChangedBy"].FillWeight = 60;
        }

        if (dgvHistory.Columns["OldStatus"] != null)
        {
            dgvHistory.Columns["OldStatus"].HeaderText = "From";
            dgvHistory.Columns["OldStatus"].FillWeight = 50;
        }

        if (dgvHistory.Columns["NewStatus"] != null)
        {
            dgvHistory.Columns["NewStatus"].HeaderText = "To";
            dgvHistory.Columns["NewStatus"].FillWeight = 50;
        }

        if (dgvHistory.Columns["Comment"] != null)
        {
            dgvHistory.Columns["Comment"].HeaderText = "Comment";
            dgvHistory.Columns["Comment"].FillWeight = 100;
        }
    }

    private async Task LoadAdminUsers()
    {
        try
        {
            _adminUsers = await _ticketService.GetAdminUsersAsync();
            
            if (_adminUsers != null)
            {
                cboAssignTo.DisplayMember = "FullName";
                cboAssignTo.ValueMember = "UserId";
                cboAssignTo.DataSource = _adminUsers;
                cboAssignTo.SelectedIndex = -1;

                // Select current assigned admin if exists
                if (_ticketDetails?.AssignedToAdminId != null)
                {
                    cboAssignTo.SelectedValue = _ticketDetails.AssignedToAdminId;
                }
            }

            // Populate status dropdown
            cboStatus.Items.AddRange(new[] { "Open", "In Progress", "Closed" });
            cboStatus.SelectedItem = _ticketDetails?.Status;
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to load admin users: {ex.Message}");
        }
    }

    private async void btnAddComment_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtComment.Text))
        {
            FormHelper.ShowError("Please enter a comment");
            return;
        }

        try
        {
            btnAddComment.Enabled = false;

            var dto = new AddCommentDto
            {
                CommentText = txtComment.Text.Trim(),
                IsInternal = chkIsInternal.Checked
            };

            await _ticketService.AddCommentAsync(_ticketId, dto);
            
            FormHelper.ShowSuccess("Comment added successfully");
            txtComment.Clear();
            chkIsInternal.Checked = false;
            
            await LoadTicketDetails();
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to add comment: {ex.Message}");
        }
        finally
        {
            btnAddComment.Enabled = true;
        }
    }

    private async void btnAssignTicket_Click(object sender, EventArgs e)
    {
        if (cboAssignTo.SelectedValue == null)
        {
            FormHelper.ShowError("Please select an admin to assign");
            return;
        }

        try
        {
            btnAssignTicket.Enabled = false;

            var dto = new AssignTicketDto
            {
                AssignedToAdminId = (int)cboAssignTo.SelectedValue
            };

            await _ticketService.AssignTicketAsync(_ticketId, dto);
            
            FormHelper.ShowSuccess("Ticket assigned successfully");
            await LoadTicketDetails();
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to assign ticket: {ex.Message}");
        }
        finally
        {
            btnAssignTicket.Enabled = true;
        }
    }

    private async void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        if (cboStatus.SelectedItem == null)
        {
            FormHelper.ShowError("Please select a status");
            return;
        }

        var newStatus = cboStatus.SelectedItem.ToString();
        
        if (newStatus == _ticketDetails?.Status)
        {
            FormHelper.ShowInfo("Status is already set to this value");
            return;
        }

        try
        {
            btnUpdateStatus.Enabled = false;

            var dto = new UpdateStatusDto
            {
                NewStatus = newStatus!,
                Comment = string.IsNullOrWhiteSpace(txtStatusComment.Text) ? null : txtStatusComment.Text.Trim()
            };

            await _ticketService.UpdateTicketStatusAsync(_ticketId, dto);
            
            FormHelper.ShowSuccess("Status updated successfully");
            txtStatusComment.Clear();
            await LoadTicketDetails();
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to update status: {ex.Message}");
        }
        finally
        {
            btnUpdateStatus.Enabled = true;
        }
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.GoBack();
    }
}
