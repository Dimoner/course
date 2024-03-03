using Application.Interfaces;
using Domain.Comments;

namespace Application.Comments.Mappers
{
    internal sealed class CommentViewModelMapper : ICommentViewModelMapper
    {
        public CommentViewModel Map(Comment entity)
        {
            return new CommentViewModel
            {
                Id = entity.Id,
                UserId = entity.UserId,
                PostId = entity.PostId,
                Content = entity.Content,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public IEnumerable<CommentViewModel> Map(IEnumerable<Comment> entities)
        {
            return entities.Select(Map);
        }

        public IEnumerable<Comment> Map(IEnumerable<CommentViewModel> viewModels)
        {
            return viewModels.Select(Map);
        }

        public Comment Map(CommentViewModel viewModel)
        {
            return new Comment
            {
                Id = viewModel.Id,
                UserId = viewModel.UserId,
                PostId = viewModel.PostId,
                Content = viewModel.Content,
                CreatedAt = viewModel.CreatedAt,
                UpdatedAt = viewModel.UpdatedAt
            };
        }
    }
}
