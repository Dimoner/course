using Microsoft.EntityFrameworkCore;

namespace Dal.Rights
{
    public class RightRepository : IRepository<RightDal>
    {
        private readonly IdentityServiceContext context;

        public RightRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(RightDal right)
        {
            var addedRight = await context.Rights.AddAsync(right);
            await context.SaveChangesAsync();

            return addedRight.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid id)
        {
            var right = await context.Rights.FindAsync(id);
            if (right == null)
                return false;

            var removedRight = context.Rights.Remove(right);
            await context.SaveChangesAsync();

            return removedRight.State == EntityState.Deleted;
        }

        public async Task<RightDal?> Get(Guid id)
        {
            return await context.Rights.FindAsync(id);
        }

        public async Task<IEnumerable<RightDal>> GetAll()
        {
            return await context.Rights.ToListAsync() ?? [];
        }

        public async Task<RightDal> Update(RightDal right)
        {
            var updatedRight = context.Rights.Update(right);
            await context.SaveChangesAsync();

            return updatedRight.Entity;
        }
    }
}
