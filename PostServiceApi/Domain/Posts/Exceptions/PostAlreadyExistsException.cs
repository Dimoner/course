using Core.Logic.Base.Exceptions;

namespace Domain.Posts.Exceptions
{
    public class PostAlreadyExistsException : BadRequestException
    {
        public PostAlreadyExistsException(Guid postId) : base($"The post with the identifier {postId} already exists.")
        {
        }
    }
}
