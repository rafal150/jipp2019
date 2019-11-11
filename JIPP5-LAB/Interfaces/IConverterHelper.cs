using System.Collections.Generic;

namespace JIPP5_LAB.Interfaces
{
    public interface IConverterHelper
    {
        string Name { get; }
        List<string> UnitTypes { get; }

        string Convert(string fromUnit, decimal input, string toUnit);
    }
}