﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.BannerDtos
{
    public class ResultBannerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
