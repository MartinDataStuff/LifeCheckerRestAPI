using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Entity.Action;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerDLL.Repository.Action
{
    class PartInformationRepository : IRepository<PartInformation>
    {
        public PartInformation Create(PartInformation item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.PartInformations == null)
                    return null;
                db.PartInformations.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public PartInformation Read(int id)
        {
            using (var db = new LifestyleCheckerContext())
            {
                return db.PartInformations.FirstOrDefault(actionParts => actionParts.Id == id);
            }
        }

        public List<PartInformation> ReadAll()
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.PartInformations != null)
                    return db.PartInformations.ToList();
                return new List<PartInformation>();
            }
        }

        public PartInformation Update(PartInformation item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return item;
            }
        }

        public bool Delete(PartInformation item)
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
