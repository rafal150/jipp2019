using System.Collections.Generic;

namespace UnitConversion
{
    [ConverterClassType(ClassType.Constant)]
    public class LengthConverter : UnitConverter
    {
        private string name = "Konwerter długości";
        public override string Name
        {
            get => name;
            set => name = value;
        }
        public LengthConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new Dictionary<string, Unit>();
            units.Add("mm", new Unit("mm", (x) => x, (x) => x));
            units.Add("cm",new Unit("cm", (x) => x / 10m, (x) => x * 10m));
            units.Add("dcm", new Unit("dcm", (x) => x / 100m, (x) => x * 100));
            units.Add("m", new Unit("m", (x) => x / 1000m, (x) => x * 1000));
            units.Add("km", new Unit("km", (x) => x / 1000000m, (x) => x * 1000000));
            units.Add("cal", new Unit("cal", (x) => x / 25.4m, (x) => x * 25.4m));
            units.Add("stop", new Unit("stop", (x) => x / 304.8m, (x) => x * 304.8m));
            units.Add("jard", new Unit("jard", (x) => x / 914.4m, (x) => x * 914.4m));
            units.Add("mila", new Unit("mila", (x) => x / 1609344m, (x) => x * 1609344m));
            units.Add("kabel", new Unit("kabel", (x) => x / 185166m, (x) => x * 185166m));
            units.Add("mila morska", new Unit("mila morska", (x) => x / 1851660m, (x) => x * 1851660m));
        }
    }
}
