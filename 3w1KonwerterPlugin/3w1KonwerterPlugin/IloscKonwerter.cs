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
        public string Typ => "konwerter ilości";
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
                            result = value / 10;
                            break;
                        case "mendel":
                            result = value / 100;
                            break;
                        case "mendel chłopski":
                            result = value / 1000;
                            break;
                        case "kopa":
                            result = value / 1000000;
                            break;
                        case "gros":
                            result = value * 0.0393700787;
                            break;
                        default:
                            break;
                    }
                    break;
                case "tuzin":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value;
                            break;
                        case "tuzin":
                            result = value / 10;
                            break;
                        case "mendel":
                            result = value / 100;
                            break;
                        case "mendel chłopski":
                            result = value / 1000;
                            break;
                        case "kopa":
                            result = value / 1000000;
                            break;
                        case "gros":
                            result = value * 0.0393700787;
                            break;
                        default:
                            break;
                    }
                    break;
                case "mendel":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value;
                            break;
                        case "tuzin":
                            result = value / 10;
                            break;
                        case "mendel":
                            result = value / 100;
                            break;
                        case "mendel chłopski":
                            result = value / 1000;
                            break;
                        case "kopa":
                            result = value / 1000000;
                            break;
                        case "gros":
                            result = value * 0.0393700787;
                            break;
                        default:
                            break;
                    }
                    break;
                case "mendel chłopski":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value;
                            break;
                        case "tuzin":
                            result = value / 10;
                            break;
                        case "mendel":
                            result = value / 100;
                            break;
                        case "mendel chłopski":
                            result = value / 1000;
                            break;
                        case "kopa":
                            result = value / 1000000;
                            break;
                        case "gros":
                            result = value * 0.0393700787;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kopa":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value;
                            break;
                        case "tuzin":
                            result = value / 10;
                            break;
                        case "mendel":
                            result = value / 100;
                            break;
                        case "mendel chłopski":
                            result = value / 1000;
                            break;
                        case "kopa":
                            result = value / 1000000;
                            break;
                        case "gros":
                            result = value * 0.0393700787;
                            break;
                        default:
                            break;
                    }
                    break;
                case "gros":
                    switch (toType)
                    {
                        case "sztuka":
                            result = value;
                            break;
                        case "tuzin":
                            result = value / 10;
                            break;
                        case "mendel":
                            result = value / 100;
                            break;
                        case "mendel chłopski":
                            result = value / 1000;
                            break;
                        case "kopa":
                            result = value / 1000000;
                            break;
                        case "gros":
                            result = value * 0.0393700787;
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
