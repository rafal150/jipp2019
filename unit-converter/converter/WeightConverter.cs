using System;
using System.Collections.Generic;

namespace converter
{
    internal class WeightConverter : IConverter
    {
        public string Name => "Weight";

        public List<string> Units => new List<string>() {
            "mg", "g", "dkg", "kg", "T",
            "uncja", "funt",
            "karat", "kwintal",
        };

        private static readonly Dictionary<string, Func<double, double>> WeightToBase = new Dictionary<string, Func<double, double>>()
        {
            {"mg", x => x * 1e-6f},
            {"g", x => x * 1e-3f},
            {"dkg", x => x * 1e-2f},
            {"kg", x => x},
            {"T", x => x * 1e3f},

            {"uncja", x => x * 0.0283495231f},
            {"funt", x => x * 0.45359237f},

            {"karat", x => x / 5000f},
            {"kwintal", x => x  * 100f},
        };


        private static readonly Dictionary<string, Func<double, double>> WeightFromBase = new Dictionary<string, Func<double, double>>()
        {
            {"mg", x => x * 1e6f},
            {"g", x => x * 1e3f},
            {"dkg", x => x * 1e2f},
            {"kg", x => x},
            {"T", x => x * 1e-3f},

            {"uncja", x => x / 0.0283495231f},
            {"funt", x => x / 0.45359237f},

            {"karat", x => x * 5000f},
            {"kwintal", x => x  / 100f},
        };

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == unitTo)
            {
                return value;
            }

            return WeightFromBase[unitTo](WeightToBase[unitFrom](value));
        }
    }
}
