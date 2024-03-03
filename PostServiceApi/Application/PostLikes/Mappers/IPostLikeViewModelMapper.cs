using Application.Interfaces;
using Domain.PostLikes;

namespace Application.PostLikes.Mappers
{
    public interface IPostLikeViewModelMapper : IMapper<PostLikeViewModel, PostLike>
    {
    }
}
