using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAllAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAllAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAllAboutQueryResult
            {
                Description = x.Description,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Title = x.Title
            }).ToList();
        }
    }
}
