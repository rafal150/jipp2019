using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public interface InterfaceRepository
    {
        IEnumerable<Values> GetValues();
        void AddCalcs(Values values);
    }
}
