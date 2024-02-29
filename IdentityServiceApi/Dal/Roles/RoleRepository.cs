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

        public async Task<IEnumerable<RoleDal>> GetAllAsync()
        {
            return await context.Roles.ToListAsync() ?? [];
        }

        public async Task<RoleDal> UpdateAsync(RoleDal role)
        {
            var updatedRole = context.Roles.Update(role);
            await context.SaveChangesAsync();

            return updatedRole.Entity;
        }
    }
}
