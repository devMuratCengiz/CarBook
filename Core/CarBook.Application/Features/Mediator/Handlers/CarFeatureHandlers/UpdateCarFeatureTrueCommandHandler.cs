using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureTrueCommandHandler : IRequestHandler<UpdateCarFeatureTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
