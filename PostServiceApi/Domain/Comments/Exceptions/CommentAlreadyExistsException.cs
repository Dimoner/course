using Core.Logic.Base.Exceptions;
using System.ComponentModel.Design;

namespace Domain.Comments.Exceptions
{
    public class CommentAlreadyExistsException : BadRequestException
    {
        public CommentAlreadyExistsException(Guid commentId) : base($"The comment with the identifier {commentId} already exists.")
        {
        }
    }
}
