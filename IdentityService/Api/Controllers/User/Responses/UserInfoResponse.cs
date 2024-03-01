namespace IdentityApi.Controllers.User.Responses;

/// <summary>
/// Информация о себе
/// </summary>
public class UserInfoResponse : Profile2InfoResponse
{
    /// <summary>
    /// Email пользователя
    /// </summary>
    public required string Email { get; init; }
}