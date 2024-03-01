using ProjectCore.Api.Responses;

namespace IdentityApi.Controllers.User.Responses;

public class CreateUserResponse
{
    public required Guid? Id { get; init; }
}