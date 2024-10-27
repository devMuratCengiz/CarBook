using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetAllCarQueryHandler _getAllCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler; 
        private readonly DeleteCarCommandHandler _deleteCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarWithBrandQueryHandler _getLast5CarWithBrandQueryHandler;

        public CarsController(GetAllCarQueryHandler getAllCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, DeleteCarCommandHandler deleteCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler)
        {
            _getAllCarQueryHandler = getAllCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _deleteCarCommandHandler = deleteCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarWithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var values = await _getAllCarQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _deleteCarCommandHandler.Handle(new DeleteCarCommand(id));
            return Ok("Deleted");
        }
        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("GetLast5CarWithBrand")]
        public async Task<IActionResult> GetLast5CarWithBrand()
        {
            var values = _getLast5CarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        
    }
}
