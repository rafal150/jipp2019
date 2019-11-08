using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterApp
{
    class ObliczarkaDlugosci
    {
        public static string Dlugosc = "Długość";

        public float KonwertujDlugosc(string JednostkaPoczatkowa, string JednostkaKoncowa, float wartosc)
        {
            //zamiana na double
            double WartoscDouble = Convert.ToDouble(wartosc);
            //Konwersja długości na metry
            if (JednostkaPoczatkowa == "Milimetry") WartoscDouble *= 0.001;
            else if (JednostkaPoczatkowa == "Centymetry")
                WartoscDouble *= 0.01;
            else if (JednostkaPoczatkowa == "Decymetry")
                WartoscDouble *= 0.1;
            else if (JednostkaPoczatkowa == "Kilometry")
                WartoscDouble *= 1000;
            else if (JednostkaPoczatkowa == "Cale")
                WartoscDouble *= 0.0254;
            else if (JednostkaPoczatkowa == "Stopy")
                WartoscDouble *= 0.3048;
            else if (JednostkaPoczatkowa == "Jardy")
                WartoscDouble *= 0.9144;
            else if (JednostkaPoczatkowa == "Mile")
                WartoscDouble *= 1609.344;
            else if (JednostkaPoczatkowa == "Kable")
                WartoscDouble *= 185.2;
            else if (JednostkaPoczatkowa == "Mile morskie")
                WartoscDouble *= 1852;
            else if (JednostkaPoczatkowa == "Metry") ;
            /*----------------------------*/
            /* -----------z metrów--------*/
            /*----------------------------*/
            if (JednostkaKoncowa == "Milimetry") WartoscDouble *= 1000;
            else if (JednostkaKoncowa == "Centymetry")
                WartoscDouble *= 100;
            else if (JednostkaKoncowa == "Decymetry")
                WartoscDouble *= 10;
            else if (JednostkaKoncowa == "Metry") ;
            else if (JednostkaKoncowa == "Kilometry")
                WartoscDouble *= 0.001;
            else if (JednostkaKoncowa == "Cale")
                WartoscDouble *= 39.37;
            else if (JednostkaKoncowa == "Stopy")
                WartoscDouble *= 3.2808399;
            else if (JednostkaKoncowa == "Jardy")
                WartoscDouble *= 1.0936133;
            else if (JednostkaKoncowa == "Mile")
                WartoscDouble *= 0.000621371192;
            else if (JednostkaKoncowa == "Kable")
                WartoscDouble *= 0.005399568034;
            else if (JednostkaKoncowa == "Mile morskie")
                WartoscDouble *= 0.0005399568034;

            //zamiana na float
            wartosc = (float)WartoscDouble;
            return wartosc;
        }
    }
}
