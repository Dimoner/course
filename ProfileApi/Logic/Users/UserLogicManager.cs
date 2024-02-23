using ProfileDal.Users.Interfaces;
using ProfileDal.Users.Models;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileLogic.Users;

/// <inheritdoc />
internal class UserLogicManager : IUserLogicManager
{
    private readonly IUserRepository _userRepository;

    public UserLogicManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <inheritdoc />
    public async Task<string> GetUserNameAsync(Guid userId)
    {
        return await _userRepository.GetUserNameAsync(userId);
    }

    /// <inheritdoc />
    public async Task<Guid> CreateUserAsync(UserLogic user)
    {
        return await _userRepository.CreateUserAsync(new UserDal
        {
            Name = user.Name,
            Login = user.Login,
            Phone = user.Phone
        });
    }
}