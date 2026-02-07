using System.ComponentModel.DataAnnotations;

namespace CustomerSupportTicketSystem.Desktop.DTOs;

// Create Ticket Request
public class CreateTicketDto
{
    [Required]
    [MaxLength(200)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Priority { get; set; } = "Medium"; // "Low", "Medium", "High"
}

// Ticket List Item (for list views)
public class TicketListItemDto
{
    public int TicketId { get; set; }
    public string TicketNumber { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? AssignedTo { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}

// Ticket Details (full ticket information)
public class TicketDetailsDto
{
    public int TicketId { get; set; }
    public string TicketNumber { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public int CreatedByUserId { get; set; }
    public string? AssignedTo { get; set; }
    public int? AssignedToAdminId { get; set; }
    public List<TicketCommentDto> Comments { get; set; } = new();
    public List<TicketHistoryDto> History { get; set; } = new();
}

// Assign Ticket Request
public class AssignTicketDto
{
    [Required]
    public int AssignedToAdminId { get; set; }
}

// Update Status Request
public class UpdateStatusDto
{
    [Required]
    public string NewStatus { get; set; } = string.Empty; // "Open", "In Progress", "Closed"
    
    public string? Comment { get; set; }
}

// Add Comment Request
public class AddCommentDto
{
    [Required]
    public string CommentText { get; set; } = string.Empty;
    
    public bool IsInternal { get; set; } = false;
}

// Comment DTO
public class TicketCommentDto
{
    public int CommentId { get; set; }
    public string CommentText { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public bool IsInternal { get; set; }
}

// History DTO
public class TicketHistoryDto
{
    public int HistoryId { get; set; }
    public string? OldStatus { get; set; }
    public string NewStatus { get; set; } = string.Empty;
    public DateTime ChangedDate { get; set; }
    public string ChangedBy { get; set; } = string.Empty;
    public string? Comment { get; set; }
}

// User List Item (for admin assignment dropdowns)
public class UserListItemDto
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
