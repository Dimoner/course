namespace Logic.UserProfiles.Models
{
    public record UserProfileLogic
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public string? Status { get; init; }
        public DateTime? BirthDate { get; init; }
        public string AvatarUrl { get; init; } = null!;
    }
}
