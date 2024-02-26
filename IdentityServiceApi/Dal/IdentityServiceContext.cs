using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class IdentityServiceContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public IdentityServiceContext(DbContextOptions<IdentityServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
