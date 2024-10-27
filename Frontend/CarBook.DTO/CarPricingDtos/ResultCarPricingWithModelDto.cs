using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarPricingDtos
{
	public class ResultCarPricingWithModelDto
	{
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
