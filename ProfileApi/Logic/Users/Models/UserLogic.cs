namespace ProfileLogic.Users.Models;

/// <summary>
/// Модель пользователя для слоя Logic 
/// </summary>
public class UserLogic
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public required string Login { get; init; }
    
    /// <summary>
    /// Номер телефона пользователя
    /// </summary>
    public required string Phone { get; init; }
}