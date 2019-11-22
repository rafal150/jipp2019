
using System.Collections.Generic;

namespace UnitConverter.Converters
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string unitFrom, string unitTo, double value);
    }
}
