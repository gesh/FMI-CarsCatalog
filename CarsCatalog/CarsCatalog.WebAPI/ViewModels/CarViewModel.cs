using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCatalog.WebAPI.ViewModels
{
    public class CarViewModel
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public int HorsePowers { get; set; }

        public string ImageUrl { get; set; }

        public double Rating { get; set; }

        public string Manufacturer { get; set; }

        public string Information { get; set; }
    }
}