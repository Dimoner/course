using IdentityDal.Users.Models;

namespace IdentityDal.Users.Interfaces;

/// <summary>
/// Хранение пользователя
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Создать пользователя
    /// </summary>
    Task<Guid> CreateUserAsync(UserDal user);

    /// <summary>
    /// Получить информацию о пользователе по Id
    /// </summary>
    Task<UserDal> GetUserByIdAsync(Guid id);

    Task<UserDal> GetUserByUsernameAsync(string username);
    
    /// <summary>
    /// Получить список друзей пользователя по Id
    /// </summary>
    Task<ICollection<UserDal>> GetUserFriendsAsync(Guid userId);

    /// <summary>
    /// Удалить пользователя по Id
    /// </summary>
    Task DeleteUserAsync(Guid userId);

    /// <summary>
    /// Обновить информацию о пользователе
    /// </summary>
    Task<UserDal> UpdateUser(UserDal updatedModel);

    Task MakeUsersFriendsAsync(Guid userId1, Guid userId2);
}


