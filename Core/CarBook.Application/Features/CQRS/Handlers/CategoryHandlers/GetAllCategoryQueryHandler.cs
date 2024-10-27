﻿using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetAllCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetAllCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetAllCategoryQueryResult
            {
                Id=x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}