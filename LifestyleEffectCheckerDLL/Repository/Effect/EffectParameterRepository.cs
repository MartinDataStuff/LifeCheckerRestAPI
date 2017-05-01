using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Entity.Effect;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerDLL.Repository.Effect
{
    class EffectParameterRepository : IRepository<EffectParameter>
    {
        public EffectParameter Create(EffectParameter item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.EffectParameters == null)
                    return null;
                db.EffectParameters.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public EffectParameter Read(int id)
        {
            using (var db = new LifestyleCheckerContext())
            {
                return db.EffectParameters.FirstOrDefault(parameter =>  parameter.Id == id);
            }
        }

        public List<EffectParameter> ReadAll()
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.EffectParameters != null)
                    return db.EffectParameters.ToList();
                return new List<EffectParameter>();
            }
        }

        public EffectParameter Update(EffectParameter item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return item;
            }
        }

        public bool Delete(EffectParameter item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Read(item.Id) == null;
            }
        }
    }
}
