using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (session.Id != Guid.Empty)
                throw new InvalidOperationException();

            var id = Guid.NewGuid();
            var entity = session with { Id = id };
            await context.Sessions.AddAsync(entity);
            await context.SaveChangesAsync();

            return id;
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

        public async Task<SessionDal?> GetByUserIdAsync(Guid id)
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
