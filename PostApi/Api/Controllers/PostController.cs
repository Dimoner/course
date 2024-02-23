using Microsoft.AspNetCore.Mvc;
using ProfileDal;
using ProfileDal.Entities;
using Services;

namespace Api.Controllers;

public record PostRequest
{
    public required Guid UserId { get; init; }
    
    public required string Title { get; init; }
    
    public required string Content { get; init; }
}

[Route("public/example")]
public class PostController : ControllerBase
{
    private readonly ICreatePost _createPost;

    public PostController(ICreatePost createPost)
    {
        _createPost = createPost;
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
