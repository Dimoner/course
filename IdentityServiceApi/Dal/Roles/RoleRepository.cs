using Core.Dal.Base;
using Dal.Sessions;
using Microsoft.EntityFrameworkCore;

namespace Dal.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IdentityServiceContext context;

        public RoleRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(RoleDal role)
        {
            if (role.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            var entity = role with { Id = id };
            await context.Roles.AddAsync(entity);
            await context.SaveChangesAsync();

            return id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null)
                return false;

            var removedRole = context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return removedRole.State == EntityState.Deleted;
        }

        public async Task<RoleDal?> GetAsync(Guid userId)
        {
            return await context.Roles.FindAsync(userId);
        }

        public async Task<PageList<RoleDal>> GetPageAsync(int pageNumber, int pageSize)
        {
            var count = context.Roles.Count();
            var roles = await context.Roles
                .OrderBy(role => role.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<RoleDal>(roles, count, pageNumber, pageSize);
        }

        public async Task<RoleDal> UpdateAsync(RoleDal role)
        {
            var updatedRole = context.Roles.Update(role);
            await context.SaveChangesAsync();

            return updatedRole.Entity;
        }
    }
}
