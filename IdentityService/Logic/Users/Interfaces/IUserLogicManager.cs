using IdentityLogic.Users.Models;

namespace IdentityLogic.Users.Interfaces;

/// <summary>
/// Работа с пользователем
/// </summary>
public interface IUserLogicManager
{
    /// <summary>
    /// Получить информацию о пользователе по его уникальному идентификатору
    /// </summary>
    Task<UserLogic> GetUserInfoAsync(Guid userId);
    
    /// <summary>
    /// Получить информацию о пользователе по его имени пользователя
    /// </summary>
    Task<UserLogic> GetUserInfoAsync(string username);

    /// <summary>
    /// Получить список друзей пользователя по его уникальному идентификатору
    /// </summary>
    Task<ICollection<UserLogic>> GetUserFriendsAsync(Guid userId);
    
    /// <summary>
    /// Создать пользователя 
    /// </summary>
    Task<Guid> CreateUserAsync(string email, string username, string password);

    Task DeleteUserAsync(Guid userId);
    
    Task<UserLogic> UpdateUserAsync(Guid userId, UserUpdateLogic updatedInfo);

    Task MakeUsersFriendsAsync(Guid userId1, Guid userId2);
}

