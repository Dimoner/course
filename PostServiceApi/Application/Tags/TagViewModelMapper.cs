using Application.Interfaces;
using Domain.Tags;

namespace Application.Tags
{
    public class TagViewModelMapper : IMapper<TagViewModel, Tag>
    {
        public TagViewModel Map(Tag entity)
        {
            return new TagViewModel
            {
                Id = entity.Id,
                Value = entity.Value,
            };
        }

        public IEnumerable<TagViewModel> Map(IEnumerable<Tag> entities)
        {
            return entities.Select(Map);
        }
    }
}
