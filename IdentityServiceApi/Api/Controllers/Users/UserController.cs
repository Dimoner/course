using Api.Controllers.Users.Requests;
using Api.Controllers.Users.Responses;
using Logic.Users.Managers;
using Logic.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users
{
    [Route("/api/users")]
    [Controller]
    public class UserController: ControllerBase
    {
        private readonly IUserLogicManager userLogicManager;

        public UserController(IUserLogicManager userLogicManager)
        {
            this.userLogicManager = userLogicManager;
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<GetUserInfoResponse>), 200)]
        public async Task<IActionResult> GetPageAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var allUsers = await userLogicManager.GetPageAsync(pageNumber, pageSize);
            var infoResponses = allUsers.Select(user => new GetUserInfoResponse
            {
                Age = user.Age,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate,
                RoleId = user.RoleId,
                SecondName = user.SecondName
            });

            return Ok(infoResponses);
        }

        [HttpPost]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(CreateUserResponse), 201)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        {
            var res = await userLogicManager.CreateUserAsync(new UserLogic
            {
                Age = request.Age,
                Email = request.Email,
                FirstName = request.FirstName,
                Password = request.Password,
                RegistrationDate = request.RegistrationDate,
                RoleId = request.RoleId,
                SecondName = request.SecondName
            });

            var response = new CreateUserResponse { Id = res };

            return StatusCode(201, response);
        }

        [HttpGet("{id}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(GetUserInfoResponse), 200)]
        public async Task<IActionResult> GetUserInfoAsync([FromRoute] Guid id)
        {
            var user = await userLogicManager.GetUserAsync(id);

            var response = new GetUserInfoResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Password = user.Password,
                RegistrationDate = user.RegistrationDate,
                Age = user.Age,
                Email = user.Email,
                RoleId = user.RoleId,
                SecondName = user.SecondName
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id)
        {
            await userLogicManager.DeleteUserAsync(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(UpdateUserResponse), 200)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserRequest request, [FromRoute] Guid id)
        {
            var updatedUser = await userLogicManager.UpdateUserAsync(new UserLogic
            {
                Age = request.Age,
                Email = request.Email,
                RoleId = request.RoleId,
                FirstName = request.FirstName,
                Password = request.Password,
                RegistrationDate = request.RegistrationDate,
                Id = id,
                SecondName = request.SecondName,
            });

            var reponse = new UpdateUserResponse
            {
                Id = id,
                SecondName = updatedUser.SecondName,
                FirstName = updatedUser.FirstName,
                Password = updatedUser.Password,
                RegistrationDate = updatedUser.RegistrationDate,
                Age = updatedUser.Age,
                Email = updatedUser.Email,
                RoleId = updatedUser.RoleId,
            };

            return Ok(reponse);
        }
    }
}
