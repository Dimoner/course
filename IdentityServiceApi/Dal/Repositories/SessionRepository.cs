using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class SessionRepository: IRepository<SessionDal>
    {
        private readonly IdentityServiceContext context;

        public SessionRepository(IdentityServiceContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(SessionDal session)
        {
            var addedSession = await context.Sessions.AddAsync(session);
            await context.SaveChangesAsync();

            return addedSession.State == EntityState.Added;
        }

        public async Task<bool> Delete(Guid id)
        {
            var session = await context.Sessions.FindAsync(id);
            if (session == null)
                return false;

            var removedSession = context.Sessions.Remove(session);
            await context.SaveChangesAsync();

            return removedSession.State == EntityState.Deleted;
        }

        public async Task<SessionDal?> Get(Guid id)
        {
            return await context.Sessions.FindAsync(id);
        }

        public async Task<IEnumerable<SessionDal>> GetAll()
        {
            return await context.Sessions.ToListAsync() ?? [];
        }

        public async Task<SessionDal> Update(SessionDal session)
        {
            var updatedSession = context.Sessions.Update(session);
            await context.SaveChangesAsync();

            return updatedSession.Entity;
        }
    }
}
