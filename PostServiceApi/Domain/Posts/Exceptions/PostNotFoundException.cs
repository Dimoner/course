using Core.Logic.Base.Exceptions;

namespace Domain.Posts.Exceptions
{
    public class PostNotFoundException : NotFoundException
    {
        public PostNotFoundException(Guid postId) : base($"The post with the identifier {postId} was not found.")
        {
        }
    }
}
