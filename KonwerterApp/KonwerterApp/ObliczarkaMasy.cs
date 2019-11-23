using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterApp.Services
{
    class ObliczarkaMasy:IConverter
    {
        public string Nazwa => "Masa";

        public List<string> Jednostki => new List<string>(new[] { "Miligramy", "Gramy", "Dekagramy", "Kilogramy", "Tony", "Uncje", "Funty", "Karaty", "Kwintale" });

        public float Konwertuj(string JednostkaPoczatkowa, string JednostkaKoncowa, float wartosc)
        {
            //  string[] Metryczne = { "Miligramy", "Gramy", "Dekagramy", "Kilogramy", "Tony" };
            //  string[] Anglosaskie = { "Uncje", "Funty" };
            //  string[] Inne = { "Karaty", "Kwintale" };

            //zamiana na double
            double WartoscDouble = Convert.ToDouble(wartosc);
            if (JednostkaPoczatkowa == "Miligramy")
                WartoscDouble *= 0.001;
            else if (JednostkaPoczatkowa == "Dekagramy")
                WartoscDouble *= 10;
            else if (JednostkaPoczatkowa == "Kilogramy")
                WartoscDouble *= 1000;
            else if (JednostkaPoczatkowa == "Tony")
                WartoscDouble *= 1000000;
            else if (JednostkaPoczatkowa == "Uncje")
                WartoscDouble *= 28.3495231;
            else if (JednostkaPoczatkowa == "Funty")
                WartoscDouble *= 453.59237;
            else if (JednostkaPoczatkowa == "Karaty")
                WartoscDouble *= 0.2;
            else if (JednostkaPoczatkowa == "Kwintale")
                WartoscDouble *= 100000;
            else if (JednostkaPoczatkowa == "Gramy") ;
            /*----------------------------*/
            /* -----------z gramów--------*/
            /*----------------------------*/
            if (JednostkaKoncowa == "Miligramy")
                WartoscDouble *= 1000;
            else if (JednostkaKoncowa == "Gramy")
                WartoscDouble *= 1;
            else if (JednostkaKoncowa == "Dekagramy")
                WartoscDouble *= 0.1;
            else if (JednostkaKoncowa == "Kilogramy")
                WartoscDouble *= 0.001;
            else if (JednostkaKoncowa == "Tony")
                WartoscDouble *= 1000000;
            else if (JednostkaKoncowa == "Uncje")
                WartoscDouble *= 0.0352739619;
            else if (JednostkaKoncowa == "Funty")
                WartoscDouble *= 0.00220462262;
            else if (JednostkaKoncowa == "Karaty")
                WartoscDouble *= 5;
            else if (JednostkaKoncowa == "Kwintale")
                WartoscDouble *= 0.00001;

            wartosc = (float)WartoscDouble;
            return wartosc;
        }
    }
}
