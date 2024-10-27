using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandler
{
    public class GetCommentListByBlogIdQueryHandler : IRequestHandler<GetCommentListByBlogIdQuery, List<GetCommentListByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _repository;

        public GetCommentListByBlogIdQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentListByBlogIdQueryResult>> Handle(GetCommentListByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetCommentListByBlogId(request.Id);
            return values.Select(x => new GetCommentListByBlogIdQueryResult
            {
                Id = x.Id,
                BlogId = x.BlogId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                Name = x.Name
            }).ToList();
        }
    }
}
