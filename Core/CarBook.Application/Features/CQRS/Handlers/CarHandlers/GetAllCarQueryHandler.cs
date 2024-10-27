using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetAllCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetAllCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllCarQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Id = x.Id,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
