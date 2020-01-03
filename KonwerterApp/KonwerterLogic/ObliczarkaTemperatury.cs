using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterApp.Services
{
    class ObliczarkaTemperatury:IConverter
    {
        //Nazwa na liście rozwijalnej
        public  string Nazwa => "Temperatura";

        public List <string> Jednostki => new List<string> (new [] { "Celcjusz", "Farenheit", "Kelvin", "Rankine" });

        //Konwerter temperatury

        public float Konwertuj(string JednostkaPoczatkowa, string JednostkaKoncowa, float wartosc)
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
