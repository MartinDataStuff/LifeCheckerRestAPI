using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Context;
using LifestyleEffectCheckerDLL.Entity;
using LifestyleEffectCheckerDLL.Interface;

namespace LifestyleEffectCheckerDLL.Repository
{
    class JournalRepository : IRepository<Journal>
    {
        public Journal Create(Journal item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.Journals == null)
                    return null;
                db.Journals.Add(item);
                db.SaveChanges();
                return item;
            }
        }

        public Journal Read(int id)
        {
            using (var db = new LifestyleCheckerContext())
            {
                return db.Journals.Include(journal => journal.Actions).FirstOrDefault(journal => journal.Id == id);
            }
        }

        public List<Journal> ReadAll()
        {
            using (var db = new LifestyleCheckerContext())
            {
                if (db.Journals != null)
                    return db.Journals.Include(journal => journal.Actions).ToList();
                return new List<Journal>();
            }
        }

        public Journal Update(Journal item)
        {
            using (var db = new LifestyleCheckerContext())
            {
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return item;
            }
        }

        public bool Delete(Journal item)
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
