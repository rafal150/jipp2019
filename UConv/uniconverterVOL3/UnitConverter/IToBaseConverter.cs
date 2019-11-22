using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    interface IToBaseConverter
    {
        float toBaseUnit(string unit, float input);
        
    }
}
