using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    public interface IRepository<T>
    {
        void Save(T dto);
        IEnumerable<T> GetAll();
    }
}
