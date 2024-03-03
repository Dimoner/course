
using Application.Comments.Mappers;
using Core.Dal.Base;
using Domain.Comments;
using Domain.Comments.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Application.Comments.Services
{
    internal sealed class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly ICommentViewModelMapper commentViewModelMapper;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<Guid> CreateAsync(CommentViewModel viewModel)
        {
            var entity =  commentViewModelMapper.Map(viewModel);

            return await commentRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await commentRepository.DeleteAsync(id);
        }

        public async Task<CommentViewModel> GetAsync(Guid id)
        {
            var entity =  await commentRepository.GetAsync(id) ?? throw new CommentNotFoundException(id);
            var viewModel = commentViewModelMapper.Map(entity);

            return viewModel;
        }

        public async Task<IEnumerable<CommentViewModel>> GetPageAsync(int pageNumber, int pageSize)
        {
            var page = await commentRepository.GetPageAsync(pageNumber, pageSize);

            return page.Select(commentViewModelMapper.Map);
        }

        public async Task<IEnumerable<CommentViewModel>> GetCommentsPageByPostIdAsync(Guid postId, int pageNumber, int pageSize)
        {
            var comments = await commentRepository.GetCommentsPageByPostIdAsync(postId, pageNumber, pageSize);

            return comments.Select(commentViewModelMapper.Map);
        }

        public async Task UpdateAsync(CommentViewModel viewModel)
        {
            if (await commentRepository.GetAsync(viewModel.Id) is null)
                throw new CommentNotFoundException(viewModel.Id);

            var entity = commentViewModelMapper.Map(viewModel);
            await commentRepository.UpdateAsync(entity);
        }
    }
}
