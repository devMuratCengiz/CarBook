using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQuery, List<GetAllLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetAllLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllLocationQueryResult>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllLocationQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
