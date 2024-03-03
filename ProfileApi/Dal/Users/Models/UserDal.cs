using ExampleCore.Dal.Base;

namespace ProfileDal.Users.Models;

/// <summary>
/// Отражение модели пользователя из хранилища данных
/// </summary>
public record UserDal : BaseEntityDal<Guid>
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public required string Login { get; set; }
    
    /// <summary>
    /// Номер телефона пользователя
    /// </summary>
    public required string Phone { get; init; }

    public void SetLogin(string login = null)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            Login = Phone;
            
            return;
        }

        Login = login;
    }
}