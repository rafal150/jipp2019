using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class ConverterD: IConverting
    {
        public ConverterD() { }
        public List<string> listaJednostek
        {
            get
            {
                return new List<String>(new[] { "mm", "cm", "dm", "m", "km", "cal", "stop", "jard", "mila", "kabel", "mila morska" });
            }
        }

        public float Convert(string from, string to, double amount)
        {
            // To m
            switch (from)
            {
                case "mm":
                    amount *= 0.001;
                    break;
                case "cm":
                    amount *= 0.01;
                    break;
                case "dm":
                    amount *= 0.1;
                    break;
                case "km":
                    amount *= 1000;
                    break;
                case "cal":
                    amount *= 0.0254;
                    break;
                case "stop":
                    amount *= 0.3048;
                    break;
                case "jard":
                    amount *= 0.9144;
                    break;
                case "mila":
                    amount *= 1609.344;
                    break;
                case "kabel":
                    amount *= 185.2;
                    break;
                case "mila morska":
                    amount *= 1852;
                    break;
            }

            switch (to)
            {
                case "mm":
                    amount *= 1000;
                    break;
                case "cm":
                    amount *= 100;
                    break;
                case "dm":
                    amount *= 10;
                    break;
                case "km":
                    amount *= 0.001;
                    break;
                case "cal":
                    amount *= 39.37;
                    break;
                case "stop":
                    amount *= 3.2808399;
                    break;
                case "jard":
                    amount *= 1.0936133;
                    break;
                case "mila":
                    amount *= 0.000621371192;
                    break;
                case "kabel":
                    amount *= 0.005399568034;
                    break;
                case "mila morska":
                    amount *= 0.0005399568034;
                    break;
            }

            return (float)amount;
        }
    }
}
