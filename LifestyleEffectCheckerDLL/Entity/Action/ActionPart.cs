using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifestyleEffectCheckerDLL.Entity.Action
{
    public class ActionPart : AbstractBaseObject
    {

        public int parentID { get; set; } = -1;
        

        public List<PartInformation> PartInformations { get; set; } = new List<PartInformation>();
    }
}
