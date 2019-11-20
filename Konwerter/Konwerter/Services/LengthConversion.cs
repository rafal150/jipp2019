using Converter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class LengthConversion : IConverter
    {
        public string Name => "Length";
        public List<string> Units => new List<string>(new[] { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });

        public double Convert(string fromUnit, string toUnit, double value)
        {
            double fromBase(double value)
            {
                double convertedLength = 0;
                switch (toUnit)
                {
                    case "mm":
                        {
                            convertedLength = value / 0.001;
                            break;
                        }
                    case "cm":
                        {
                            convertedLength = value / 0.01;
                            break;
                        }
                    case "dm":
                        {
                            convertedLength = value / 0.1;
                            break;
                        }
                    case "m":
                        {
                            convertedLength = value;
                            break;
                        }
                    case "km":
                        {
                            convertedLength = value / 1000;
                            break;
                        }
                    case "cal":
                        {
                            convertedLength = value / 0.0254;
                            break;
                        }
                    case "stopa":
                        {
                            convertedLength = value / 0.3048;
                            break;
                        }
                    case "jard":
                        {
                            convertedLength = value / 0.9144;
                            break;
                        }
                    case "mila":
                        {
                            convertedLength = value / 1609.344;
                            break;
                        }
                    case "kabel":
                        {
                            convertedLength = value / 185.2;
                            break;
                        }
                    case "mila morska":
                        {
                            convertedLength = value / 1852;
                            break;
                        }
                }
                return convertedLength;
            }

            double toBase(double value)
            {
                double convertedLength = 0;
                switch (fromUnit)
                {
                    case "mm":
                        {
                            convertedLength = value * 0.001;
                            break;
                        }
                    case "cm":
                        {
                            convertedLength = value * 0.01;
                            break;
                        }
                    case "dm":
                        {
                            convertedLength = value * 0.1;
                            break;
                        }
                    case "m":
                        {
                            convertedLength = value;
                            break;
                        }
                    case "km":
                        {
                            convertedLength = value * 1000;
                            break;
                        }
                    case "cal":
                        {
                            convertedLength = value * 0.0254;
                            break;
                        }
                    case "stopa":
                        {
                            convertedLength = value * 0.3048;
                            break;
                        }
                    case "jard":
                        {
                            convertedLength = value * 0.9144;
                            break;
                        }
                    case "mila":
                        {
                            convertedLength = value * 1609.344;
                            break;
                        }
                    case "kabel":
                        {
                            convertedLength = value * 185.2;
                            break;
                        }
                    case "mila morska":
                        {
                            convertedLength = value * 1852;
                            break;
                        }
                }
                return convertedLength;
            }
            return fromBase(toBase(value));
        }
    }
}
