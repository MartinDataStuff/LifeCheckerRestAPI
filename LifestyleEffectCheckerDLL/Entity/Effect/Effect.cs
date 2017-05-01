using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifestyleEffectCheckerDLL.Entity.Effect
{
    public class Effect : AbstractBaseObject
    {
        public List<EffectParameter> EffectParameters { get; set; } = new List<EffectParameter>();
    }
}
