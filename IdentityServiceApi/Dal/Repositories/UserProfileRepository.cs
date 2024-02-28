using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class UserProfileRepository : IRepository<UserProfileDal>
    {
        private readonly IdentityServiceContext context;

        public UserProfileRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(UserProfileDal profile)
        {
            var addedProfile = await context.UserProfiles.AddAsync(profile);
            await context.SaveChangesAsync();

            return addedProfile.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid id)
        {
            var profile = await context.UserProfiles.FindAsync(id);
            if (profile == null)
                return false;

            var removedProfile = context.UserProfiles.Remove(profile);
            await context.SaveChangesAsync();

            return removedProfile.State == EntityState.Deleted;
        }

        public async Task<UserProfileDal?> Get(Guid id)
        {
            return await context.UserProfiles.FindAsync(id);
        }

        public async Task<UserProfileDal> Update(UserProfileDal profile)
        {
            var updatedProfile = context.UserProfiles.Update(profile);
            await context.SaveChangesAsync();

            return updatedProfile.Entity;
        }
    }
}
