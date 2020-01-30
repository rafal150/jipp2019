using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class TemperaturaKonwerter : IKonwerter
    {
        public string Name => "Temperatura C, F, K, R";

        public List<string> Units => new List<string>(new[] { "Celsjusz", "Fahrenheit", "Kelvin", "Rankine" });


        public double Convert(string unitFrom, string unitTo, double value)
        {

            if (unitFrom == "Celsjusz" && unitTo == "Fahrenheit")
            {
                return value * 33.8;
            }
            else if (unitFrom == "Celsjusz" && unitTo == "Kelvin")
            {
                return value * 274.15;
            }
            else if (unitFrom == "Celsjusz" && unitTo == "Rankine")
            {
                return value * 493.47;
            }
            else if (unitFrom == "Fahrenheit" && unitTo == "Celsjusz")
            {
                return value * -17.22;
            }
            if (unitFrom == "Fahrenheit" && unitTo == "Rankine")
            {
                return value * 460;
            }
            else if (unitFrom == "Fahrenheit" && unitTo == "Kelvin")
            {
                return value * 255;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Celsjusz")
            {
                return value * -272;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Fahrenheit")
            {
                return value * -457;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Rankine")
            {
                return value * 1.8;
            }
            else if (unitFrom == "Rankine" && unitTo == "Celsjusz")
            {
                return value * -272;
            }
            else if (unitFrom == "Rankine" && unitTo == "Fahrenheit")
            {
                return value * -458;
            }
            else if (unitFrom == "Rankine" && unitTo == "Kelvin")
            {
                return value * 0.56;
            }
            else
                return value;
        }

    }
}
