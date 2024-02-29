using Api.Controllers.Users.Requests;
using Api.Controllers.Users.Responses;
using AutoMapper;
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
        private readonly IMapper mapper;

        public UserController(IUserLogicManager userLogicManager, IMapper mapper)
        {
            this.userLogicManager = userLogicManager;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<GetUserInfoResponse>), 200)]
        public async Task<IActionResult> GetPageAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var allUsers = await userLogicManager.GetPageAsync(pageNumber, pageSize);
            var infoResponses = allUsers.Select(user => mapper.Map<GetUserInfoResponse>(user));

            return Ok(infoResponses);
        }

        [HttpPost]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(CreateUserResponse), 201)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        {
            var res = await userLogicManager.CreateUserAsync(mapper.Map<UserLogic>(request));

            var response = new CreateUserResponse { Id = res };

            return StatusCode(201, response);
        }

        [HttpGet("{id}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(GetUserInfoResponse), 200)]
        public async Task<IActionResult> GetUserInfoAsync([FromRoute] Guid id)
        {
            var user = await userLogicManager.GetUserAsync(id);

            var response = mapper.Map<GetUserInfoResponse>(user);

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
            var updatedUser = await userLogicManager.UpdateUserAsync(mapper.Map<UserLogic>(request));

            var reponse = mapper.Map<UpdateUserResponse>(updatedUser);

            return Ok(reponse);
        }
    }
}
