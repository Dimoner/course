using Core.Logic.Base.Exceptions;

namespace Domain.PostLikes.Exceptions
{
    public class PostLikeNotFoundException : NotFoundException
    {
        public PostLikeNotFoundException(Guid postLikeId) : base($"The post like with the identifier {postLikeId} was not found.")
        {
        }
    }
}
