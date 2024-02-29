using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class RoleRepository: IRepository<RoleDal>
    {
        private readonly IdentityServiceContext context;

        public RoleRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(RoleDal role)
        {
            var addedRole = await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();

            return addedRole.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null)
                return false;

            var removedRole = context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return removedRole.State == EntityState.Deleted;
        }

        public async Task<RoleDal?> Get(Guid userId)
        {
            return await context.Roles.FindAsync(userId);
        }

        public async Task<IEnumerable<RoleDal>> GetAll()
        {
            return await context.Roles.ToListAsync() ?? [];
        }

        public async Task<RoleDal> Update(RoleDal role)
        {
            var updatedRole = context.Roles.Update(role);
            await context.SaveChangesAsync();

            return updatedRole.Entity;
        }
    }
}
