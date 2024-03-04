using Application.Interfaces;
using Domain.Posts;

namespace Application.Posts.Mappers
{
    public interface IPostViewModelMapper : IMapper<PostViewModel, Post>
    {
    }
}
