using CustomerSupportTicketSystem.Desktop.DTOs;

namespace CustomerSupportTicketSystem.Desktop.Services;

public class AuthService : ApiService
{
    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        return await PostAsync<LoginResponse>("Auth/login", request);
    }
}
