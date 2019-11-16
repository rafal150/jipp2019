using JIPP5_LAB.SDK;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Plugin
{
    public class EnergyConverterHelper : IConverterHelper
    {
        public string Name => "Energia";

        public List<string> UnitTypes => new List<string>()
        {
            "Dżul",
            "Kilodżul",
            "Kilogramometr",
            "Watogodzina",
        };

        public string Convert(string fromUnit, decimal input, string toUnit, out decimal convertedValue)
        {
            convertedValue = ConverterLogic[fromUnit][toUnit].Invoke(input);
            return string.Format("{0} {1}", convertedValue.ToString("N", new NumberFormatInfo() { NumberDecimalDigits = 2 }), toUnit);
        }


        public Dictionary<string, Dictionary<string, Func<decimal, decimal>>> ConverterLogic => new Dictionary<string, Dictionary<string, Func<decimal, decimal>>>()
        {
            {
                "Dżul",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Dżul"] = (input)=> input,
                    ["Kilodżul"] = (input)=> input*(decimal)0.001,
                    ["Kilogramometr"] = (input)=> input*(decimal)0.102,
                    ["Watogodzina"] = (input)=> input*(decimal)0.0003,
                }
            },
            {
                "Kilodżul",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Dżul"] = (input)=> input*1000,
                    ["Kilodżul"] = (input)=> input,
                    ["Kilogramometr"] = (input)=> input*(decimal)101.9716,
                    ["Watogodzina"] = (input)=> input*(decimal)0.2778,
                }
            },
            {
                "Kilogramometr",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Dżul"] = (input)=> input*(decimal)9.8067,
                    ["Kilodżul"] = (input)=> input*(decimal)0.0098,
                    ["Kilogramometr"] = (input)=> input,
                    ["Watogodzina"] = (input)=> input *(decimal)0.0027,
                }
            },
            {
                "Watogodzina",
                new Dictionary<string, Func<decimal, decimal>>(){
                    ["Dżul"] = (input)=> input*3600,
                    ["Kilodżul"] = (input)=> input*(decimal)3.6,
                    ["Kilogramometr"] = (input)=> input*(decimal)367.0978,
                    ["Watogodzina"] = (input)=> input,
                }
            },
        };
    }
}
