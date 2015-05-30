using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCatalog.Database.Models
{
    public class Manufacturer
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Information { get; set; }
    }
}
