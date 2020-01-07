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
        public string Typ => "konwerter_mocy";
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
                            result = value / 1000;
                            break;
                        case "KM":
                            result = value * 0.0013596;
                            break;
                        case "HP":
                            result = value * 0.00134102;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kW":
                    switch (toType)
                    {
                        case "W":
                            result = value * 1000;
                            break;
                        case "kW":
                            result = value;
                            break;
                        case "KM":
                            result = value * 1.3596;
                            break;
                        case "HP":
                            result = value * 1.341;
                            break;
                        default:
                            break;
                    }
                    break;
                case "KM":
                    switch (toType)
                    {
                        case "W":
                            result = value * 735.4988;
                            break;
                        case "kW":
                            result = value * 0.7355;
                            break;
                        case "KM":
                            result = value;
                            break;
                        case "HP":
                            result = value * 0.9863;
                            break;
                        default:
                            break;
                    }
                    break;
                case "HP":
                    switch (toType)
                    {
                        case "W":
                            result = value * 745.6999;
                            break;
                        case "kW":
                            result = value * 0.7457;
                            break;
                        case "KM":
                            result = value * 1.0139;
                            break;
                        case "HP":
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
