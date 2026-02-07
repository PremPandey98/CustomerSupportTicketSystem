using Microsoft.EntityFrameworkCore;
using CustomerSupportTicketSystem.API.Data;
using CustomerSupportTicketSystem.API.DTOs;
using CustomerSupportTicketSystem.API.Models;

namespace CustomerSupportTicketSystem.API.Services;

public class TicketService : ITicketService
{
    private readonly ApplicationDbContext _context;

    public TicketService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TicketDetailsDto> CreateTicketAsync(CreateTicketDto createDto, int userId)
    {
        // Validate priority
        if (!IsValidPriority(createDto.Priority))
            throw new ArgumentException("Invalid priority. Must be Low, Medium, or High.");

        // Generate ticket number
        var ticketNumber = await GenerateTicketNumberAsync();

        var ticket = new Ticket
        {
            TicketNumber = ticketNumber,
            Subject = createDto.Subject,
            Description = createDto.Description,
            Priority = createDto.Priority,
            Status = "Open",
            CreatedDate = DateTime.UtcNow,
            CreatedByUserId = userId
        };

        _context.Tickets.Add(ticket);
        
        // Save ticket first to get the TicketId
        await _context.SaveChangesAsync();

        // Add initial status history (now ticket.TicketId has a value)
        var history = new TicketStatusHistory
        {
            TicketId = ticket.TicketId,
            OldStatus = null,
            NewStatus = "Open",
            ChangedDate = DateTime.UtcNow,
            ChangedByUserId = userId,
            Comment = "Ticket created"
        };

        _context.TicketStatusHistories.Add(history);
        await _context.SaveChangesAsync();

        // Reload ticket with user information
        var createdTicket = await _context.Tickets
            .Include(t => t.CreatedBy)
            .Include(t => t.AssignedToAdmin)
            .Include(t => t.Comments).ThenInclude(c => c.CreatedBy)
            .Include(t => t.StatusHistory).ThenInclude(h => h.ChangedBy)
            .FirstOrDefaultAsync(t => t.TicketId == ticket.TicketId);

        return MapToTicketDetailsDto(createdTicket!);
    }

    public async Task<List<TicketListItemDto>> GetTicketListAsync(int userId, string userRole)
    {
        IQueryable<Ticket> query = _context.Tickets
            .Include(t => t.CreatedBy)
            .Include(t => t.AssignedToAdmin);

        // Role-based filtering
        if (userRole != "Admin")
        {
            // Users see only their tickets
            query = query.Where(t => t.CreatedByUserId == userId);
        }

        var tickets = await query
            .OrderByDescending(t => t.CreatedDate)
            .ToListAsync();

        return tickets.Select(t => new TicketListItemDto
        {
            TicketId = t.TicketId,
            TicketNumber = t.TicketNumber,
            Subject = t.Subject,
            Priority = t.Priority,
            Status = t.Status,
            CreatedDate = t.CreatedDate,
            AssignedTo = t.AssignedToAdmin?.FullName,
            CreatedBy = t.CreatedBy?.FullName ?? "Unknown"
        }).ToList();
    }

    public async Task<TicketDetailsDto?> GetTicketDetailsAsync(int ticketId, int userId, string userRole)
    {
        var ticket = await _context.Tickets
            .Include(t => t.CreatedBy)
            .Include(t => t.AssignedToAdmin)
            .Include(t => t.Comments).ThenInclude(c => c.CreatedBy)
            .Include(t => t.StatusHistory).ThenInclude(h => h.ChangedBy)
            .FirstOrDefaultAsync(t => t.TicketId == ticketId);

        if (ticket == null)
            return null;

        // Check access permissions
        if (userRole != "Admin" && ticket.CreatedByUserId != userId)
            return null; // User can only view their own tickets

        var ticketDto = MapToTicketDetailsDto(ticket);

        // Filter internal comments for non-admins
        if (userRole != "Admin")
        {
            ticketDto.Comments = ticketDto.Comments.Where(c => !c.IsInternal).ToList();
        }

        return ticketDto;
    }

    public async Task<bool> AssignTicketAsync(int ticketId, AssignTicketDto assignDto, int adminUserId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket == null)
            throw new KeyNotFoundException("Ticket not found");

        // Prevent assignment to closed tickets
        if (ticket.Status == "Closed")
            throw new InvalidOperationException("Cannot assign a closed ticket");

        // Verify admin user exists
        var adminUser = await _context.Users.FindAsync(assignDto.AssignedToAdminId);
        if (adminUser == null || adminUser.Role != "Admin")
            throw new ArgumentException("Invalid admin user");

        var oldAssignedTo = ticket.AssignedToAdminId;
        ticket.AssignedToAdminId = assignDto.AssignedToAdminId;

        // Log assignment in history
        var history = new TicketStatusHistory
        {
            TicketId = ticketId,
            OldStatus = ticket.Status,
            NewStatus = ticket.Status,
            ChangedDate = DateTime.UtcNow,
            ChangedByUserId = adminUserId,
            Comment = $"Ticket assigned to {adminUser.FullName}"
        };

        _context.TicketStatusHistories.Add(history);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateTicketStatusAsync(int ticketId, UpdateStatusDto statusDto, int adminUserId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket == null)
            throw new KeyNotFoundException("Ticket not found");

        // Prevent modifications to closed tickets
        if (ticket.Status == "Closed")
            throw new InvalidOperationException("Cannot modify a closed ticket");

        // Validate status
        if (!IsValidStatus(statusDto.NewStatus))
            throw new ArgumentException("Invalid status. Must be Open, In Progress, or Closed.");

        // Validate status flow
        if (!IsValidStatusTransition(ticket.Status, statusDto.NewStatus))
            throw new InvalidOperationException($"Invalid status transition from {ticket.Status} to {statusDto.NewStatus}");

        var oldStatus = ticket.Status;
        ticket.Status = statusDto.NewStatus;

        // Log status change
        var history = new TicketStatusHistory
        {
            TicketId = ticketId,
            OldStatus = oldStatus,
            NewStatus = statusDto.NewStatus,
            ChangedDate = DateTime.UtcNow,
            ChangedByUserId = adminUserId,
            Comment = statusDto.Comment ?? $"Status changed from {oldStatus} to {statusDto.NewStatus}"
        };

        _context.TicketStatusHistories.Add(history);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> AddCommentAsync(int ticketId, AddCommentDto commentDto, int userId, string userRole)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket == null)
            throw new KeyNotFoundException("Ticket not found");

        // Users can only comment on their own tickets
        if (userRole != "Admin" && ticket.CreatedByUserId != userId)
            throw new UnauthorizedAccessException("Cannot comment on this ticket");

        // Prevent comments on closed tickets
        if (ticket.Status == "Closed")
            throw new InvalidOperationException("Cannot add comments to a closed ticket");

        // Only admins can add internal comments
        if (commentDto.IsInternal && userRole != "Admin")
            throw new UnauthorizedAccessException("Only admins can add internal comments");

        var comment = new TicketComment
        {
            TicketId = ticketId,
            CommentText = commentDto.CommentText,
            CreatedDate = DateTime.UtcNow,
            CreatedByUserId = userId,
            IsInternal = commentDto.IsInternal
        };

        _context.TicketComments.Add(comment);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<UserListItemDto>> GetAdminUsersAsync()
    {
        var admins = await _context.Users
            .Where(u => u.Role == "Admin")
            .Select(u => new UserListItemDto
            {
                UserId = u.UserId,
                Username = u.Username,
                FullName = u.FullName,
                Role = u.Role
            })
            .ToListAsync();

        return admins;
    }

    // Helper methods
    private async Task<string> GenerateTicketNumberAsync()
    {
        var lastTicket = await _context.Tickets
            .OrderByDescending(t => t.TicketId)
            .FirstOrDefaultAsync();

        int nextNumber = 1;
        if (lastTicket != null)
        {
            // Extract number from last ticket (e.g., "TKT-000001" -> 1)
            var lastNumber = lastTicket.TicketNumber.Split('-').Last();
            if (int.TryParse(lastNumber, out int parsed))
            {
                nextNumber = parsed + 1;
            }
        }

        return $"TKT-{nextNumber:D6}";
    }

    private bool IsValidPriority(string priority)
    {
        return priority == "Low" || priority == "Medium" || priority == "High";
    }

    private bool IsValidStatus(string status)
    {
        return status == "Open" || status == "In Progress" || status == "Closed";
    }

    private bool IsValidStatusTransition(string currentStatus, string newStatus)
    {
        // Open -> In Progress or Closed
        if (currentStatus == "Open")
            return newStatus == "In Progress" || newStatus == "Closed";

        // In Progress -> Closed
        if (currentStatus == "In Progress")
            return newStatus == "Closed";

        // Closed -> no transitions allowed (already checked before)
        return false;
    }

    private TicketDetailsDto MapToTicketDetailsDto(Ticket ticket)
    {
        return new TicketDetailsDto
        {
            TicketId = ticket.TicketId,
            TicketNumber = ticket.TicketNumber,
            Subject = ticket.Subject,
            Description = ticket.Description,
            Priority = ticket.Priority,
            Status = ticket.Status,
            CreatedDate = ticket.CreatedDate,
            CreatedBy = ticket.CreatedBy?.FullName ?? "Unknown",
            CreatedByUserId = ticket.CreatedByUserId,
            AssignedTo = ticket.AssignedToAdmin?.FullName,
            AssignedToAdminId = ticket.AssignedToAdminId,
            Comments = ticket.Comments
                .OrderBy(c => c.CreatedDate)
                .Select(c => new TicketCommentDto
                {
                    CommentId = c.CommentId,
                    CommentText = c.CommentText,
                    CreatedDate = c.CreatedDate,
                    CreatedBy = c.CreatedBy?.FullName ?? "Unknown",
                    IsInternal = c.IsInternal
                }).ToList(),
            History = ticket.StatusHistory
                .OrderBy(h => h.ChangedDate)
                .Select(h => new TicketHistoryDto
                {
                    HistoryId = h.HistoryId,
                    OldStatus = h.OldStatus,
                    NewStatus = h.NewStatus,
                    ChangedDate = h.ChangedDate,
                    ChangedBy = h.ChangedBy?.FullName ?? "Unknown",
                    Comment = h.Comment
                }).ToList()
        };
    }
}
