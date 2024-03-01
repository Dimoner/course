using Core.Dal.Base;

namespace Dal.Users
{
    public record UserDal : BaseEntity
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public int Age { get; init; }
        public DateTime RegistrationDate { get; init; }
        public string Password { get; init; } = null!;
        public Guid RoleId { get; init; }
    }
}
