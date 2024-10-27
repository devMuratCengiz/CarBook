using CarBook.Application.Interfaces.PricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 2).ToList();
            return values;
        }

        public List<CarPricing> GetCarPricingWithTime()
        {
           throw new NotImplementedException();
        }

		public List<CarPricingViewModel> GetCarPricingWithTime1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * from(Select Name,Model,CoverImageUrl,PricingId,Price from CarPricings Inner Join Cars on Cars.Id=CarPricings.CarId Inner Join Brands on Brands.Id=Cars.BrandId) as SourceTable Pivot (Sum(Price) for PricingId In([2],[3],[4])) as PivotTable";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Price = new List<decimal>
							{
								Convert.ToDecimal(reader[3]),
								Convert.ToDecimal(reader[4]),
								Convert.ToDecimal(reader[5])
							}
						};
						values.Add(carPricingViewModel);

						
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
	}
    }
}
	//public List<CarPricing> GetCarPricingWithTime()
	//{
	//          var values = from x in _context.CarPricings
	//                       group x by x.PricingId into g
	//                       select new
	//                       {
	//                           CarId = g.Key,
	//                           DailyPrice = g.Where(y => y.Id == 2).Sum(z => z.Price),
	//                           WeeklyPrice = g.Where(y => y.Id == 3).Sum(z => z.Price),
	//                           MonthlyPrice = g.Where(y => y.Id == 4).Sum(z => z.Price)

//                       };
//          return values.ToList();
//}


// List<CarPricing> values = new List<CarPricing>();
//using (var command = _context.Database.GetDbConnection().CreateCommand())
//{
//	command.CommandText = "Select * from(Select Model,PricingId,Price from CarPricings Inner Join Cars on Cars.Id==CarPricings.CarId Inner Join Brands on Brands.Id==Cars.BrandId) as SourceTable Pivot (Sum(Price) for PricingId In([2],[3],[4])) as PivotTable";
//	command.CommandType = System.Data.CommandType.Text;
//	_context.Database.OpenConnection();
//	using (var reader = command.ExecuteReader())
//	{
//		while (reader.Read())
//		{
//			CarPricing carPricing = new CarPricing();
//			Enumerable.Range(1, 3).ToList().ForEach(x =>
//			{
//				if (DBNull.Value.Equals(reader[x]))
//				{
//					carPricing.

//							}
//				else
//				{
//					carPricing.Price

//							}

//			});
//			values.Add(carPricing);
//		}
//	}
//	_context.Database.CloseConnection();
//	return values;