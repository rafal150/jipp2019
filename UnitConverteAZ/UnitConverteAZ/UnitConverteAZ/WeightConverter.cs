using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverteAZ
{

    public class WeightConverter
    {
        private string fromValue;
        private string tounitValue;
        private double value;
   

        public WeightConverter(string fromValue, string tounitValue, double value)
        {
            this.fromValue = fromValue;
            this.tounitValue = tounitValue;
            this.value = value;

        }

//COnvertuje
        public double convert(string from, string to)
        {
            double calcuatedValue = 0;
            var units = getUnits();
            double indicator = 0;

            foreach (var k in units)
            {
                if (k.Key == from)
                {
                    indicator = k.Value;
                }

            }
            calcuatedValue = (this.value * indicator);

            foreach (var k in units)
            {
                if (k.Key == to)
                {
                    indicator = k.Value;
                }

            }
            calcuatedValue = calcuatedValue / indicator;
            return calcuatedValue;
        }
     

        private static  Dictionary<string,double> getUnits()
        {
            var units = new Dictionary<string, double>();
            //metric
            units.Add("Kilogram", 1);
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
