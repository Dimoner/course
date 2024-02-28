using Core.Dal.Base;

namespace Dal.Models
{
    public record RightDal: BaseEntity
    {
        public string Name { get; init; } = null!;
    }
}
