using Application.Interfaces;
using Domain.PostLikes;

namespace Application.PostLikes.Mappers
{
    internal sealed class PostLikeViewModelMapper : IPostLikeViewModelMapper
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
    }
}
