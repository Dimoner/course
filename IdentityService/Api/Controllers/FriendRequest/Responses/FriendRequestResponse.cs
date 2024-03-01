using IdentityApi.Controllers.User.Responses;

namespace IdentityApi.Controllers.FriendRequest.Responses;

/// <summary>
/// Заявка на добавления в друзья
/// </summary>
public class FriendRequestResponse
{
    public required ProfileInfoResponse SenderProfile { get; init; }
    
    public required ProfileInfoResponse RecipientProfile { get; set; }
    
    public required DateTime CreatedDate { get; init; }
}