using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Temperatura
    {
        public static double przelicz(string fromType, string toType, double value)
        {
            double result = 0;
            switch (fromType)
            {
                case "C":
                    switch (toType)
                    {
                        case "C":
                            result = value;
                            break;
                        case "K":
                            result = value + 273.15;
                            break;
                        case "F":
                            result = (value * 1.8) + 32;
                            break;
                        case "R":
                            result = (value + 273.15) * 1.8;
                            break;
                        default:
                            break;
                    }
                    break;
                case "K":
                    switch (toType)
                    {
                        case "C":
                            result = value - 273.15;
                            break;
                        case "K":
                            result = value;
                            break;
                        case "F":
                            result = (value * 1.8) - 459.67;
                            break;
                        case "R":
                            result = value * 1.8;
                            break;
                        default:
                            break;
                    }
                    break;
                case "F":
                    switch (toType)
                    {
                        case "C":
                            result = (value - 32) * 5/9;
                            break;
                        case "K":
                            result = (value + 459.67) * 5/9;
                            break;
                        case "F":
                            result = value;
                            break;
                        case "R":
                            result = value + 459.67;
                            break;
                        default:
                            break;
                    }
                    break;
                case "R":
                    switch (toType)
                    {
                        case "C":
                            result = (value - 491.67) * 5/9;
                            break;
                        case "K":
                            result = value * 5/9;
                            break;
                        case "F":
                            result = value - 459.67;
                            break;
                        case "R":
                            result = value;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
