using KonwerterJedn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterCzasuPlugin
{
    public class Czas : IConverter
    {
        public string Nazwa => "Czas";

        public List<string> Jednostki => new List<string>(new[] { "s", "min", "h", "dzien", "tydzien", "miesiac", "rok", "wiek" });

        public double Convert(string unitFrom, string unitTo, double Wartosc)
        {
            //////s///////
            if (unitFrom == "s" && unitTo == "s")
            {
                return Wartosc;
            }
            else if (unitFrom == "s" && unitTo == "min")
            {
                Wartosc = (Wartosc * 0.01667);
                return Wartosc;
            }
            else if (unitFrom == "s" && unitTo == "h")
            {
                Wartosc = (Wartosc * 0.0002778);
                return Wartosc;
            }
            else if (unitFrom == "s" && unitTo == "dzien")
            {
                Wartosc = (Wartosc * 0.00001157);
                return Wartosc;
            }
            else if (unitFrom == "s" && unitTo == "tydzien")
            {
                Wartosc = (Wartosc * 0.000001653);
                return Wartosc;
            }
            else if (unitFrom == "s" && unitTo == "miesiac")
            {
                Wartosc = (Wartosc * 0.0000003803);
                return Wartosc;
            }
            else if (unitFrom == "s" && unitTo == "rok")
            {
                Wartosc = (Wartosc * 0.00000003169);
                return Wartosc;
            }
            else if (unitFrom == "s" && unitTo == "wiek")
            {
                Wartosc = (Wartosc * 0.0000000003169);
                return Wartosc;
            }


            ///////////min////////////
            else if (unitFrom == "min" && unitTo == "min")
            {
                return Wartosc;
            }
            else if (unitFrom == "min" && unitTo == "s")
            {
                Wartosc = (Wartosc * 60);
                return Wartosc;
            }
            else if (unitFrom == "min" && unitTo == "h")
            {
                Wartosc = (Wartosc * 0.01667);
                return Wartosc;
            }
            else if (unitFrom == "min" && unitTo == "dzien")
            {
                Wartosc = (Wartosc * 0.0006944);
                return Wartosc;
            }
            else if (unitFrom == "min" && unitTo == "tydzien")
            {
                Wartosc = (Wartosc * 0.00009921);
                return Wartosc;
            }
            else if (unitFrom == "min" && unitTo == "miesiac")
            {
                Wartosc = (Wartosc * 0.00002282);
                return Wartosc;
            }
            else if (unitFrom == "min" && unitTo == "rok")
            {
                Wartosc = (Wartosc * 0.00002282);
                return Wartosc;
            }
            else if (unitFrom == "min" && unitTo == "wiek")
            {
                Wartosc = (Wartosc * 0.00000001901);
                return Wartosc;
            }



            ////h/////
            else if (unitFrom == "h" && unitTo == "h")
            {
                return Wartosc;
            }
            else if (unitFrom == "h" && unitTo == "s")
            {
                Wartosc = (Wartosc * 3600);
                return Wartosc;
            }
            else if (unitFrom == "h" && unitTo == "min")
            {
                Wartosc = (Wartosc * 60);
                return Wartosc;
            }
            else if (unitFrom == "h" && unitTo == "dzien")
            {
                Wartosc = (Wartosc * 0.04167);
                return Wartosc;
            }
            else if (unitFrom == "h" && unitTo == "tydzien")
            {
                Wartosc = (Wartosc * 0.005952);
                return Wartosc;
            }
            else if (unitFrom == "h" && unitTo == "miesiac")
            {
                Wartosc = (Wartosc * 0.001369);
                return Wartosc;
            }
            else if (unitFrom == "h" && unitTo == "rok")
            {
                Wartosc = (Wartosc * 0.0001141);
                return Wartosc;
            }

            else if (unitFrom == "h" && unitTo == "wiek")
            {
                Wartosc = (Wartosc * 0.000001141);
                return Wartosc;
            }



            ////dzien/////
            if (unitFrom == "dzien" && unitTo == "dzien")
            {
                return Wartosc;
            }
            else if (unitFrom == "dzien" && unitTo == "s")
            {
                Wartosc = (Wartosc * 86400);
                return Wartosc;
            }
            else if (unitFrom == "dzien" && unitTo == "min")
            {
                Wartosc = (Wartosc * 1440);
                return Wartosc;
            }
            else if (unitFrom == "dzien" && unitTo == "h")
            {
                Wartosc = (Wartosc * 24);
                return Wartosc;
            }
            else if (unitFrom == "dzien" && unitTo == "tydzien")
            {
                Wartosc = (Wartosc * 0.1429);
                return Wartosc;
            }
            else if (unitFrom == "dzien" && unitTo == "miesiac")
            {
                Wartosc = (Wartosc * 0.03285);
                return Wartosc;
            }
            else if (unitFrom == "dzien" && unitTo == "rok")
            {
                Wartosc = (Wartosc * 0.002738);
                return Wartosc;
            }
            else if (unitFrom == "dzien" && unitTo == "wiek")
            {
                Wartosc = (Wartosc * 0.00002738);
                return Wartosc;
            }




            ////tydzien/////
            if (unitFrom == "tydzien" && unitTo == "tydzien")
            {
                return Wartosc;
            }
            else if (unitFrom == "tydzien" && unitTo == "s")
            {
                Wartosc = (Wartosc * 604800);
                //WartoscString = Wartosc.ToString();
                return Wartosc;
            }
            else if (unitFrom == "tydzien" && unitTo == "min")
            {
                Wartosc = (Wartosc * 10080);
                // WartoscString = Wartosc.ToString();
                return Wartosc;
            }
            else if (unitFrom == "tydzien" && unitTo == "h")
            {
                Wartosc = (Wartosc * 168);
                // WartoscString = Wartosc.ToString();
                return Wartosc;
            }
            else if (unitFrom == "tydzien" && unitTo == "dzien")
            {
                Wartosc = (Wartosc * 7);
                // WartoscString = Wartosc.ToString();
                return Wartosc;
            }
            else if (unitFrom == "tydzien" && unitTo == "miesiac")
            {
                Wartosc = (Wartosc * 0.23);
                // WartoscString = Wartosc.ToString();
                return Wartosc;
            }
            else if (unitFrom == "tydzien" && unitTo == "rok")
            {
                Wartosc = (Wartosc * 0.01916);
                // WartoscString = Wartosc.ToString();
                return Wartosc;
            }
            else if (unitFrom == "tydzien" && unitTo == "wiek")
            {
                Wartosc = (Wartosc * 0.0001917);
                // WartoscString = Wartosc.ToString();
                return Wartosc;
            }



            /////miesiac//////
            if (unitFrom == "miesiac" && unitTo == "miesiac")
            {
                return Wartosc;
            }
            else if (unitFrom == "miesiac" && unitTo == "s")
            {
                Wartosc = (Wartosc * 2629744);
                return Wartosc;
            }
            else if (unitFrom == "miesiac" && unitTo == "min")
            {
                Wartosc = (Wartosc * 43829);
                return Wartosc;
            }
            else if (unitFrom == "miesiac" && unitTo == "h")
            {
                Wartosc = (Wartosc * 730.5);
                return Wartosc;
            }
            else if (unitFrom == "miesiac" && unitTo == "dzien")
            {
                Wartosc = (Wartosc * 730.5);
                return Wartosc;
            }
            else if (unitFrom == "miesiac" && unitTo == "tydzien")
            {
                Wartosc = (Wartosc * 4.348);
                return Wartosc;
            }
            else if (unitFrom == "miesiac" && unitTo == "rok")
            {
                Wartosc = (Wartosc * 0.08333);
                return Wartosc;
            }
            else if (unitFrom == "miesiac" && unitTo == "wiek")
            {
                Wartosc = (Wartosc * 0.08333);
                return Wartosc;
            }

            ////rok///////
            else if (unitFrom == "rok" && unitTo == "rok")
            {
                return Wartosc;
            }
            else if (unitFrom == "rok" && unitTo == "s")
            {
                Wartosc = (Wartosc * 31557600);
                return Wartosc;
            }
            else if (unitFrom == "rok" && unitTo == "min")
            {
                Wartosc = (Wartosc * 525960);
                return Wartosc;
            }
            else if (unitFrom == "rok" && unitTo == "h")
            {
                Wartosc = (Wartosc * 8766);
                return Wartosc;
            }
            else if (unitFrom == "rok" && unitTo == "dzien")
            {
                Wartosc = (Wartosc * 365.3);
                return Wartosc;
            }
            else if (unitFrom == "rok" && unitTo == "tydzien")
            {
                Wartosc = (Wartosc * 365.3);
                return Wartosc;
            }
            else if (unitFrom == "rok" && unitTo == "miesiac")
            {
                Wartosc = (Wartosc * 12);
                return Wartosc;
            }
            else if (unitFrom == "rok" && unitTo == "wiek")
            {
                Wartosc = (Wartosc * 365.3);
                return Wartosc;
            }

            ////wiek/////
            if (unitFrom == "wiek" && unitTo == "wiek")
            {
                return Wartosc;
            }
            else if (unitFrom == "wiek" && unitTo == "s")
            {
                Wartosc = (Wartosc * 3155692600);
                return Wartosc;
            }
            else if (unitFrom == "wiek" && unitTo == "min")
            {
                Wartosc = (Wartosc * 52594877);
                return Wartosc;
            }
            else if (unitFrom == "wiek" && unitTo == "h")
            {
                Wartosc = (Wartosc * 876581);
                return Wartosc;
            }
            else if (unitFrom == "wiek" && unitTo == "dzien")
            {
                Wartosc = (Wartosc * 876581);
                return Wartosc;
            }
            else if (unitFrom == "wiek" && unitTo == "tydzien")
            {
                Wartosc = (Wartosc * 5218);
                return Wartosc;
            }
            else if (unitFrom == "wiek" && unitTo == "miesiac")
            {
                Wartosc = (Wartosc * 1200);
                return Wartosc;
            }
            else if (unitFrom == "wiek" && unitTo == "rok")
            {
                Wartosc = (Wartosc * 100);
                return Wartosc;
            }

            else
                return 0;
        }
        //public string PodajWartosc()
        // { return this.WartoscString; }

    }
}
    

