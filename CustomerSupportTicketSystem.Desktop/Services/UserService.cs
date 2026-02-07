using CustomerSupportTicketSystem.Desktop.DTOs;

namespace CustomerSupportTicketSystem.Desktop.Services;

public class UserService : ApiService
{
    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        return await GetAsync<List<UserDto>>("Users") ?? new List<UserDto>();
    }

    public async Task<UserDto?> CreateUserAsync(CreateUserDto createUserDto)
    {
        return await PostAsync<UserDto>("Users", createUserDto);
    }

    public async Task<UserDto?> UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
    {
        return await PutAsync<UserDto>($"Users/{userId}", updateUserDto);
    }

    public async Task DeleteUserAsync(int userId)
    {
        await DeleteAsync($"Users/{userId}");
    }

    public async Task ChangeUserStatusAsync(int userId, bool isActive)
    {
        var dto = new ChangeStatusDto { IsActive = isActive };
        // The API returns an object or message, we just need to know it succeeded
        // PostAsync<object> or just PostAsync void if we don't care about response body
        // The API returns OK with a message. PostAsync<T> checks success status code.
        await PostAsync($"Users/{userId}/status", dto);
    }

    public async Task ResetPasswordAsync(int userId, string newPassword)
    {
        var dto = new ResetPasswordDto { NewPassword = newPassword };
        await PostAsync($"Users/{userId}/reset-password", dto);
    }
}
