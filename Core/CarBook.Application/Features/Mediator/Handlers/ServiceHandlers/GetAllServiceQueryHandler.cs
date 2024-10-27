using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, List<GetAllServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetAllServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllServiceQueryResult>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAllServiceQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                IconUrl = x.IconUrl,
                Description = x.Description
            }).ToList();
        }
    }
}
