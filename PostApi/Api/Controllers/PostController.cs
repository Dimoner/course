using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Intefaces;

namespace Api.Controllers;

public record PostRequest
{
    public required Guid UserId { get; init; }
    
    public required string Title { get; init; }
    
    public required string Content { get; init; }
}

public record PostListResponse
{
    public required PostResponse[] PostList { get; init; }
}

/// <summary>
/// 
/// </summary>
public record PostResponse
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("id")]
    public required Guid Id { get;  init; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("userId")]
    public required Guid UserId { get; init; }
    
    public required UserInfoResponse UserInfo { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("title")]
    public required string Title { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("content")]
    public required string Content { get; init; }
}

public record UserInfoResponse
{
    public required string Name { get; init; }
}


[Route("public/example")]
public class PostController : ControllerBase
{
    private readonly ICreatePost _createPost;

    public PostController(ICreatePost createPost)
    {
        _createPost = createPost;
    }
    
    [HttpGet]
    [ProducesResponseType<PostListResponse>(200)]
    public async Task<IActionResult> GetPostListAsync()
    {
        var res = await _createPost.GetPostListAsync();
        
        var response = new PostListResponse
        {
            PostList = res.Select(value => new PostResponse
            {
                Id = value.Id,
                UserId = value.UserId,
                Title = value.Title,
                Content = value.Content,
                UserInfo = new UserInfoResponse
                {
                    Name = value.UserInfo.Name
                }
            }).ToArray()
        };
        
        return Ok(response);
    }
    
    
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<ActionResult> CreatePostAsync([FromBody] PostRequest request)
    {
        await _createPost.CreatePostAsync(new Post
        {
            UserId = request.UserId,
            Title = request.Title,
            Content = request.Content
        });
        return Ok();
    }
}