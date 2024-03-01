namespace IdentityApi.Controllers.User.Requests;

public class PasswordChangeRequest
{
    public required string NewPassword { get; init; }
}