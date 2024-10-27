using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetLast5CarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetLast5CarWithBrands();
            return values.Select(x=> new GetLast5CarWithBrandQueryResult 
            {
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
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
