using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConvLogic.Services
{
    public class WeightConverter : IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "kg", "T", "g" });

        public decimal Convert(string startsValue, string endValue, decimal value)
        {
            if (startsValue == "kg" && endValue == "T")
            {
                return value * 1000;
            }
            else if (startsValue == "kg" && endValue == "g")
            {
                return value / 100;
            }
            else if (startsValue == "T" && endValue == "kg")
            {
                return value * 1000;
            }
            else if (startsValue == "T" && endValue == "g")
            {
                return value * 10000;
            }
            else if (startsValue == "g" && endValue == "kg")
            {
                return value * 100;
            }
            else if (startsValue == "g" && endValue == "T")
            {
                return value / 100000;
            }

            else
                return value;
        }
    }
}
