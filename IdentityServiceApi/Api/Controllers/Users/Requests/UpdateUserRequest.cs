using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Users.Requests
{
    public class UpdateUserRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FirstName length should be from 3 to 50 symbols")]
        [RegularExpression(@"^\p{L}*$", ErrorMessage = "FirstName should contain only letters")]
        public string FirstName { get; init; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "SecondName length should be from 3 to 50 symbols")]
        [RegularExpression(@"^\p{L}*$", ErrorMessage = "SecondName should contain only letters")]
        public string SecondName { get; init; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; init; } = null!;

        [Required]
        [Range(1, 110, ErrorMessage = "Invalid age")]
        public int Age { get; init; }

        [Required]
        public DateTime RegistrationDate { get; init; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password length should be from 6 to 100 symbols")]
        public string Password { get; init; } = null!;

        [Required]
        public Guid RoleId { get; init; }
    }
}
