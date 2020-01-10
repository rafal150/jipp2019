
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverteAZ.Services
{
    public class MetricConverter : IConverter
    {

        //private string fromValue;
        //private string tounitValue;
        //private double value;

        public string Name => "Miary";

        public List<string> Units => getUnitsNames();

        //public MetricConverter(string fromValue, string tounitValue, double value)
        //{
        //    this.fromValue = fromValue;
        //    this.tounitValue = tounitValue;
        //    this.value = value;
                      
        //}


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
            units.Add("m", 1);
            units.Add("mm", 0.001);
            units.Add("cm", 0.01);
            units.Add("dcm", 0.1);
            units.Add("km", 1000);

            //anglosas
            units.Add("cal", 0.0254);
            units.Add("stopa", 0.3048);
            units.Add("jard", 0.9144);
            units.Add("mila", 1609.344);

            //navy
            units.Add("kabel", 207.264);
            units.Add("mila morska", 1851.85);
            
            
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
