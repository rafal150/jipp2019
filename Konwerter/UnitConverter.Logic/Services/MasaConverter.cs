//using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class MasaConverter:IConverter
    {
        public string Name => "Masa";
        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal"});
        double wyjscie =0;
        public double Liczenie(string z, string na, double wartosc)   //"mg", "g", "dkg","kg", "T","uncja","funt","karat","kwintal"
        {
            double wartosc_pocz = wartosc;
            if (z == "mg")  //przeliczenie wszystkiego na kg
            {
                wartosc = wartosc * 0.000001;
            }
            else if (z == "g")
            {
                wartosc = wartosc * 0.001;
            }
            else if (z == "dkg")
            {
                wartosc = wartosc * 0.01;
            }
            else if (z == "T")
            {
                wartosc = wartosc * 1000;
            }
            else if (z == "uncja")
            {
                wartosc = wartosc * 0.02834952;
            }
            else if (z == "funt")
            {
                wartosc = wartosc * 0.45359237;
            }
            else if (z == "karat")
            {
                wartosc = wartosc * 0.0002;
            }
            else if (z == "kwintal")
            {
                wartosc = wartosc * 100;
            }
            else //z==kg
            { }

            if (na != z)
            {
                switch (na)
                {
                    case "mg":
                        wartosc = wartosc * 1000000;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                    case "g":
                        wartosc = wartosc * 1000;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                    case "dkg":
                        wartosc = wartosc * 100;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                    case "kg": //brak zmian
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                    case "T":
                        wartosc = wartosc * 0.001;
                        wartosc = Math.Round(wartosc, 10);
                        wyjscie = wartosc;
                        break;
                    case "uncja":
                        wartosc = wartosc * 35.2739621;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                    case "funt":
                        wartosc = wartosc * 2.20462262;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                    case "karat":
                        wartosc = wartosc * 5000;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                    case "kwintal":
                        wartosc = wartosc * 0.01;
                        wartosc = Math.Round(wartosc, 6);
                        wyjscie = wartosc;
                        break;
                }
            }
            else
            {
                wyjscie = wartosc_pocz;
            }
            return wyjscie;
        }
        //public string wynik()
        //{
        //    return wyjscie;
        //}
    }
}
