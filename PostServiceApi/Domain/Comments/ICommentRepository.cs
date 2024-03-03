using Core.Dal.Base;
using Domain.Interfaces;

namespace Domain.Comments
{
    public interface ICommentRepository : IRepository<Comment>
    {
        /// <summary>
        /// Get list of Comments that refer to 
        /// a certain Post which is decided by Post id
        /// </summary>
        Task<PageList<Comment>> GetCommentsPageByPostIdAsync(Guid postId);
    }
}
