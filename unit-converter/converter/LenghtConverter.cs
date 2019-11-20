using System;
using System.Collections.Generic;

namespace converter
{
    internal class LenghtConverter : IConverter
    {
        public string Name => "Lenght";

        public List<string> Units => new List<string>() {
            "mm", "cm", "dcm", "m", "km",
            "cal", "stopa", "jard", "mila",
            "kabel", "mila morska",
        };

        private static readonly Dictionary<string, Func<double, double>> LengthToBase = new Dictionary<string, Func<double, double>>()
        {
            {"mm", x => x * 1e-3f},
            {"cm", x => x * 1e-2f},
            {"dcm", x => x * 1e-1f},
            {"m", x => x},
            {"km", x => x * 1e3f},

            {"cal", x => x * 0.0254f},
            {"stopa", x => x * 0.3048f},
            {"jard", x => x * 0.9144f},
            {"mila", x => x * 1609.344f},

            {"kabel", x => x * 185.2f},
            {"mila morska", x => x * 1852f},
        };


        private static readonly Dictionary<string, Func<double, double>> LengthFromBase = new Dictionary<string, Func<double, double>>()
        {
            {"mm", x => x * 1e3f},
            {"cm", x => x * 1e2f},
            {"dcm", x => x * 1e1f},
            {"m", x => x},
            {"km", x => x * 1e-3f},

            {"cal", x => x / 0.0254f},
            {"stopa", x => x / 0.3048f},
            {"jard", x => x / 0.9144f},
            {"mila", x => x / 1609.344f},

            {"kabel", x => x / 185.2f},
            {"mila morska", x => x / 1852f},
        };

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == unitTo)
            {
                return value;
            }

            return LengthFromBase[unitTo](LengthToBase[unitFrom](value));
        }
    }
}
