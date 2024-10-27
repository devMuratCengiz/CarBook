using CarBook.Application.Features.Mediator.Queries.SocailMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetAllSocialMediaQueryHandler : IRequestHandler<GetAllSocialMediaQuery, List<GetAllSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetAllSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllSocialMediaQueryResult>> Handle(GetAllSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAllSocialMediaQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
                Icon = x.Icon
            }).ToList();
        }
    }
}
