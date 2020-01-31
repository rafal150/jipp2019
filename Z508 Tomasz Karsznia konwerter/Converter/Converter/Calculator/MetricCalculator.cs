using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Converter.Calculator;

namespace Converter
{
    public class MetricCalculator : ICalculator
    {
        public MetricCalculator()
        {
        }

        private static readonly ReadOnlyDictionary<string, decimal> ValuesDictionary =
            new ReadOnlyDictionary<string, decimal>(new Dictionary<string, decimal>
            {
                ["Milimeters"] = 1,
                ["Centimeters"] = 10,
                ["Decimeters"] = 100,
                ["Meters"] = 1000,
                ["Kilometers"] = 1000000,
                ["Inches"] = 25.4M,
                ["Yards"] = 914.4M,
                ["Miles"] = 1609344,
                ["Cables"] = 185318,
                ["Nautical Miles"] = 1853180

            });

        public static decimal GetMultiplier(string from, string to)
        {
            return ValuesDictionary[from] / ValuesDictionary[to];
        }

        public string Name => "Metric";

        public List<string> Units => new List<string>(new[] { "Milimeters", "Centimeters", "Decimeters" ,"Meters", "Kilometers", "Inches", "Yards", "Miles", "Cables", "Nautical Miles" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            var multiplier = GetMultiplier(unitFrom, unitTo);

            var convertedValue = value * multiplier;

            return convertedValue;
        }
    }
}
