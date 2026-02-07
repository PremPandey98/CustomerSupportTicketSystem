using CustomerSupportTicketSystem.Desktop.Managers;

namespace CustomerSupportTicketSystem.Desktop.Forms;

public partial class MainContainerForm : Form
{
    public MainContainerForm()
    {
        InitializeComponent();
        
        // Initialize NavigationManager with the content panel
        NavigationManager.Instance.Initialize(panelContent);
        
        // Navigate to login screen on startup
        NavigationManager.Instance.NavigateTo<LoginForm>();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Clear navigation history and dispose controls
        NavigationManager.Instance.ClearHistory();
        base.OnFormClosing(e);
    }
}
