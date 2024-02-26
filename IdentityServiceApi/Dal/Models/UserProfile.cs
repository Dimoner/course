using Core.Dal.Base;

namespace Dal.Models
{
    public record UserProfile: BaseEntity
    {
        public string? Status { get; init; }
        public DateTime? BirthDate { get; init; }
        public string AvatarUrl { get; init; } = null!;
    }
}
