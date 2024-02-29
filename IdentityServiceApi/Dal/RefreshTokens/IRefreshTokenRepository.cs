using Dal.Sessions;

namespace Dal.RefreshTokens
{
    public interface IRefreshTokenRepository: IRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByUserIdAsync(Guid id);
    }
}
