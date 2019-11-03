using System;
using System.Collections.Generic;

namespace converter
{
    enum UnitsType
    {
        Temperature,
        Length,
        Weight,
    }


    class UnitConverter
    {
        public UnitsType unitsType = UnitsType.Temperature;

        public string fromUnit = "";
        public string toUnit = "";

        private static readonly Dictionary<string, Func<float, float>> TemperatureToBase = new Dictionary<string, Func<float, float>>()
        {
            {"C", x => x + 273.15f},
            {"K", x => x},
            {"F", x => (x + 459.67f) * (5f/9f)},
            {"R", x => x * (5f/9f)},
        };


        private static readonly Dictionary<string, Func<float, float>> TemperatureFromBase = new Dictionary<string, Func<float, float>>()
        {
            {"C", x => x - 273.15f},
            {"K", x => x},
            {"F", x => (x * (9f/5f)) - 459.67f},
            {"R", x => x * (9f/5f)},
        };

        private static readonly Dictionary<string, Func<float, float>> LengthToBase = new Dictionary<string, Func<float, float>>()
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


        private static readonly Dictionary<string, Func<float, float>> LengthFromBase = new Dictionary<string, Func<float, float>>()
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

        private static readonly Dictionary<string, Func<float, float>> WeightToBase = new Dictionary<string, Func<float, float>>()
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


        private static readonly Dictionary<string, Func<float, float>> WeightFromBase = new Dictionary<string, Func<float, float>>()
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


        public List<string> GetUnits()
        {
            switch (unitsType)
            {
                case UnitsType.Temperature:
                    return new List<string>() { "C", "F", "K", "R" };
                case UnitsType.Length:
                    return new List<string>() {
                        "mm", "cm", "dcm", "m", "km",
                        "cal", "stopa", "jard", "mila",
                        "kabel", "mila morska",
                    };
                case UnitsType.Weight:
                    return new List<string>() {
                        "mg", "g", "dkg", "kg", "T",
                        "uncja", "funt",
                        "karat", "kwintal",
                    };
            }

            return new List<string>();
        }

        public float Convert(float from)
        {
            if (fromUnit == toUnit)
                return from;

            return ConvertFromBase(ConvertToBase(from));
        }

        private float ConvertToBase(float from)
        {
            switch (unitsType)
            {
                case UnitsType.Temperature:
                    return TemperatureToBase[fromUnit](from);
                case UnitsType.Length:
                    return LengthToBase[fromUnit](from);
                case UnitsType.Weight:
                    return WeightToBase[fromUnit](from);
            }

            throw new Exception("Unknow unit type: " + unitsType.ToString());
        }

        private float ConvertFromBase(float from)
        {
            switch (unitsType)
            {
                case UnitsType.Temperature:
                    return TemperatureFromBase[toUnit](from);
                case UnitsType.Length:
                    return LengthFromBase[toUnit](from);
                case UnitsType.Weight:
                    return WeightFromBase[toUnit](from);
            }

            throw new Exception("Unknow unit type: " + unitsType.ToString());
        }
    }
}
