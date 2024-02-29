using Dal.UserProfiles;

namespace Dal.Sessions
{
    public interface ISessionRepository: IRepository<SessionDal>
    {
        Task<SessionDal?> GetByUserIdAsync(Guid id);
    }
}
