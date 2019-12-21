using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEM5WPF_1.Services;

namespace SEM5WPF_1.Services
{
    class TemperaturyKonwerter : IKonwerter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>(new[] { "Celsjusze", "Kelviny", "Farainhaity", "Rinkine'a", });

        public decimal Konwerter(string jednostkaZ, string jednostkaDo, decimal wartosc)
        {
            decimal K = 273.15M;
           
            switch (jednostkaZ)
            {
                case "Celsjusze":

                    if (jednostkaZ == "Celsjusze" && jednostkaDo == "Kelviny")
                    {
                       return wartosc + K;
                    }
                    else if (jednostkaZ == "Celsjusze" && jednostkaDo == "Farainhaity")
                    {
                        return (wartosc * 1.8M) + 32;
                    }
                    else if (jednostkaZ == "Celsjusze" && jednostkaDo == "Rinkine'a")
                    {
                       return (wartosc + K) * 1.8M;
                    }
                    break;

                case "Kelviny":
                    if (jednostkaZ == "Kelviny" && jednostkaDo == "Celsjusze")
                    {
                        return wartosc - K;
                    }
                    else if (jednostkaZ == "Kelviny" && jednostkaDo == "Farainhaity")
                    {
                        return ((wartosc - K) * 1.8M) + 32; 
                    }
                    else if (jednostkaZ == "Kelviny" && jednostkaDo == "Rinkine'a")
                    {
                        return ((wartosc - K) * 1.8M) + 491.67M; 
                    }
                    break;
                case "Farainhaity":
                    if (jednostkaZ == "Farainhaity" && jednostkaDo == "Celsjusze")
                    {
                        return (wartosc - 32) * 5 / 9;
                    }
                    else if (jednostkaZ == "Farainhaity" && jednostkaDo == "Kelviny")
                    {
                        return (wartosc + 459.67M) * 5 / 9; 
                    }
                    else if (jednostkaZ == "Farainhaity" && jednostkaDo == "Rinkine'a")
                    {
                         return wartosc + 459.67M; 
                    }
                    break;
                case "Rinkine'a":
                    if (jednostkaZ == "Rinkine'a" && jednostkaDo == "Celsjusze")
                    {
                         return (wartosc / 1.8M) - K; 
                    }
                    else if (jednostkaZ == "Rinkine'a" && jednostkaDo == "Kelviny")
                    {
                         return (wartosc / 1.8M) + K;
                    }
                    else if (jednostkaZ == "Rinkine'a" && jednostkaDo == "Farainhaity")
                    {
                         return wartosc - 459.67M;
                    }
                    break;
                default:
                    break;
            }
            return wartosc;
        }
    }
}
