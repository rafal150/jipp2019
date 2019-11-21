using Konwerter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPlugins
{
    class DaneKonwerter : IKonwerter
    {
        public string Typ => "konwerter ilości danych";
        public List<string> Jednostki => new List<string>(new[] { "B", "kB", "MB", "GB", "TB"});
        public double Przelicz(string fromType, string toType, double value)
        {
            double result = 0;
            switch (fromType)
            {
                case "B":
                    switch (toType)
                    {
                        case "B":
                            result = value;
                            break;
                        case "kB":
                            result = value / 10;
                            break;
                        case "MB":
                            result = value / 100;
                            break;
                        case "GB":
                            result = value / 1000;
                            break;
                        case "TB":
                            result = value / 1000000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "kB":
                    switch (toType)
                    {
                        case "B":
                            result = value;
                            break;
                        case "kB":
                            result = value / 10;
                            break;
                        case "MB":
                            result = value / 100;
                            break;
                        case "GB":
                            result = value / 1000;
                            break;
                        case "TB":
                            result = value / 1000000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "MB":
                    switch (toType)
                    {
                        case "B":
                            result = value;
                            break;
                        case "kB":
                            result = value / 10;
                            break;
                        case "MB":
                            result = value / 100;
                            break;
                        case "GB":
                            result = value / 1000;
                            break;
                        case "TB":
                            result = value / 1000000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "GB":
                    switch (toType)
                    {
                        case "B":
                            result = value;
                            break;
                        case "kB":
                            result = value / 10;
                            break;
                        case "MB":
                            result = value / 100;
                            break;
                        case "GB":
                            result = value / 1000;
                            break;
                        case "TB":
                            result = value / 1000000;
                            break;
                        default:
                            break;
                    }
                    break;
                case "TB":
                    switch (toType)
                    {
                        case "B":
                            result = value;
                            break;
                        case "kB":
                            result = value / 10;
                            break;
                        case "MB":
                            result = value / 100;
                            break;
                        case "GB":
                            result = value / 1000;
                            break;
                        case "TB":
                            result = value / 1000000;
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
