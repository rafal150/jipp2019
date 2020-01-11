using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Serwisy
{
    class KonwerterMasy : IKonwerter
    {
        public struct JednostkiMasa
        {
            private const double mg = 1;
            private const double g = 0.01;
            private const double dkg = 0.0001;
            private const double kg = 0.00001;
            private const double T = 0.00000001;
            private const double uncja = 0.000035274;
            private const double funt = 0.0000024419;
            private const double karat = 0.005;
            private const double kwintal = 10;

            public static double PobierzJednostkeMasy(int index)
            {

                switch (index)
                {
                    case 0:
                        return mg;
                    case 1:
                        return g;
                    case 2:
                        return dkg;
                    case 3:
                        return kg;
                    case 4:
                        return T;
                    case 5:
                        return uncja;
                    case 6:
                        return funt;
                    case 7:
                        return karat;
                    case 8:
                        return kwintal;
                    default:
                        return 0;
                }
            }
        }
        public string Nazwa => "Masa";

        public List<string> Jednostki => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });
        public decimal Konwertuj(int unitTo, int unitFrom, double value)
        {
            double NaMase = 0;
            double ZMasy = value;
            double tmpZ = JednostkiMasa.PobierzJednostkeMasy(unitFrom);
            double tmpNa = JednostkiMasa.PobierzJednostkeMasy(unitTo);
            NaMase = (ZMasy * tmpNa) / tmpZ;
            return Convert.ToDecimal(NaMase);
        }
    }
}
