using Application.Interfaces.Services;

namespace Application.Posts.Services
{
    public interface IPostService :
        ICreateService<PostViewModel>,
        IUpdateService<PostViewModel>,
        IDeleteService<PostViewModel>,
        IGetPageService<PostViewModel>,
        IGetService<PostViewModel>
    {
    }
}
