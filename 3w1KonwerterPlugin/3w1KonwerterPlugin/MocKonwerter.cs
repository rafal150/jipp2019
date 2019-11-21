using Konwerter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPlugins
{
    class MocKonwerter : IKonwerter
    {
        public string Typ => "konwerter mocy";
        public List<string> Jednostki => new List<string>(new[] { "W", "kW", "KM", "HP"});
        public double Przelicz(string fromType, string toType, double value)
        {
            double result = 0;
            switch (fromType)
            {
                case "W":
                    switch (toType)
                    {
                        case "W":
                            result = value;
                            break;
                        case "kW":
                            result = value / 10;
                            break;
                        case "KM":
                            result = value / 100;
                            break;
                        case "HP":
                            result = value / 1000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kW":
                    switch (toType)
                    {
                        case "W":
                            result = value;
                            break;
                        case "kW":
                            result = value / 10;
                            break;
                        case "KM":
                            result = value / 100;
                            break;
                        case "HP":
                            result = value / 1000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "KM":
                    switch (toType)
                    {
                        case "W":
                            result = value;
                            break;
                        case "kW":
                            result = value / 10;
                            break;
                        case "KM":
                            result = value / 100;
                            break;
                        case "HP":
                            result = value / 1000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "HP":
                    switch (toType)
                    {
                        case "W":
                            result = value;
                            break;
                        case "kW":
                            result = value / 10;
                            break;
                        case "KM":
                            result = value / 100;
                            break;
                        case "HP":
                            result = value / 1000;
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
