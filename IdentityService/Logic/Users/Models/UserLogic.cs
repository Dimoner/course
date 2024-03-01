namespace IdentityLogic.Users.Models;

/// <summary>
/// Модель пользователя для слоя Logic 
/// </summary>
public class UserLogic
{
    public required Guid Id { get; init; }
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; set; }
    
    /// <summary>
    /// Логин пользователя
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Описание о себе, которое пишет пользователь
    /// </summary>
    public required string? Description { get; set; }

    /// <summary>
    /// Ссылка на изображение (аватар) пользователя
    /// </summary>
    public required string AvatarUrl { get; set; } = "images/defaultAvatar.jpg";
    
    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public required DateOnly RegisterDate { get; init; }
    
    public required string HashedPassword { get; set; }
}