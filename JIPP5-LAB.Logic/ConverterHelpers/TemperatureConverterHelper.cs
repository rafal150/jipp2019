using JIPP5_LAB.DataProviders;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Unity;

namespace JIPP5_LAB.ConverterHelpers
{
    public class TemperatureConverterHelper : IConverterHelper
    {
        private IDataHelper DataHelper { get; }
        private IUnityContainer Container { get; }

        public string Name => "Temperatura";

        public List<string> UnitTypes => new List<string> {
            "Celsius",
            "Fahrenheit",
            "Kelvin",
            "Rankine"
        };

        public TemperatureConverterHelper(IDataHelper dataHelper, IUnityContainer unityContainer)
        {
            DataHelper = dataHelper;
            Container = unityContainer;
        }

        public string Convert(string fromUnit, decimal input, string toUnit, out decimal convertedValue)
        {
            convertedValue = ConverterLogic[fromUnit][toUnit].Invoke(input);
            return string.Format("{0} {1}", convertedValue.ToString("N", new NumberFormatInfo() { NumberDecimalDigits = 2 }), toUnit);
        }

        public Dictionary<string, Dictionary<string, Func<decimal, decimal>>> ConverterLogic => new Dictionary<string, Dictionary<string, Func<decimal, decimal>>>()
        {
            {
                "Celsius",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Kelvin"] = (input)=> input + (decimal)273.15,
                    ["Celsius"] = (input)=> input,
                    ["Fahrenheit"] = (input)=> ((input + 40) * (decimal)1.8)-40,
                    ["Rankine"] = (input)=> (input + (decimal)273.15) * (decimal)1.8,
                }
            },
            {
                "Kelvin",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Kelvin"] = (input)=> input,
                    ["Celsius"] = (input)=> input - (decimal)273.15,
                    ["Fahrenheit"] = (input)=> (input * (decimal)1.8) - (decimal)459.67,
                    ["Rankine"] = (input)=> input * (decimal)1.8,
                }
            },
            {
                "Fahrenheit",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Kelvin"] = (input)=> (input + (decimal)459.67) * ((decimal)5/(decimal)9),
                    ["Celsius"] = (input)=> (input-32)/(decimal)1.8,
                    ["Fahrenheit"] = (input)=> input,
                    ["Rankine"] = (input)=> input + (decimal)459.67,
                }
            },
            {
                "Rankine",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Kelvin"] = (input)=> input * ((decimal)5/(decimal)9),
                    ["Celsius"] = (input)=> (input - (decimal)491.67) * ((decimal)5/(decimal)9),
                    ["Fahrenheit"] = (input)=> input - (decimal)459.67,
                    ["Rankine"] = (input)=> input,
                }
            },
        };
    }
}