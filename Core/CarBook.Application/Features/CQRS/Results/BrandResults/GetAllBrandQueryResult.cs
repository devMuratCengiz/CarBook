﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.BrandResults
{
    public class GetAllBrandQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
