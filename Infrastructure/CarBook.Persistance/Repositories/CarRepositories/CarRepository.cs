﻿using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

		

		public List<Car> GetCarsListWithBrands()
        {
            var value = _context.Cars.Include(x=>x.Brand).ToList();
            return value;
        }

        

        public List<Car> GetLast5CarWithBrands()
        {
            var values = _context.Cars.Include(x=>x.Brand).OrderByDescending(x=>x.Id).Take(5).ToList();
            return values;
        }
    }
}
