using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.PricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetAllCarPricingWithCarQueryHandler : IRequestHandler<GetAllCarPricingWithCarQuery, List<GetAllCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetAllCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllCarPricingWithCarQueryResult>> Handle(GetAllCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();
            return values.Select(x=> new GetAllCarPricingWithCarQueryResult
            {
                Price = x.Price,
                Brand = x.Car.Brand.Name,
                Id = x.Id,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                CarId = x.Car.Id
            }).ToList();
        }
    }
}
