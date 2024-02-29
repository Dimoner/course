using Microsoft.EntityFrameworkCore;

namespace Dal.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IdentityServiceContext context;

        public SessionRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(SessionDal session)
        {
            var addedSession = await context.Sessions.AddAsync(session);
            await context.SaveChangesAsync();

            return addedSession.Entity.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var session = await context.Sessions.FindAsync(id);
            if (session == null)
                return false;

            var removedSession = context.Sessions.Remove(session);
            await context.SaveChangesAsync();

            return removedSession.State == EntityState.Deleted;
        }

        public async Task<SessionDal?> GetAsync(Guid id)
        {
            return await context.Sessions.FindAsync(id);
        }

        public async Task<IEnumerable<SessionDal>> GetAllAsync()
        {
            return await context.Sessions.ToListAsync() ?? [];
        }

        public async Task<SessionDal> UpdateAsync(SessionDal session)
        {
            var updatedSession = context.Sessions.Update(session);
            await context.SaveChangesAsync();

            return updatedSession.Entity;
        }
    }
}
