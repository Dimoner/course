using Microsoft.EntityFrameworkCore;

namespace Dal.FriendRequests
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly IdentityServiceContext context;

        public FriendRequestRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(FriendRequestDal request)
        {
            var addedRequest = await context.FriendRequests.AddAsync(request);
            await context.SaveChangesAsync();

            return addedRequest.Entity.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var request = await context.FriendRequests.FindAsync(id);
            if (request == null)
                return false;

            var removedRequest = context.FriendRequests.Remove(request);
            await context.SaveChangesAsync();

            return removedRequest.State == EntityState.Deleted;
        }

        public async Task<FriendRequestDal?> GetAsync(Guid userId)
        {
            return await context.FriendRequests.FindAsync(userId);
        }

        public async Task<IEnumerable<FriendRequestDal>> GetAllAsync()
        {
            return await context.FriendRequests.ToListAsync() ?? [];
        }

        public async Task<FriendRequestDal> UpdateAsync(FriendRequestDal request)
        {
            var updatedRequest = context.FriendRequests.Update(request);
            await context.SaveChangesAsync();

            return updatedRequest.Entity;
        }
    }
}
