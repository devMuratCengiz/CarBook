using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetAllContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetAllContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAllContactQueryResult
            {
                Email = x.Email,
                Id = x.Id,
                Message = x.Message,
                Name = x.Name,
                SendDate = x.SendDate,
                Subject = x.Subject
            }).ToList();
        }
    }
}
