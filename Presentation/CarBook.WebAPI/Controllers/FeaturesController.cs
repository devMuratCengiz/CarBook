using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetAllFeatureQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _mediator.Send(new DeleteFeatureCommand(id));
            return Ok("Deleted");
        }
    }
}
