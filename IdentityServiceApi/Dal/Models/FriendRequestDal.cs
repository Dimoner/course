using Core.Dal.Base;

namespace Dal.Models
{
    public record FriendRequestDal: BaseEntity
    {
        public Guid SenderUserId { get; init; }
        public Guid ReceiverUserId { get; init; }
        public FriendRequestStatus Status { get; init; }
    }
}
