using Converter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverteAZ
{

    public class WeightConverter : IConverter
    {

        public string Name => "Masy";

  
        List<string> IConverter.Units => getUnitsNames();
   

        //public WeightConverter(string fromValue, string tounitValue, double value)
        //{
        //    this.fromValue = fromValue;
        //    this.tounitValue = tounitValue;
        //    this.value = value;

        //}

        //COnvertuje
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
     

        private static Dictionary<string,double> getUnits()
        {
            var units = new Dictionary<string, double>();
            //metric
            units.Add("Kilo", 1);
            units.Add("Miligram", 0.000001);
            units.Add("Gram", 0.001);
            units.Add("Dekagram", 0.01);
            units.Add("Tona", 1000.0);

            //anglosas
            units.Add("Uncja", 0.0283495231);
            units.Add("Funt", 0.45359237);

            //others
            units.Add("Karat", 0.0002);
            units.Add("Kwintal", 100);

            return units;
        }

        public static List<string> getUnitsNames() {
            var units = getUnits();
            var list = new List<string>();
            foreach(var k in units)
            {
                list.Add(k.Key);
            }
            return list;

        }

 
    }
}
