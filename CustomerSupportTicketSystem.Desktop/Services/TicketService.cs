using CustomerSupportTicketSystem.Desktop.DTOs;

namespace CustomerSupportTicketSystem.Desktop.Services;

public class TicketService : ApiService
{
    public async Task<TicketDetailsDto?> CreateTicketAsync(CreateTicketDto dto)
    {
        return await PostAsync<TicketDetailsDto>("Tickets", dto);
    }

    public async Task<List<TicketListItemDto>?> GetTicketsAsync()
    {
        return await GetAsync<List<TicketListItemDto>>("Tickets");
    }

    public async Task<TicketDetailsDto?> GetTicketDetailsAsync(int id)
    {
        return await GetAsync<TicketDetailsDto>($"Tickets/{id}");
    }

    public async Task AssignTicketAsync(int id, AssignTicketDto dto)
    {
        await PutAsync($"Tickets/{id}/assign", dto);
    }

    public async Task UpdateTicketStatusAsync(int id, UpdateStatusDto dto)
    {
        await PutAsync($"Tickets/{id}/status", dto);
    }

    public async Task AddCommentAsync(int id, AddCommentDto dto)
    {
        await PostAsync($"Tickets/{id}/comments", dto);
    }

    public async Task<List<UserListItemDto>?> GetAdminUsersAsync()
    {
        return await GetAsync<List<UserListItemDto>>("Tickets/admins");
    }
}
