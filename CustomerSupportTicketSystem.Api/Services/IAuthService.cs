using CustomerSupportTicketSystem.API.DTOs;
using CustomerSupportTicketSystem.API.Models;

namespace CustomerSupportTicketSystem.API.Services;

public interface IAuthService
{
    Task<LoginResponseDto?> AuthenticateAsync(LoginRequestDto loginDto);
    string GenerateJwtToken(User user);
}
