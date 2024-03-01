namespace IdentityApi.Controllers.FriendRequest.Requests;

/// <summary>
/// Создание запроса на добваления в друзья
/// </summary>
public class CreateFriendRequestRequest
{
    public Guid SenderUserId { get; init; }
    
    public Guid RecipientUserId { get; init; }
}