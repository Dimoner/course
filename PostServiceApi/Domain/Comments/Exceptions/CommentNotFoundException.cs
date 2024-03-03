using Core.Logic.Base.Exceptions;

namespace Domain.Comments.Exceptions
{
    public class CommentNotFoundException : NotFoundException
    {
        public CommentNotFoundException(Guid commentId) :
            base($"The comment with the identifier {commentId} was not found.")
        {
        }
    }
}
