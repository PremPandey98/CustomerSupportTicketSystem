using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupportTicketSystem.API.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }

    [Required]
    [MaxLength(20)]
    public string TicketNumber { get; set; } = string.Empty; // Auto-generated: TKT-000001

    [Required]
    [MaxLength(200)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Priority { get; set; } = "Medium"; // "Low", "Medium", "High"

    [Required]
    [MaxLength(20)]
    public string Status { get; set; } = "Open"; // "Open", "In Progress", "Closed"

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    [Required]
    public int CreatedByUserId { get; set; }

    public int? AssignedToAdminId { get; set; }

    // Navigation properties
    [ForeignKey("CreatedByUserId")]
    public virtual User? CreatedBy { get; set; }

    [ForeignKey("AssignedToAdminId")]
    public virtual User? AssignedToAdmin { get; set; }

    public virtual ICollection<TicketStatusHistory> StatusHistory { get; set; } = new List<TicketStatusHistory>();
    public virtual ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
}
