using Dal.RefreshTokens;

namespace Dal.Friendships
{
    public interface IFriendshipRepository: IRepository<FriendshipDal>
    {
        Task<FriendshipDal?> GetByUserIdAsync(Guid id);
    }
}
