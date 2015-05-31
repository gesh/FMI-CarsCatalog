using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCatalog.Database.Models
{
    public class Advertisement
    {
        [Key]
        public int ID { get; set; }

        public string AuthorID { get; set; }

        public int CarID { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string VideoURL { get; set; }

        public string Body { get; set; }

        public int Year { get; set; }

        public double Kilometres { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Car Car { get; set; }
    }
}
