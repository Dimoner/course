using Dal.UserProfiles;
using Logic.UserProfiles.Models;

namespace Logic.UserProfiles.Managers
{
    public class UserProfileLogicManager : IUserProfileLogicManager
    {
        private readonly IUserProfileRepository profileRepository;

        public UserProfileLogicManager(IUserProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<Guid> CreateUserProfileAsync(UserProfileLogic profile)
        {
            return await profileRepository.CreateAsync(new UserProfileDal
            {
                AvatarUrl = profile.AvatarUrl,
                BirthDate = profile.BirthDate,
                Id = profile.Id,
                Status = profile.Status,
                UserId = profile.Id
            });
        }

        public async Task<bool> DeleteUserProfileAsync(Guid profileId)
        {
            return await profileRepository.DeleteAsync(profileId);
        }

        public async Task<IEnumerable<UserProfileLogic>> GetPageAsync(int pageNumber, int pageSize)
        {
            var profiles = await profileRepository.GetPageAsync(pageNumber, pageSize);

            return profiles.Select(profile => new UserProfileLogic
            {
                AvatarUrl = profile.AvatarUrl,
                BirthDate = profile.BirthDate,
                Id = profile.Id,
                UserId = profile.UserId,
                Status = profile.Status
            });
        }

        public async Task<UserProfileLogic> GetUserProfileAsync(Guid profileId)
        {
            var profile = await profileRepository.GetAsync(profileId);

            return profile == null
                ? new UserProfileLogic()
                : new UserProfileLogic
                {
                    AvatarUrl = profile.AvatarUrl,
                    BirthDate = profile.BirthDate,
                    Id = profile.Id,
                    Status = profile.Status,
                    UserId = profileId
                };
        }

        public async Task<UserProfileLogic> UpdateUserProfileAsync(UserProfileLogic profile)
        {
            var updatedProfile = await profileRepository.UpdateAsync(new UserProfileDal
            {
                UserId = profile.Id,
                AvatarUrl = profile.AvatarUrl,
                BirthDate = profile.BirthDate,
                Id = profile.Id,
                Status = profile.Status,
            });

            return new UserProfileLogic
            {
                AvatarUrl = updatedProfile.AvatarUrl,
                BirthDate = updatedProfile.BirthDate,
                Id = updatedProfile.Id,
                Status = updatedProfile.Status,
                UserId = updatedProfile.UserId
            };
        }
    }
}
