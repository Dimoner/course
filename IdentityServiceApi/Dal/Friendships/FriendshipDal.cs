using Core.Dal.Base;

namespace Dal.Friendships
{
    public record FriendshipDal: BaseEntity
    {
        public Guid UserId1 { get; init; }
        public Guid UserId2 { get; init; }
    }
}
