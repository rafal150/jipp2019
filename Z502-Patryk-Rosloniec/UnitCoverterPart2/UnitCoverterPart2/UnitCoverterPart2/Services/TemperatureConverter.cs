using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "°C", "°F", "K", "°R" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "K")
            {
                if (unitTo == "°C")
                    return value - 273.15;

                else if (unitTo == "°F")
                    return ((value - 273.15) * 1.8) + 32.0;

                else if (unitTo == "°R")
                    return value * 1.8;

            }
            else if (unitFrom == "°C")
            {
                if (unitTo == "K")
                    return value + 273.15;

                else if (unitTo == "°F")
                    return (value * 1.8) + 32.0;

                else if (unitTo == "°R")
                    return (value + 273.15) * 1.8;

            }
            else if (unitFrom == "°F")
            {
                if (unitTo == "°C")
                    return (value - 32.0) / 1.8;

                else if (unitTo == "K")
                    return ((value - 32.0) / 1.8) + 273.15;

                else if (unitTo == "°R")
                    return (((value - 32.0) / 1.8) + 273.15) * 1.8;

            }
            else if (unitFrom == "°R")
            {
                if (unitTo == "°C")
                    return (value / 1.8) - 273.15;

                else if (unitTo == "K")
                    return (value / 1.8);

                else if (unitTo == "°F")
                    return (((value / 1.8) - 273.15) * 1.8) + 32.0;
            }

            return 0;

        }
    }
}
