namespace IdentityApi.Controllers.User.Responses;

/// <summary>
/// Информация о себе
/// </summary>
public class UserInfoResponse : ProfileInfoResponse
{
    /// <summary>
    /// Email пользователя
    /// </summary>
    public required string Email { get; init; }
}