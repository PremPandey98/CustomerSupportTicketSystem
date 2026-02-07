using System.ComponentModel.DataAnnotations;

namespace CustomerSupportTicketSystem.API.DTOs;

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

public class AssignTicketDto
{
    [Required]
    public int AssignedToAdminId { get; set; }
}

public class UpdateStatusDto
{
    [Required]
    public string NewStatus { get; set; } = string.Empty; // "Open", "In Progress", "Closed"
    
    public string? Comment { get; set; }
}

public class AddCommentDto
{
    [Required]
    public string CommentText { get; set; } = string.Empty;
    
    public bool IsInternal { get; set; } = false;
}

public class TicketCommentDto
{
    public int CommentId { get; set; }
    public string CommentText { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public bool IsInternal { get; set; }
}

public class TicketHistoryDto
{
    public int HistoryId { get; set; }
    public string? OldStatus { get; set; }
    public string NewStatus { get; set; } = string.Empty;
    public DateTime ChangedDate { get; set; }
    public string ChangedBy { get; set; } = string.Empty;
    public string? Comment { get; set; }
}

public class UserListItemDto
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
