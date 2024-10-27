using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<GetAllAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAllAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllAuthorQueryResult>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetAllAuthorQueryResult
            {
                Description = x.Description,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name
            }).ToList();
        }
    }
}
