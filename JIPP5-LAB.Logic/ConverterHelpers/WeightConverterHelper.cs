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
    public class WeightConverterHelper : IConverterHelper
    {
        private IDataHelper DataHelper { get; }
        private IUnityContainer Container { get; }

        public string Name => "Masa";

        public List<string> UnitTypes => new List<string>() {
            "Miligram",
            "Gram",
            "Decagram",
            "Kilogram",
            "Ton",
            "Ounce",
            "Pound",
            "Carat",
            "Cental",
        };

        public WeightConverterHelper(IDataHelper dataHelper, IUnityContainer unityContainer)
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
                "Miligram",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input,
                    ["Gram"] = (input)=> input/1000,
                    ["Decagram"] = (input)=> input/10000,
                    ["Kilogram"] = (input)=> input/100000,
                    ["Ton"] = (input)=> input/10000000,
                    ["Ounce"] = (input)=> input * (decimal)0.000035,
                    ["Pound"] = (input)=> input * (decimal)0.000002,
                    ["Carat"] = (input)=> input * (decimal)0.005,
                    ["Cental"] = (input)=> input/100000000,
                }
            },
            {
                "Gram",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input*1000,
                    ["Gram"] = (input)=> input,
                    ["Decagram"] = (input)=> input/10,
                    ["Kilogram"] = (input)=> input/1000,
                    ["Ton"] = (input)=> input/1000000,
                    ["Ounce"] = (input)=> input * (decimal)0.035,
                    ["Pound"] = (input)=> input * (decimal)0.002,
                    ["Carat"] = (input)=> input * 5,
                    ["Cental"] = (input)=> input/100000,
                }
            },
            {
                "Decagram",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input*10000,
                    ["Gram"] = (input)=> input*10,
                    ["Decagram"] = (input)=> input,
                    ["Kilogram"] = (input)=> input/100,
                    ["Ton"] = (input)=> input/100000,
                    ["Ounce"] = (input)=> input * (decimal)0.35,
                    ["Pound"] = (input)=> input * (decimal)0.02,
                    ["Carat"] = (input)=> input * 50,
                    ["Cental"] = (input)=> input/10000,
                }
            },
            {
                "Kilogram",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input*1000000,
                    ["Gram"] = (input)=> input*1000,
                    ["Decagram"] = (input)=> input*10,
                    ["Kilogram"] = (input)=> input,
                    ["Ton"] = (input)=> input/1000,
                    ["Ounce"] = (input)=> input * (decimal)350,
                    ["Pound"] = (input)=> input * (decimal)2,
                    ["Carat"] = (input)=> input * 5000,
                    ["Cental"] = (input)=> input/100,
                }
            },
            {
                "Ton",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input*1000000000,
                    ["Gram"] = (input)=> input*1000000,
                    ["Decagram"] = (input)=> input*10000,
                    ["Kilogram"] = (input)=> input*1000,
                    ["Ton"] = (input)=> input,
                    ["Ounce"] = (input)=> input * (decimal)350000,
                    ["Pound"] = (input)=> input * (decimal)2000,
                    ["Carat"] = (input)=> input * 5000000,
                    ["Cental"] = (input)=> input*10,
                }
            },
            {
                "Ounce",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input*(decimal)28349.523,
                    ["Gram"] = (input)=> input*(decimal)28.349523,
                    ["Decagram"] = (input)=> input*(decimal)2.834952,
                    ["Kilogram"] = (input)=> input*(decimal)0.02835,
                    ["Ton"] = (input)=> input*(decimal)0.000028,
                    ["Ounce"] = (input)=> input,
                    ["Pound"] = (input)=> input * (decimal)0.0625,
                    ["Carat"] = (input)=> input * (decimal)141.747615,
                    ["Cental"] = (input)=> input * (decimal)0.000283,
                }
            },
            {
                "Pound",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input*(decimal)453592.4,
                    ["Gram"] = (input)=> input*(decimal)453.59237,
                    ["Decagram"] = (input)=> input*(decimal)45.359237,
                    ["Kilogram"] = (input)=> input*(decimal)0.453592,
                    ["Ton"] = (input)=> input*(decimal)0.000454,
                    ["Ounce"] = (input)=> input * 16,
                    ["Pound"] = (input)=> input,
                    ["Carat"] = (input)=> input * (decimal)2267.96185,
                    ["Cental"] = (input)=> input * (decimal)0.004536,
                }
            },
            {
                "Carat",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Miligram"] = (input)=> input*(decimal)200,
                    ["Gram"] = (input)=> input*(decimal)0.2,
                    ["Decagram"] = (input)=> input*(decimal)0.02,
                    ["Kilogram"] = (input)=> input*(decimal)0.0002,
                    ["Ton"] = (input)=> input*(decimal)0.0000002,
                    ["Ounce"] = (input)=> input * (decimal)0.007055,
                    ["Pound"] = (input)=> input * (decimal)0.000441,
                    ["Carat"] = (input)=> input * (decimal)500000,
                    ["Cental"] = (input)=> input * (decimal)0.000002,
                }
            },
            {
                "Cental",
                new Dictionary<string, Func<decimal, decimal>>(){
                    {"Miligram", (input)=> input*100000000 },
                    {"Gram", (input)=> input*100000 },
                    {"Decagram", (input)=> input*1000 },
                    {"Kilogram", (input)=> input*100 },
                    {"Ton", (input)=> input/10 },
                    {"Ounce", (input)=> input * (decimal)35000 },
                    {"Pound", (input)=> input * (decimal)200 },
                    {"Carat", (input)=> input * 500000 },
                    {"Cental", (input)=> input },
                }
            },
        };
    }
}