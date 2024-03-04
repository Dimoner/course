using Application.PostLikes.Mappers;
using Domain.PostLikes;
using Domain.PostLikes.Exceptions;

namespace Application.PostLikes.Services
{
    public sealed class PostLikeService : IPostLikeService
    {
        private readonly IPostLikeRepository postLikeRepository;
        private readonly IPostLikeViewModelMapper postLikeViewModelMapper;

        public PostLikeService(IPostLikeRepository postLikeRepository, IPostLikeViewModelMapper postLikeViewModelMapper)
        {
            this.postLikeRepository = postLikeRepository;
            this.postLikeViewModelMapper = postLikeViewModelMapper;
        }

        public async Task<Guid> CreateAsync(PostLikeViewModel viewModel)
        {
            var entity = postLikeViewModelMapper.Map(viewModel);

            return await postLikeRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await postLikeRepository.DeleteAsync(id);
        }

        public async Task<PostLikeViewModel> GetAsync(Guid id)
        {
            var entity = await postLikeRepository.GetAsync(id) ?? throw new PostLikeNotFoundException(id);
            var viewModel = postLikeViewModelMapper.Map(entity);

            return viewModel;
        }

        public async Task<IEnumerable<PostLikeViewModel>> GetPageAsync(int pageNumber, int pageSize)
        {
            var page = await postLikeRepository.GetPageAsync(pageNumber, pageSize);

            return page.Select(postLikeViewModelMapper.Map);
        }

        public async Task<IEnumerable<PostLikeViewModel>> GetPostLikesPageByPostIdAsync(Guid postId, int pageNumber, int pageSize)
        {
            var page = await postLikeRepository.GetPostLikesPageByPostIdAsync(postId, pageNumber, pageSize);

            return page.Select(postLikeViewModelMapper.Map);
        }
    }
}
