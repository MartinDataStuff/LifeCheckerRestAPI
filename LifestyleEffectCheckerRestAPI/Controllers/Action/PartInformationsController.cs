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
using LifestyleEffectCheckerDLL.Entity.Action;
using LifestyleEffectCheckerDLL.Facade;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerRestAPI.Controllers.Action
{
    public class PartInformationsController : ApiController
    {
        private IRepository<PartInformation> db = new RepositoryFacade().GetPartInformationRepository();

        // GET: api/PartInformations
        public List<PartInformation> GetPartInformations()
        {
            return db.ReadAll();
        }

        // GET: api/PartInformations/5
        [ResponseType(typeof(PartInformation))]
        public IHttpActionResult GetPartInformation(int id)
        {
            PartInformation partInformation = db.Read(id);
            if (partInformation == null)
            {
                return NotFound();
            }

            return Ok(partInformation);
        }

        // PUT: api/PartInformations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartInformation(int id, PartInformation partInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partInformation.Id)
            {
                return BadRequest();
            }
            

            try
            {
                db.Update(partInformation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartInformationExists(id))
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

        // POST: api/PartInformations
        [ResponseType(typeof(PartInformation))]
        public IHttpActionResult PostPartInformation(PartInformation partInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(partInformation);

            return CreatedAtRoute("DefaultApi", new { id = partInformation.Id }, partInformation);
        }

        // DELETE: api/PartInformations/5
        [ResponseType(typeof(PartInformation))]
        public IHttpActionResult DeletePartInformation(int id)
        {
            PartInformation partInformation = db.Read(id);
            if (partInformation == null)
            {
                return NotFound();
            }

            db.Delete(partInformation);

            return Ok(partInformation);
        }


        private bool PartInformationExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}