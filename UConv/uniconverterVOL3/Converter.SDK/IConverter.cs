using System.Collections.Generic;

namespace UnitConverter.Services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string temp, float input);

        float toBaseUnit(string temp, float input);
    }

}
