using CarsCatalog.Database.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCatalog.Database
{
    public class CarsCatalogContext : IdentityDbContext<ApplicationUser>
    {
        public CarsCatalogContext()
            : base("CarsCatalog")
        {

        }

        public static CarsCatalogContext Create()
        {
            return new CarsCatalogContext();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
    }
}
