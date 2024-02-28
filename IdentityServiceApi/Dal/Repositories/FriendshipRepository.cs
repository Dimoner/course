using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class FriendshipRepository: IRepository<FriendshipDal>
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

        public async Task<bool> Delete(Guid id)
        {
            var friendship = await context.Friendships.FindAsync(id);
            if (friendship == null)
                return false;

            var removedFriendship = context.Friendships.Remove(friendship);
            await context.SaveChangesAsync();

            return removedFriendship.State == EntityState.Deleted;
        }

        public async Task<FriendshipDal?> Get(Guid id)
        {
            return await context.Friendships.FindAsync(id);
        }

        public async Task<FriendshipDal> Update(FriendshipDal friendship)
        {
            var updatedFriendship = context.Friendships.Update(friendship);
            await context.SaveChangesAsync();

            return updatedFriendship.Entity;
        }
    }
}
