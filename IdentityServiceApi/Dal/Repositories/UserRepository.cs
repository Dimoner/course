using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IdentityServiceContext context;
        public UserRepository(IdentityServiceContext context) 
        { 
            this.context = context;
        }
        public async Task<bool> Create(User user)
        {
            var addedUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return addedUser.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
                return false;
            var removedUser = context.Users.Remove(user);
            await context.SaveChangesAsync();

            return removedUser.State == EntityState.Deleted;
        }

        public async Task<User?> Get(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> Update(User user)
        {
            var updatedUser = context.Users.Update(user);
            await context.SaveChangesAsync();
            
            return updatedUser.Entity;
        }
    }
}
