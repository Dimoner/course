using Microsoft.EntityFrameworkCore;

namespace Dal.Friendships
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly IdentityServiceContext context;

        public FriendshipRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(FriendshipDal friendship)
        {
            var addedFriendship = await context.Friendships.AddAsync(friendship);
            await context.SaveChangesAsync();

            return addedFriendship.State == EntityState.Added;
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            var friendship = await context.Friendships.FindAsync(userId);
            if (friendship == null)
                return false;

            var removedFriendship = context.Friendships.Remove(friendship);
            await context.SaveChangesAsync();

            return removedFriendship.State == EntityState.Deleted;
        }

        public async Task<FriendshipDal?> GetAsync(Guid userId)
        {
            return await context.Friendships.FindAsync(userId);
        }

        public async Task<IEnumerable<FriendshipDal>> GetAllAsync()
        {
            return await context.Friendships.ToListAsync() ?? [];
        }

        public async Task<FriendshipDal> UpdateAsync(FriendshipDal friendship)
        {
            var updatedFriendship = context.Friendships.Update(friendship);
            await context.SaveChangesAsync();

            return updatedFriendship.Entity;
        }
    }
}
