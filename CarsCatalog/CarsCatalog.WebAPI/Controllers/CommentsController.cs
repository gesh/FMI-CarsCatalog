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
using Microsoft.AspNet.Identity;

namespace CarsCatalog.WebAPI.Controllers
{
    public class CommentsController : ApiController
    {
        private CarsCatalogContext db = new CarsCatalogContext();

        // GET: api/Comments
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }

        // GET: api/Comments/5
        [HttpGet]
        public IHttpActionResult GetComment(int id)
        {
            var comments = new List<Comment>();
            comments = db.Comments.Where(c => c.CarID == id).ToList();

            return Ok(comments);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.ID)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [HttpPost]
        public IHttpActionResult PostComment(CommentViewModel commentVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Comment comment = new Comment()
            {
                AuthorID = this.User.Identity.GetUserId(),
                AuthorName = this.User.Identity.Name,
                CarID = commentVM.CarID,
                Title = commentVM.Title,
                Body = commentVM.Body,
                Rating = commentVM.Rating
            };

            db.Comments.Add(comment);
            var res = db.SaveChanges();

            return Ok(res);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.ID == id) > 0;
        }
    }
}