using Core.Dal.Base;

namespace Dal.RefreshTokens
{
    public record RefreshToken : BaseEntity
    {
        public Guid UserId { get; init; }
        public string Token { get; init; } = null!;
        public DateTime ExpiresAt { get; init; }
    }
}
