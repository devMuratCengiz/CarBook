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
    public class DeleteCommentCommanHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public DeleteCommentCommanHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
