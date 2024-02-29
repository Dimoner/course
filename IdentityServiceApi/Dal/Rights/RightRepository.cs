using Microsoft.EntityFrameworkCore;

namespace Dal.Rights
{
    public class RightRepository : IRightRepository
    {
        private readonly IdentityServiceContext context;

        public RightRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(RightDal right)
        {
            var addedRight = await context.Rights.AddAsync(right);
            await context.SaveChangesAsync();

            return addedRight.Entity.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var right = await context.Rights.FindAsync(id);
            if (right == null)
                return false;

            var removedRight = context.Rights.Remove(right);
            await context.SaveChangesAsync();

            return removedRight.State == EntityState.Deleted;
        }

        public async Task<RightDal?> GetAsync(Guid id)
        {
            return await context.Rights.FindAsync(id);
        }

        public async Task<IEnumerable<RightDal>> GetAllAsync()
        {
            return await context.Rights.ToListAsync() ?? [];
        }

        public async Task<RightDal> UpdateAsync(RightDal right)
        {
            var updatedRight = context.Rights.Update(right);
            await context.SaveChangesAsync();

            return updatedRight.Entity;
        }
    }
}
