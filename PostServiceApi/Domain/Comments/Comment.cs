using Core.Dal.Base;

namespace Domain.Comments
{
    public record Comment : BaseEntity
    {
        /// <summary>
        /// Id of the user that created this comment
        /// </summary>
        public Guid UserId { get; init; }

        /// <summary>
        /// Id of the post to which this comment refers
        /// </summary>
        public Guid PostId { get; init; }

        /// <summary>
        /// Content of this comment
        /// </summary>
        public string Content { get; init; } = null!;

        /// <summary>
        /// The date and time of the comment creation
        /// </summary>
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// The date and time of the comment last update
        /// </summary>
        public DateTime UpdatedAt { get; init; }
    }
}
