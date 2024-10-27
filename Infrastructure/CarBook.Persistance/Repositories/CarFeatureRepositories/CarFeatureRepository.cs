﻿using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public  void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values =   _context.CarFeatures.Where(x=>x.FeatureId==id).FirstOrDefault();
            values.Available = false;
             _context.SaveChanges();
        }

        public  void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values =  _context.CarFeatures.Where(x => x.FeatureId == id).FirstOrDefault();
            values.Available = true;
             _context.SaveChanges();
        }

        public List<CarFeature> GetCatFeaturesByCarId(int id)
        {
            var values = _context.CarFeatures.Include(y=>y.Feature).Where(x=>x.CarId==id).ToList();
            return values;
        }
    }
}