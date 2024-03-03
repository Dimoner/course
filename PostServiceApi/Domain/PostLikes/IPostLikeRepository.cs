using Core.Dal.Base;
using Domain.Interfaces;

namespace Domain.PostLikes
{
    public interface IPostLikeRepository : IRepository<PostLike>
    {
        /// <summary>
        /// Get list of PostLikes that refer to 
        /// a certain Post which is decided by Post id
        /// </summary>
        Task<PageList<PostLike>> GetPostLikesPageByPostIdAsync(Guid postId);
    }
}
