using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupportTicketSystem.API.Models;

public class TicketComment
{
    [Key]
    public int CommentId { get; set; }

    [Required]
    public int TicketId { get; set; }

    [Required]
    public string CommentText { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public int CreatedByUserId { get; set; }

    public bool IsInternal { get; set; } = false; // Admin-only comments

    // Navigation properties
    [ForeignKey("TicketId")]
    public virtual Ticket? Ticket { get; set; }

    [ForeignKey("CreatedByUserId")]
    public virtual User? CreatedBy { get; set; }
}
