using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetAllFooterAddressQueryHandler : IRequestHandler<GetAllFooterAddressQuery, List<GetAllFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetAllFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllFooterAddressQueryResult>> Handle(GetAllFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllFooterAddressQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                Id = x.Id,
                Phone = x.Phone
            }).ToList();
        }
    }
}
