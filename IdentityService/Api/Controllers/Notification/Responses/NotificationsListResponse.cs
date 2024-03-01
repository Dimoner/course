namespace IdentityApi.Controllers.Notification.Responses;

public class NotificationsListResponse
{
    /// <summary>
    /// Id пользователя, которому пришли уведомления
    /// </summary>
    public required Guid UserId { get; init; }

    public required NotificationInfoResponse[] NotificationsList;
}