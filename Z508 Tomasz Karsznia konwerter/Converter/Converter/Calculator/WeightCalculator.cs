using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Converter.Calculator;

namespace Converter
{
    public class WeightCalculator : ICalculator
    {
        public string Name => "Speed";

        private static readonly ReadOnlyDictionary<string, decimal> ValuesDictionary =
            new ReadOnlyDictionary<string, decimal>(new Dictionary<string, decimal>
            {
                ["M/s"] = 340,
                ["Mach"] = 1,
           
            });

        public static decimal GetMultiplier(string from, string to)
        {
            return ValuesDictionary[from] / ValuesDictionary[to];
        }
        public List<string> Units => new List<string>(new[] { "M/s", "Mach"});

        public decimal Convert(string fromType, string toType, decimal value)
        {
            var multiplier = GetMultiplier(fromType, toType);

            var convertedValue = value * multiplier;

            return convertedValue;
        }
    }
}