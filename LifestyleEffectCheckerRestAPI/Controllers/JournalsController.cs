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
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Entity;
using LifestyleEffectCheckerDLL.Facade;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerRestAPI.Controllers
{
    public class JournalsController : ApiController
    {
        private IRepository<Journal> db = new RepositoryFacade().GetJournalRepository();

        // GET: api/Journals
        public List<Journal> GetJournals()
        {
            return db.ReadAll();
        }

        // GET: api/Journals/5
        [ResponseType(typeof(Journal))]
        public IHttpActionResult GetJournal(int id)
        {
            Journal journal = db.Read(id);
            if (journal == null)
            {
                return NotFound();
            }

            return Ok(journal);
        }

        // PUT: api/Journals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJournal(int id, Journal journal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != journal.Id)
            {
                return BadRequest();
            }
            

            try
            {
                db.Update(journal);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(id))
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

        // POST: api/Journals
        [ResponseType(typeof(Journal))]
        public IHttpActionResult PostJournal(Journal journal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(journal);
            return CreatedAtRoute("DefaultApi", new { id = journal.Id }, journal);
        }

        // DELETE: api/Journals/5
        [ResponseType(typeof(Journal))]
        public IHttpActionResult DeleteJournal(int id)
        {
            Journal journal = db.Read(id);
            if (journal == null)
            {
                return NotFound();
            }

            db.Delete(journal);

            return Ok(journal);
        }


        private bool JournalExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}