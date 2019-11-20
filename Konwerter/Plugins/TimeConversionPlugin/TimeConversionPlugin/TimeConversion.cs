using Converter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeConversionPlugin
{
    public class TimeConversion : IConverter
    {
        public string Name => "Time";

        public List<string> Units => new List<string>(new[] { "ms", "s", "min", "h", "dzien", "tydzien", "miesiac", "rok" });

        public double Convert(string fromUnit, string toUnit, double value)
        {
            double fromBase(double time)
            {
                double convertedTime = 0;
                switch (toUnit)
                {
                    case "ms":
                        {
                            convertedTime = time / 0.001;
                            break;
                        }
                    case "s":
                        {
                            convertedTime = time;
                            break;
                        }
                    case "min":
                        {
                            convertedTime = time / 60;
                            break;
                        }
                    case "h":
                        {
                            convertedTime = time / 3600;
                            break;
                        }
                    case "dzien":
                        {
                            convertedTime = time / 86400;
                            break;
                        }
                    case "tydzien":
                        {
                            convertedTime = time / 604800;
                            break;
                        }
                    case "miesiac":
                        {
                            convertedTime = time / 2592000;
                            break;
                        }
                    case "rok":
                        {
                            convertedTime = time / 31536000;
                            break;
                        }
                }
                return convertedTime;
            }

            double toBase(double time)
            {
                double convertedTime = 0;
                switch (fromUnit)
                {
                    case "ms":
                        {
                            convertedTime = time * 0.001;
                            break;
                        }
                    case "s":
                        {
                            convertedTime = time;
                            break;
                        }
                    case "min":
                        {
                            convertedTime = time * 60;
                            break;
                        }
                    case "h":
                        {
                            convertedTime = time * 3600;
                            break;
                        }
                    case "dzien":
                        {
                            convertedTime = time * 86400;
                            break;
                        }
                    case "tydzien":
                        {
                            convertedTime = time * 604800;
                            break;
                        }
                    case "miesiac":
                        {
                            convertedTime = time * 2592000;
                            break;
                        }
                    case "rok":
                        {
                            convertedTime = time * 31536000;
                            break;
                        }
                }
                return convertedTime;
            }
            return fromBase(toBase(value));
        }
    }
}
