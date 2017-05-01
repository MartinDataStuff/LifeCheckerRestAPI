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

namespace LifestyleEffectCheckerRestAPI.Controllers.Effect
{
    public class EffectParametersController : ApiController
    {
        private IRepository<EffectParameter> db = new RepositoryFacade().GetEffectParameterRepository();

        // GET: api/EffectParameters
        public List<EffectParameter> GetEffectParameters()
        {
            return db.ReadAll();
        }

        // GET: api/EffectParameters/5
        [ResponseType(typeof(EffectParameter))]
        public IHttpActionResult GetEffectParameter(int id)
        {
            EffectParameter effectParameter = db.Read(id);
            if (effectParameter == null)
            {
                return NotFound();
            }

            return Ok(effectParameter);
        }

        // PUT: api/EffectParameters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEffectParameter(int id, EffectParameter effectParameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != effectParameter.Id)
            {
                return BadRequest();
            }
            
            try
            {
                db.Update(effectParameter);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EffectParameterExists(id))
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

        // POST: api/EffectParameters
        [ResponseType(typeof(EffectParameter))]
        public IHttpActionResult PostEffectParameter(EffectParameter effectParameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Create(effectParameter);

            return CreatedAtRoute("DefaultApi", new { id = effectParameter.Id }, effectParameter);
        }

        // DELETE: api/EffectParameters/5
        [ResponseType(typeof(EffectParameter))]
        public IHttpActionResult DeleteEffectParameter(int id)
        {
            EffectParameter effectParameter = db.Read(id);
            if (effectParameter == null)
            {
                return NotFound();
            }

            db.Delete(effectParameter);

            return Ok(effectParameter);
        }


        private bool EffectParameterExists(int id)
        {
            return db.ReadAll().Count(e => e.Id == id) > 0;
        }
    }
}