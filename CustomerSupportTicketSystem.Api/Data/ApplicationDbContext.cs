using Microsoft.EntityFrameworkCore;
using CustomerSupportTicketSystem.API.Models;

namespace CustomerSupportTicketSystem.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketStatusHistory> TicketStatusHistories { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User entity configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasIndex(e => e.TicketNumber).IsUnique();

            //relationships
            entity.HasOne(t => t.CreatedBy)
                .WithMany(u => u.CreatedTickets)
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.AssignedToAdmin)
                .WithMany(u => u.AssignedTickets)
                .HasForeignKey(t => t.AssignedToAdminId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // TicketStatusHistory entity configuration
        modelBuilder.Entity<TicketStatusHistory>(entity =>
        {
            entity.HasOne(h => h.Ticket)
                .WithMany(t => t.StatusHistory)
                .HasForeignKey(h => h.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(h => h.ChangedBy)
                .WithMany(u => u.StatusChanges)
                .HasForeignKey(h => h.ChangedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // TicketComment entity configuration
        modelBuilder.Entity<TicketComment>(entity =>
        {
            entity.HasOne(c => c.Ticket)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(c => c.CreatedBy)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
