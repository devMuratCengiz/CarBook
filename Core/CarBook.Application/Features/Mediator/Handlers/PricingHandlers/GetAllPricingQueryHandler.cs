using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetAllPricingQueryHandler : IRequestHandler<GetAllPricingQuery, List<GetAllPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetAllPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllPricingQueryResult>> Handle(GetAllPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllPricingQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
