using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupportTicketSystem.API.Models;

public class TicketStatusHistory
{
    [Key]
    public int HistoryId { get; set; }

    [Required]
    public int TicketId { get; set; }

    [MaxLength(20)]
    public string? OldStatus { get; set; }

    [Required]
    [MaxLength(20)]
    public string NewStatus { get; set; } = string.Empty;

    public DateTime ChangedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public int ChangedByUserId { get; set; }

    public string? Comment { get; set; }

    // Navigation properties
    [ForeignKey("TicketId")]
    public virtual Ticket? Ticket { get; set; }

    [ForeignKey("ChangedByUserId")]
    public virtual User? ChangedBy { get; set; }
}
