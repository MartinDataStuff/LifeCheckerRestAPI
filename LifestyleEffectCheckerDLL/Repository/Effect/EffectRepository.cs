using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerDLL.Repository.Effect
{
    class EffectRepository : IRepository<Entity.Effect.Effect>
    {
        public Entity.Effect.Effect Create(Entity.Effect.Effect item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.Effects == null)
                    return null;
                db.Effects.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public Entity.Effect.Effect Read(int id)
        {
            using (var db = new LifestyleCheckerContext())
            {
                return db.Effects.Include(effect => effect.EffectParameters).FirstOrDefault(effect => effect.Id == id);
            }
        }

        public List<Entity.Effect.Effect> ReadAll()
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.Effects != null)
                    return db.Effects.Include(effect => effect.EffectParameters).ToList();
                return new List<Entity.Effect.Effect>();
            }
        }
    

        public Entity.Effect.Effect Update(Entity.Effect.Effect item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return item;
            }
        }

        public bool Delete(Entity.Effect.Effect item)
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
