using Application.Interfaces;
using Application.Tags;
using Domain.Posts;
using Domain.Tags;

namespace Application.Posts
{
    public class PostViewModelMapper : IMapper<PostViewModel, Post>
    {
        private readonly IMapper<TagViewModel, Tag> tagMapper;

        public PostViewModelMapper(IMapper<TagViewModel, Tag> tagMapper)
        {
            this.tagMapper = tagMapper;
        }

        public PostViewModel Map(Post entity)
        {
            var mappedTags = tagMapper.Map(entity.Tags).ToArray();

            return new PostViewModel
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Content = entity.Content,
                LikesCount = entity.LikesCount,
                CommentsCount = entity.CommentsCount,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Tags = mappedTags
            };
        }

        public IEnumerable<PostViewModel> Map(IEnumerable<Post> entities)
        {
            return entities.Select(Map);
        }
    }
}
