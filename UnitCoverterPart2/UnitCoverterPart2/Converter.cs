using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2
{
    class Converter
    {

        private readonly Dictionary<Tuple<String, String>, UnitConversion> _conversions = new Dictionary<Tuple<string, string>, UnitConversion>();

        public double Convert(String from, String to, double value)
        {
            if (from.Equals(to))
            {
                return value;
            }

            var conversionKey = new Tuple<String, String>(from, to);
            if (!_conversions.ContainsKey(conversionKey))
            {
                throw new ArgumentException("Nieznana konwersja from " + from + " to " + to);
            }
            return _conversions[conversionKey].Convert(value);
        }

        public void AddConvertion(String from, String to, Func<double, double> conversionFunc, Func<double, double> reconversionFunc)
        {
            var conversionKey = new Tuple<String, String>(from, to);
            _conversions[conversionKey] = new UnitConversion(from, to, conversionFunc);
            var conversionKey2 = new Tuple<String, String>(to, from);
            _conversions[conversionKey2] = new UnitConversion(to, from, reconversionFunc);
        }

        internal List<string> GetKeysFrom() => _conversions.Keys.Select(x => x.Item1).Distinct().ToList();

        internal List<string> GetKeysTo(string from) => _conversions.Keys.Where(x => x.Item1 == from).Select(x => x.Item2).Distinct().ToList();
    }
}
