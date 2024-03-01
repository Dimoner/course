using IdentityApi.Controllers.FriendRequest.Requests;
using IdentityApi.Controllers.FriendRequest.Responses;
using IdentityLogic.FriendRequests.Interfaces;
using IdentityLogic.FriendRequests.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers.FriendRequest;

[Route("api/friend-requests")]
public class FriendRequestController : ControllerBase
{
    private readonly IFriendRequestManager _friendRequestManager;
    
    public FriendRequestController(IFriendRequestManager friendRequestManager)
    {
        _friendRequestManager = friendRequestManager;
    }
    
    [ProducesResponseType<FriendRequestsListResponse>(200)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] Guid userId)
    {
        var res = await _friendRequestManager.GetAllRequests(userId);
        return Ok(res);
    }
    
    [ProducesResponseType(200)]
    [HttpPost("accept")]
    public async Task<IActionResult> AcceptAsync([FromBody] FriendRequestInfoRequest dto)
    {
        await _friendRequestManager.AcceptFriendRequest(dto.SenderUserId, dto.RecipientUserId);
        return Ok();
    }
    
    [ProducesResponseType(200)]
    [HttpPost("cancel")]
    public async Task<IActionResult> CancelAsync([FromBody] FriendRequestInfoRequest dto)
    {
        await _friendRequestManager.DeleteFriendRequest(dto.SenderUserId, dto.RecipientUserId);
        return Ok();
    }
    
    [ProducesResponseType(200)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] FriendRequestInfoRequest dto)
    {
        var res = await _friendRequestManager.CreateFriendRequest(dto.SenderUserId, dto.RecipientUserId);
        return Ok(res);
    }
}