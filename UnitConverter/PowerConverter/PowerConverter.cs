using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion;

namespace PowerConverter
{
    public class PowerConverter : UnitConverter
    {
        private List<Unit> units;

        public override string Name => "Konwerter mocy";

        public override List<Unit> Units => units;

        public PowerConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new List<Unit>();
            units.Add(new Unit("Watt", (x) => x, (x) => x));
            units.Add(new Unit("Kilowat", (x) => x / 1000m, (x) => x * 1000m));
            units.Add(new Unit("Koń mechaniczny", (x) => x / 735.49875m, (x) => x * 735.49875m));
            units.Add(new Unit("Koń parowy", (x) => x / 745.69987158227022m, (x) => x * 745.69987158227022m));
            units.Add(new Unit("BTU/godzinę", (x) => x / 0.293071m, (x) => x * 0.293071m));
            units.Add(new Unit("BTU/minutę", (x) => x / 17.584264m, (x) => x * 17.584264m));
            units.Add(new Unit("BTU/sekundę", (x) => x / 1055.05585262m, (x) => x * 1055.05585262m));
        }
    }
}
