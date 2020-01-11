using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Serwisy
{
    class KonwerterTemperatury : IKonwerter
    {
        public string Nazwa => "Temperatura";

        public List<string> Jednostki => new List<string>(new[] { "Celsjusz", "Farenheit", "Kelvin", "Rankin" });
        public decimal Konwertuj(int unitTo, int unitFrom, double value)
        {
            double ret = new double();
            if (unitFrom == 0)
            {
                switch (unitTo)
                {
                    case 0:
                        ret = value;
                        break;
                    case 1:
                        ret = value * 9 / 5 + 32;
                        break;
                    case 2:
                        ret = value + 273.15;
                        break;
                    case 3:
                        ret = (value + 273.15) * 9 / 5;
                        break;
                }
            }
            else if (unitFrom == 1)
            {
                switch (unitTo)
                {
                    case 0:
                        ret = (value - 32) * 5 / 9;
                        break;
                    case 1:
                        ret = value;
                        break;
                    case 2:
                        ret = (value + 459.67) * 5 / 9;
                        break;
                    case 3:
                        ret = (value + 459.67);
                        break;
                }
            }
            else if (unitFrom == 2)
            {
                switch (unitTo)
                {
                    case 0:
                        ret = value - 273.15;
                        break;
                    case 1:
                        ret = (value * 9 / 5) - 459.67;
                        break;
                    case 2:
                        ret = value;
                        break;
                    case 3:
                        ret = value * 9 / 5;
                        break;
                }
            }
            else if (unitFrom == 3)
            {
                switch (unitTo)
                {
                    case 0:
                        ret = (value - 491.67) * 5 / 9;
                        break;
                    case 1:
                        ret = value - 459.67;
                        break;
                    case 2:
                        ret = value * 5 / 9;
                        break;
                    case 3:
                        ret = value;
                        break;
                }
            }
            return Convert.ToDecimal(ret);
        }
    }
}
