using System.Collections.Generic;

namespace UnitConversion
{
    public class WeightConverter : UnitConverter
    {
        List<Unit> units;
        public override string Name => "Konwerter masy";

        public override List<Unit> Units => units;

        public WeightConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new List<Unit>();
            units.Add(new Unit("mg", (x) => x, (x) => x));
            units.Add(new Unit("g", (x) => x / 1000m, (x) => x * 1000m));
            units.Add(new Unit("dkg", (x) => x / 10000m, (x) => x * 10000m));
            units.Add(new Unit("kg", (x) => x / 1000000m, (x) => x * 1000000));
            units.Add(new Unit("T", (x) => x / 1000000000m, (x) => x * 1000000000));
            units.Add(new Unit("uncja", (x) => x / 28349.5231m, (x) => x * 28349.5231m));
            units.Add(new Unit("funt", (x) => x / 453592.37m, (x) => x * 453592.37m));
            units.Add(new Unit("karat", (x) => x / 200m, (x) => x * 200m));
            units.Add(new Unit("kwintal", (x) => x / 100000000m, (x) => x * 100000000m));
        }


    }
}
