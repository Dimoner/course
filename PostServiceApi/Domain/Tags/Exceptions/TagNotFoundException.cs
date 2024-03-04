using Core.Logic.Base.Exceptions;

namespace Domain.Tags.Exceptions
{
    public class TagNotFoundException : NotFoundException
    {
        public TagNotFoundException(Guid tagId) : base($"The tag with the identifier {tagId} was not found.")
        {
        }
    }
}
