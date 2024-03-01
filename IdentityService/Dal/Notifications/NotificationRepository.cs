using System.Collections.Concurrent;
using IdentityDal.Notifications.Interfaces;
using IdentityDal.Notifications.Models;

namespace IdentityDal.Notifications;

public class NotificationRepository : INotificationRepository
{
    private readonly ConcurrentDictionary<Guid, NotificationDal> _store = new();
    
    public async Task<NotificationDal[]> GetUserNotificationsAsync(Guid userId, bool onlyNew = false)
    {
        return _store.Where(kvPair => kvPair.Value.UserId == userId && !(onlyNew && kvPair.Value.WasRead))
            .Select(kvPair => kvPair.Value)
            .ToArray();
    }

    public async Task MarkNotificationsAsReadAsync(params Guid[] notificationsIds)
    {
        foreach (var id in notificationsIds)
        {
            _store[id].WasRead = true;
        }
    }

    public async Task DeleteNotificationAsync(Guid notificationId)
    {
        if (!_store.TryRemove(notificationId, out var _))
        {
            throw new Exception("Уведомление не найдено");
        }
    }

    public async Task<Guid> CreateNewNotificationAsync(NotificationDal notification)
    {
        if (!_store.TryAdd(notification.Id, notification))
        {
            throw new Exception("Уведомление уже было создано ранее");
        }
        return notification.Id;
    }
}