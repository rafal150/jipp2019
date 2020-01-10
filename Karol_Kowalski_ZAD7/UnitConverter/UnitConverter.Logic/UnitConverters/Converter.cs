using System.Collections.Generic;
using System.Linq;
using UnitConverter.SDK;

namespace UnitConverter.Logic.UnitConverters
{
    public class Converter
    {
        private IDictionary<string, IUnitConverter> unitConvertersPerUnit;

        public string Type { get; }

        public IEnumerable<string> Units { get; }

        public Converter(IEnumerable<IUnitConverter> unitConverters, string type)
        {
            unitConvertersPerUnit = unitConverters
                .Where(c => c.Type == type)
                .ToDictionary(g => g.Unit, g => g);

            Type = type;
            Units = unitConvertersPerUnit.Keys;
        }

        public IUnitConverter GetUnitConverterForUnit(string unit)
        {
            return unitConvertersPerUnit[unit];
        }
    }
}
