﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public int Seat { get; set; }
        public int Luggage { get; set; }
        public string Fuel { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
        public List<Rezervation> Rezervations { get; set; }
    }
}
