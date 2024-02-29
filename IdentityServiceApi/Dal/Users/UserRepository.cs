using Microsoft.EntityFrameworkCore;

namespace Dal.Users
{
    public class UserRepository : IRepository<UserDal>
    {
        private readonly IdentityServiceContext context;

        public UserRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(UserDal user)
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

        public async Task<UserDal?> Get(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<UserDal>> GetAll()
        {
            return await context.Users.ToListAsync() ?? [];
        }

        public async Task<UserDal> Update(UserDal user)
        {
            var updatedUser = context.Users.Update(user);
            await context.SaveChangesAsync();

            return updatedUser.Entity;
        }
    }
}
