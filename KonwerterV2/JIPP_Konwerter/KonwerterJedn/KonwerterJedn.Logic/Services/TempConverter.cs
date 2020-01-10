using KonwerterJedn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn.Logic.Services
{
    class TempConverter : IConverter
    {
        public string Type = "Temp";


        public string Nazwa => "Temp";

        public List<string> Jednostki => new List<string>(new[] { "Celciusz", "Kelvin", "Ferenheit", "Rankin" });

        public double Convert(string unitFrom, string unitTo, double Wartosc)
        {
            if (unitFrom == "Celciusz" && unitTo == "Ferenheit")
            {
                Wartosc = (Wartosc * 1.8 + 32);
                return Wartosc;

            }
            else if (unitFrom == "Celciusz" && unitTo == "Celciusz")
            {
                return Wartosc;

            }
            else if (unitFrom == "Celciusz" && unitTo == "Kelvin")
            {
                Wartosc = (Wartosc + 273.15);
                return Wartosc;

            }
            else if (unitFrom == "Celciusz" && unitTo == "Rankin")
            {
                Wartosc = ((Wartosc + 273.15) * 1.8);
                return Wartosc;

            }
            ////F////
            else if (unitFrom == "Ferenheit" && unitTo == "Ferenheit")
            {
                return Wartosc;
            }
            else if (unitFrom == "Ferenheit" && unitTo == "Celciusz")
            {
                Wartosc = ((Wartosc - 32) / 1.8);
                return Wartosc;
            }
            else if (unitFrom == "Ferenheit" && unitTo == "Kelvin")
            {
                Wartosc = ((5 / 9) * (Wartosc - 32) + 273.15);
                return Wartosc;
            }
            else if (unitFrom == "Ferenheit" && unitTo == "Rankin")
            {
                Wartosc = (Wartosc + 459.67);
                return Wartosc;
            }
            /////K/////
            else if (unitFrom == "Kelvin" && unitTo == "Kelvin")
            {
                return Wartosc;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Ferenheit")
            {
                Wartosc = ((9 / 5) * (Wartosc - 273.15) + 32);
                return Wartosc;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Celciusz")
            {
                Wartosc = (Wartosc - 273.15);
                return Wartosc;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Rankin")
            {
                Wartosc = (Wartosc * 9 / 5);
                return Wartosc;
            }
            /////R/////
            else if (unitFrom == "Rankin" && unitTo == "Rankin")
            {
                return Wartosc;
            }
            else if (unitFrom == "Rankin" && unitTo == "Ferenheit")
            {
                Wartosc = (Wartosc - 459.67);
                return Wartosc;
            }
            else if (unitFrom == "Rankin" && unitTo == "Celciusz")
            {
                Wartosc = ((Wartosc - 491.7) * 5 / 9);
                return Wartosc;
            }
            else if (unitFrom == "Rankin" && unitTo == "Kelvin")
            {
                Wartosc = (Wartosc * 5 / 9);
                return Wartosc;
            }
            else
                return 0;
        }

    }
}

