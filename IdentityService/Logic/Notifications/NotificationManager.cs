using IdentityDal.Notifications.Interfaces;
using IdentityDal.Notifications.Models;
using IdentityLogic.Notifications.Interfaces;
using IdentityLogic.Notifications.Models;

namespace IdentityLogic.Notifications;

public class NotificationManager : INotificationManager
{
    private readonly INotificationRepository _notificationRepository;
    
    public NotificationManager(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }
    
    public async Task<NotificationLogic[]> GetUserNotificationsAsync(Guid userId, bool onlyNew = false)
    {
        var dalModels = await _notificationRepository.GetUserNotificationsAsync(userId, onlyNew);
        return dalModels.Select(n => new NotificationLogic
        {
            Id = n.Id,
            UserId = n.UserId,
            Title = n.Title,
            Content = n.Content,
            WasRead = n.WasRead,
            CreatedTime = n.CreatedTime
        }).ToArray();
    }

    public async Task MarkNotificationsAsReadAsync(params Guid[] notificationsIds)
    {
        await _notificationRepository.MarkNotificationsAsReadAsync(notificationsIds);
    }

    public async Task DeleteNotificationAsync(Guid notificationId)
    {
        await _notificationRepository.DeleteNotificationAsync(notificationId);
    }

    public async Task<Guid> CreateNewNotificationAsync(NotificationLogic notification)
    {
        var dalModel = new NotificationDal
        {
            UserId = notification.UserId,
            Title = notification.Title,
            Content = notification.Content,
            WasRead = notification.WasRead,
            CreatedTime = notification.CreatedTime,
            Id = notification.Id
        };
        
        return await _notificationRepository.CreateNewNotificationAsync(dalModel);
    }
}