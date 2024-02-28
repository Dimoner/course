using Core.Dal.Base;

namespace Dal.Models
{
    public record RoleDal: BaseEntity
    {
        public string Name { get; init; } = null!;
        public List<RightDal> Rights { get; set; } = null!;
    }
}
