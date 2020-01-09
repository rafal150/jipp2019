using System.Collections.Generic;

namespace UnitConversion
{
    [ConverterClassType(ClassType.Constant)]
    public class TemperatureConverter : UnitConverter
    {
        private string name = "Konwerter temperatur";
        public override string Name
        {
            get => name;
            set => name = value;
        }

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
