using Konwerter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class MasaKonwerter:IKonwerter
    {
        public string Typ => "konwerter masy";
        public List<string> Jednostki => new List<string> (new[] { "mg", "g", "dkg", "kg", "t", "uncja", "funt", "karat", "kwintal" });
        public double Przelicz(string fromType, string toType, double value)
        {
            double result = 0;
            switch (fromType)
            {
                case "mg":
                    switch (toType)
                    {
                        case "mg":
                            result = value;
                            break;
                        case "g":
                            result = value / 1000;
                            break;
                        case "dkg":
                            result = value / 10000;
                            break;
                        case "kg":
                            result = value / 1000000;
                            break;
                        case "t":
                            result = value / 1000000000;
                            break;
                        case "uncja":
                            result = value * 0.000035274;
                            break;
                        case "funt":
                            result = value * 0.00000220462;
                            break;
                        case "karat":
                            result = value * 0.005;
                            break;
                        case "kwintal":
                            result = value / 100000000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "g":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 1000;
                            break;
                        case "g":
                            result = value;
                            break;
                        case "dkg":
                            result = value / 10;
                            break;
                        case "kg":
                            result = value / 1000;
                            break;
                        case "t":
                            result = value / 1000000;
                            break;
                        case "uncja":
                            result = value * 0.035274;
                            break;
                        case "funt":
                            result = value * 0.00220462;
                            break;
                        case "karat":
                            result = value * 5;
                            break;
                        case "kwintal":
                            result = value / 100000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "dkg":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 10000;
                            break;
                        case "g":
                            result = value * 10;
                            break;
                        case "dkg":
                            result = value;
                            break;
                        case "kg":
                            result = value / 100;
                            break;
                        case "t":
                            result = value / 100000;
                            break;
                        case "uncja":
                            result = value * 0.35274;
                            break;
                        case "funt":
                            result = value * 0.0220462;
                            break;
                        case "karat":
                            result = value * 50;
                            break;
                        case "kwintal":
                            result = value / 10000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kg":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 1000000;
                            break;
                        case "g":
                            result = value * 1000;
                            break;
                        case "dkg":
                            result = value * 100;
                            break;
                        case "kg":
                            result = value;
                            break;
                        case "t":
                            result = value /1000;
                            break;
                        case "uncja":
                            result = value * 35.274;
                            break;
                        case "funt":
                            result = value * 2.20462;
                            break;
                        case "karat":
                            result = value * 5000;
                            break;
                        case "kwintal":
                            result = value / 100;
                            break;
                        default:
                            break;
                    }
                    break;
                case "t":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 1000000000;
                            break;
                        case "g":
                            result = value * 1000000;
                            break;
                        case "dkg":
                            result = value * 100000;
                            break;
                        case "kg":
                            result = value * 1000;
                            break;
                        case "t":
                            result = value;
                            break;
                        case "uncja":
                            result = value * 35274;
                            break;
                        case "funt":
                            result = value * 2204.62;
                            break;
                        case "karat":
                            result = value * 5000000;
                            break;
                        case "kwintal":
                            result = value * 10;
                            break;
                        default:
                            break;
                    }
                    break;
                case "uncja":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 28349.52;
                            break;
                        case "g":
                            result = value * 28.34952;
                            break;
                        case "dkg":
                            result = value * 2.834952;
                            break;
                        case "kg":
                            result = value * 0.0283495;
                            break;
                        case "t":
                            result = value * 0.0000283495;
                            break;
                        case "uncja":
                            result = value;
                            break;
                        case "funt":
                            result = value * 0.0625;
                            break;
                        case "karat":
                            result = value * 141.7476;
                            break;
                        case "kwintal":
                            result = value * 0.000283495;
                            break;
                        default:
                            break;
                    }
                    break;
                case "funt":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 453592.4;
                            break;
                        case "g":
                            result = value * 453.5924;
                            break;
                        case "dkg":
                            result = value * 45.35924;
                            break;
                        case "kg":
                            result = value * 0.453592;
                            break;
                        case "t":
                            result = value * 0.000453592;
                            break;
                        case "uncja":
                            result = value * 16;
                            break;
                        case "funt":
                            result = value;
                            break;
                        case "karat":
                            result = value * 2267.962;
                            break;
                        case "kwintal":
                            result = value * 0.00453592;
                            break;
                        default:
                            break;
                    }
                    break;
                case "karat":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 200;
                            break;
                        case "g":
                            result = value * 0.2;
                            break;
                        case "dkg":
                            result = value * 0.02;
                            break;
                        case "kg":
                            result = value * 0.0002;
                            break;
                        case "t":
                            result = value * 0.0000002;
                            break;
                        case "uncja":
                            result = value * 0.00705479;
                            break;
                        case "funt":
                            result = value * 0.000440925;
                            break;
                        case "karat":
                            result = value;
                            break;
                        case "kwintal":
                            result = value * 0.000002;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kwintal":
                    switch (toType)
                    {
                        case "mg":
                            result = value * 100000000;
                            break;
                        case "g":
                            result = value * 100000;
                            break;
                        case "dkg":
                            result = value * 10000;
                            break;
                        case "kg":
                            result = value * 100;
                            break;
                        case "t":
                            result = value / 10;
                            break;
                        case "uncja":
                            result = value * 3527.396;
                            break;
                        case "funt":
                            result = value * 220.4623;
                            break;
                        case "karat":
                            result = value * 500000;
                            break;
                        case "kwintal":
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

