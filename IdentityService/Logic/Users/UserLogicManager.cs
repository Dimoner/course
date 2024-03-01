using IdentityDal.Users.Interfaces;
using IdentityDal.Users.Models;
using IdentityLogic.Users.Interfaces;
using IdentityLogic.Users.Models;

namespace IdentityLogic.Users;

/// <inheritdoc />
internal class UserLogicManager : IUserLogicManager
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;

    public UserLogicManager(IUserRepository userRepository, IPasswordManager passwordManager)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
    }

    public async Task<UserLogic> GetUserInfoAsync(Guid userId)
    {
        var userDal = await _userRepository.GetUserByIdAsync(userId);
        return new UserLogic
        {
            Username = userDal.Username,
            Email = userDal.Email,
            Description = userDal.Description,
            Id = userId,
            AvatarUrl = userDal.AvatarUrl,
            RegisterDate = userDal.RegisterDate,
            HashedPassword = userDal.HashedPassword
        };
    }
    
    public async Task<UserLogic> GetUserInfoAsync(string username)
    {
        var userDal = await _userRepository.GetUserByUsernameAsync(username);
        return new UserLogic
        {
            Username = userDal.Username,
            Email = userDal.Email,
            Description = userDal.Description,
            Id = userDal.Id,
            AvatarUrl = userDal.AvatarUrl,
            RegisterDate = userDal.RegisterDate,
            HashedPassword = userDal.HashedPassword
        };
    }

    public async Task<ICollection<UserLogic>> GetUserFriendsAsync(Guid userId)
    {
        var friends = await _userRepository.GetUserFriendsAsync(userId);
        var result = friends.Select(u => new UserLogic
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email,
            Description = u.Description,
            AvatarUrl = u.AvatarUrl,
            RegisterDate = u.RegisterDate,
            HashedPassword = u.HashedPassword
        });
        return result.ToList();
    }

    public async Task<Guid> CreateUserAsync(string email, string username, string password)
    {
        var salt = _passwordManager.GenerateSalt();
        var hashedPassword = _passwordManager.HashPassword(password, salt);
        var res = await _userRepository.CreateUserAsync(new UserDal
        {
            Username = username,
            Email = email,
            AvatarUrl = "images/defaultAvatar.jpg",
            RegisterDate = DateOnly.FromDateTime(DateTime.Now),
            HashedPassword = hashedPassword,
            HashSalt = salt,
            Id = Guid.NewGuid()
        });
        return res;
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        await _userRepository.DeleteUserAsync(userId);
    }

    public async Task<UserLogic> UpdateUserAsync(Guid userId, UserUpdateLogic updatedInfo)
    {
        var dalModel = new UserDal
        {
            Username = updatedInfo.Username,
            Email = updatedInfo.Email,
            AvatarUrl = updatedInfo.AvatarUrl,
            Description = updatedInfo.Description,
            HashedPassword = null,
            HashSalt = null,
            Id = userId
        };
        var updatedDal = await _userRepository.UpdateUser(dalModel);
        return new UserLogic()
        {
            Id = updatedDal.Id,
            Username = updatedDal.Username,
            Email = updatedDal.Email,
            Description = updatedDal.Description,
            AvatarUrl = updatedDal.AvatarUrl,
            RegisterDate = updatedDal.RegisterDate,
            HashedPassword = updatedDal.HashedPassword
        };
    }

    public async Task MakeUsersFriendsAsync(Guid userId1, Guid userId2)
    {
        await _userRepository.MakeUsersFriendsAsync(userId1, userId2);
    }
}