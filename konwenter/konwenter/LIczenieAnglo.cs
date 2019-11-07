using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwenter
{
    class LIczenieAnglo
    {
        public double konwe(int glowna, int pierwszaLista, int drugaLista, int wartosc)
        {
            if (pierwszaLista == drugaLista) return wartosc;

            switch (glowna)
            {
                case 2:
                    if ((pierwszaLista == 0) && (drugaLista == 1)) return (wartosc * 0.83);
                    if ((pierwszaLista == 0) && (drugaLista == 2)) return (wartosc * 0.27);
                    if ((pierwszaLista == 0) && (drugaLista == 3)) return (wartosc * 0.0000157);
                    if ((pierwszaLista == 1) && (drugaLista == 0)) return (wartosc * 12);
                    if ((pierwszaLista == 1) && (drugaLista == 2)) return (wartosc * 0.33);
                    if ((pierwszaLista == 1) && (drugaLista == 3)) return (wartosc * 0.00018);
                    if ((pierwszaLista == 2) && (drugaLista == 0)) return (wartosc * 36);
                    if ((pierwszaLista == 2) && (drugaLista == 1)) return (wartosc * 3);
                    if ((pierwszaLista == 2) && (drugaLista == 3)) return (wartosc * 0.00056);
                    if ((pierwszaLista == 3) && (drugaLista == 0)) return (wartosc * 63360);
                    if ((pierwszaLista == 3) && (drugaLista == 1)) return (wartosc * 5280);
                    if ((pierwszaLista == 3) && (drugaLista == 2)) return (wartosc * 1760);
                    break;

            }
            return 0;
        }
    }
}
