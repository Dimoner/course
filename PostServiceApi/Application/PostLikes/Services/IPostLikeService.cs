using Application.Comments;
using Application.Interfaces.Services;
using Domain.PostLikes;

namespace Application.PostLikes.Services
{
    public interface IPostLikeService :
        ICreateService<PostLikeViewModel>,
        IDeleteService<PostLikeViewModel>,
        IGetPageService<PostLikeViewModel>,
        IGetService<PostLikeViewModel>
    {
        Task<IEnumerable<PostLikeViewModel>> GetPostLikesPageByPostIdAsync(Guid postId, int pageNumber, int pageSize);
    }
}
