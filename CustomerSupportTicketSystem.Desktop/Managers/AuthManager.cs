namespace CustomerSupportTicketSystem.Desktop.Managers;

/// <summary>
/// Singleton class to manage authentication state across the application
/// </summary>
public class AuthManager
{
    private static AuthManager? _instance;
    private static readonly object _lock = new object();

    public string Token { get; private set; } = string.Empty;
    public int UserId { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Role { get; private set; } = string.Empty;

    public bool IsAuthenticated => !string.IsNullOrEmpty(Token);
    public bool IsAdmin => Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

    private AuthManager() { }

    public static AuthManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AuthManager();
                    }
                }
            }
            return _instance;
        }
    }

    public void SetAuthData(string token, int userId, string username, string fullName, string email, string role)
    {
        Token = token;
        UserId = userId;
        Username = username;
        FullName = fullName;
        Email = email;
        Role = role;
    }

    public void ClearAuthData()
    {
        Token = string.Empty;
        UserId = 0;
        Username = string.Empty;
        FullName = string.Empty;
        Email = string.Empty;
        Role = string.Empty;
    }
}
