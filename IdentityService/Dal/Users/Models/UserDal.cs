using ProjectCore.Dal.Base;

namespace IdentityDal.Users.Models;

/// <summary>
/// Модель пользователя в хранилище данных
/// </summary>
public record UserDal : BaseEntityDal<Guid>
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; set; }
    
    /// <summary>
    /// Email пользователя
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Описание о себе, которое пишет пользователь
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Ссылка на изображение (аватар) пользователя
    /// </summary>
    public required string AvatarUrl { get; set; }
    
    public required string HashedPassword { get; set; }
    
    public required string HashSalt { get; set; }
    
    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public DateOnly RegisterDate { get; init; }
}