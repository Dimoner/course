using ProfileDal.Users.Models;

namespace ProfileDal.Users.Interfaces;

/// <summary>
/// Хранение пользователя
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// получить по имени 
    /// </summary>
    Task<string> GetUserNameAsync(Guid userId);
    
    /// <summary>
    /// Создать пользователя
    /// </summary>
    Task<Guid> CreateUserAsync(UserDal user);
}


