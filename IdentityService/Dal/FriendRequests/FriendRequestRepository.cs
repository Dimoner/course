using IdentityDal.FriendRequests.Interfaces;
using IdentityDal.FriendRequests.Models;
using IdentityDal.Users.Interfaces;

namespace IdentityDal.FriendRequests;

public class FriendRequestRepository : IFriendRequestRepository
{
    private static readonly List<FriendRequestDal> Store = new();
    
    public async Task<FriendRequestDal> CreateFriendRequestAsync(Guid senderId, Guid recipientId, Guid notificationId)
    {
        var model = new FriendRequestDal
        {
            SenderId = senderId,
            RecipientId = recipientId,
            CreatedDate = DateTime.Now,
            NotificationId = notificationId
        };
        Store.Add(model);
        return model;
    }

    public async Task DeleteFriendRequestAsync(Guid senderId, Guid recipientId)
    {
        var model = Store.FirstOrDefault(r => r.SenderId == senderId && r.RecipientId == recipientId);
        if (model != null)
        {
            Store.Remove(model);
            return;
        }

        throw new Exception("Запрос не найден");
    }

    public async Task<ICollection<FriendRequestDal>> GetAllFriendRequestsByUserId(Guid userId)
    {
        var result = Store.Where(r => r.SenderId == userId || r.RecipientId == userId);
        return result.ToList();
    }

    public async Task<FriendRequestDal> GetRequestInfo(Guid senderId, Guid recipientId)
    {
        var result = Store.FirstOrDefault(r => r.SenderId == senderId && r.RecipientId == recipientId);
        if (result == null)
        {
            throw new Exception("Запрос не найден");
        }

        return result;
    }
}