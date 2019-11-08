using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterApp
{
    class ObliczarkaTemperatury
    {
        //Nazwa na liście rozwijalnej
        public static string Temperatura = "Temperatura";

        //Konwerter temperatury

        public float KonwertujTemperature(string JednostkaPoczatkowa, string JednostkaKoncowa, float wartosc)
        {
            //"Celcjusz", "Farenheit", "Kelvin"
            //zamiana wartosci na double
            double WartoscDouble = Convert.ToDouble(wartosc);

            //Konwersja temperatury na Kelwiny            
            if (JednostkaPoczatkowa == "Celcjusz")
                WartoscDouble += 273.15;
            else if (JednostkaPoczatkowa == "Farenheit")
                WartoscDouble = (WartoscDouble + 459.67) * ((double)5 / (double)9);
            else if (JednostkaPoczatkowa == "Rankine")
                WartoscDouble = (WartoscDouble) * ((double)5 / (double)9);
            else if (JednostkaPoczatkowa == "Kelvin") ;
            /*----------------------------*/
            /* ----------z kelvinów-------*/
            /*----------------------------*/
            if (JednostkaKoncowa == "Celcjusz")
                WartoscDouble -= 273.15;
            else if (JednostkaKoncowa == "Farenheit")
                WartoscDouble = WartoscDouble * ((double)9 / (double)5) - 459.67;
            else if (JednostkaKoncowa == "Rankine")
                WartoscDouble = WartoscDouble * ((double)9 / (double)5);
            else if (JednostkaKoncowa == "Kelvin") ;

            wartosc = (float)WartoscDouble;
            return wartosc;

        }
    }
}
