using Core.Dal.Base;

namespace Dal.Rights
{
    public record RightDal : BaseEntity
    {
        public string Name { get; init; } = null!;
    }
}
