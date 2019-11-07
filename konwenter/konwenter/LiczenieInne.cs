using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwenter
{
    class LiczenieInne
    {
        public double konwe(int glowna, int pierwszaLista, int drugaLista, int wartosc)
        {
            if (pierwszaLista == drugaLista) return wartosc;

            switch (glowna)
            {
                case 6:
                    if ((pierwszaLista == 0) && (drugaLista == 1)) return (wartosc * 0.000002);
                    if ((pierwszaLista == 1) && (drugaLista == 0)) return (wartosc * 500000);
                   
                    break;

            }
            return 0;
        }
    }
}
