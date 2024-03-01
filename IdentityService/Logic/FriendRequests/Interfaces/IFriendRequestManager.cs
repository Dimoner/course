using IdentityLogic.FriendRequests.Models;

namespace IdentityLogic.FriendRequests.Interfaces;

public interface IFriendRequestManager
{
    Task<FriendRequestLogic> CreateFriendRequest(Guid senderId, Guid recipientId);

    Task DeleteFriendRequest(Guid senderId, Guid recipientId);

    Task AcceptFriendRequest(Guid senderId, Guid recipientId);

    Task<ICollection<FriendRequestLogic>> GetAllRequests(Guid userId);

}