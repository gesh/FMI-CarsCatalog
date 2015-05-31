using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCatalog.Database.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        public string AuthorID { get; set; }

        public int CarID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public double Rating { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Car Car { get; set; }

    }
}
