using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafal_Ciupak_converter
{
    interface IRepository<T>
    {
        void Save(T dto);
        IEnumerable<T> GetAll();
    }
}
