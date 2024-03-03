using System.ComponentModel.DataAnnotations;

namespace Application.PostLikes
{
    public record PostLikeViewModel
    {
        /// <summary>
        /// Id of the PostLike
        /// </summary>
        [Required]
        public Guid Id { get; init; }

        /// <summary>
        /// Id of the post that this like was put on
        /// </summary>
        [Required]
        public Guid PostId { get; init; }

        /// <summary>
        /// Id of the user that put this like
        /// </summary>
        [Required]
        public Guid UserId { get; init; }
    }
}
