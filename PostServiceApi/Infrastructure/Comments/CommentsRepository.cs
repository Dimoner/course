using Core.Dal.Base;
using Domain.Comments;
using Domain.Comments.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Comments
{
    internal sealed class CommentsRepository : ICommentRepository
    {
        private readonly PostServiceContext context;

        public CommentsRepository(PostServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(Comment entity)
        {
            if (entity.Id != Guid.Empty)
                throw new CommentAlreadyExistsException(entity.Id);

            var id = Guid.NewGuid();
            var comment = entity with { Id = id };
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            return id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Comments.FindAsync(id) ?? throw new CommentNotFoundException(id);

            context.Comments.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Comment> GetAsync(Guid id)
        {
            var entity = await context.Comments.FindAsync(id) ?? throw new CommentNotFoundException(id);

            return entity;
        }

        public Task<PageList<Comment>> GetCommentsPageByPostIdAsync(Guid postId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<PageList<Comment>> GetPageAsync(int pageNumber, int pageSize)
        {
            var count = context.Comments.Count();
            var comments = await context.Comments
                .OrderBy(comment => comment.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<Comment>(comments, count, pageNumber, pageSize);
        }

        public async Task UpdateAsync(Comment entity)
        {
            context.Comments.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
