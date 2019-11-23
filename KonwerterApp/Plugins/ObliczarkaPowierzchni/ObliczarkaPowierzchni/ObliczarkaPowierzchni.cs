using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterApp.Services;

namespace ObliczarkaPowierzchni
{
    public class ObliczarkaPowierzchni : IConverter
    {
        public string Nazwa => "Powierzchnia";

        public List<string> Jednostki => new List<string>(new[] { "milimetr kwadratowy","centymetr kwadratowy","decymetr kwadratowy", "metr kwadratowy"});

        public float Konwertuj(string JednostkaPoczatkowa, string JednostkaKoncowa, float wartosc)
        {

            double WartoscDouble = Convert.ToDouble(wartosc);

            if (JednostkaPoczatkowa == "milimetr kwadratowy")
                WartoscDouble /= 1000000;
            else if (JednostkaPoczatkowa == "centymetr kwadratowy")
                WartoscDouble /= 10000;
            else if (JednostkaPoczatkowa == "decymetr kwadratowy")
                WartoscDouble /= 100;
            else if (JednostkaPoczatkowa == "metr kwadratowy") ;
            /*----------------------------*/
            /* ----------z metrów kwadratowych-------*/
            /*----------------------------*/
            if (JednostkaKoncowa == "milimetr kwadratowy")
                WartoscDouble *= 1000000;
            else if (JednostkaKoncowa == "centymetr kwadratowy")
                WartoscDouble *= 10000;
            else if (JednostkaKoncowa == "decymetr kwadratowy")
                WartoscDouble *= 100;
            else if (JednostkaKoncowa == "metr kwadratowy") ;

            wartosc = (float)WartoscDouble;
            return wartosc;
        }
    }
}
