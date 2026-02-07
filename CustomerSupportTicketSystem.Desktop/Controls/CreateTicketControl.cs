using CustomerSupportTicketSystem.Desktop.DTOs;
using CustomerSupportTicketSystem.Desktop.Helpers;
using CustomerSupportTicketSystem.Desktop.Managers;
using CustomerSupportTicketSystem.Desktop.Services;

namespace CustomerSupportTicketSystem.Desktop.Controls;

public partial class CreateTicketControl : UserControl
{
    private readonly TicketService _ticketService;

    public CreateTicketControl()
    {
        InitializeComponent();
        _ticketService = new TicketService();
        
        // Populate priority dropdown
        cboPriority.Items.AddRange(new[] { "Low", "Medium", "High" });
        cboPriority.SelectedIndex = 1; // Default to Medium
    }

    private async void btnSubmit_Click(object sender, EventArgs e)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(txtSubject.Text))
        {
            FormHelper.ShowError("Please enter a subject");
            txtSubject.Focus();
            return;
        }

        if (txtSubject.Text.Length > 200)
        {
            FormHelper.ShowError("Subject must be 200 characters or less");
            txtSubject.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDescription.Text))
        {
            FormHelper.ShowError("Please enter a description");
            txtDescription.Focus();
            return;
        }

        if (cboPriority.SelectedItem == null)
        {
            FormHelper.ShowError("Please select a priority");
            cboPriority.Focus();
            return;
        }

        try
        {
            btnSubmit.Enabled = false;
            btnCancel.Enabled = false;

            var dto = new CreateTicketDto
            {
                Subject = txtSubject.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Priority = cboPriority.SelectedItem.ToString() ?? "Medium"
            };

            await _ticketService.CreateTicketAsync(dto);
            
            FormHelper.ShowSuccess("Ticket created successfully!");
            
            // Navigate back to ticket list
            NavigationManager.Instance.GoBack();
        }
        catch (Exception ex)
        {
            FormHelper.ShowError($"Failed to create ticket: {ex.Message}");
            btnSubmit.Enabled = true;
            btnCancel.Enabled = true;
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        NavigationManager.Instance.GoBack();
    }
}
