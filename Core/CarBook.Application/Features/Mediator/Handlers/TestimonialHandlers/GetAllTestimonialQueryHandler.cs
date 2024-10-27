using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
	public class GetAllTestimonialQueryHandler : IRequestHandler<GetAllTestimonialQuery, List<GetAllTestimonialQueryResult>>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetAllTestimonialQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllTestimonialQueryResult>> Handle(GetAllTestimonialQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAllTestimonialQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Name = x.Name,
				ImageUrl = x.ImageUrl,
				Comment = x.Comment
			}).ToList();
		}
	}
}
