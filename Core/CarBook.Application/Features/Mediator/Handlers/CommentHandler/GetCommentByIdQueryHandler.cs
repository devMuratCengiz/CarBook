﻿using CarBook.Application.Features.Mediator.Queries.CommentQueries;
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
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetCommentByIdQueryResult
            {
                Blog = value.Blog,
                BlogId = value.BlogId,
                Content = value.Content,
                CreatedDate = value.CreatedDate,
                Id = value.Id,
                Name = value.Name
            };
        }
    }
}
