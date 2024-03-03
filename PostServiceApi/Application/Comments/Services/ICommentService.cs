using Application.Interfaces.Services;

namespace Application.Comments.Services
{
    public interface ICommentService : 
        ICreateService<CommentViewModel>,
        IUpdateService<CommentViewModel>,
        IDeleteService<CommentViewModel>,
        IGetPageService<CommentViewModel>,
        IGetService<CommentViewModel>
    {
        Task<IEnumerable<CommentViewModel>> GetPostComments(Guid postId);
    }
}
