using CustomerSupportTicketSystem.API.Models;

namespace CustomerSupportTicketSystem.API.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        // Check if admin user exists
        if (!context.Users.Any(u => u.Role == "Admin"))
        {
            // Create default admin if not exists
            var adminUser = new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                FullName = "System Administrator",
                Email = "admin@example.com",
                Role = "Admin",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            context.Users.Add(adminUser);
            context.SaveChanges();
        }
    }
}
