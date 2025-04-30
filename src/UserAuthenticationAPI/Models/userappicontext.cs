using Microsoft.EntityFrameworkCore;
using UserAuthenticationAPI.Models;

namespace UserAuthenticationApi.Models
{


    public class UserAppiContext : DbContext
    {
        public UserAppiContext(DbContextOptions<UserAppiContext> options)
            : base(options)
        {
        }


        public DbSet<User> User { get; set; }
    }
}
