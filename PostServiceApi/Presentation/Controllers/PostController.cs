using Application.Posts;
using Application.Posts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("/api/posts")]
    public class PostController: ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("{postId:guid}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(PostViewModel), 200)]
        public async Task<IActionResult> GetPostAsync([FromRoute] Guid postId)
        {
            var post = await postService.GetAsync(postId);

            return Ok(post);
        }

        [HttpPost]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(Guid), 201)]
        public async Task<IActionResult> CreatePostAsync([FromBody] PostViewModel postViewModel)
        {
            var id = await postService.CreateAsync(postViewModel);

            return CreatedAtRoute(nameof(GetPostAsync), new { postId = id }, id);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdatePostAsync([FromBody] PostViewModel postViewModel)
        {
            await postService.UpdateAsync(postViewModel);

            return NoContent();
        }

        [HttpDelete("{postId:guid}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeletePostAsync([FromRoute] Guid postId)
        {
            await postService.DeleteAsync(postId);

            return NoContent();
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<PostViewModel>), 200)]
        public async Task<IActionResult> GetPostsPageAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var page = await postService.GetPageAsync(pageNumber, pageSize);

            return Ok(page);
        }
    }
}
