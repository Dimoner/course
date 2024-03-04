using Application.Posts.Mappers;
using Domain.Posts;
using Domain.Posts.Exceptions;

namespace Application.Posts.Services
{
    public sealed class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IPostViewModelMapper postMapper;

        public PostService(IPostRepository postRepository, IPostViewModelMapper postMapper)
        {
            this.postRepository = postRepository;
            this.postMapper = postMapper;
        }

        public async Task<Guid> CreateAsync(PostViewModel viewModel)
        {
            var entity = postMapper.Map(viewModel);

            return await postRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await postRepository.DeleteAsync(id);
        }

        public async Task<PostViewModel> GetAsync(Guid id)
        {
            var entity = await postRepository.GetAsync(id) ?? throw new PostNotFoundException(id);
            var viewModel = postMapper.Map(entity);

            return viewModel;
        }

        public async Task<IEnumerable<PostViewModel>> GetPageAsync(int pageNumber, int pageSize)
        {
            var page = await postRepository.GetPageAsync(pageNumber, pageSize);

            return page.Select(postMapper.Map);
        }

        public async Task UpdateAsync(PostViewModel viewModel)
        {
            if(await postRepository.GetAsync(viewModel.Id) is null)
                throw new PostNotFoundException(viewModel.Id);

            var entity = postMapper.Map(viewModel);
            await postRepository.UpdateAsync(entity);
        }
    }
}
