using System.Collections.Generic;

namespace konwerter.services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string inputUnit, string outputUnit, decimal value);
    }
}
