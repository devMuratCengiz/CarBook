using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Rezervation> _repository;

        public CreateReservationCommandHandler(IRepository<Rezervation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Rezervation
            {
                Age = request.Age,
                CarId = request.CarId,
                Description = request.Description,
                LicenseYear = request.LicenseYear,
                DropOffId = request.DropOffId,
                PickUpId = request.PickUpId,
                Mail = request.Mail,
                Name = request.Name,
                Phone = request.Phone,
                Surname = request.Surname,
                Status = "Rezervasyon Alındı"
            });
        }
    }
}
