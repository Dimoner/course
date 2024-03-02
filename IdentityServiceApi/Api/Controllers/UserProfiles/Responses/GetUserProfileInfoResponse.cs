namespace Api.Controllers.UserProfiles.Responses
{
    public class GetUserProfileInfoResponse
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public string? Status { get; init; }
        public DateTime? BirthDate { get; init; }
        public string AvatarUrl { get; init; } = null!;
    }
}
