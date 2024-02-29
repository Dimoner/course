using Logic.Users.Models;

namespace Logic.Users.Managers
{
    public interface IUserLogicManager
    {
        Task<UserLogic> GetUserAsync(Guid userId);
        Task<IEnumerable<UserLogic>> GetAllUsersAsync();
        Task<Guid> CreateUserAsync(UserLogic user);
        Task<bool> DeleteUserAsync(Guid userId);
        Task<UserLogic> UpdateUserAsync(UserLogic user);
    }
}
