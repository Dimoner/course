using Core.Dal.Base;
using Domain.PostLikes;
using Domain.PostLikes.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PostLikes
{
    public sealed class PostLikeRepository : IPostLikeRepository
    {
        private PostServiceContext context;

        public PostLikeRepository(PostServiceContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateAsync(PostLike entity)
        {
            if (entity.Id != Guid.Empty)
                throw new PostLikeAlreadyExistsException(entity.Id);

            var id = Guid.NewGuid();
            var postLike = entity with { Id = id };
            await context.PostLikes.AddAsync(postLike);
            await context.SaveChangesAsync();

            return id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.PostLikes.FindAsync(id) ?? throw new PostLikeNotFoundException(id);

            context.PostLikes.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<PostLike> GetAsync(Guid id)
        {
            var entity = await context.PostLikes.FindAsync(id) ?? throw new PostLikeNotFoundException(id);

            return entity;
        }

        public async Task<PageList<PostLike>> GetPageAsync(int pageNumber, int pageSize)
        {
            var count = context.PostLikes.Count();
            var postLikes = await context.PostLikes
                .OrderBy(posLike => posLike.PostId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<PostLike>(postLikes, count, pageNumber, pageSize);
        }

        public async Task<PageList<PostLike>> GetPostLikesPageByPostIdAsync(Guid postId, int pageNumber, int pageSize)
        {
            var count = context.PostLikes.Count();
            var postLikes = await context.PostLikes
                .Where(postLike => postLike.PostId == postId)
                .OrderBy(posLike => posLike.PostId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<PostLike>(postLikes, count, pageNumber, pageSize);
        }

        public async Task UpdateAsync(PostLike entity)
        {
            context.PostLikes.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
