using Microsoft.EntityFrameworkCore;

namespace Dal.UserProfiles
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IdentityServiceContext context;

        public UserProfileRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(UserProfileDal profile)
        {
            var addedProfile = await context.UserProfiles.AddAsync(profile);
            await context.SaveChangesAsync();

            return addedProfile.State == EntityState.Added;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var profile = await context.UserProfiles.FindAsync(id);
            if (profile == null)
                return false;

            var removedProfile = context.UserProfiles.Remove(profile);
            await context.SaveChangesAsync();

            return removedProfile.State == EntityState.Deleted;
        }

        public async Task<UserProfileDal?> GetAsync(Guid id)
        {
            return await context.UserProfiles.FindAsync(id);
        }

        public async Task<IEnumerable<UserProfileDal>> GetAllAsync()
        {
            return await context.UserProfiles.ToListAsync() ?? [];
        }

        public async Task<UserProfileDal> UpdateAsync(UserProfileDal profile)
        {
            var updatedProfile = context.UserProfiles.Update(profile);
            await context.SaveChangesAsync();

            return updatedProfile.Entity;
        }
    }
}
