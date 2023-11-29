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
using ParcialFinal.Modelo.DB;

namespace WebApi.Controllers
{
    public class FACTURAController : ApiController
    {
        private DesarrolloWebParcialEntities db = new DesarrolloWebParcialEntities();

        // GET: api/FACTURA
        public IQueryable<FACTURA> GetFACTURA()
        {
            return db.FACTURA;
        }

        // GET: api/FACTURA/5
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult GetFACTURA(int id)
        {
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return NotFound();
            }

            return Ok(fACTURA);
        }

        // PUT: api/FACTURA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFACTURA(int id, FACTURA fACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fACTURA.IDFACTURA)
            {
                return BadRequest();
            }

            db.Entry(fACTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FACTURAExists(id))
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

        // POST: api/FACTURA
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult PostFACTURA(FACTURA fACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FACTURA.Add(fACTURA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fACTURA.IDFACTURA }, fACTURA);
        }

        // DELETE: api/FACTURA/5
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult DeleteFACTURA(int id)
        {
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return NotFound();
            }

            db.FACTURA.Remove(fACTURA);
            db.SaveChanges();

            return Ok(fACTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FACTURAExists(int id)
        {
            return db.FACTURA.Count(e => e.IDFACTURA == id) > 0;
        }
    }
}