using IdentityLogic.Users.Models;

namespace IdentityApi.Controllers.User.Responses;

/// <summary>
/// Базовая информация о любом пользователе
/// </summary>
public class ProfileInfoResponse
{
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; init; }

    /// <summary>
    /// Описание о себе, которое пишет пользователь
    /// </summary>
    public required string? Description { get; init; }
    
    /// <summary>
    /// Ссылка на изображение (аватар) пользователя
    /// </summary>
    public required string AvatarUrl { get; init; }
    
    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public required DateOnly RegisterDate { get; init; }
    
    /// <summary>
    /// Список друзей пользователя
    /// </summary>
    public required ICollection<UserLogic> Friends { get; init; } 
}