using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAllAboutQueryHandler _getAllAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAllAboutQueryHandler getAllAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, DeleteAboutCommandHandler deleteAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAllAboutQueryHandler = getAllAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAllAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Added");    
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _deleteAboutCommandHandler.Handle(new DeleteAboutCommand(id));
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Updated");
        }
    }
}
