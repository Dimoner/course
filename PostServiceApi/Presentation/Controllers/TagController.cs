using Microsoft.AspNetCore.Mvc;
using Application.Tags.Services;
using Application.Tags;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/tags")]
    public class TagController : ControllerBase
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet("{tagId:guid}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(TagViewModel), 200)]
        public async Task<IActionResult> GetTagAsync([FromRoute] Guid tagId)
        {
            var tag = await tagService.GetAsync(tagId);

            return Ok(tag);
        }

        [HttpPost]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(Guid), 201)]
        public async Task<IActionResult> CreateTagAsync([FromBody] TagViewModel tagViewModel)
        {
            var id = await tagService.CreateAsync(tagViewModel);

            return CreatedAtRoute(nameof(GetTagAsync), new { Id = id }, id);
        }

        [HttpDelete("{tagId:guid}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTagAsync([FromRoute] Guid tagId)
        {
            await tagService.DeleteAsync(tagId);

            return NoContent();
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(typeof(IEnumerable<TagViewModel>), 200)]
        public async Task<IActionResult> GetTagsPageAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var page = await tagService.GetPageAsync(pageNumber, pageSize);

            return Ok(page);
        }
    }
}
