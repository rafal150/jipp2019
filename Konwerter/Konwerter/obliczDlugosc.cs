using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class obliczDlugosc
    {
        string wyjscie = "";
        public void liczenieDlug(string z, string na, double wartosc)
        {   //"mm", "cm", "dcm","m", "km","cal","stop","jard","mila","kabel","mila morska"
            double wartosc_pocz = wartosc;
            if (z == "mm")  //przeliczenie wszystkiego na metry
            {
                wartosc = wartosc * 0.001;
            }
            else if (z == "cm")
            {
                wartosc = wartosc * 0.01;
            }
            else if (z == "dcm")
            {
                wartosc = wartosc * 0.1;
            }
            else if (z == "km")
            {
                wartosc = wartosc * 1000;
            }
            else if (z == "cal")
            {
                wartosc = wartosc * 0.0254;
            }
            else if (z == "stop")
            {
                wartosc = wartosc * 0.3048;
            }
            else if (z == "jard")
            {
                wartosc = wartosc * 0.9144;
            }
            else if (z == "mila")
            {
                wartosc = wartosc * 1609.344;
            }
            else if (z == "kabel")
            {
                wartosc = wartosc * 185.2;
            }
            else if (z == "mila morska")
            {
                wartosc = wartosc * 1852;
            }
            else //if (z == "m")
            { }

            if (na != z)
            {
                switch (na)
                {
                    case "mm":
                        wartosc = wartosc * 1000;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "cm":
                        wartosc = wartosc * 100;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "dcm":
                        wartosc = wartosc * 10;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "m":   //brak zmian
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "km":
                        wartosc = wartosc * 0.001;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "cal":
                        wartosc = wartosc * 39.3700787;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "stop":
                        wartosc = wartosc * 3.2808399;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "jard":
                        wartosc = wartosc * 1.0936133;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "mila":
                        wartosc = wartosc * 0.000621371;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "kabel":
                        wartosc = wartosc * 0.005399568;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                    case "mila morska":
                        wartosc = wartosc * 0.0005399568;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc.ToString();
                        break;
                }
            }
            else
            {
                wyjscie = wartosc_pocz.ToString();
            }
        }
        public string wynik()
        {
            return wyjscie;
        }
    }
}
