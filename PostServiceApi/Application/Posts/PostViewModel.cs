using Application.Tags;
using System.ComponentModel.DataAnnotations;

namespace Application.Posts
{
    public record PostViewModel
    {
        /// <summary>
        /// Id of the post
        /// </summary>
        [Required]
        public Guid Id { get; init; }

        /// <summary>
        /// Id of the user that created this post
        /// </summary>
        [Required]
        public Guid UserId { get; init; }

        /// <summary>
        /// Post content: text/images/videos etc
        /// </summary>
        [Required]
        public string Content { get; init; } = null!;

        /// <summary>
        /// Amount of likes on the post
        /// </summary>
        [Required]
        public int LikesCount { get; init; }

        /// <summary>
        /// Amount of comments on the post
        /// </summary>
        [Required]
        public int CommentsCount { get; init; }

        /// <summary>
        /// The date and time when the post was created
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; init; }

        /// <summary>
        /// The date and time when the post was last updated
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; init; }

        /// <summary>
        /// The tags that were asigned to the post
        /// </summary>
        [Required]
        public ICollection<TagViewModel> Tags { get; init; } = null!;
    }
}
