using Logic.UserProfiles.Models;

namespace Logic.UserProfiles.Managers
{
    public interface IUserProfileLogicManager
    {
        Task<UserProfileLogic> GetUserProfileAsync(Guid userId);
        Task<IEnumerable<UserProfileLogic>> GetAllUsersProfilesAsync();
        Task<Guid> CreateUserProfileAsync(UserProfileLogic user);
        Task<bool> DeleteUserProfileAsync(Guid userId);
        Task<UserProfileLogic> UpdateUserProfileAsync(UserProfileLogic user);
    }
}
