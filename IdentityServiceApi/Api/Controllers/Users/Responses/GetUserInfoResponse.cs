namespace Api.Controllers.Users.Responses
{
    public class GetUserInfoResponse
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; } = null!;
        public required string SecondName { get; init; } = null!;
        public required string Email { get; init; } = null!;
        public required int Age { get; init; }
        public required DateTime RegistrationDate { get; init; }
        public required string Password { get; init; } = null!;
        public required Guid RoleId { get; init; }
    }
}
