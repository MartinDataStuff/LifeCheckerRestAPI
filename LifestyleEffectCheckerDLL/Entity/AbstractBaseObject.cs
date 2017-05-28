using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifestyleEffectCheckerDLL.Entity
{
    public class AbstractBaseObject
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public string Name { get; set; }
    }
}
