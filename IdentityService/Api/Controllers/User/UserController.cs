using IdentityApi.Controllers.User.Requests;
using IdentityApi.Controllers.User.Responses;
using IdentityLogic.Users.Interfaces;
using IdentityLogic.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers.User;

/// <summary>
/// Работа с пользователями
/// </summary>
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserLogicManager _userLogicManager;

    public UserController(IUserLogicManager userLogicManager)
    {
        _userLogicManager = userLogicManager;
    }
    
    /// <summary>
    /// запрос персональной информации о пользователи
    /// выполняется самим пользователем
    /// </summary>
    [HttpGet("info")]
    [ProducesResponseType<UserInfoResponse>(200)]
    public async Task<IActionResult> GetInfoAsync([FromQuery] Guid userId)
    {
        var userInfo = await _userLogicManager.GetUserInfoAsync(userId);
        var friends = await _userLogicManager.GetUserFriendsAsync(userId);
        return Ok(new UserInfoResponse
        {
            Id = userId,
            Email = userInfo.Email,
            Username = userInfo.Username,
            AvatarUrl = userInfo.AvatarUrl,
            Friends = friends,
            Description = userInfo.Description,
            RegisterDate = userInfo.RegisterDate
        });
    }
    
    /// <summary>
    /// запрос информации о пользователе, выполняется любым пользователем
    /// </summary>
    [HttpGet]
    [ProducesResponseType<UserInfoResponse>(200)]
    public async Task<IActionResult> GetProfileAsync([FromQuery] string username)
    {
        var userInfo = await _userLogicManager.GetUserInfoAsync(username);
        var friends = await _userLogicManager.GetUserFriendsAsync(userInfo.Id);
        return Ok(new ProfileInfoResponse
        {
            Id = userInfo.Id,
            Username = userInfo.Username,
            AvatarUrl = userInfo.AvatarUrl,
            Friends = friends,
            Description = userInfo.Description,
            RegisterDate = userInfo.RegisterDate
        });
    }
    
    [HttpPost]
    [ProducesResponseType<CreateUserResponse>(200)]
    public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserRequest dto)
    {
        // не должно быть в контроллере
        // 1 - валидации - либо Attribute, либо слой отдельный
        // 2 - бизнес логики - Logic (проверка доступов)
        // 3 - проверка авторизации - Attribute
        var res = await _userLogicManager.CreateUserAsync(dto.Email, dto.Username, dto.Password);
        
        return Ok(new CreateUserResponse
        {
            Id = res
        });
    }
    
    [HttpPut]
    [ProducesResponseType<UserInfoResponse>(200)]
    public async Task<ActionResult> UpdateUserAsync([FromQuery] Guid userId, [FromBody] UserInfoUpdateRequest dto)
    {
        var res = await _userLogicManager.UpdateUserAsync(userId, new UserUpdateLogic()
        {
            Username = dto.Username,
            Email = dto.Email,
            AvatarUrl = dto.AvatarUrl,
            Description = dto.Description,
        });
        var friends = await _userLogicManager.GetUserFriendsAsync(userId);
        return Ok(new ProfileInfoResponse
        {
            Id = userId,
            Username = res.Username,
            Description = res.Description,
            AvatarUrl = res.AvatarUrl,
            RegisterDate = res.RegisterDate,
            Friends = friends
        });
    }
    
    [HttpDelete]
    [ProducesResponseType(200)]
    public async Task<ActionResult> DeleteUserAsync([FromQuery] Guid userId)
    {
        await _userLogicManager.DeleteUserAsync(userId);
        return Ok();
    }
    
}