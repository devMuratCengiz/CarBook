using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetAllFeatureQueryHandler : IRequestHandler<GetAllFeatureQuery, List<GetAllFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetAllFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllFeatureQueryResult>> Handle(GetAllFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAllFeatureQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
