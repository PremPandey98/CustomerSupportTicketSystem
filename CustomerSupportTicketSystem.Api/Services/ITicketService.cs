using CustomerSupportTicketSystem.API.DTOs;
using CustomerSupportTicketSystem.API.Models;

namespace CustomerSupportTicketSystem.API.Services;

public interface ITicketService
{
    Task<TicketDetailsDto> CreateTicketAsync(CreateTicketDto createDto, int userId);
    Task<List<TicketListItemDto>> GetTicketListAsync(int userId, string userRole);
    Task<TicketDetailsDto?> GetTicketDetailsAsync(int ticketId, int userId, string userRole);
    Task<bool> AssignTicketAsync(int ticketId, AssignTicketDto assignDto, int adminUserId);
    Task<bool> UpdateTicketStatusAsync(int ticketId, UpdateStatusDto statusDto, int adminUserId);
    Task<bool> AddCommentAsync(int ticketId, AddCommentDto commentDto, int userId, string userRole);
    Task<List<UserListItemDto>> GetAdminUsersAsync();
}
