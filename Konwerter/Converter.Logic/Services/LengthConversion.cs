using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Converter.SDK;

namespace Konwerter
{
    class LengthConversion : IConverter
    {
        public string Name => "Length";
        public List<string> Units => new List<string>(new[] { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });

        public double Convert(string fromUnit, string toUnit, double value)
        {
            double fromBase(double v)
            {
                double convertedLength = 0;
                switch (toUnit)
                {
                    case "mm":
                        {
                            convertedLength = v / 0.001;
                            break;
                        }
                    case "cm":
                        {
                            convertedLength = v / 0.01;
                            break;
                        }
                    case "dm":
                        {
                            convertedLength = v / 0.1;
                            break;
                        }
                    case "m":
                        {
                            convertedLength = v;
                            break;
                        }
                    case "km":
                        {
                            convertedLength = v / 1000;
                            break;
                        }
                    case "cal":
                        {
                            convertedLength = v / 0.0254;
                            break;
                        }
                    case "stopa":
                        {
                            convertedLength = v / 0.3048;
                            break;
                        }
                    case "jard":
                        {
                            convertedLength = v / 0.9144;
                            break;
                        }
                    case "mila":
                        {
                            convertedLength = v / 1609.344;
                            break;
                        }
                    case "kabel":
                        {
                            convertedLength = v / 185.2;
                            break;
                        }
                    case "mila morska":
                        {
                            convertedLength = v / 1852;
                            break;
                        }
                }
                return convertedLength;
            }

            double toBase(double v)
            {
                double convertedLength = 0;
                switch (fromUnit)
                {
                    case "mm":
                        {
                            convertedLength = v * 0.001;
                            break;
                        }
                    case "cm":
                        {
                            convertedLength = v * 0.01;
                            break;
                        }
                    case "dm":
                        {
                            convertedLength = v * 0.1;
                            break;
                        }
                    case "m":
                        {
                            convertedLength = v;
                            break;
                        }
                    case "km":
                        {
                            convertedLength = v * 1000;
                            break;
                        }
                    case "cal":
                        {
                            convertedLength = v * 0.0254;
                            break;
                        }
                    case "stopa":
                        {
                            convertedLength = v * 0.3048;
                            break;
                        }
                    case "jard":
                        {
                            convertedLength = v * 0.9144;
                            break;
                        }
                    case "mila":
                        {
                            convertedLength = v * 1609.344;
                            break;
                        }
                    case "kabel":
                        {
                            convertedLength = v * 185.2;
                            break;
                        }
                    case "mila morska":
                        {
                            convertedLength = v * 1852;
                            break;
                        }
                }
                return convertedLength;
            }
            return fromBase(toBase(value));
        }
    }
}
