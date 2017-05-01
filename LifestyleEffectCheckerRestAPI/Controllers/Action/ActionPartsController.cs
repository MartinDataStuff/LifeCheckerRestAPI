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

namespace LifestyleEffectCheckerRestAPI.Controllers
{
    public class ActionPartsController : ApiController
    {
        private readonly IRepository<ActionPart> db = new RepositoryFacade().GetActionPartRepository();

        // GET: api/ActionParts
        public List<ActionPart> GetActionParts()
        {
            return db.ReadAll();
        }

        // GET: api/ActionParts/5
        [ResponseType(typeof(ActionPart))]
        public IHttpActionResult GetActionPart(int id)
        {
            ActionPart actionPart = db.Read(id);
            if (actionPart == null)
            {
                return NotFound();
            }

            return Ok(actionPart);
        }

        // PUT: api/ActionParts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActionPart(int id, ActionPart actionPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actionPart.Id)
            {
                return BadRequest();
            }
            

            try
            {
                db.Update(actionPart);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionPartExists(id))
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

        // POST: api/ActionParts
        [ResponseType(typeof(ActionPart))]
        public IHttpActionResult PostActionPart(ActionPart actionPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(actionPart);
 

            return CreatedAtRoute("DefaultApi", new { id = actionPart.Id }, actionPart);
        }

        // DELETE: api/ActionParts/5
        [ResponseType(typeof(ActionPart))]
        public IHttpActionResult DeleteActionPart(int id)
        {
            ActionPart actionPart = db.Read(id);
            if (actionPart == null)
            {
                return NotFound();
            }

            db.Delete(actionPart);

            return Ok(actionPart);
        }

        private bool ActionPartExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}