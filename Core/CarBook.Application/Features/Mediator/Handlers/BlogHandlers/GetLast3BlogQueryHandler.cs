using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogQueryHandler : IRequestHandler<GetLast3BlogsQuery, List<GetLast3BlogsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsQueryResult>> Handle(GetLast3BlogsQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetLast3Blogs();
            return values.Select(x=> new GetLast3BlogsQueryResult
            {
                AuthorName = x.Author.Name,
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
