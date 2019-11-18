using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class TempConverter : IConverter
    {
        public string Name=> "Temperatura";
        public List<string> Units => new List<string>(new[] {"C", "F", "K","R" });

        double wyjscie =0;
        public double Liczenie(string z, string na, double wartosc)
        {
            double wartosc_pocz = wartosc;
            if (z == "C")     //przeliczenie wszystkiego najpierw na K 
            {
                wartosc = wartosc + 273.15;
            }
            else if (z == "F")
            {
                wartosc = (wartosc + 459.67) * 0.5555555556;
            }
            else if (z == "R")
            {
                wartosc = ((wartosc - 491.67) / 1.8) + 273.15;
            }
            else { }    //jeśli z K

            if (z != na)
            {
                switch (na) //przeliczanie z Kelvin
                {
                    case "C":   //°C = K − 273.15
                        wartosc = (wartosc - 273.15);
                        wartosc = Math.Round(wartosc, 2);
                        wyjscie = wartosc;
                        break;

                    case "F":   //°F = (K × 1.8) - 459.67
                        wartosc = (wartosc * 1.8) - 459.67;
                        wartosc = Math.Round(wartosc, 2);
                        wyjscie = wartosc;
                        break;

                    case "K": //bez zmian 
                        wartosc = Math.Round(wartosc, 2);
                        wyjscie = wartosc;
                        break;

                    case "R":   //R=(K-273.15)* 1.8+ 491.67
                        wartosc = ((wartosc - 273.15) * 1.8) + 491.67;
                        wartosc = Math.Round(wartosc, 2);
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
            //return wyjscie;
        //}
    }
}
