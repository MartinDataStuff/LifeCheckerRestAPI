using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Entity;
using LifestyleEffectCheckerDLL.Interface;
using LifestyleEffectCheckerDLL.Repository;

namespace LifestyleEffectCheckerDLL.Facade
{
    public class RepositoryFacade 
    {
        public IRepository<PartInformation> GetPartInformationRepository()
        {
            return new PartInformationRepository();
        }

        public IRepository<Journal> GetJournalRepository()
        {
            return new JournalRepository();
        }
    }
}
