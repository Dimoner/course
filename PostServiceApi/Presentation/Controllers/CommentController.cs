using Application.Comments;
using Application.Comments.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/comments")]
    public class CommentController: ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("{commentId:guid}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(CommentViewModel), 200)]
        public async Task<IActionResult> GetCommentAsync([FromRoute] Guid commentId)
        {
            var comment = await commentService.GetAsync(commentId);

            return Ok(comment);
        }

        [HttpPost]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(Guid), 201)]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CommentViewModel commentViewModel)
        {
            var id = await commentService.CreateAsync(commentViewModel);

            return CreatedAtRoute(nameof(GetCommentAsync), new {Id = id}, id);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateCommentAsync([FromBody] CommentViewModel commentViewModel)
        {
            await commentService.UpdateAsync(commentViewModel);

            return NoContent();
        }

        [HttpDelete("{commentId:guid}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteCommentAsync([FromRoute] Guid commentId)
        {
            await commentService.DeleteAsync(commentId);

            return NoContent();
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<CommentViewModel>), 200)]
        public async Task<IActionResult> GetCommentsPageAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var page = await commentService.GetPageAsync(pageNumber, pageSize);

            return Ok(page);
        }

        [HttpGet("of-post/{postId:guid}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<CommentViewModel>), 200)]
        public async Task<IActionResult> GetPostCommentsPage(
            [FromRoute] Guid postId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            var page = await commentService.GetCommentsPageByPostIdAsync(postId, pageNumber, pageSize);

            return Ok(page);
        }
    }
}
