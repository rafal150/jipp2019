using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.SDK;


namespace KonwerterPlugin
{
    public class KonwerterPlugin : IKonwerter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>(new[] { "milisekunda", "sekunda","Minuta","Kwadrans","Godzina","Dzień" });

        public decimal Konwerter(string jednostkaZ, string jednostkaDo, decimal wartosc)
        {

            switch (jednostkaZ)
            {
                case "milisekunda":

                    if (jednostkaZ == "milisekunda" && jednostkaDo == "sekunda")
                    {
                        return wartosc / 1000;
                    }
                    else if (jednostkaZ == "milisekunda" && jednostkaDo == "Minuta")
                    {
                        return (wartosc / 1000) / 60;
                    }
                    else if (jednostkaZ == "milisekunda" && jednostkaDo == "Kwadrans'a")
                    {
                        return ((wartosc / 1000) / 60)/15;
                    }
                    else if (jednostkaZ == "milisekunda" && jednostkaDo == "Godzina")
                    {
                        return (((wartosc / 1000) / 60) / 15)/4;
                    }
                    else if (jednostkaZ == "milisekunda" && jednostkaDo == "Dzień")
                    {
                        return ((((wartosc / 1000) / 60) / 15) / 4)/24;
                    }
                    break;
                case "sekunda":

                    if (jednostkaZ == "sekunda" && jednostkaDo == "milisekunda")
                    {
                        return wartosc * 1000;
                    }
                    else if (jednostkaZ == "sekunda" && jednostkaDo == "Minuta")
                    {
                        return (wartosc / 60);
                    }
                    else if (jednostkaZ == "sekunda" && jednostkaDo == "Kwadrans'a")
                    {
                        return (wartosc / 60) / 15;
                    }
                    else if (jednostkaZ == "sekunda" && jednostkaDo == "Godzina")
                    {
                        return ((wartosc  / 60) / 15) / 4;
                    }
                    else if (jednostkaZ == "sekunda" && jednostkaDo == "Dzień")
                    {
                        return (((wartosc / 60) / 15) / 4) / 24;
                    }
                    break;
                case "Minuta":

                    if (jednostkaZ == "Minuta" && jednostkaDo == "milisekunda")
                    {
                        return  (wartosc * 60) * 1000;
                    }
                    else if (jednostkaZ == "Minuta" && jednostkaDo == "sekunda")
                    {
                        return (wartosc * 60);
                    }
                    else if (jednostkaZ == "Minuta" && jednostkaDo == "Kwadrans'a")
                    {
                        return wartosc / 15;
                    }
                    else if (jednostkaZ == "Minuta" && jednostkaDo == "Godzina")
                    {
                        return (wartosc / 15) / 4;
                    }
                    else if (jednostkaZ == "Minuta" && jednostkaDo == "Dzień")
                    {
                        return ((wartosc / 15) / 4) / 24;
                    }
                    break;
                case "Kwadrans":

                    if (jednostkaZ == "Kwadrans" && jednostkaDo == "milisekunda")
                    {
                        return ((wartosc * 15)*60) * 1000;
                    }
                    else if (jednostkaZ == "Kwadrans" && jednostkaDo == "sekunda")
                    {
                        return (wartosc * 15) * 60;
                    }
                    else if (jednostkaZ == "Kwadrans" && jednostkaDo == "Minuta")
                    {
                        return wartosc * 15;
                    }
                    else if (jednostkaZ == "Kwadrans" && jednostkaDo == "Godzina")
                    {
                        return (wartosc / 4);
                    }
                    else if (jednostkaZ == "Kwadrans" && jednostkaDo == "Dzień")
                    {
                        return (wartosc / 4) / 24;
                    }
                    break;
                case "Godzina":

                    if (jednostkaZ == "Godzina" && jednostkaDo == "milisekunda")
                    {
                        return (((wartosc * 4) * 15) * 60) * 1000;
                    }
                    else if (jednostkaZ == "Godzina" && jednostkaDo == "sekunda")
                    {
                        return (((wartosc )*4)* 15) * 60;
                    }
                    else if (jednostkaZ == "Godzina" && jednostkaDo == "Minuta")
                    {
                        return (wartosc * 4)*15;
                    }
                    else if (jednostkaZ == "Godzina" && jednostkaDo == "Kwadrans")
                    {
                        return (wartosc * 4);
                    }
                    else if (jednostkaZ == "Godzina" && jednostkaDo == "Dzień")
                    {
                        return wartosc / 24;
                    }
                    break;
                case "Dzień":

                    if (jednostkaZ == "Dzień" && jednostkaDo == "milisekunda")
                    {
                        return ((((wartosc * 4)*24) * 15) * 60) * 1000;
                    }
                    else if (jednostkaZ == "Dzień" && jednostkaDo == "sekunda")
                    {
                        return ((((wartosc)*24) * 4) * 15) * 60;
                    }
                    else if (jednostkaZ == "Dzień" && jednostkaDo == "Minuta")
                    {
                        return ((wartosc)*24 * 4) * 15;
                    }
                    else if (jednostkaZ == "Dzień" && jednostkaDo == "Kwadrans")
                    {
                        return (wartosc * 24)* 4;
                    }
                    else if (jednostkaZ == "Dzień" && jednostkaDo == "Godzina")
                    {
                        return wartosc * 24;
                    }
                    break;
            }

            return wartosc;
        }
    }
}
