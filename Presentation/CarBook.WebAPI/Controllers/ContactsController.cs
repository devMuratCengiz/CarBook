using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetAllContactQueryHandler _getAllContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly DeleteContactCommandHandler _deleteContactCommandHandler;

        public ContactsController(GetAllContactQueryHandler getAllContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, DeleteContactCommandHandler deleteContactCommandHandler)
        {
            _getAllContactQueryHandler = getAllContactQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _deleteContactCommandHandler = deleteContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value =await  _getAllContactQueryHandler.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _deleteContactCommandHandler.Handle(new DeleteContactCommand(id));
            return Ok("Deleted");
        }
    }
}
