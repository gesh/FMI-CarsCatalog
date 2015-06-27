using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarsCatalog.Database;
using CarsCatalog.Database.Models;
using CarsCatalog.WebAPI.ViewModels;

namespace CarsCatalog.WebAPI.Controllers
{
    public class CarsController : ApiController
    {
        private CarsCatalogContext db = new CarsCatalogContext();

        // GET: api/Cars
        [HttpGet]
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.ID)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cars
        [HttpPost]
        public IHttpActionResult PostCar(CarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = new Car();

            var manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == carVM.Manufacturer);

            if (manufacturer == null)
            {
                db.Manufacturers.Add(new Manufacturer()
                {
                    Name = carVM.Manufacturer,
                    ImageUrl = "http://cdn.flaticon.com/png/256/66599.png"
                });
                db.SaveChanges();
            }
            car.ManufacturerID = db.Manufacturers.FirstOrDefault(m => m.Name == carVM.Manufacturer).ID;
            car.Model = carVM.Model;
            car.Year = carVM.Year;
            car.ImageUrl = carVM.ImageUrl;
            car.HorsePowers = carVM.HorsePowers;
            car.Information = carVM.Information;

            db.Cars.Add(car);
            var res = db.SaveChanges();
            return Ok(res);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.ID == id) > 0;
        }
    }
}