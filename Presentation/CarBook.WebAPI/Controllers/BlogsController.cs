using CarBook.Application.Features.Mediator.Commands.BlogCommand;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetAllBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _mediator.Send(new DeleteBlogCommand(id));
            return Ok("Deleted");
        }
        [HttpGet("GetLast3Blogs")]
        public async Task<IActionResult> GetLast3Blogs()
        {
            var values = await _mediator.Send(new GetLast3BlogsQuery());
            return Ok(values);
        }
        [HttpGet("GetAllBlogsWithAuthor")]
        public async Task<IActionResult> GetAllBLogsWithAuthor()
        {
            var values = await _mediator.Send(new GetAllBlogWithAuthorQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(values);
        }
    }
}
