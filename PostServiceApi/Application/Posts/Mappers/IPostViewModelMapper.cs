using Application.Interfaces;
using Domain.Posts;

namespace Application.Posts.Mappers
{
    internal interface IPostViewModelMapper : IMapper<PostViewModel, Post>
    {
    }
}
