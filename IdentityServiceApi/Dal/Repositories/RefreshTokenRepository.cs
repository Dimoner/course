using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class RefreshTokenRepository: IRepository<RefreshToken>
    {
        private readonly IdentityServiceContext context;

        public RefreshTokenRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(RefreshToken token)
        {
            var addedToken = await context.RefreshTokens.AddAsync(token);
            await context.SaveChangesAsync();

            return addedToken.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid id)
        {
            var token = await context.RefreshTokens.FindAsync(id);
            if (token == null)
                return false;

            var removedToken = context.RefreshTokens.Remove(token);
            await context.SaveChangesAsync();

            return removedToken.State == EntityState.Deleted;
        }

        public async Task<RefreshToken?> Get(Guid id)
        {
            return await context.RefreshTokens.FindAsync(id);
        }

        public async Task<IEnumerable<RefreshToken>> GetAll()
        {
            return await context.RefreshTokens.ToListAsync() ?? [];
        }

        public async Task<RefreshToken> Update(RefreshToken token)
        {
            var updatedToken = context.RefreshTokens.Update(token);
            await context.SaveChangesAsync();

            return updatedToken.Entity;
        }
    }
}
