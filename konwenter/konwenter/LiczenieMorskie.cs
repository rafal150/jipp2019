using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwenter
{
    class LiczenieMorskie
    {
        public double konwe(int glowna, int pierwszaLista, int drugaLista, int wartosc)
        {
            if (pierwszaLista == drugaLista) return wartosc;

            switch (glowna)
            {
                case 3:
                    if ((pierwszaLista == 0) && (drugaLista == 1)) return (wartosc / 10);
                    if ((pierwszaLista == 1) && (drugaLista == 0)) return (wartosc * 10);
                   
                    break;

            }
            return 0;
        }
    }
}
