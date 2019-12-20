using System.Collections.Generic;

namespace UnitConversion
{
    public class TemperatureConverter : UnitConverter
    {
        Dictionary<string, Unit> units;

        public override string Name => "Konwerter temperatur";

        public override Dictionary<string, Unit> Units => units;

        public TemperatureConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new Dictionary<string, Unit>();
            units.Add("C", new Unit("C", (x) => x, (x) => x));
            units.Add("F", new Unit("F", (x) => 32 + (1.8m * x), (x) => (5m/9m) * (x - 32)));
            units.Add("R", new Unit("R", (x) => (x + 273.15m) * 1.8m, (x) => (x / 1.8m) - 273.15m));
            units.Add("K", new Unit("K", (x) => x + 273.15m, (x) => x - 273.15m));
        }
    }
}
