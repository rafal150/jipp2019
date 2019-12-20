using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.SDK;

namespace WpfApp1.Logic
{
    class TemperatureMeasure : IGetMeasures
    {
        public string Nam => "temperature";
        public List<string> Units => new List<string>(new[] { "celsius", "kelvin", "fahrenheit", "rankine" });
        public double Convert(string from, string to, double value_from)
        {
            switch (from)
            {
                case "celsius":
                    value_from += 273.15;
                    break;
                case "kelvin":
                    //value_from += 0;
                    break;
                case "fahrenheit":
                    value_from = (value_from + 459.67) / 1.8;
                    break;
                case "rankine":
                    value_from /= 1.8;
                    break;
            }
            switch (to)
            {
                case "celsius":
                    value_from -= 273.15;
                    break;
                case "kelvin":
                    //value_from += 0;
                    break;
                case "fahrenheit":
                    value_from = (value_from * 1.8) - 459.67;
                    break;
                case "rankine":
                    value_from *= 1.8;
                    break;
            }
            return value_from;
        }
    }
}
