using IdentityLogic.Users.Models;

namespace IdentityLogic.FriendRequests.Models;

public class FriendRequestLogic
{
    public required Guid SenderUserId { get; init; }
    
    public required Guid RecipientUserId { get; init; }
    
    public required DateTime CreatedDate { get; init; }
    
    /// <summary>
    /// Уникальный идентификатор уведомления, которое создаётся с запросом на добавление в друзья
    /// </summary>
    public required Guid NotificationId { get; init; }
}