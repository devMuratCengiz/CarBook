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
	public class GetCarPricingWithTimeQueryHandler : IRequestHandler<GetCarPricingWithTimeQuery, List<GetCarPricingWithTimeQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithTimeQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithTimeQueryResult>> Handle(GetCarPricingWithTimeQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingWithTime1();
			return values.Select(x=> new GetCarPricingWithTimeQueryResult
			{
				Brand = x.Brand,
				CoverImageUrl = x.CoverImageUrl,
				DailyPrice = x.Price[0],
				WeeklyPrice = x.Price[1],
				MonthlyPrice = x.Price[2],
				Model = x.Model
			}).ToList();
		}
	}
}
