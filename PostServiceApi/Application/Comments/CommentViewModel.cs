using System.ComponentModel.DataAnnotations;

namespace Application.Comments
{
    public record CommentViewModel
    {
        /// <summary>
        /// Id of the comment
        /// </summary>
        [Required]
        public Guid Id { get; init; }

        /// <summary>
        /// Id of the user that created this comment
        /// </summary>
        [Required]
        public Guid UserId { get; init; }

        /// <summary>
        /// Id of the post to which this comment refers
        /// </summary>
        [Required]
        public Guid PostId { get; init; }

        /// <summary>
        /// Content of this comment
        /// </summary>
        [Required]
        [MinLength(1)]
        public string Content { get; init; } = null!;

        /// <summary>
        /// The date and time of the comment creation
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// The date and time of the comment last update
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; init; }
    }
}
