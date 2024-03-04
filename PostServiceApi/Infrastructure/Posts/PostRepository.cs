using Core.Dal.Base;
using Domain.Posts;
using Domain.Posts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Posts
{
    public sealed class PostRepository : IPostRepository
    {
        private PostServiceContext context;

        public PostRepository(PostServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(Post entity)
        {
            if (entity.Id != Guid.Empty)
                throw new PostAlreadyExistsException(entity.Id);

            var id = Guid.NewGuid();
            var post = entity with { Id = id };
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();

            return id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Posts.FindAsync(id) ?? throw new PostNotFoundException(id);

            context.Posts.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Post> GetAsync(Guid id)
        {
            var entity = await context.Posts.FindAsync(id) ?? throw new PostNotFoundException(id);

            return entity;
        }

        public async Task<PageList<Post>> GetPageAsync(int pageNumber, int pageSize)
        {
            var count = context.Posts.Count();
            var posts = await context.Posts
                .OrderBy(post => post.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<Post>(posts, count, pageNumber, pageSize);
        }

        public async Task UpdateAsync(Post entity)
        {
            context.Posts.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
