using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek.Services
{
    public class TemperatureConverter : iKonwerter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "°C", "°F", "K", "°R" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom == "K")
            {
                if (unitTo == "°C")
                    return value - 273.15M;

                else if (unitTo == "°F")
                    return ((value - 273.15M) * 1.8M) + 32.0M;

                else if (unitTo == "°R")
                    return value * 1.8M;

            }
            else if (unitFrom == "°C")
            {
                if (unitTo == "K")
                    return value + 273.15M;

                else if (unitTo == "°F")
                    return (value * 1.8M) + 32.0M;

                else if (unitTo == "°R")
                    return (value + 273.15M) * 1.8M;

            }
            else if (unitFrom == "°F")
            {
                if (unitTo == "°C")
                    return (value - 32.0M) / 1.8M;

                else if (unitTo == "K")
                    return ((value - 32.0M) / 1.8M) + 273.15M;

                else if (unitTo == "°R")
                    return (((value - 32.0M) / 1.8M) + 273.15M) * 1.8M;

            }
            else if (unitFrom == "°R")
            {
                if (unitTo == "°C")
                    return (value / 1.8M) - 273.15M;

                else if (unitTo == "K")
                    return (value / 1.8M);

                else if (unitTo == "°F")
                    return (((value / 1.8M) - 273.15M) * 1.8M) + 32.0M;
            }

            return 0;

        }

     
    }
}
