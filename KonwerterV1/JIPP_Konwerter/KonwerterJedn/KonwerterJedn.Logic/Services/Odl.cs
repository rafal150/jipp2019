using KonwerterJedn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    class Odl : IConverter
    {
        //public string valueFrom;
        //public string valueTo;
       // public double Wartosc; //value

        public string WartoscString;
        public string Type = "Odleglosc";


        public string Nazwa => "Odleglosc";

        public List<string> Jednostki => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });

        public double Convert(string unitFrom, string unitTo, double Wartosc)
        {

            ////mm////
            if (unitFrom == "mm" && unitTo == "mm")
            {
                return Wartosc;

            }
            if (unitFrom == "mm" && unitTo == "cm")
            {
                Wartosc = (Wartosc / 10);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "dcm")
            {
                Wartosc = (Wartosc / 100);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "m")
            {
                Wartosc = (Wartosc / 1000);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "km")
            {
                Wartosc = (Wartosc / 1000000);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 0.03937);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 0.0033);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 0.0033);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.00000062137);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 0.000053996);
                return Wartosc;
            }
            if (unitFrom == "mm" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.0000053996);
                return Wartosc;
            }


            //cm////
            if (unitFrom == "cm" && unitTo == "cm")
            {
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 10);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "m")
            {
                Wartosc = (Wartosc * 0.01);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "km")
            {
                Wartosc = (Wartosc / 100000);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "cal")
            {
                Wartosc = (Wartosc / 2.54);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 0.0328);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 0.010936);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "mila")
            {
                Wartosc = (Wartosc / 6.214);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 0.00053996);
                return Wartosc;
            }
            if (unitFrom == "cm" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.000053996);
                return Wartosc;
            }


            ///dcm////
            if (unitFrom == "dcm" && unitTo == "dcm")
            {
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 100);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "m")
            {
                Wartosc = (Wartosc / 10);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 10);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "km")
            {
                Wartosc = (Wartosc / 10000);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 25.4);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "stopa")
            {
                Wartosc = ((Wartosc / 25) / 12);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 914.4);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.00062137);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 0.0005);
                return Wartosc;
            }
            if (unitFrom == "dcm" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.00005);
                return Wartosc;
            }



            ////m////
            if (unitFrom == "m" && unitTo == "m")
            {
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 100);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 10);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 1000);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "km")
            {
                Wartosc = (Wartosc * 0.001);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 39.370079);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 3.28084);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 1.093613);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.000621);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 0.0054);
                return Wartosc;
            }
            if (unitFrom == "m" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.0054);
                return Wartosc;
            }


            //km///
            if (unitFrom == "km" && unitTo == "km")
            {
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 1000000);
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 10000);
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 100000);
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "m")
            {
                Wartosc = (Wartosc * 1000);
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 39.37007874);
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 3.280839895);
                WartoscString = Wartosc.ToString();
            }
            if (unitFrom == "km" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 1.093613298);
                return Wartosc;
            }

            if (unitFrom == "km" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.621371);
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 5.3996);
                return Wartosc;
            }
            if (unitFrom == "km" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.54);
                return Wartosc;
            }


            ////cal////
            if (unitFrom == "cal" && unitTo == "cal")
            {
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 25.4);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 0.254);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 2.54);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "m")
            {
                Wartosc = (Wartosc * 0.0254);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "km")
            {
                Wartosc = (Wartosc * 0.0000254);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "stopa")
            {
                Wartosc = (Wartosc / 12);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 0.027778);
                return Wartosc;
            }

            if (unitFrom == "cal" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.000015783);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 0.0001);
                return Wartosc;
            }
            if (unitFrom == "cal" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.00013715);
                return Wartosc;
            }


            ///stopa////
            if (unitFrom == "stopa" && unitTo == "stopa")
            {
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 304.8);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 3.048);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "km")
            {
                Wartosc = (Wartosc * 0.000305);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 30.48);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "m")
            {
                Wartosc = (Wartosc * 0.3048);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 12);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 0.333333);
                return Wartosc;
            }

            if (unitFrom == "stopa" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.000189);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 0.0016);
                return Wartosc;
            }
            if (unitFrom == "stopa" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.0002);
                return Wartosc;
            }

            ////jard////
            if (unitFrom == "jard" && unitTo == "jard")
            {
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 914.4);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 9.144);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 91.44);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "m")
            {
                Wartosc = (Wartosc * 0.9144);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "km")
            {
                Wartosc = (Wartosc * 0.000914);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 3);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 0.000568);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.000568);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 0.0049);
                return Wartosc;
            }
            if (unitFrom == "jard" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.0005);
                return Wartosc;
            }


            ///mila////
            if (unitFrom == "mila" && unitTo == "mila")
            {
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 1.609344);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 160.9344);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 16093.44);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "m")
            {
                Wartosc = (Wartosc * 1.609344);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 63.360);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 5.280);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 1.760);
                return Wartosc;
            }

            if (unitFrom == "mila" && unitTo == "km")
            {
                Wartosc = (Wartosc * 1.609344);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 8.6898);
                return Wartosc;
            }
            if (unitFrom == "mila" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.869);
                return Wartosc;
            }


            ///kabel///
            if (unitFrom == "kabel" && unitTo == "kabel")
            {
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 0.00018520);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 1.8520);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 1852);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "m")
            {
                Wartosc = (Wartosc * 185.2);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 7291.3386);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 607.6116);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 202.5372);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 0.1151);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "km")
            {
                Wartosc = (Wartosc * 0.1852);
                return Wartosc;
            }
            if (unitFrom == "kabel" && unitTo == "mila morska")
            {
                Wartosc = (Wartosc * 0.1);
                return Wartosc;
            }


            ///milamorska////
            if (unitFrom == "mila morska" && unitTo == "mila morska")
            {
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "mm")
            {
                Wartosc = (Wartosc * 0.000018520);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "dcm")
            {
                Wartosc = (Wartosc * 18520);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "cm")
            {
                Wartosc = (Wartosc * 0.00018520);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "m")
            {
                Wartosc = (Wartosc * 1852);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "cal")
            {
                Wartosc = (Wartosc * 72913.3858);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "stopa")
            {
                Wartosc = (Wartosc * 6076.1155);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "jard")
            {
                Wartosc = (Wartosc * 2025.3718);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "mila")
            {
                Wartosc = (Wartosc * 1.1508);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "kabel")
            {
                Wartosc = (Wartosc * 19);
                return Wartosc;
            }
            if (unitFrom == "mila morska" && unitTo == "km")
            {
                Wartosc = (Wartosc * 1.852);
                return Wartosc;
            }
            else
                return 0;
        }
       // public string PodajWartosc()
       // { return this.WartoscString; }
    }

}
