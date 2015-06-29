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
    public class ManufacturersController : ApiController
    {
        private CarsCatalogContext db = new CarsCatalogContext();

        // GET: api/Manufacturers
        public IQueryable<Manufacturer> GetManufacturers()
        {
            return db.Manufacturers;
        }

        // GET: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult GetManufacturer(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        // PUT: api/Manufacturers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.ID)
            {
                return BadRequest();
            }

            db.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

        // POST: api/Manufacturers
        [HttpPost]
        public IHttpActionResult PostManufacturer(ManufacturerViewModel manufacturerVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = db.Manufacturers.FirstOrDefault(m => m.Name == manufacturerVM.Name);
            if (exists == null)
            {

                var manufacturer = new Manufacturer()
                {
                    Name = manufacturerVM.Name,
                    ImageUrl = manufacturerVM.ImageUrl,
                    Information = manufacturerVM.Information  
                };

                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();
            }

            return Ok();
        }

        // DELETE: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();

            return Ok(manufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManufacturerExists(int id)
        {
            return db.Manufacturers.Count(e => e.ID == id) > 0;
        }
    }
}