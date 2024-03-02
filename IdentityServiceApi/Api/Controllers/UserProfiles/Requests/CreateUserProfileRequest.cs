using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.UserProfiles.Requests
{
    public class CreateUserProfileRequest
    {
        [Required]
        public Guid UserId { get; init; }
        
        [Required]
        public string? Status { get; init; }

        [Required]
        public DateTime? BirthDate { get; init; }

        [Required]
        [Url]
        public string AvatarUrl { get; init; } = null!;
    }
}
