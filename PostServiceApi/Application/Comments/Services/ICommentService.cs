using Application.Interfaces.Services;
using Core.Dal.Base;

namespace Application.Comments.Services
{
    public interface ICommentService : 
        ICreateService<CommentViewModel>,
        IUpdateService<CommentViewModel>,
        IDeleteService<CommentViewModel>,
        IGetPageService<CommentViewModel>,
        IGetService<CommentViewModel>
    {
        Task<IEnumerable<CommentViewModel>> GetCommentsPageByPostIdAsync(Guid postId, int pageNumber, int pageSize);
    }
}
