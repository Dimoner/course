using Application.Interfaces.Services;

namespace Application.Tags.Services
{
    public interface ITagService :
        ICreateService<TagViewModel>,
        IDeleteService<TagViewModel>,
        IGetPageService<TagViewModel>,
        IGetService<TagViewModel>
    {
    }
}
