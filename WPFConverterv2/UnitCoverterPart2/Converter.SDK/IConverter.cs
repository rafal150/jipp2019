using System.Collections.Generic;

namespace UnitCoverterPart2.Services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string unitFrom, string unitTo, double value);
    }
}