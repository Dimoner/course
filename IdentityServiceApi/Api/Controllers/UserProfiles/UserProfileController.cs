using Api.Controllers.UserProfiles.Requests;
using Api.Controllers.UserProfiles.Responses;
using Api.Controllers.Users.Requests;
using Api.Controllers.Users.Responses;
using AutoMapper;
using Logic.UserProfiles.Managers;
using Logic.UserProfiles.Models;
using Logic.Users.Managers;
using Logic.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.UserProfiles
{
    [Route("/api/users")]
    [Controller]
    public class UserProfileController: ControllerBase
    {
        private readonly IUserProfileLogicManager profileLogicManager;
        private readonly IMapper mapper;

        public UserProfileController(IUserProfileLogicManager profileLogicManager, IMapper mapper)
        {
            this.profileLogicManager = profileLogicManager;
            this.mapper = mapper;
        }

        [HttpGet("{id}/profile")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(GetUserProfileInfoResponse), 200)]
        public async Task<IActionResult> GetUserProfileAsync([FromRoute] Guid id)
        {
            var profile = await profileLogicManager.GetUserProfileByUserIdAsync(id);

            var response = mapper.Map<GetUserProfileInfoResponse>(profile);

            return Ok(response);
        }

        [HttpPost("{id}/profile")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(CreateUserProfileResponse), 201)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserProfileRequest request)
        {
            var res = await profileLogicManager.CreateUserProfileAsync(mapper.Map<UserProfileLogic>(request));

            var response = new CreateUserProfileResponse { Id = res };

            return StatusCode(201, response);
        }
    }
}
