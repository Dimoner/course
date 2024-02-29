using Core.Dal.Base;
using Dal.RefreshTokens;
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

        public async Task<Guid> CreateAsync(FriendshipDal friendship)
        {
            if (friendship.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            var entity = friendship with { Id = id };
            await context.Friendships.AddAsync(entity);
            await context.SaveChangesAsync();

            return id;
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

        public async Task<FriendshipDal?> GetByUserIdAsync(Guid userId)
        {
            return await context.Friendships.FindAsync(userId);
        }

        public async Task<PageList<FriendshipDal>> GetPageAsync(int pageNumber, int pageSize)
        {
            var count = context.Friendships.Count();
            var friendships = await context.Friendships
                .OrderBy(friendship => friendship.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<FriendshipDal>(friendships, count, pageNumber, pageSize);
        }

        public async Task<FriendshipDal> UpdateAsync(FriendshipDal friendship)
        {
            var updatedFriendship = context.Friendships.Update(friendship);
            await context.SaveChangesAsync();

            return updatedFriendship.Entity;
        }
    }
}
