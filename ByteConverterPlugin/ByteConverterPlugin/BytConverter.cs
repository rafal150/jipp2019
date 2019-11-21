using Converter.SDK;
using System;
using System.Collections.Generic;

namespace ByteConverterPlugin
{
    public class BytConverter : IConverter


    {
        public string Name => "Bity";

        public List<string> Units => getUnitsNames();

        public double Convert(string unitFrom, string unitTo, double value)
        {
            double calcuatedValue = 0;
            var units = getUnits();
            double indicator = 0;

            foreach (var k in units)
            {
                if (k.Key == unitFrom)
                {
                    indicator = k.Value;
                }

            }
            calcuatedValue = (value * indicator);

            foreach (var k in units)
            {
                if (k.Key == unitTo)
                {
                    indicator = k.Value;
                }

            }
            calcuatedValue = calcuatedValue / indicator;

            return calcuatedValue;
        }




        private static Dictionary<string, double> getUnits()
        {
            var units = new Dictionary<string, double>();
            //metric
            units.Add("Bit", 1);
            units.Add("Bajt", 0.125);

            //anglosas

            //others

            return units;
        }

        public static List<string> getUnitsNames()
        {
            var units = getUnits();
            var list = new List<string>();
            foreach (var k in units)
            {
                list.Add(k.Key);
            }
            return list;

        }
    }
}

