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
using Project_Web_Api.Models;

namespace Project_Web_Api.Controllers
{
    public class EmployersController : ApiController
    {
        private CRUDDBEntities db = new CRUDDBEntities();

        // GET: api/Employers
        public IQueryable<Employer> GetEmployer()
        {
            return db.Employer;
        }

        // GET: api/Employers/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult GetEmployer(int id)
        {
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }

        // PUT: api/Employers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployer(int id, Employer employer)
        {
            
            if (id != employer.EmployerId)
            {
                return BadRequest();
            }

            db.Entry(employer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        // POST: api/Employers
        [ResponseType(typeof(Employer))]
        public IHttpActionResult PostEmployer(Employer employer)
        {
           

            db.Employer.Add(employer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employer.EmployerId }, employer);
        }

        // DELETE: api/Employers/5
        [ResponseType(typeof(Employer))]
        public IHttpActionResult DeleteEmployer(int id)
        {
            Employer employer = db.Employer.Find(id);
            if (employer == null)
            {
                return NotFound();
            }

            db.Employer.Remove(employer);
            db.SaveChanges();

            return Ok(employer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployerExists(int id)
        {
            return db.Employer.Count(e => e.EmployerId == id) > 0;
        }
    }
}