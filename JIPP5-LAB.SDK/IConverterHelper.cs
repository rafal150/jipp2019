using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.SDK
{
    public interface IConverterHelper
    {
        string Name { get; }
        List<string> UnitTypes { get; }
        string Convert(string fromUnit, decimal input, string toUnit, out decimal convertedValue);
    }
}
