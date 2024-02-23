using Microsoft.AspNetCore.Mvc;
using ProfileApi.Controllers.User.Requests;
using ProfileApi.Controllers.User.Responses;
using ProfileLogic.Users.Interfaces;
using ProfileLogic.Users.Models;

namespace ProfileApi.Controllers;

/// <summary>
/// Работа с пользователями
/// </summary>
[Route("public/user")]
public class UserController : ControllerBase
{
    private readonly IUserLogicManager _userLogicManager;

    public UserController(IUserLogicManager userLogicManager)
    {
        _userLogicManager = userLogicManager;
    }
    
    /// <summary>
    /// запроса персональной информации о пользователи
    /// выполняется самим пользователем
    /// </summary>
    [ProducesResponseType<UserInfoResponse>(200)]
    public async Task<IActionResult> GetInfoAsync([FromQuery] Guid userId)
    {
        var userName = await _userLogicManager.GetUserNameAsync(userId);
        return Ok(new UserInfoResponse
        {
            Id = default,
            Name = null,
            Login = null,
            Phone = null
        });
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), 200)]
    public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserRequest dto)
    {
        // не должно быть в контроллере
        // 1 - валидации - либо Attribute, либо слой отдельный
        // 2 - бизнес логики - Logic (проверка доступов)
        // 3 - проверка авторизации - Attribute
        var res = await _userLogicManager.CreateUserAsync(new UserLogic
        {
            Name = dto.Name,
            Login = dto.Login,
            Phone = dto.Phone
        });
        
        return Ok(new CreateUserResponse
        {
            Id = res
        });
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(object), 200)]
    public async Task<ActionResult> GetAsync()
    {
        return Ok();
    }
}