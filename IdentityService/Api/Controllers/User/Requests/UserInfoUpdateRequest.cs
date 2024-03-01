namespace IdentityApi.Controllers.User.Requests;

/// <summary>
/// Изменение данных пользователя
/// </summary>
public class UserInfoUpdateRequest
{
    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; init; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; init; }

    /// <summary>
    /// Описание о себе, которое пишет пользователь
    /// </summary>
    public string? Description { get; init; }
    
    /// <summary>
    /// Ссылка на изображение (аватар) пользователя
    /// </summary>
    public required string AvatarUrl { get; init; }
}