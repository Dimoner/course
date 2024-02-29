using Core.Dal.Base;
using Dal.Friendships;
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
            if (request.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            var entity = request with { Id = id };
            await context.FriendRequests.AddAsync(entity);
            await context.SaveChangesAsync();

            return id;
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

        public async Task<FriendRequestDal?> GetByUserIdAsync(Guid userId)
        {
            return await context.FriendRequests.FindAsync(userId);
        }

        public async Task<PageList<FriendRequestDal>> GetPageAsync(int pageNumber, int pageSize)
        {
            var count = context.FriendRequests.Count();
            var requests = await context.FriendRequests
                .OrderBy(request => request.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<FriendRequestDal>(requests, count, pageNumber, pageSize);
        }

        public async Task<FriendRequestDal> UpdateAsync(FriendRequestDal request)
        {
            var updatedRequest = context.FriendRequests.Update(request);
            await context.SaveChangesAsync();

            return updatedRequest.Entity;
        }
    }
}
