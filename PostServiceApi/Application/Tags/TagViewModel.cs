using System.ComponentModel.DataAnnotations;

namespace Application.Tags
{
    public record TagViewModel
    {
        /// <summary>
        /// Id of the tag
        /// </summary>
        [Required]
        public Guid Id { get; init; }

        /// <summary>
        /// The tag's value
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Value { get; init; } = null!;
    }
}
