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
using LifestyleEffectCheckerDLL.Entity.Effect;
using LifestyleEffectCheckerDLL.Facade;
using LifestyleEffectCheckerDLL.Interface;
using MyEffect = LifestyleEffectCheckerDLL.Entity.Effect.Effect;

namespace LifestyleEffectCheckerRestAPI.Controllers.Effect
{
    public class EffectsController : ApiController
    {
        private IRepository<MyEffect> db = new RepositoryFacade().GetEffectRepository();

        // GET: api/Effects
        public List<MyEffect> GetEffects()
        {
            return db.ReadAll();
        }

        // GET: api/Effects/5
        [ResponseType(typeof(MyEffect))]
        public IHttpActionResult GetEffect(int id)
        {
            MyEffect effect = db.Read(id);
            if (effect == null)
            {
                return NotFound();
            }

            return Ok(effect);
        }

        // PUT: api/Effects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEffect(int id, MyEffect effect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != effect.Id)
            {
                return BadRequest();
            }
            
            try
            {
                db.Update(effect);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EffectExists(id))
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

        // POST: api/Effects
        [ResponseType(typeof(MyEffect))]
        public IHttpActionResult PostEffect(MyEffect effect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(effect);

            return CreatedAtRoute("DefaultApi", new { id = effect.Id }, effect);
        }

        // DELETE: api/Effects/5
        [ResponseType(typeof(MyEffect))]
        public IHttpActionResult DeleteEffect(int id)
        {
            MyEffect effect = db.Read(id);
            if (effect == null)
            {
                return NotFound();
            }

            db.Delete(effect);

            return Ok(effect);
        }

        private bool EffectExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}