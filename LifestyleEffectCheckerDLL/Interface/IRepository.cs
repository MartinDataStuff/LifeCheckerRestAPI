using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifestyleEffectCheckerDLL.Entity;

namespace LifestyleEffectCheckerDLL.Interface
{
    public interface IRepository <T> where T : AbstractBaseObject
    {
        T Create(T item);

        T Read(int id);

        List<T> ReadAll();

        T Update(T item);

        bool Delete(T item);
    }
}
