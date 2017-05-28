using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Entity;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerDLL.Repository
{
    class PartInformationRepository : IRepository<PartInformation>
    {
        public PartInformation Create(PartInformation item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.PartInformations == null)
                    return null;


                item.Journal = db.Journals.Include(journal => journal.PartInformations).FirstOrDefault(journal => journal.Id == item.Journal.Id);

                db.PartInformations.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public PartInformation Read(int id)
        {
            using (var db = new LifestyleCheckerContext())
            {
                return db.PartInformations.Include(journal => journal.Journal).FirstOrDefault(schoolEvent => schoolEvent.Id == id);
            }
        }

        public List<PartInformation> ReadAll()
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.PartInformations != null)
                    return db.PartInformations.Include(partInformation => partInformation.Journal).ToList();

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
