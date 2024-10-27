using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetAllBrandQueryHandler _getAllBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly DeleteBrandCommandHandler _deleteBrandCommandHandler;

        public BrandsController(GetAllBrandQueryHandler getAllBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, DeleteBrandCommandHandler deleteBrandCommandHandler)
        {
            _getAllBrandQueryHandler = getAllBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _deleteBrandCommandHandler = deleteBrandCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _getAllBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _deleteBrandCommandHandler.Handle(new DeleteBrandCommand(id));
            return Ok("Deleted");
        }
    }
}
