namespace IdentityDal.FriendRequests.Models;

/// <summary>
/// Запрос, находящийся в ожидании, на добавления в друзья от одного пользователя другому
/// </summary>
public class FriendRequestDal
{
    public required Guid SenderId { get; init; }
    
    public required Guid RecipientId { get; init; }
    
    public required DateTime CreatedDate { get; init; }
    
    /// <summary>
    /// Уникальный идентификатор уведомления, которое создаётся с запросом на добавление в друзья
    /// </summary>
    public required Guid NotificationId { get; init; }
}