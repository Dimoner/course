using Application.Interfaces;
using Domain.Comments;

namespace Application.Comments.Mappers
{
    public interface ICommentViewModelMapper : IMapper<CommentViewModel, Comment>
    {
    }
}
