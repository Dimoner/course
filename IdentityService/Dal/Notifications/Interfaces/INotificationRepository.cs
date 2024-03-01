using IdentityDal.Notifications.Models;

namespace IdentityDal.Notifications.Interfaces;

public interface INotificationRepository
{
    /// <summary>
    /// Получить все уведомления пользователя
    /// </summary>
    /// <param name="userId">Id пользователя</param>
    /// <param name="onlyNew">Если true, то возвращаются только те уведомления, которые не были прочитаны пользователем</param>
    Task<NotificationDal[]> GetUserNotificationsAsync(Guid userId, bool onlyNew = false);

    /// <summary>
    /// Пометить уведомления с указанным уникальными идентификаторами как прочитанные
    /// </summary>
    Task MarkNotificationsAsReadAsync(params Guid[] notificationsIds);

    Task DeleteNotificationAsync(Guid notificationId);

    Task<Guid> CreateNewNotificationAsync(NotificationDal notification);
}