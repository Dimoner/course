using Application.Interfaces;
using Domain.Comments;

namespace Application.Comments
{
    public class CommentViewModelMapper : IMapper<CommentViewModel, Comment>
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
    }
}
