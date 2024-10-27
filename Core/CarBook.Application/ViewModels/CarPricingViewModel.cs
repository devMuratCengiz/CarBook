using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.ViewModels
{
	public class CarPricingViewModel
	{
        public CarPricingViewModel()
        {
            Price = new List<decimal>();
        }
        public string Model { get; set; }
        public List<decimal> Price { get; set; }
        public string Brand { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
