using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwenter
{
    class LiczenieMasy
    {
        public double konwe(int glowna, int pierwszaLista, int drugaLista, int wartosc)
        {
            if (pierwszaLista == drugaLista) return wartosc;

            switch (glowna)
            {
                case 4:
                    if ((pierwszaLista == 0) && (drugaLista == 1)) return (wartosc / 1000);
                    if ((pierwszaLista == 0) && (drugaLista == 2)) return (wartosc / 10000);
                    if ((pierwszaLista == 0) && (drugaLista == 3)) return (wartosc / 100000);
                    if ((pierwszaLista == 0) && (drugaLista == 4)) return (wartosc / 1000000);
                    if ((pierwszaLista == 1) && (drugaLista == 0)) return (wartosc * 1000);
                    if ((pierwszaLista == 1) && (drugaLista == 2)) return (wartosc / 10);
                    if ((pierwszaLista == 1) && (drugaLista == 3)) return (wartosc / 1000);
                    if ((pierwszaLista == 1) && (drugaLista == 4)) return (wartosc / 1000000);
                    if ((pierwszaLista == 2) && (drugaLista == 0)) return (wartosc * 1000);
                    if ((pierwszaLista == 2) && (drugaLista == 2)) return (wartosc / 10);
                    if ((pierwszaLista == 2) && (drugaLista == 3)) return (wartosc / 1000);
                    if ((pierwszaLista == 2) && (drugaLista == 4)) return (wartosc / 1000000);
                    if ((pierwszaLista == 3) && (drugaLista == 0)) return (wartosc * 10000);
                    if ((pierwszaLista == 3) && (drugaLista == 1)) return (wartosc * 10);
                    if ((pierwszaLista == 3) && (drugaLista == 2)) return (wartosc / 100);
                    if ((pierwszaLista == 3) && (drugaLista == 4)) return (wartosc / 100000);
                    if ((pierwszaLista == 4) && (drugaLista == 0)) return (wartosc * 1000000000);
                    if ((pierwszaLista == 4) && (drugaLista == 1)) return (wartosc * 1000000);
                    if ((pierwszaLista == 4) && (drugaLista == 2)) return (wartosc * 100000);
                    if ((pierwszaLista == 4) && (drugaLista == 3)) return (wartosc * 1000);
                    break;

            }
            return 0;
        }
    }
}
