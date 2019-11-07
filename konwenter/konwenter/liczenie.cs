using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwenter
{
    class liczenie
    {
        public double konwe(int glowna, int pierwszaLista, int drugaLista, int wartosc)
        {
            if (pierwszaLista == drugaLista) return wartosc;

            switch (glowna)
            {
                case 0:
                    if ((pierwszaLista == 0) && (drugaLista == 1)) return (wartosc + 273);
                    if ((pierwszaLista == 0) && (drugaLista == 2)) return (wartosc + 34);
                    if ((pierwszaLista == 0) && (drugaLista == 3)) return (wartosc * 1.8 + 491);
                    if ((pierwszaLista == 1) && (drugaLista == 0)) return (wartosc - 273);
                    if ((pierwszaLista == 1) && (drugaLista == 2)) return (wartosc + 1.8 + 32);
                    if ((pierwszaLista == 1) && (drugaLista == 3)) return (wartosc * 1.8 + 491);
                    if ((pierwszaLista == 2) && (drugaLista == 0)) return (wartosc - 32 / 1.8);
                    if ((pierwszaLista == 2) && (drugaLista == 1)) return (wartosc - 32 / 1.8 + 273);
                    if ((pierwszaLista == 2) && (drugaLista == 3)) return (wartosc - 32 + 491);
                    if ((pierwszaLista == 3) && (drugaLista == 0)) return (wartosc - 491 / 1.8);
                    if ((pierwszaLista == 3) && (drugaLista == 1)) return (wartosc - 491 / 1.8 + 273);
                    if ((pierwszaLista == 3) && (drugaLista == 2)) return (wartosc + 32);
                    break;
                
            }return 0;
        }
    }
}