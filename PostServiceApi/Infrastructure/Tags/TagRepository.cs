using Core.Dal.Base;
using Domain.Tags;
using Domain.Tags.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tags
{
    internal sealed class TagRepository : ITagRepository
    {
        private PostServiceContext context;

        public TagRepository(PostServiceContext context)
        {
            this.context = context;
        }
        public async Task<Guid> CreateAsync(Tag entity)
        {
            if (entity.Id != Guid.Empty)
                throw new TagAlreadyExistsException(entity.Id);

            var id = Guid.NewGuid();
            var tag = entity with { Id = id };
            await context.Tags.AddAsync(tag);
            await context.SaveChangesAsync();

            return id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Tags.FindAsync(id) ?? throw new TagNotFoundException(id);

            context.Tags.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Tag> GetAsync(Guid id)
        {
            var entity = await context.Tags.FindAsync(id) ?? throw new TagNotFoundException(id);

            return entity;
        }

        public async Task<PageList<Tag>> GetPageAsync(int pageNumber, int pageSize)
        {
            var count = context.Tags.Count();
            var tags = await context.Tags
                .OrderBy(tag => tag.Value)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageList<Tag>(tags, count, pageNumber, pageSize);
        }

        public async Task UpdateAsync(Tag entity)
        {
            context.Tags.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
