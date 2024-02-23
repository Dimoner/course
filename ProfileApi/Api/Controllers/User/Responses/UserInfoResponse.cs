namespace ProfileApi.Controllers.User.Responses;

public record UserInfoResponse
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Login { get; init; }
    
    public required string Phone { get; init; }
}