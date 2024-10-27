using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            value.Transmission = command.Transmission;
            value.BigImageUrl = command.BigImageUrl;
            value.Km = command.Km;
            value.BrandId = command.BrandId;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Seat = command.Seat;
            value.Fuel = command.Fuel;
            value.Luggage = command.Luggage;
            value.Model = command.Model;
            await _repository.UpdateAsync(value);
        }
    }
}
