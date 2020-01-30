using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Converter.Calculator
{
    public class PressureCalculator : ICalculator
    {
        private static readonly ReadOnlyDictionary<string, decimal> ValuesDictionary =
            new ReadOnlyDictionary<string, decimal>(new Dictionary<string, decimal>
            {
                ["Pascal"] = 1,
                ["Hectopascal"] = 100,
                ["Bar"] = 100000,
                ["Psi"] = 6894.757293178M,
                ["Newton/square milimeter"] = 1000000,
                ["Kilogram/square meter"] = 9.80665M,
                ["Technical atmosphere"] = 98066.5M,
                ["Standard atmosphere"] = 101325,
                ["Torr"] = 133.3223684211M,
                ["Milimeter Mercury"] = 133.322M

            });

        public static decimal GetMultiplier(string from, string to)
        {
            return ValuesDictionary[from] / ValuesDictionary[to];
        }

        public string Name => "Pressure";

        public List<string> Units => new List<string>(new[]
        {
            "Pascal", "Hectopascal", "Bar", "Psi", "Newton/square milimeter", "Kilogram/square meter", "Technical atmosphere", "Standard atmosphere", "Torr", "Milimeter Mercury"
        });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            var multiplier = GetMultiplier(unitFrom, unitTo);

            var convertedValue = value * multiplier;

            return convertedValue;
        }
    }
}
