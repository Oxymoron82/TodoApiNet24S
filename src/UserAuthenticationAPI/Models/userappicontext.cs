using Microsoft.EntityFrameworkCore;

namespace UserAuthenticationApi.Models;

public class UserAppiContext : DbContext
{
    public UserAppiContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; } = null!;
}