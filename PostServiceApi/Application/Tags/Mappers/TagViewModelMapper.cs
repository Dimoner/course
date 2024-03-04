using Domain.Tags;

namespace Application.Tags.Mappers
{
    public class TagViewModelMapper : ITagViewModelMapper
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

        public IEnumerable<Tag> Map(IEnumerable<TagViewModel> viewModels)
        {
            return viewModels.Select(Map);
        }

        public Tag Map(TagViewModel viewModel)
        {
            return new Tag
            {
                Id = viewModel.Id,
                Value = viewModel.Value,
            };
        }
    }
}
