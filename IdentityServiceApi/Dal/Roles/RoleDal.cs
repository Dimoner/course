using Core.Dal.Base;
using Dal.Rights;

namespace Dal.Roles
{
    public record RoleDal : BaseEntity
    {
        public string Name { get; init; } = null!;
        public List<RightDal> Rights { get; set; } = null!;
    }
}
