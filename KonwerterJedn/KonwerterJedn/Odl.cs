using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    class Odl
    {
        public string OdlFrom;
        public string OdlTo;
        public double Wartosc;
        public double Wynik;
        public string Type = "Odleglosc";
        public string WynikString;

        public Odl(string OdlFrom, string OdlTo, double Wartosc)
        {
            ////mm////
            if (OdlFrom == "mm" && OdlTo == "mm")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "cm")
            {
                Wynik = (Wartosc / 10);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "dcm")
            {
                Wynik = (Wartosc / 100);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "m")
            {
                Wynik = (Wartosc / 1000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "km")
            {
                Wynik = (Wartosc / 1000000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 0.03937);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 0.0033);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 0.0033);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.00000062137);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 0.000053996);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mm" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.0000053996);
                WynikString = Wynik.ToString();
            }


            //cm////
            if (OdlFrom == "cm" && OdlTo == "cm")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 10);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "m")
            {
                Wynik = (Wartosc * 0.01);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "km")
            {
                Wynik = (Wartosc / 100000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "cal")
            {
                Wynik = (Wartosc / 2.54);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 0.0328);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 0.010936);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "mila")
            {
                Wynik = (Wartosc / 6.214);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 0.00053996);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cm" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.000053996);
                WynikString = Wynik.ToString();
            }


            ///dcm////
            if (OdlFrom == "dcm" && OdlTo == "dcm")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 100);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "m")
            {
                Wynik = (Wartosc / 10);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 10);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "km")
            {
                Wynik = (Wartosc / 10000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 25.4);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "stopa")
            {
                Wynik = ((Wartosc / 25) / 12);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 914.4);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.00062137);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 0.0005);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "dcm" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.00005);
                WynikString = Wynik.ToString();
            }



            ////m////
            if (OdlFrom == "m" && OdlTo == "m")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 100);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 10);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 1000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "km")
            {
                Wynik = (Wartosc * 0.001);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 39.370079);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 3.28084);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 1.093613);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.000621);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 0.0054);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "m" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.0054);
                WynikString = Wynik.ToString();
            }


            //km///
            if (OdlFrom == "km" && OdlTo == "km")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 1000000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 10000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 100000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "m")
            {
                Wynik = (Wartosc * 1000);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 39.37007874);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 3.280839895);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 1.093613298);
                WynikString = Wynik.ToString();
            }

            if (OdlFrom == "km" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.621371);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 5.3996);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "km" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.54);
                WynikString = Wynik.ToString();
            }


            ////cal////
            if (OdlFrom == "cal" && OdlTo == "cal")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 25.4);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 0.254);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 2.54);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "m")
            {
                Wynik = (Wartosc * 0.0254);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "km")
            {
                Wynik = (Wartosc * 0.0000254);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "stopa")
            {
                Wynik = (Wartosc / 12);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 0.027778);
                WynikString = Wynik.ToString();
            }

            if (OdlFrom == "cal" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.000015783);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 0.0001);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "cal" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.00013715);
                WynikString = Wynik.ToString();
            }


            ///stopa////
            if (OdlFrom == "stopa" && OdlTo == "stopa")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 304.8);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 3.048);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "km")
            {
                Wynik = (Wartosc * 0.000305);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 30.48);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "m")
            {
                Wynik = (Wartosc * 0.3048);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 12);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 0.333333);
                WynikString = Wynik.ToString();
            }

            if (OdlFrom == "stopa" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.000189);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 0.0016);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "stopa" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.0002);
                WynikString = Wynik.ToString();
            }

            ////jard////
            if (OdlFrom == "jard" && OdlTo == "jard")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 914.4);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 9.144);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 91.44);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "m")
            {
                Wynik = (Wartosc * 0.9144);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "km")
            {
                Wynik = (Wartosc * 0.000914);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 3);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 0.000568);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.000568);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 0.0049);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "jard" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.0005);
                WynikString = Wynik.ToString();
            }


            ///mila////
            if (OdlFrom == "mila" && OdlTo == "mila")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 1.609344);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 160.9344);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 16093.44);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "m")
            {
                Wynik = (Wartosc * 1.609344);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 63.360);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 5.280);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 1.760);
                WynikString = Wynik.ToString();
            }

            if (OdlFrom == "mila" && OdlTo == "km")
            {
                Wynik = (Wartosc * 1.609344);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 8.6898);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.869);
                WynikString = Wynik.ToString();
            }


            ///kabel///
            if (OdlFrom == "kabel" && OdlTo == "kabel")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 0.00018520);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 1.8520);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 1852);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "m")
            {
                Wynik = (Wartosc * 185.2);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 7291.3386);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 607.6116);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 202.5372);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 0.1151);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "km")
            {
                Wynik = (Wartosc * 0.1852);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "kabel" && OdlTo == "mila morska")
            {
                Wynik = (Wartosc * 0.1);
                WynikString = Wynik.ToString();
            }


            ///milamorska////
            if (OdlFrom == "mila morska" && OdlTo == "mila morska")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "mm")
            {
                Wynik = (Wartosc * 0.000018520);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "dcm")
            {
                Wynik = (Wartosc * 18520);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "cm")
            {
                Wynik = (Wartosc * 0.00018520);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "m")
            {
                Wynik = (Wartosc * 1852);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "cal")
            {
                Wynik = (Wartosc * 72913.3858);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "stopa")
            {
                Wynik = (Wartosc * 6076.1155);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "jard")
            {
                Wynik = (Wartosc * 2025.3718);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "mila")
            {
                Wynik = (Wartosc * 1.1508);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "kabel")
            {
                Wynik = (Wartosc * 19);
                WynikString = Wynik.ToString();
            }
            if (OdlFrom == "mila morska" && OdlTo == "km")
            {
                Wynik = (Wartosc * 1.852);
                WynikString = Wynik.ToString();
            }
        }
        public string PodajWynik()
        { return this.WynikString; }
    }

}
