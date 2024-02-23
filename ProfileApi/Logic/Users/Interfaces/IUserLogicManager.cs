using ProfileLogic.Users.Models;

namespace ProfileLogic.Users.Interfaces;

/// <summary>
/// Работа с пользователем
/// </summary>
public interface IUserLogicManager
{
    /// <summary>
    /// Получить имя пользователю по его уникальному идентификатору
    /// </summary>
    Task<string> GetUserNameAsync(Guid userId);

    /// <summary>
    /// Создать пользователя 
    /// </summary>
    Task<Guid> CreateUserAsync(UserLogic user);
}

