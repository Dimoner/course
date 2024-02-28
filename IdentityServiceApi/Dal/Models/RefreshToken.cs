using Core.Dal.Base;

namespace Dal.Models
{
    public record RefreshToken:BaseEntity
    {
        public Guid UserId { get; init; }
        public string Token { get; init; } = null!;
        public DateTime ExpiresAt { get; init; }
    }
}
