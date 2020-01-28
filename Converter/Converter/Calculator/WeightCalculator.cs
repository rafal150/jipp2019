using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Converter.Calculator;

namespace Converter
{
    public class WeightCalculator : ICalculator
    {
        public string Name => "Weight";

        private static readonly ReadOnlyDictionary<string, decimal> ValuesDictionary =
            new ReadOnlyDictionary<string, decimal>(new Dictionary<string, decimal>
            {
                ["Miligrams"] = 1,
                ["Grams"] = 1000,
                ["Decagrams"] = 10000,
                ["Kilograms"] = 1000000,
                ["Tons"] = 1000000000,
                ["Ounces"] = 28349.523125M,
                ["Pounds"] = 453592.37M,
                ["Carats"] = 200,
                ["Quintals"] = 100000000

            });

        public static decimal GetMultiplier(string from, string to)
        {
            return ValuesDictionary[from] / ValuesDictionary[to];
        }
        public List<string> Units => new List<string>(new[] { "Miligrams", "Grams", "Decagrams","Kilograms","Tons","Ounces", "Pounds", "Carats", "Quintals" });

        public decimal Convert(string fromType, string toType, decimal value)
        {
            var multiplier = GetMultiplier(fromType, toType);

            var convertedValue = value * multiplier;

            return convertedValue;
        }
    }
}