using System.Collections.Generic;

namespace kalkulator.Services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(int unitFrom, int unitTo, double value);
    }
}