using Core.Dal.Base;

namespace Domain.PostLikes
{
    public record PostLike : BaseEntity
    {
        /// <summary>
        /// Id of the post that this like was put on
        /// </summary>
        public Guid PostId { get; init; }

        /// <summary>
        /// Id of the user that put this like
        /// </summary>
        public Guid UserId { get; init; }
    }
}   