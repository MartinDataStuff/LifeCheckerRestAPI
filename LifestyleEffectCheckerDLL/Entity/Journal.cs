using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifestyleEffectCheckerDLL.Entity
{
    public class Journal : AbstractBaseObject
    {
        
        public List<Action.Action> Actions { get; set; } = new List<Action.Action>();
    }
}
