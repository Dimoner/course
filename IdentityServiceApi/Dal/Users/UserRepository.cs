using Microsoft.EntityFrameworkCore;

namespace Dal.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityServiceContext context;

        public UserRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(UserDal user)
        {
            var addedUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return addedUser.Entity.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
                return false;

            var removedUser = context.Users.Remove(user);
            await context.SaveChangesAsync();

            return removedUser.State == EntityState.Deleted;
        }

        public async Task<UserDal?> GetAsync(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<UserDal>> GetAllAsync()
        {
            return await context.Users.ToListAsync() ?? [];
        }

        public async Task<UserDal> UpdateAsync(UserDal user)
        {
            var updatedUser = context.Users.Update(user);
            await context.SaveChangesAsync();

            return updatedUser.Entity;
        }
    }
}
