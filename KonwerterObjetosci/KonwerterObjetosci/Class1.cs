using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Serwisy;

namespace KonwerterObjetosci 
{
    public class KonwerterObjetoscii : IKonwerter
    {
        public struct JednostkiObjetosc
        {
            private const double m3 = 1;
            private const double km3 = 1000000000;
            private const double l = 0.00001;
            private const double gallon = 0.0037854118;

            public static double PobierzJednostkeObjetosci(int index)
            {

                switch (index)
                {
                    case 0:
                        return m3;
                    case 1:
                        return km3;
                    case 2:
                        return l;
                    case 3:
                        return gallon;
                    default:
                        return 0;
                }
            }
        }
        public string Nazwa => "Objetosc";

        public List<string> Jednostki => new List<string>(new[] { "m^3", "km^3", "l", "gallon" });
        public decimal Konwertuj(int unitFrom, int unitTo, double value)
        {
            double NaMase = 0;
            double ZMasy = value;
            double tmpZ = JednostkiObjetosc.PobierzJednostkeObjetosci(unitFrom);
            double tmpNa = JednostkiObjetosc.PobierzJednostkeObjetosci(unitTo);
            NaMase = (ZMasy * tmpNa) / tmpZ;
            return Convert.ToDecimal(NaMase);
        }
    }
}
