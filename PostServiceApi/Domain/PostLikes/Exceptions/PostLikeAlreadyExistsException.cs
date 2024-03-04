using Core.Logic.Base.Exceptions;

namespace Domain.PostLikes.Exceptions
{
    public class PostLikeAlreadyExistsException : BadRequestException
    {
        public PostLikeAlreadyExistsException(Guid postLikeId) : base($"The post like with the identifier {postLikeId} already exists.")
        {
        }
    }
}
