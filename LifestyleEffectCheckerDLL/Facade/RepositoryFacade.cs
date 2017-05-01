using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Entity;
using LifestyleEffectCheckerDLL.Entity.Action;
using LifestyleEffectCheckerDLL.Entity.Effect;
using LifestyleEffectCheckerDLL.Interface;
using LifestyleEffectCheckerDLL.Repository;
using LifestyleEffectCheckerDLL.Repository.Action;
using LifestyleEffectCheckerDLL.Repository.Effect;
using Action = LifestyleEffectCheckerDLL.Entity.Action.Action;

namespace LifestyleEffectCheckerDLL.Facade
{
    public class RepositoryFacade 
    {
        public IRepository<Action> GetActionRepository()
        {
            return new ActionRepository();
        }
        public IRepository<ActionPart> GetActionPartRepository()
        {
            return new ActionPartRepository();
        }

        public IRepository<PartInformation> GetPartInformationRepository()
        {
            return new PartInformationRepository();
        }

        public IRepository<Effect> GetEffectRepository()
        {
            return new EffectRepository();
        }

        public IRepository<EffectParameter> GetEffectParameterRepository()
        {
            return new EffectParameterRepository();
        }

        public IRepository<Journal> GetJournalRepository()
        {
            return new JournalRepository();
        }
    }
}
