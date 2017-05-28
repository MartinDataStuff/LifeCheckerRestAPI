using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifestyleEffectCheckerDLL.Entity
{
    public class Journal : AbstractBaseObject
    {

        public List<PartInformation> PartInformations { get; set; } = new List<PartInformation>();
    }
}
