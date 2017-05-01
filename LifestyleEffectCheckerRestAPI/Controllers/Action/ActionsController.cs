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

using MyAction = LifestyleEffectCheckerDLL.Entity.Action.Action;

namespace LifestyleEffectCheckerRestAPI.Controllers
{
    public class ActionsController : ApiController
    {

        private readonly IRepository<MyAction> db = new RepositoryFacade().GetActionRepository();

        // GET: api/Actions
        public List<MyAction> GetActions()
        {
            return db.ReadAll();
        }

        // GET: api/Actions/5
        [ResponseType(typeof(MyAction))]
        public IHttpActionResult GetAction(int id)
        {
            MyAction action = db.Read(id);
            if (action == null)
            {
                return NotFound();
            }

            return Ok(action);
        }

        // PUT: api/Actions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAction(int id, MyAction action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != action.Id)
            {
                return BadRequest();
            }
            
            try
            {
                db.Update(action);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionExists(id))
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

        // POST: api/Actions
        [ResponseType(typeof(MyAction))]
        public IHttpActionResult PostAction(MyAction action)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(action);

            return CreatedAtRoute("DefaultApi", new { id = action.Id }, action);
        }

        // DELETE: api/Actions/5
        [ResponseType(typeof(MyAction))]
        public IHttpActionResult DeleteAction(int id)
        {
            MyAction action = db.Read(id);
            if (action == null)
            {
                return NotFound();
            }

            db.Delete(action);

            return Ok(action);
        }
        
        private bool ActionExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}