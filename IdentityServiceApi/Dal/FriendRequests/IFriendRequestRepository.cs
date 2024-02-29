using Dal.Friendships;

namespace Dal.FriendRequests
{
    public interface IFriendRequestRepository: IRepository<FriendRequestDal>
    {
        Task<FriendRequestDal?> GetByUserIdAsync(Guid id);
    }
}
