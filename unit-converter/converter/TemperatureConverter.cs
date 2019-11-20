using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    class TemperatureConverter : IConverter
    {
        public string Name => "Temperature";

        public List<string> Units => new List<string>() { "C", "K", "F", "R" };


        private static readonly Dictionary<string, Func<double, double>> TemperatureToBase = new Dictionary<string, Func<double, double>>()
        {
            {"C", x => x + 273.15f},
            {"K", x => x},
            {"F", x => (x + 459.67f) * (5f/9f)},
            {"R", x => x * (5f/9f)},
        };


        private static readonly Dictionary<string, Func<double, double>> TemperatureFromBase = new Dictionary<string, Func<double, double>>()
        {
            {"C", x => x - 273.15f},
            {"K", x => x},
            {"F", x => (x * (9f/5f)) - 459.67f},
            {"R", x => x * (9f/5f)},
        };

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == unitTo)
            {
                return value;
            }

            return TemperatureFromBase[unitTo](TemperatureToBase[unitFrom](value));
        }
    }
}
