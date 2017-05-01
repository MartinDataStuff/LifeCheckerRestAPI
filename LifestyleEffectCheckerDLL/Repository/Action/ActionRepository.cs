using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Interface;
namespace LifestyleEffectCheckerDLL.Repository.Action
{
    class ActionRepository : IRepository<Entity.Action.Action>
    {
        public Entity.Action.Action Create(Entity.Action.Action item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.Actions == null)
                    return null;
                db.Actions.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public Entity.Action.Action Read(int id)
        {
            using (var db = new LifestyleCheckerContext())
            {
                return db.Actions.Include(action => action.ActionParts).FirstOrDefault(action => action.Id == id);
            }
        }

        public List<Entity.Action.Action> ReadAll()
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.Actions != null)
                    return db.Actions.Include(action => action.ActionParts).ToList();
                return new List<Entity.Action.Action>();
            }
        }

        public Entity.Action.Action Update(Entity.Action.Action item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return item;
            }
        }

        public bool Delete(Entity.Action.Action item)
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
