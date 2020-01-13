using System.Collections.Generic;

namespace UnitConverter.Services
{
    public interface InterfejsKonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}