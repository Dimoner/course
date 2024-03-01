namespace IdentityApi.Controllers.FriendRequest.Requests;

public class FriendRequestInfoRequest
{
    public required Guid SenderUserId { get; init; }
    
    public required Guid RecipientUserId { get; init; }
}