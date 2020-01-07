using Konwerter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPlugins
{
    public class IloscKonwerter : IKonwerter
    {
        public string Typ => "konwerter_ilości";
        public List<string> Jednostki => new List<string>(new[] { "sztuka", "tuzin", "mendel", "mendel chłopski", "kopa", "gros"});
        public double Przelicz(string fromType, string toType, double value)
        {
            double result = 0;
            switch (fromType)
            {
                case "sztuka":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value;
                            break;
                        case "tuzin":
                            result = value / 12;
                            break;
                        case "mendel":
                            result = value / 15;
                            break;
                        case "mendel chłopski":
                            result = value / 16;
                            break;
                        case "kopa":
                            result = value / 60;
                            break;
                        case "gros":
                            result = value / 144;
                            break;
                        default:
                            break;
                    }
                    break;
                case "tuzin":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value * 12;
                            break;
                        case "tuzin":
                            result = value;
                            break;
                        case "mendel":
                            result = value * 0.8;
                            break;
                        case "mendel chłopski":
                            result = value * 0.75;
                            break;
                        case "kopa":
                            result = value / 5;
                            break;
                        case "gros":
                            result = value / 12;
                            break;
                        default:
                            break;
                    }
                    break;
                case "mendel":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value * 15;
                            break;
                        case "tuzin":
                            result = value * 1.25;
                            break;
                        case "mendel":
                            result = value;
                            break;
                        case "mendel chłopski":
                            result = value * 0.9375;
                            break;
                        case "kopa":
                            result = value / 4;
                            break;
                        case "gros":
                            result = value * 0.1042;
                            break;
                        default:
                            break;
                    }
                    break;
                case "mendel chłopski":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value * 16;
                            break;
                        case "tuzin":
                            result = value * 1.3333;
                            break;
                        case "mendel":
                            result = value * 1.0666;
                            break;
                        case "mendel chłopski":
                            result = value;
                            break;
                        case "kopa":
                            result = value * 1.0666;
                            break;
                        case "gros":
                            result = value * 0.1111;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kopa":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value * 60;
                            break;
                        case "tuzin":
                            result = value * 5;
                            break;
                        case "mendel":
                            result = value * 4;
                            break;
                        case "mendel chłopski":
                            result = value * 3.75;
                            break;
                        case "kopa":
                            result = value;
                            break;
                        case "gros":
                            result = value * 0.4167;
                            break;
                        default:
                            break;
                    }
                    break;
                case "gros":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value * 144;
                            break;
                        case "tuzin":
                            result = value * 12;
                            break;
                        case "mendel":
                            result = value * 9.6;
                            break;
                        case "mendel chłopski":
                            result = value * 9;
                            break;
                        case "kopa":
                            result = value * 2.4;
                            break;
                        case "gros":
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
