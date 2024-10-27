using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandler
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<GetAllCommentQueryResults>>
    {
        private readonly IRepository<Comment> _repository;

        public GetAllCommentQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllCommentQueryResults>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetAllCommentQueryResults
            {
                Blog = x.Blog,
                BlogId = x.BlogId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                Name = x.Name,
                Id = x.Id
            }).ToList();
        }
    }
}
