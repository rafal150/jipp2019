using System.Collections.Generic;

namespace UnitConversion
{
    public class LengthConverter : UnitConverter
    {
        List<Unit> units;
        public override string Name => "Konwerter długości";

        public override List<Unit> Units => units;

        public LengthConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new List<Unit>();
            units.Add(new Unit("mm", (x) => x, (x) => x));
            units.Add(new Unit("cm", (x) => x / 10m, (x) => x * 10m));
            units.Add(new Unit("dcm", (x) => x / 100m, (x) => x * 100));
            units.Add(new Unit("m", (x) => x / 1000m, (x) => x * 1000));
            units.Add(new Unit("km", (x) => x / 1000000m, (x) => x * 1000000));
            units.Add(new Unit("cal", (x) => x / 25.4m, (x) => x * 25.4m));
            units.Add(new Unit("stop", (x) => x / 304.8m, (x) => x * 304.8m));
            units.Add(new Unit("jard", (x) => x / 914.4m, (x) => x * 914.4m));
            units.Add(new Unit("mila", (x) => x / 1609344m, (x) => x * 1609344m));
            units.Add(new Unit("kabel", (x) => x / 185166m, (x) => x * 185166m));
            units.Add(new Unit("mila morska", (x) => x / 1851660m, (x) => x * 1851660m));
        }
    }
}
