using Dal.Users;
using Logic.Users.Models;

namespace Logic.Users.Managers
{
    public class UserLogicManager : IUserLogicManager
    {
        private readonly IUserRepository userRepository;

        public UserLogicManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid> CreateUserAsync(UserLogic user)
        {
            var userId = await userRepository.CreateAsync(new UserDal
            {
                Age = user.Age,
                Email = user.Email,
                FirstName = user.FirstName,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate,
                RoleId = user.RoleId,
                SecondName = user.SecondName
            });

            return userId;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var hasDeleted = await userRepository.DeleteAsync(userId);

            return hasDeleted;
        }

        public async Task<IEnumerable<UserLogic>> GetPageAsync(int pageNumber, int pageSize)
        {
            var users = await userRepository.GetPageAsync(pageNumber, pageSize);

            return users.Select(user => new UserLogic
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Password = user.Password,
                Age = user.Age,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                RoleId = user.RoleId,
                SecondName = user.SecondName
            });
        }

        public async Task<UserLogic> GetUserAsync(Guid userId)
        {
            var user = await userRepository.GetAsync(userId);

            return user == null
                ? new UserLogic()
                : new UserLogic
                {
                    SecondName = user.SecondName,
                    FirstName = user.FirstName,
                    Password = user.Password,
                    Age = user.Age,
                    Email = user.Email,
                    RegistrationDate = user.RegistrationDate,
                    RoleId = user.RoleId,
                    Id = userId,
                };
        }

        public async Task<UserLogic> UpdateUserAsync(UserLogic user)
        {
            var updatedUser = await userRepository.UpdateAsync(new UserDal
            {
                Age = user.Age,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                RoleId = user.RoleId,
                FirstName = user.FirstName,
                Id = user.Id,
                Password = user.Password,
                SecondName = user.SecondName
            });

            return new UserLogic
            {
                SecondName = updatedUser.SecondName,
                FirstName = updatedUser.FirstName,
                Password = updatedUser.Password,
                Id = updatedUser.Id,
                RoleId = updatedUser.RoleId,
                Age = updatedUser.Age,
                Email = updatedUser.Email,
                RegistrationDate = updatedUser.RegistrationDate
            };
        }
    }
}
