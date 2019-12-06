using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.SDK;

namespace Konwerter.Services
{
    public class DlugoscKonwerter : IKonwerter
    {
        public string Typ => "konwerter długości";
        public List<string> Jednostki => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });
        public double Przelicz(string fromType, string toType, double value)
        {
            double result = 0;
            switch (fromType)
            {
                case "mm":
                    switch (toType)
                    {
                        case "mm":
                            result = value;
                            break;
                        case "cm":
                            result = value /10;
                            break;
                        case "dcm":
                            result = value /100;
                            break;
                        case "m":
                            result = value / 1000;
                            break;
                        case "km":
                            result = value / 1000000;
                            break;
                        case "cal":
                            result = value * 0.0393700787;
                            break;
                        case "stopa":
                            result = value * 0.0032808399;
                            break;
                        case "jard":
                            result = value * 0.0010936133;
                            break;
                        case "mila":
                            result = value * 0.000000621371192;
                            break;
                        case "kabel":
                            result = value * 0.0000053995680346;
                            break;
                        case "mila morska":
                            result = value * 0.00000053995680346;
                            break;
                        default:
                            break;
                    }
                    break;
                case "cm":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 10;
                            break;
                        case "cm":
                            result = value;
                            break;
                        case "dcm":
                            result = value / 10;
                            break;
                        case "m":
                            result = value / 100;
                            break;
                        case "km":
                            result = value / 100000;
                            break;
                        case "cal":
                            result = value * 0.393700787;
                            break;
                        case "stopa":
                            result = value * 0.032808399;
                            break;
                        case "jard":
                            result = value * 0.010936133;
                            break;
                        case "mila":
                            result = value * 0.00000621371192;
                            break;
                        case "kabel":
                            result = value * 0.000053995680346;
                            break;
                        case "mila morska":
                            result = value * 0.0000053995680346;
                            break;
                        default:
                            break;
                    }
                    break;
                case "dcm":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 100;
                            break;
                        case "cm":
                            result = value * 10;
                            break;
                        case "dcm":
                            result = value;
                            break;
                        case "m":
                            result = value / 10;
                            break;
                        case "km":
                            result = value / 10000;
                            break;
                        case "cal":
                            result = value * 3.93700787;
                            break;
                        case "stopa":
                            result = value * 0.32808399;
                            break;
                        case "jard":
                            result = value * 0.10936133;
                            break;
                        case "mila":
                            result = value * 0.0000621371192;
                            break;
                        case "kabel":
                            result = value * 0.00053995680346;
                            break;
                        case "mila morska":
                            result = value * 0.000053995680346;
                            break;
                        default:
                            break;
                    }
                    break;
                case "m":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 1000;
                            break;
                        case "cm":
                            result = value * 100;
                            break;
                        case "dcm":
                            result = value * 10;
                            break;
                        case "m":
                            result = value;
                            break;
                        case "km":
                            result = value / 1000;
                            break;
                        case "cal":
                            result = value * 39.3700787;
                            break;
                        case "stopa":
                            result = value * 3.2808399;
                            break;
                        case "jard":
                            result = value * 1.0936133;
                            break;
                        case "mila":
                            result = value * 0.000621371192;
                            break;
                        case "kabel":
                            result = value * 0.0053995680346;
                            break;
                        case "mila morska":
                            result = value * 0.00053995680346;
                            break;
                        default:
                            break;
                    }
                    break;
                case "km":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 1000000;
                            break;
                        case "cm":
                            result = value * 100000;
                            break;
                        case "dcm":
                            result = value * 10000;
                            break;
                        case "m":
                            result = value * 1000;
                            break;
                        case "km":
                            result = value;
                            break;
                        case "cal":
                            result = value * 39370.0787;
                            break;
                        case "stopa":
                            result = value * 3280.8399;
                            break;
                        case "jard":
                            result = value * 1093.6133;
                            break;
                        case "mila":
                            result = value * 0.621371192;
                            break;
                        case "kabel":
                            result = value * 5.3995680346;
                            break;
                        case "mila morska":
                            result = value * 0.53995680346;
                            break;
                        default:
                            break;
                    }
                    break;
                case "cal":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 25.4;
                            break;
                        case "cm":
                            result = value * 2.54;
                            break;
                        case "dcm":
                            result = value * 0.254;
                            break;
                        case "m":
                            result = value * 0.0254;
                            break;
                        case "km":
                            result = value * 0.0000254;
                            break;
                        case "cal":
                            result = value;
                            break;
                        case "stopa":
                            result = value * 0.0833333333;
                            break;
                        case "jard":
                            result = value * 0.0277777778;
                            break;
                        case "mila":
                            result = value * 0.0000157828;
                            break;
                        case "kabel":
                            result = value * 0.000137149;
                            break;
                        case "mila morska":
                            result = value * 0.0000137149;
                            break;
                        default:
                            break;
                    }
                    break;
                case "stopa":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 304.8;
                            break;
                        case "cm":
                            result = value * 30.48;
                            break;
                        case "dcm":
                            result = value * 3.048;
                            break;
                        case "m":
                            result = value * 0.3048;
                            break;
                        case "km":
                            result = value * 0.0003048;
                            break;
                        case "cal":
                            result = value * 12;
                            break;
                        case "stopa":
                            result = value;
                            break;
                        case "jard":
                            result = value * 0.3333333333;
                            break;
                        case "mila":
                            result = value * 0.0001893939;
                            break;
                        case "kabel":
                            result = value * 0.001645788;
                            break;
                        case "mila morska":
                            result = value * 0.0001645788;
                            break;
                        default:
                            break;
                    }
                    break;
                case "jard":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 914.4;
                            break;
                        case "cm":
                            result = value * 91.44;
                            break;
                        case "dcm":
                            result = value * 9.144;
                            break;
                        case "m":
                            result = value * 0.9144;
                            break;
                        case "km":
                            result = value * 0.0009144;
                            break;
                        case "cal":
                            result = value * 36;
                            break;
                        case "stopa":
                            result = value * 3;
                            break;
                        case "jard":
                            result = value;
                            break;
                        case "mila":
                            result = value * 0.0005681818;
                            break;
                        case "kabel":
                            result = value * 0.004937365;
                            break;
                        case "mila morska":
                            result = value * 0.0004937365;
                            break;
                        default:
                            break;
                    }
                    break;
                case "mila":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 1609344;
                            break;
                        case "cm":
                            result = value * 160934.4;
                            break;
                        case "dcm":
                            result = value * 16093.44;
                            break;
                        case "m":
                            result = value * 1609.344;
                            break;
                        case "km":
                            result = value * 1.609344;
                            break;
                        case "cal":
                            result = value * 63360;
                            break;
                        case "stopa":
                            result = value * 5280;
                            break;
                        case "jard":
                            result = value * 1760;
                            break;
                        case "mila":
                            result = value;
                            break;
                        case "kabel":
                            result = value * 8.689762419;
                            break;
                        case "mila morska":
                            result = value * 0.8689762419;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kabel":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 185200;
                            break;
                        case "cm":
                            result = value * 18520;
                            break;
                        case "dcm":
                            result = value * 185.2;
                            break;
                        case "m":
                            result = value * 18.52;
                            break;
                        case "km":
                            result = value * 0.01852;
                            break;
                        case "cal":
                            result = value * 7291.3385827;
                            break;
                        case "stopa":
                            result = value * 607.61154856;
                            break;
                        case "jard":
                            result = value * 202.53718285;
                            break;
                        case "mila":
                            result = value * 0.1150779448;
                            break;
                        case "kabel":
                            result = value;
                            break;
                        case "mila morska":
                            result = value * 0.1;
                            break;
                        default:
                            break;
                    }
                    break;
                case "mila morska":
                    switch (toType)
                    {
                        case "mm":
                            result = value * 1852000;
                            break;
                        case "cm":
                            result = value * 185200;
                            break;
                        case "dcm":
                            result = value * 18520;
                            break;
                        case "m":
                            result = value * 1852;
                            break;
                        case "km":
                            result = value * 1.852;
                            break;
                        case "cal":
                            result = value * 72913.385827;
                            break;
                        case "stopa":
                            result = value * 6076.1154856;
                            break;
                        case "jard":
                            result = value * 2025.3718285;
                            break;
                        case "mila":
                            result = value * 1.150779448;
                            break;
                        case "kabel":
                            result = value * 0.1;
                            break;
                        case "mila morska":
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