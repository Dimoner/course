using Core.Dal.Base;

namespace Domain.Tags
{
    public record Tag : BaseEntity
    {
        /// <summary>
        /// The tag's value
        /// </summary>
        public string Value { get; init; } = null!;
    }
}
