using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationWpf
{
    class ConvSupply
    {
        public static string[] suffix;
        public static int toIndex, fromIndex;
        public static double value;
        public static double convertedValue;
        public static string converterName;

        public static void pairData(string[] _suffix, int _fromIndex, int _toIndex, double _value, double _convertedValue, string _converterName)
        {
            suffix = _suffix;
            toIndex = _toIndex;
            fromIndex = _fromIndex;
            value = _value;
            convertedValue = _convertedValue;
            converterName = _converterName;

        }

        public static string GetConvertedString()
        {
            if (convertedValue != double.NaN)
                return $"{convertedValue} {suffix[toIndex]}";
            else return "NaN";
        }

        public static void AddDbEntry()
        {
            MainWindow.repo.AddStatistic(new StatisticsDTO()
            {
                Date = DateTime.Now,
                SourceUnit = suffix[fromIndex],
                SourceValue = value,
                ConvertedUnit = suffix[toIndex],
                ConvertedValue = convertedValue,
                Type = converterName
            });
        }
    }
}
