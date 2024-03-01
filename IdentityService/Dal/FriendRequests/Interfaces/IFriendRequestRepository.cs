using IdentityDal.FriendRequests.Models;

namespace IdentityDal.FriendRequests.Interfaces;

public interface IFriendRequestRepository
{
    Task<FriendRequestDal> CreateFriendRequestAsync(Guid senderId, Guid recipientId, Guid notificationId);

    Task DeleteFriendRequestAsync(Guid senderId, Guid recipientId);

    Task<ICollection<FriendRequestDal>> GetAllFriendRequestsByUserId(Guid userId);

    Task<FriendRequestDal> GetRequestInfo(Guid senderId, Guid recipientId);
}