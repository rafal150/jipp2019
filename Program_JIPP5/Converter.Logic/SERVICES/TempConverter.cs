using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    class TempConverter : IConverter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "Celcjusz", "Fahrenheit", "Kelvin", "Rankine" });
        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal fromBase(decimal v)
            {
                decimal valueRAW = 0;
                switch (unitTo)
                {
                    case "Celcjusz":
                        {
                            valueRAW = v;
                            break;
                        }
                    case "Fahrenheit":
                        {
                            valueRAW = (v * (decimal)1.8) + 32;
                            break;
                        }
                    case "Kelvin":
                        {
                            valueRAW = v + (decimal)273.15;
                            break;
                        }
                    case "Rankine":
                        {
                            valueRAW = (v + (decimal)273.15) * (decimal)1.8;
                            break;
                        }
                }
                return valueRAW;
            }

            decimal toBase(decimal v)
            {
                decimal valueRAW = 0;
                switch (unitFrom)
                {
                    case "Celcjusz":
                        {
                            valueRAW = v;
                            break;
                        }
                    case "Fahrenheit":
                        {
                            valueRAW = (v - 32) / (decimal)1.8;
                            break;
                        }
                    case "Kelvin":
                        {
                            valueRAW = v - (decimal)273.15;
                            break;
                        }
                    case "Rankine":
                        {
                            valueRAW = (v / (decimal)1.8) - (decimal)273.15;
                            break;
                        }
                }
                return valueRAW;
            }
            return Math.Round(fromBase(toBase(value)), 2);
        }
    }
}