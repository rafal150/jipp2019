using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Serwisy
{
    class KonwerterDlugosci : IKonwerter
    {
        public struct JednostkiDlugosci
        {
            private const double mm = 1;
            private const double Cm = 0.1;
            private const double Dcm = 0.01;
            private const double M = 0.001;
            private const double Km = 0.000001;
            private const double Cal = 0.039370;
            private const double Stopa = 0.0032808;
            private const double Jard = 0.0010936100483;
            private const double Mila = 0.00000621371192237334;
            private const double Kabel = 0.0000053995680345572;
            private const double MilaMorska = 0.00000053995680345572;
            public static double PobierzJednostkeDlugosci(int index)
            {
                switch (index)
                {
                    case 0:
                        return mm;
                    case 1:
                        return Cm;
                    case 2:
                        return Dcm;
                    case 3:
                        return M;
                    case 4:
                        return Km;
                    case 5:
                        return Cal;
                    case 6:
                        return Stopa;
                    case 7:
                        return Jard;
                    case 8:
                        return Mila;
                    case 9:
                        return Kabel;
                    case 10:
                        return MilaMorska;
                    default:
                        return 0;
                }
            }
        }
        public string Nazwa => "Dlugosc";

        public List<string> Jednostki => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });

        public decimal Konwertuj(int unitTo, int unitFrom, double value)
        {
            double NaDlugosci = 0;
            double ZDlugosci = value;
            double tmpZ = JednostkiDlugosci.PobierzJednostkeDlugosci(unitFrom);
            double tmpNa = JednostkiDlugosci.PobierzJednostkeDlugosci(unitTo);
            NaDlugosci = (ZDlugosci * tmpNa) / tmpZ;
            return Convert.ToDecimal(NaDlugosci);
        }
    }
}
