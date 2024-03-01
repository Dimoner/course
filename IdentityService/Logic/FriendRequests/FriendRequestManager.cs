using IdentityDal.FriendRequests.Interfaces;
using IdentityDal.Users.Interfaces;
using IdentityLogic.FriendRequests.Interfaces;
using IdentityLogic.FriendRequests.Models;
using IdentityLogic.Notifications.Interfaces;
using IdentityLogic.Notifications.Models;
using IdentityLogic.Users.Interfaces;

namespace IdentityLogic.FriendRequests;

public class FriendRequestManager : IFriendRequestManager
{
    private readonly IFriendRequestRepository _friendRequestRepository;
    private readonly IUserLogicManager _userLogicManager;
    private readonly INotificationManager _notificationManager;
    
    public FriendRequestManager(IFriendRequestRepository friendRequestRepository, IUserLogicManager userLogicManager, 
        INotificationManager notificationManager)
    {
        _friendRequestRepository = friendRequestRepository;
        _userLogicManager = userLogicManager;
        _notificationManager = notificationManager;
    }
    
    public async Task<FriendRequestLogic> CreateFriendRequest(Guid senderId, Guid recipientId)
    {
        var senderUserModel = await _userLogicManager.GetUserInfoAsync(senderId);
        var notificationId = await _notificationManager.CreateNewNotificationAsync(new NotificationLogic
        {
            Id = Guid.NewGuid(),
            UserId = recipientId,
            Title = "Новый запрос в друзья",
            Content = $"Пользователь {senderUserModel.Username} хочет добавить вас в друзья.",
            WasRead = false,
            CreatedTime = DateTime.Now
        });
        
        var friendRequestDal = await _friendRequestRepository.CreateFriendRequestAsync(senderId, recipientId, notificationId);
        
        return new FriendRequestLogic
        {
            SenderUserId = friendRequestDal.SenderId,
            RecipientUserId = friendRequestDal.RecipientId,
            CreatedDate = friendRequestDal.CreatedDate,
            NotificationId = friendRequestDal.NotificationId
        };
    }

    public async Task DeleteFriendRequest(Guid senderId, Guid recipientId)
    {
        var model = await _friendRequestRepository.GetRequestInfo(senderId, recipientId);
        await _friendRequestRepository.DeleteFriendRequestAsync(senderId, recipientId);
        await _notificationManager.DeleteNotificationAsync(model.NotificationId);
    }

    public async Task AcceptFriendRequest(Guid senderId, Guid recipientId)
    {
        await _userLogicManager.MakeUsersFriendsAsync(senderId, recipientId);
        var model = await _friendRequestRepository.GetRequestInfo(senderId, recipientId);
        
        await _friendRequestRepository.DeleteFriendRequestAsync(senderId, recipientId);
        await _notificationManager.DeleteNotificationAsync(model.NotificationId);
    }

    public async Task<ICollection<FriendRequestLogic>> GetAllRequests(Guid userId)
    {
        var list = await _friendRequestRepository.GetAllFriendRequestsByUserId(userId);
        return list.Select(r => new FriendRequestLogic
        {
            SenderUserId = r.SenderId,
            RecipientUserId = r.RecipientId,
            CreatedDate = r.CreatedDate,
            NotificationId = r.NotificationId
        }).ToList();
    }
}