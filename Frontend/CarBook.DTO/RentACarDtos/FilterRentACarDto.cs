using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.RentACarDtos
{
    public class FilterRentACarDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
