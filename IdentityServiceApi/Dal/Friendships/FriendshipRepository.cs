using Microsoft.EntityFrameworkCore;

namespace Dal.Friendships
{
    public class FriendshipRepository : IRepository<FriendshipDal>
    {
        private readonly IdentityServiceContext context;

        public FriendshipRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(FriendshipDal friendship)
        {
            var addedFriendship = await context.Friendships.AddAsync(friendship);
            await context.SaveChangesAsync();

            return addedFriendship.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid userId)
        {
            var friendship = await context.Friendships.FindAsync(userId);
            if (friendship == null)
                return false;

            var removedFriendship = context.Friendships.Remove(friendship);
            await context.SaveChangesAsync();

            return removedFriendship.State == EntityState.Deleted;
        }

        public async Task<FriendshipDal?> Get(Guid userId)
        {
            return await context.Friendships.FindAsync(userId);
        }

        public async Task<IEnumerable<FriendshipDal>> GetAll()
        {
            return await context.Friendships.ToListAsync() ?? [];
        }

        public async Task<FriendshipDal> Update(FriendshipDal friendship)
        {
            var updatedFriendship = context.Friendships.Update(friendship);
            await context.SaveChangesAsync();

            return updatedFriendship.Entity;
        }
    }
}
