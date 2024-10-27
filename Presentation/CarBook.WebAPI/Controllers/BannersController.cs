using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetAllBannerQueryHandler _getAllBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly DeleteBannerCommandHandler _deleteBannerCommandHandler;

        public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetAllBannerQueryHandler getAllBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, DeleteBannerCommandHandler deleteBannerCommandHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getAllBannerQueryHandler = getAllBannerQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _deleteBannerCommandHandler = deleteBannerCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var values = await _getAllBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Added");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _deleteBannerCommandHandler.Handle(new DeleteBannerCommand(id));
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Updated");
        }
    }
}
