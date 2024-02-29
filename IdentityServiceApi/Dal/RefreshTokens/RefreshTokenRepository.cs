using Microsoft.EntityFrameworkCore;

namespace Dal.RefreshTokens
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IdentityServiceContext context;

        public RefreshTokenRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(RefreshToken token)
        {
            var addedToken = await context.RefreshTokens.AddAsync(token);
            await context.SaveChangesAsync();

            return addedToken.State == EntityState.Added;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var token = await context.RefreshTokens.FindAsync(id);
            if (token == null)
                return false;

            var removedToken = context.RefreshTokens.Remove(token);
            await context.SaveChangesAsync();

            return removedToken.State == EntityState.Deleted;
        }

        public async Task<RefreshToken?> GetAsync(Guid id)
        {
            return await context.RefreshTokens.FindAsync(id);
        }

        public async Task<IEnumerable<RefreshToken>> GetAllAsync()
        {
            return await context.RefreshTokens.ToListAsync() ?? [];
        }

        public async Task<RefreshToken> UpdateAsync(RefreshToken token)
        {
            var updatedToken = context.RefreshTokens.Update(token);
            await context.SaveChangesAsync();

            return updatedToken.Entity;
        }
    }
}
