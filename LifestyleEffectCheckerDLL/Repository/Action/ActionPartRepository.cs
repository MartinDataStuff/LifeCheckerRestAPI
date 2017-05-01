using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Entity.Action;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerDLL.Repository.Action
{
    class ActionPartRepository : IRepository<ActionPart>
    {
        public ActionPart Create(ActionPart item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.ActionParts == null)
                    return null;
                db.ActionParts.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public ActionPart Read(int id)
        {
            using (var db = new LifestyleCheckerContext())
            {
                return db.ActionParts.Include(part => part.PartInformations).FirstOrDefault(actionParts => actionParts.Id == id);
            }
        }

        public List<ActionPart> ReadAll()
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.ActionParts != null)
                    return db.ActionParts.Include(part => part.PartInformations).ToList();
                return new List<ActionPart>();
            }
        }

        public ActionPart Update(ActionPart item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return item;
            }
        }

        public bool Delete(ActionPart item)
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
