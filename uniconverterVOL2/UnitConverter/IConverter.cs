using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    interface IConverter
    {
        float toBaseUnit(string unit, float input);
        float toUnit(string unit, float baseValue);
    }
}
