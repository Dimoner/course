using Microsoft.EntityFrameworkCore;
using System.Data;

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
            if (right.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            var entity = right with { Id = id };
            await context.Rights.AddAsync(entity);
            await context.SaveChangesAsync();

            return id;
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
