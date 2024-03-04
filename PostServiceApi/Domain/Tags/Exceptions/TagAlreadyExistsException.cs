using Core.Logic.Base.Exceptions;

namespace Domain.Tags.Exceptions
{
    public class TagAlreadyExistsException : BadRequestException
    {
        public TagAlreadyExistsException(Guid tagId) : base($"The tag with the identifier {tagId} already exists.")
        {
        }
    }
}
