namespace Logic.Users.Models
{
    public record UserLogic
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; } = null!;
        public string SecondName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public int Age { get; init; }
        public DateTime RegistrationDate { get; init; }
        public string Password { get; init; } = null!;
        public Guid RoleId { get; init; }
    }
}
