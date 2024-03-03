using Application.Interfaces;
using Domain.PostLikes;

namespace Application.PostLikes
{
    public class PostLikeViewModelMapper : IMapper<PostLikeViewModel, PostLike>
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
