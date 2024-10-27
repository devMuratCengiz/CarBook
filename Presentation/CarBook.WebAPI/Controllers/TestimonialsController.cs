using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TestimonialsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _mediator.Send(new GetAllTestimonialQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateTestimonialCommand command)
		{
			await _mediator.Send(command);
			return Ok("Added");
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateTestimonialCommand command)
		{
			await _mediator.Send(command);
			return Ok("Updated");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _mediator.Send(new DeleteTestimonialCommand(id));
			return Ok("Deleted");
		}
	}
}
