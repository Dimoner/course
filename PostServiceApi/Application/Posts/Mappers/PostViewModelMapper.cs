using Application.Interfaces;
using Application.Tags;
using Application.Tags.Mappers;
using Domain.Posts;
using Domain.Tags;

namespace Application.Posts.Mappers
{
    public class PostViewModelMapper : IPostViewModelMapper
    {
        private readonly ITagViewModelMapper tagMapper;

        public PostViewModelMapper(ITagViewModelMapper tagMapper)
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

        public IEnumerable<Post> Map(IEnumerable<PostViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Post Map(PostViewModel viewModel)
        {
            var mappedTagViewModels = tagMapper.Map(viewModel.Tags).ToArray();

            return new Post
            {
                Id = viewModel.Id,
                UserId = viewModel.UserId,
                Content = viewModel.Content,
                LikesCount = viewModel.LikesCount,
                CommentsCount = viewModel.CommentsCount,
                CreatedAt = viewModel.CreatedAt,
                UpdatedAt = viewModel.UpdatedAt,
                Tags = mappedTagViewModels
            };
        }
    }
}
