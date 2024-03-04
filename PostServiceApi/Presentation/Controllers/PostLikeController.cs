using Microsoft.AspNetCore.Mvc;
using Application.PostLikes.Services;
using Application.PostLikes;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/postLikes")]
    public class PostLikeController : ControllerBase
    {
        private readonly IPostLikeService postLikeService;

        public PostLikeController(IPostLikeService postLikeService)
        {
            this.postLikeService = postLikeService;
        }

        [HttpGet("{postLikeId:guid}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(PostLikeViewModel), 200)]
        public async Task<IActionResult> GetPostLikeAsync([FromRoute] Guid postLikeId)
        {
            var postLike = await postLikeService.GetAsync(postLikeId);

            return Ok(postLike);
        }

        [HttpPost]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(Guid), 201)]
        public async Task<IActionResult> CreatePostLikeAsync([FromBody] PostLikeViewModel postLikeViewModel)
        {
            var id = await postLikeService.CreateAsync(postLikeViewModel);

            return CreatedAtRoute(nameof(GetPostLikeAsync), new { Id = id }, id);
        }

        [HttpDelete("{postLikeId:guid}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeletePostLikeAsync([FromRoute] Guid postLikeId)
        {
            await postLikeService.DeleteAsync(postLikeId);

            return NoContent();
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<PostLikeViewModel>), 200)]
        public async Task<IActionResult> GetPostLikesPageAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var page = await postLikeService.GetPageAsync(pageNumber, pageSize);

            return Ok(page);
        }

        [HttpGet("of-post/{postId:guid}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<PostLikeViewModel>), 200)]
        public async Task<IActionResult> GetPostLikesPage(
            [FromRoute] Guid postId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            var page = await postLikeService.GetPostLikesPageByPostIdAsync(postId, pageNumber, pageSize);

            return Ok(page);
        }
    }
}
