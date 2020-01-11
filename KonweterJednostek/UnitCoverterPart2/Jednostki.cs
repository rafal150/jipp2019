using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Jednostki
    {

        public List<string> temp = new List<string>() { "C", "F", "K", "R" };
        public List<string> dlugosci = new List<string>() { "mm", "cm", "dcm", "m", "km" };
        public List<string> masa = new List<string>() { "mg", "g", "dkg", "kg", "T" };

        public string Oblicz(double i, string x, string y)
        {
            // TEMPERATURA
            //celcjusze
            double conver = 0;
            if (x == "C" && y == "K")
            {
                conver = i + 273.15;
                return conver.ToString();
            }
            if (x == "C" && y == "C")
            {
                conver = i;
                return conver.ToString();
            }
            if (x == "C" && y == "R")
            {
                conver = (i + 273.15) * 1.8;
                return conver.ToString();
            }
            if (x == "C" && y == "F")
            {
                conver = (i * 1.8) + 32;
                return conver.ToString();
            }

            //Kelviny
            if (x == "K" && y == "C")
            {
                conver = i - 273.15;
                return conver.ToString();
            }
            if (x == "K" && y == "F")
            {
                conver = (i - 273.15) * 1.8 + 32;
                return conver.ToString();
            }
            if (x == "K" && y == "K")
            {
                conver = i;
                return conver.ToString();
            }
            if (x == "K" && y == "R")
            {
                conver = i * 1.8;
                return conver.ToString();
            }
            //Fahrenheity
            if (x == "F" && y == "C")
            {
                conver = (i - 32) / 1.8;
                return conver.ToString();
            }
            if (x == "F" && y == "F")
            {
                conver = i;
                return conver.ToString();
            }
            if (x == "F" && y == "K")
            {
                conver = (i + 459.67) * 0.555555555;
                return conver.ToString();
            }
            if (x == "F" && y == "R")
            {
                conver = i + 459.67;
                return conver.ToString();
            }
            // rankine

            //Kelviny
            if (x == "R" && y == "C")
            {
                conver = i / 1.8 - 273.15;
                return conver.ToString();
            }
            if (x == "R" && y == "F")
            {
                conver = i - 459.67;
                return conver.ToString();
            }
            if (x == "R" && y == "K")
            {
                conver = i / 1.8;
                return conver.ToString();
            }
            if (x == "R" && y == "R")
            {
                conver = i;
                return conver.ToString();
            }




            // DLUGOSCI
            //milimetry
            if (x == "mm" && y == "mm") { conver = i; return conver.ToString(); }
            if (x == "mm" && y == "cm") { conver = i * 0.1; return conver.ToString(); }
            if (x == "mm" && y == "dcm") { conver = i * 0.01; return conver.ToString(); }
            if (x == "mm" && y == "m") { conver = i * 0.001; return conver.ToString(); }
            if (x == "mm" && y == "km") { conver = i * 0.000001; return conver.ToString(); }

            //centymetry
            if (x == "cm" && y == "mm") { conver = i * 10; return conver.ToString(); }
            if (x == "cm" && y == "cm") { conver = i; return conver.ToString(); }
            if (x == "cm" && y == "dcm") { conver = i * 0.1; return conver.ToString(); }
            if (x == "cm" && y == "m") { conver = i * 0.01; return conver.ToString(); }
            if (x == "cm" && y == "km") { conver = i * 0.00001; return conver.ToString(); }

            //decymetry
            if (x == "dcm" && y == "mm") { conver = i * 100; return conver.ToString(); }
            if (x == "dcm" && y == "cm") { conver = i * 10; return conver.ToString(); }
            if (x == "dcm" && y == "dcm") { conver = i * 1; return conver.ToString(); }
            if (x == "dcm" && y == "m") { conver = i * 0.1; return conver.ToString(); }
            if (x == "dcm" && y == "km") { conver = i * 0.0001; return conver.ToString(); }

            //metry
            if (x == "m" && y == "mm") { conver = i * 1000; return conver.ToString(); }
            if (x == "m" && y == "cm") { conver = i * 100; return conver.ToString(); }
            if (x == "m" && y == "dcm") { conver = i * 10; return conver.ToString(); }
            if (x == "m" && y == "m") { conver = i * 1; return conver.ToString(); }
            if (x == "m" && y == "km") { conver = i * 0.001; return conver.ToString(); }

            //kilometry

            if (x == "km" && y == "mm") { conver = i * 1000000; return conver.ToString(); }
            if (x == "km" && y == "cm") { conver = i * 100000; return conver.ToString(); }
            if (x == "km" && y == "dcm") { conver = i * 10000; return conver.ToString(); }
            if (x == "km" && y == "m") { conver = i * 1000; return conver.ToString(); }
            if (x == "km" && y == "km") { conver = i * 1; return conver.ToString(); }



            //MASA

            // MASA
            //MILIGRAMY
            if (x == "mg" && y == "mg") { conver = i * 1; return conver.ToString(); }
            if (x == "mg" && y == "g") { conver = i * 0.001; return conver.ToString(); }
            if (x == "mg" && y == "dkg") { conver = i * 0.0001; return conver.ToString(); }
            if (x == "mg" && y == "kg") { conver = i * 0.000001; return conver.ToString(); }
            if (x == "mg" && y == "T") { conver = i * 0.000000001; return conver.ToString(); }

            //GRAMY
            if (x == "g" && y == "mg") { conver = i * 1000; return conver.ToString(); }
            if (x == "g" && y == "g") { conver = i; return conver.ToString(); }
            if (x == "g" && y == "dkg") { conver = i * 0.1; return conver.ToString(); }
            if (x == "g" && y == "kg") { conver = i * 0.001; return conver.ToString(); }
            if (x == "g" && y == "T") { conver = i * 0.000001; return conver.ToString(); }

            //DEKAGRAMY
            if (x == "dkg" && y == "mg") { conver = i * 10000; return conver.ToString(); }
            if (x == "dkg" && y == "g") { conver = i * 10; return conver.ToString(); }
            if (x == "dkg" && y == "dkg") { conver = i; return conver.ToString(); }
            if (x == "dkg" && y == "kg") { conver = i * 0.01; return conver.ToString(); }
            if (x == "dkg" && y == "T") { conver = i * 0.00001; return conver.ToString(); }

            //KILOGRAM
            if (x == "kg" && y == "mg") { conver = i * 1000000; return conver.ToString(); }
            if (x == "kg" && y == "g") { conver = i * 1000; return conver.ToString(); }
            if (x == "kg" && y == "dkg") { conver = i * 100; return conver.ToString(); }
            if (x == "kg" && y == "kg") { conver = i; return conver.ToString(); }
            if (x == "kg" && y == "T") { conver = i * 0.001; return conver.ToString(); }

            //TONA

            if (x == "T" && y == "mg") { conver = i * 1000000000; return conver.ToString(); }
            if (x == "T" && y == "g") { conver = i * 1000000; return conver.ToString(); }
            if (x == "T" && y == "dkg") { conver = i * 100000; return conver.ToString(); }
            if (x == "T" && y == "kg") { conver = i * 1000; return conver.ToString(); }
            if (x == "T" && y == "T") { conver = i * 1; return conver.ToString(); }


            else
                return "błędny wybór";
        }


    }
}
