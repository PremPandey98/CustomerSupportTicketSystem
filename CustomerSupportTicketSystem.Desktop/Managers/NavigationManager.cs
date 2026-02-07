using System.Windows.Forms;

namespace CustomerSupportTicketSystem.Desktop.Managers;

/// <summary>
/// Singleton manager for handling navigation between UserControls in a panel container
/// </summary>
public class NavigationManager
{
    private static NavigationManager? _instance;
    private Panel? _contentPanel;
    private Stack<UserControl> _navigationHistory = new();
    private UserControl? _currentControl;

    public static NavigationManager Instance => _instance ??= new NavigationManager();

    private NavigationManager() { }

    /// <summary>
    /// Initialize the NavigationManager with the main content panel
    /// </summary>
    public void Initialize(Panel contentPanel)
    {
        _contentPanel = contentPanel ?? throw new ArgumentNullException(nameof(contentPanel));
        _navigationHistory.Clear();
    }

    /// <summary>
    /// Navigate to a new UserControl by type
    /// </summary>
    public void NavigateTo<T>(params object[] args) where T : UserControl
    {
        if (_contentPanel == null)
            throw new InvalidOperationException("NavigationManager is not initialized. Call Initialize() first.");

        try
        {
            // Create instance of the UserControl
            var control = (UserControl?)Activator.CreateInstance(typeof(T), args);
            if (control == null)
                throw new InvalidOperationException($"Failed to create instance of {typeof(T).Name}");

            NavigateTo(control);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Navigation error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Navigate to a specific UserControl instance
    /// </summary>
    public void NavigateTo(UserControl control)
    {
        if (_contentPanel == null)
            throw new InvalidOperationException("NavigationManager is not initialized. Call Initialize() first.");

        // Add current control to history before navigating away
        if (_currentControl != null)
        {
            _navigationHistory.Push(_currentControl);
        }

        LoadControl(control);
    }

    /// <summary>
    /// Navigate back to the previous control
    /// </summary>
    public void GoBack()
    {
        if (_contentPanel == null)
            throw new InvalidOperationException("NavigationManager is not initialized. Call Initialize() first.");

        if (_navigationHistory.Count == 0)
        {
            MessageBox.Show("No previous page to navigate to.", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Dispose current control
        if (_currentControl != null)
        {
            _contentPanel.Controls.Remove(_currentControl);
            _currentControl.Dispose();
        }

        // Load previous control from history
        var previousControl = _navigationHistory.Pop();
        LoadControl(previousControl, addToHistory: false);
    }

    /// <summary>
    /// Clear navigation history
    /// </summary>
    public void ClearHistory()
    {
        // Dispose all controls in history
        while (_navigationHistory.Count > 0)
        {
            var control = _navigationHistory.Pop();
            control.Dispose();
        }
    }

    /// <summary>
    /// Check if back navigation is available
    /// </summary>
    public bool CanGoBack => _navigationHistory.Count > 0;

    /// <summary>
    /// Load a control into the content panel
    /// </summary>
    private void LoadControl(UserControl control, bool addToHistory = true)
    {
        if (_contentPanel == null)
            throw new InvalidOperationException("Content panel is not set.");

        // Remove and dispose current control if not adding to history
        if (_currentControl != null && !addToHistory)
        {
            _contentPanel.Controls.Remove(_currentControl);
            _currentControl.Dispose();
        }
        else if (_currentControl != null)
        {
            // Just remove from panel if adding to history (already added)
            _contentPanel.Controls.Remove(_currentControl);
        }

        // Set the new current control
        _currentControl = control;

        // Configure control to fill the panel
        control.Dock = DockStyle.Fill;

        // Add to panel
        _contentPanel.Controls.Add(control);
        control.BringToFront();

        // Focus the control
        control.Focus();
    }

    /// <summary>
    /// Refresh the current control (useful after data changes)
    /// </summary>
    public void RefreshCurrent()
    {
        if (_currentControl != null)
        {
            _currentControl.Refresh();
        }
    }

    /// <summary>
    /// Get the current control
    /// </summary>
    public UserControl? CurrentControl => _currentControl;
}
