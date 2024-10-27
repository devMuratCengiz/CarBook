using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarPricingListWithCar()
        {
            var values = await _mediator.Send(new GetAllCarPricingWithCarQuery());
            return Ok(values);
        }
        [HttpGet("GetCarPricingWithTime")]
        public async Task<IActionResult> GetCarPricingWithTime()
        {
            var values = await _mediator.Send(new GetCarPricingWithTimeQuery());
            return Ok(values);
        }

	}
}
