namespace IdentityApi.Controllers.User.Requests;

/// <summary>
/// Запрос на авторизацию пользователя
/// </summary>
public class AuthorizeRequest
{
    public required string Email { get; init; }
    
    public required string Password { get; init; }
}