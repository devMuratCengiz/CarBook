using CarBook.Application.Features.Mediator.Commands.CommentCommands;
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
    public class UpdateCommentCommanHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommanHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.CreatedDate = request.CreatedDate;
            value.Name = request.Name;
            value.Content = request.Content;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);
        }
    }
}
