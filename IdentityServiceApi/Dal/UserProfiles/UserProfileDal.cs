using Core.Dal.Base;

namespace Dal.UserProfiles
{
    public record UserProfileDal : BaseEntity
    {
        public Guid UserId { get; init; }
        public string? Status { get; init; }
        public DateTime? BirthDate { get; init; }
        public string AvatarUrl { get; init; } = null!;
    }
}
