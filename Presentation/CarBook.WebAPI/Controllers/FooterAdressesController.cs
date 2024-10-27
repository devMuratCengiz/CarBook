using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _mediator.Send(new GetAllFooterAddressQuery());
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateFooterAddressCommand commnad)
        {
            await _mediator.Send(commnad);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteFooterAddressCommand(id));
            return Ok("Deleted");
        }
    }
}
