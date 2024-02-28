using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class FriendRequestRepository: IRepository<FriendRequestDal>
    {
        private readonly IdentityServiceContext context;

        public FriendRequestRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(FriendRequestDal request)
        {
            var addedRequest = await context.FriendRequests.AddAsync(request);
            await context.SaveChangesAsync();

            return addedRequest.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid id)
        {
            var request = await context.FriendRequests.FindAsync(id);
            if (request == null)
                return false;

            var removedRequest = context.FriendRequests.Remove(request);
            await context.SaveChangesAsync();

            return removedRequest.State == EntityState.Deleted;
        }

        public async Task<FriendRequestDal?> Get(Guid userId)
        {
            return await context.FriendRequests.FindAsync(userId);
        }

        public async Task<FriendRequestDal> Update(FriendRequestDal request)
        {
            var updatedRequest = context.FriendRequests.Update(request);
            await context.SaveChangesAsync();

            return updatedRequest.Entity;
        }
    }
}
