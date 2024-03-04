using Application.Tags.Mappers;
using Domain.Tags;
using Domain.Tags.Exceptions;

namespace Application.Tags.Services
{
    public sealed class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        private readonly ITagViewModelMapper tagViewModelMapper;

        public TagService(ITagRepository tagRepository, ITagViewModelMapper tagViewModelMapper)
        {
            this.tagRepository = tagRepository;
            this.tagViewModelMapper = tagViewModelMapper;
        }

        public async Task<Guid> CreateAsync(TagViewModel viewModel)
        {
            var entity = tagViewModelMapper.Map(viewModel);

            return await tagRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await tagRepository.DeleteAsync(id);
        }

        public async Task<TagViewModel> GetAsync(Guid id)
        {
            var entity = await tagRepository.GetAsync(id) ?? throw new TagNotFoundException(id);
            var viewModel = tagViewModelMapper.Map(entity);

            return viewModel;
        }

        public async Task<IEnumerable<TagViewModel>> GetPageAsync(int pageNumber, int pageSize)
        {
            var page = await tagRepository.GetPageAsync(pageNumber, pageSize);

            return page.Select(tagViewModelMapper.Map);
        }
    }
}
