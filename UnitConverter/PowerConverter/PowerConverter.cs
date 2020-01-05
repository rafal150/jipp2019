using System.Collections.Generic;
using UnitConversion;

namespace PowerConverter
{
    public class PowerConverter : UnitConverter
    {

        public override string Name => "Konwerter mocy";

        //public override Dictionary<string, Unit> Units => units;

        public PowerConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new Dictionary<string, Unit>();
            units.Add("Watt", new Unit("Watt", (x) => x, (x) => x));
            units.Add("Kilowat", new Unit("Kilowat", (x) => x / 1000m, (x) => x * 1000m));
            units.Add("Koń mechaniczny", new Unit("Koń mechaniczny", (x) => x / 735.49875m, (x) => x * 735.49875m));
            units.Add("Koń parowy", new Unit("Koń parowy", (x) => x / 745.69987158227022m, (x) => x * 745.69987158227022m));
            units.Add("BTU/godzinę", new Unit("BTU/godzinę", (x) => x / 0.293071m, (x) => x * 0.293071m));
            units.Add("BTU/minutę", new Unit("BTU/minutę", (x) => x / 17.584264m, (x) => x * 17.584264m));
            units.Add("BTU/sekundę", new Unit("BTU/sekundę", (x) => x / 1055.05585262m, (x) => x * 1055.05585262m));
        }
    }
}
