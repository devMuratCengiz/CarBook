using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class DeleteFeatureCommanHandler : IRequestHandler<DeleteFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public DeleteFeatureCommanHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
