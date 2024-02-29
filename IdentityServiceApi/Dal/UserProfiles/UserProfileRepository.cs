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

        public async Task<Guid> CreateAsync(UserProfileDal profile)
        {
            if (profile.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            var entity = profile with { Id = id };
            await context.UserProfiles.AddAsync(entity);
            await context.SaveChangesAsync();

            return id;
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
