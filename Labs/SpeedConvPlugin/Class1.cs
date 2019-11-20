using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs.Converters;

namespace SpeedConvPlugin
{
    public class SpeedConv : IConverter
    {
        public string Name => "Predkosci";

        public List<string> Units => new List<string>(new[] { "kmh", "mph", "mach" });

        public double Convert(string from, string to, double value)
        {
            switch (from)
            {
                case "kmh":

                    if (to == "kmh")
                    {
                        //value = value;
                    }
                    else if (to == "mph")
                    {
                        value = value * 0.621;
                    }
                    else if (to == "mach")
                    {
                        value = value / 1234.8;
                    }

                    break;

                case "mph":

                    if (to == "kmh")
                    {
                        value = value * 1.609;
                    }
                    else if (to == "mph")
                    {
                        //value = value;
                    }
                    else if (to == "mach")
                    {
                        value = value / 767.26;
                    }

                    break;

                case "mach":

                    if (to == "kmh")
                    {
                        value = value * 1234.8;
                    }
                    else if (to == "mph")
                    {
                        value = value * 767.26;
                    }
                    else if (to == "mach")
                    {
                        //value = value;
                    }

                    break;
            }


            return value;
        }
    }
}
