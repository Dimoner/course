using Dal.FriendRequests;
using Dal.Friendships;
using Dal.RefreshTokens;
using Dal.Rights;
using Dal.Roles;
using Dal.Sessions;
using Dal.UserProfiles;
using Dal.Users;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class IdentityServiceContext: DbContext
    {
        public DbSet<UserDal> Users { get; set; } = null!;
        public DbSet<UserProfileDal> UserProfiles { get; set; } = null!;
        public DbSet<FriendshipDal> Friendships { get; set; } = null!;
        public DbSet<RoleDal> Roles { get; set; } = null!;
        public DbSet<SessionDal> Sessions { get; set; } = null!;
        public DbSet<RightDal> Rights { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public DbSet<FriendRequestDal> FriendRequests { get; set; } = null!;
        public IdentityServiceContext(DbContextOptions<IdentityServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
