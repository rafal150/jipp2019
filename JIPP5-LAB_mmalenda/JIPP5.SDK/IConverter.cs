using System.Collections.Generic;

namespace JIPP5.SDK
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }

        decimal Converter(string FromUNIT, decimal RawVALUE, string ToUNIT);
    }
}