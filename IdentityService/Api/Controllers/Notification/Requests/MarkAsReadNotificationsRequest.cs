namespace IdentityApi.Controllers.Notification.Requests;

public class MarkAsReadNotificationsRequest
{
    public required Guid[] NotificationsIds { get; init; }
}