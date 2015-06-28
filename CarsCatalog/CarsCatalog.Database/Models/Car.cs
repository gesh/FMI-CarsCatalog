using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCatalog.Database.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int HorsePowers { get; set; }

        public string ImageUrl { get; set; }
        
        public string Information { get; set; }
        
        public int ManufacturerID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
