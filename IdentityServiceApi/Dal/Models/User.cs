using Core.Dal.Base;

namespace Dal.Models
{
    public record User: BaseEntity
    {
        public string FirstName { get; init; } = null!;
        public string SecondName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public int Age { get; init; }
        public DateTime RegistrationDate { get; init; }
        public string Password { get; init; } = null!;
    }
}
