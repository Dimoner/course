using Domain.PostLikes;

namespace Application.PostLikes.Mappers
{
    public sealed class PostLikeViewModelMapper : IPostLikeViewModelMapper
    {
        public PostLikeViewModel Map(PostLike entity)
        {
            return new PostLikeViewModel
            {
                Id = entity.Id,
                PostId = entity.PostId,
                UserId = entity.UserId,
            };
        }

        public IEnumerable<PostLikeViewModel> Map(IEnumerable<PostLike> entities)
        {
            return entities.Select(Map);
        }

        public IEnumerable<PostLike> Map(IEnumerable<PostLikeViewModel> viewModels)
        {
           return viewModels.Select(Map);
        }

        public PostLike Map(PostLikeViewModel viewModel)
        {
            return new PostLike
            {
                Id = viewModel.Id,
                PostId = viewModel.PostId,
                UserId = viewModel.UserId,
            };
        }
    }
}
