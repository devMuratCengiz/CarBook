using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, List<GetAllBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetAllBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogQueryResult>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllBlogQueryResult
            {
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
