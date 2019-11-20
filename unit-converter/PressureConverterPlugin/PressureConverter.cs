using converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureConverterPlugin
{
    public class PressureConverter : IConverter
    {
        public string Name => "Pressure";

        public List<string> Units => new List<string>() { "Pa", "hPa", "Bar", "at", "atm", "mmHg", "psi" };

        private static readonly Dictionary<string, Func<double, double>> PressureToBase = new Dictionary<string, Func<double, double>>()
        {
            {"Pa", x => x},
            {"hPa", x => x * 100},
            {"Bar", x => x * 100000},
            {"at", x => x * 98066.5},
            {"atm", x => x * 101325},
            {"mmHg", x => x * 133.322},
            {"psi", x => x * 6894.76},
        };

        private static readonly Dictionary<string, Func<double, double>> PressureFromBase = new Dictionary<string, Func<double, double>>()
        {
            {"Pa", x => x},
            {"hPa", x => x / 100},
            {"Bar", x => x / 100000},
            {"at", x => x / 98066.5},
            {"atm", x => x / 101325},
            {"mmHg", x => x / 133.322},
            {"psi", x => x / 6894.76},
        };

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == unitTo)
            {
                return value;
            }

            return PressureFromBase[unitTo](PressureToBase[unitFrom](value));
        }
    }
}
