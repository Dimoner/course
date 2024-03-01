namespace IdentityApi.Controllers.User.Requests;

public record CreateUserRequest
{
    public required string Username { get; init; }
    
    public required string Email { get; init; }
    
    public required string Password { get; init; }
}