using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetAllLocationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _mediator.Send(new DeleteLocationCommand(id));
            return Ok("Deleted");
        }
    }
}
