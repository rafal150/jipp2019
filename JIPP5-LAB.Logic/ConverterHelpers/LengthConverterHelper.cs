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
    public class LengthConverterHelper : IConverterHelper
    {
        private IDataHelper DataHelper { get; }
        private IUnityContainer Container { get; }

        public string Name => "Długość";

        public List<string> UnitTypes => new List<string>()
        {
            "Millimeter",
            "Meter",
            "Kilometer",
            "Centymeter",
            "Decimeter",
            "Mile",
            "NauticalMile",
            "Cable",
            "Yard",
            "Inch",
            "Foot",
        };

        public LengthConverterHelper(IDataHelper dataHelper, IUnityContainer unityContainer)
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
                "Milimeter",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Millimeter"] = (input)=> input,
                    ["Meter"] = (input)=> input/1000,
                    ["Kilometer"] = (input)=> input/1000000,
                    ["Centymeter"] = (input)=> input * (decimal)0.1,
                    ["Decimeter"] = (input)=> input * (decimal)0.01,
                    ["Mile"] = (input)=> input * ((decimal)6.2137119223733/(decimal)10000000),
                    ["NauticalMile"] = (input)=> input * ((decimal)5.3995680345572/(decimal)10000000),
                    ["Cable"] = (input)=> input * ((decimal)4.55672208/1000000),
                    ["Yard"] = (input)=> input * (decimal)0.0011963081929167,
                    ["Inch"] = (input)=> input * (decimal)0.039370078740157,
                    ["Foot"] = (input)=> input * (decimal)0.0032808398950131,
                }
            },
            {
                "Meter",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * 1000,
                    ["Meter"] = (input)=> input,
                    ["Kilometer"] = (input)=> input/1000,
                    ["Centymeter"] = (input)=> input * (decimal)100,
                    ["Decimeter"] = (input)=> input * (decimal)10,
                    ["Mile"] = (input)=> input * ((decimal)6.2137119223733/(decimal)10000),
                    ["NauticalMile"] = (input)=> input * ((decimal)5.3995680345572/(decimal)10000),
                    ["Cable"] = (input)=> input * ((decimal)4.55672208/1000),
                    ["Yard"] = (input)=> input * (decimal)1.1963081929167,
                    ["Inch"] = (input)=> input * (decimal)39.370078740157,
                    ["Foot"] = (input)=> input * (decimal)3.2808398950131,
                }
            },
            {
                "Kilometer",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * 1000000,
                    ["Meter"] = (input)=> input * 1000,
                    ["Kilometer"] = (input)=> input,
                    ["Centymeter"] = (input)=> input * (decimal)100000,
                    ["Decimeter"] = (input)=> input * (decimal)10000,
                    ["Mile"] = (input)=> input * ((decimal)6.2137119223733/(decimal)10),
                    ["NauticalMile"] = (input)=> input * ((decimal)5.3995680345572/(decimal)10),
                    ["Cable"] = (input)=> input * ((decimal)4.55672208),
                    ["Yard"] = (input)=> input * (decimal)1196.3081929167,
                    ["Inch"] = (input)=> input * (decimal)39370.078740157,
                    ["Foot"] = (input)=> input * (decimal)3280.8398950131,
                }
            },
            {
                "Centymeter",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * 10,
                    ["Meter"] = (input)=> input / 100,
                    ["Kilometer"] = (input)=> input / 100000,
                    ["Centymeter"] = (input)=> input,
                    ["Decimeter"] = (input)=> input / (decimal)10,
                    ["Mile"] = (input)=> input * ((decimal)6.2137119223733/(decimal)1000000),
                    ["NauticalMile"] = (input)=> input * ((decimal)5.3995680345572/(decimal)100000),
                    ["Cable"] = (input)=> input * ((decimal)4.55672208/10000),
                    ["Yard"] = (input)=> input * (decimal)119.63081929167,
                    ["Inch"] = (input)=> input * (decimal)3937.0078740157,
                    ["Foot"] = (input)=> input * (decimal)328.08398950131,
                }
            },
            {
                "Decimeter",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * 100,
                    ["Meter"] = (input)=> input / 10,
                    ["Kilometer"] = (input)=> input / 10000,
                    ["Centymeter"] = (input)=> input * 10,
                    ["Decimeter"] = (input)=> input,
                    ["Mile"] = (input)=> input * ((decimal)6.2137119223733/(decimal)100000),
                    ["NauticalMile"] = (input)=> input * ((decimal)5.3995680345572/(decimal)10000),
                    ["Cable"] = (input)=> input * ((decimal)4.55672208/1000),
                    ["Yard"] = (input)=> input * (decimal)11.963081929167,
                    ["Inch"] = (input)=> input * (decimal)393.70078740157,
                    ["Foot"] = (input)=> input * (decimal)32.808398950131,
                }
            },
            {
                "Mile",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] =(input)=> input * 1609344,
                    ["Meter"] = (input)=> input * (decimal)1609.344,
                    ["Kilometer"] = (input)=> input * (decimal)1.609344,
                    ["Centymeter"] =(input)=> input * (decimal)160934.4,
                    ["Decimeter"] = (input)=> input * (decimal)16093.44,
                    ["Mile"] = (input)=> input,
                    ["NauticalMile"] = (input)=> input * (decimal)0.868976242,
                    ["Cable"] = (input)=> input * (decimal)7.33333333,
                    ["Yard"] = (input)=> input * 1760,
                    ["Inch"] = (input)=> input * 63360,
                    ["Foot"] = (input)=> input * 5280,
                }
            },
            {
                "NauticalMile",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] =(input)=> input * 18520000,
                    ["Meter"] = (input)=> input * 1852,
                    ["Kilometer"] = (input)=> input * (1852/10000),
                    ["Centymeter"] =(input)=> input * 185200,
                    ["Decimeter"] = (input)=> input * 18520,
                    ["Mile"] = (input)=> input * (decimal)1.15077945,
                    ["NauticalMile"] = (input)=> input,
                    ["Cable"] = (input)=> input * 10,
                    ["Yard"] = (input)=> input * (decimal)2025.37183,
                    ["Inch"] = (input)=> input * (decimal)72913.3858,
                    ["Foot"] = (input)=> input * (decimal)6076.11549,
                }
            },
            {
                "Cable",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * (decimal)21945600,
                    ["Meter"] = (input)=> input * (decimal)219.456,
                    ["Kilometer"] = (input)=> input * (decimal)2.19456,
                    ["Centymeter"] = (input)=> input * (decimal)21945.6,
                    ["Decimeter"] = (input)=> input * (decimal)2194.56,
                    ["Mile"] = (input)=> input * (decimal)0.13636363636364,
                    ["NauticalMile"] = (input)=> input * (decimal)0.12,
                    ["Cable"] = (input)=> input,
                    ["Yard"] = (input)=> input * 240,
                    ["Inch"] = (input)=> input * 8640,
                    ["Foot"] = (input)=> input * 720,
                }
            },
            {
                "Yard",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * (decimal)914.4,
                    ["Meter"] = (input)=> input * (decimal)0.9144,
                    ["Kilometer"] = (input)=> input * (decimal)0.0009144,
                    ["Centymeter"] = (input)=> input * (decimal)91.44,
                    ["Decimeter"] = (input)=> input * (decimal)9.14400,
                    ["Mile"] = (input)=> input * (decimal)0.000568181818,
                    ["NauticalMile"] = (input)=> input * (decimal)0.000493736501,
                    ["Cable"] = (input)=> input * (decimal)0.00493421,
                    ["Yard"] = (input)=> input,
                    ["Inch"] = (input)=> input * 36,
                    ["Foot"] = (input)=> input * 3,
                }
            },
            {
                "Inch",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * (decimal)25.4,
                    ["Meter"] = (input)=> input * (decimal)0.0254,
                    ["Kilometer"] = (input)=> input * (decimal)0.0000254,
                    ["Centymeter"] = (input)=> input * (decimal)2.54,
                    ["Decimeter"] = (input)=> input * (decimal)0.254,
                    ["Mile"] = (input)=> input * (decimal)0.0000157828,
                    ["NauticalMile"] = (input)=> input * (decimal)0.0000137149028078,
                    ["Cable"] = (input)=> input * (decimal)0.0001157407407407,
                    ["Yard"] = (input)=> input * (decimal)0.0277777778,
                    ["Inch"] = (input)=> input,
                    ["Foot"] = (input)=> input * (decimal)0.0833333333,
                }
            },
            {
                "Foot",
                new Dictionary<string, Func<decimal, decimal>>()
                {
                    ["Millimeter"] = (input)=> input * (decimal)304.8,
                    ["Meter"] = (input)=> input * (decimal)0.3048,
                    ["Kilometer"] = (input)=> input * (decimal)0.0003048,
                    ["Centymeter"] = (input)=> input * (decimal)30.48,
                    ["Decimeter"] = (input)=> input * (decimal)3.04800,
                    ["Mile"] = (input)=> input * (decimal)0.000189393939,
                    ["NauticalMile"] = (input)=> input * (decimal)0.000164578834,
                    ["Cable"] = (input)=> input * (decimal)0.00138888889,
                    ["Yard"] = (input)=> input * (decimal)0.333333333,
                    ["Inch"] = (input)=> input * 12,
                    ["Foot"] = (input)=> input,
                }
            },
        };
    }
}