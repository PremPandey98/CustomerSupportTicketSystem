using CustomerSupportTicketSystem.API.DTOs;
using CustomerSupportTicketSystem.API.Models;

namespace CustomerSupportTicketSystem.API.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserByIdAsync(int id);
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    Task<bool> DeleteUserAsync(int id);
    Task<bool> ChangeUserStatusAsync(int id, bool isActive);
    Task<bool> ResetPasswordAsync(int id, string newPassword);
}
