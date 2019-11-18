using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Services;

namespace MocConverterPlugin
{
    public class MocConverter : IConverter
    {
        public string Name => "Moc";

        public List<string> Units => new List<string>(new[] { "W", "kW", "KM", "HP" });

        double wyjscie = 0;
        public double Liczenie(string z, string na, double wartosc)
        {
            double wartosc_pocz = wartosc;
            if (z == "kW")     //przeliczenie wszystkiego najpierw na W 
            {
                wartosc = wartosc * 1000;
            }
            else if (z == "KM")
            {
                wartosc = wartosc * 735.49875;
            }
            else if (z == "HP")
            {
                wartosc = wartosc * 745.699872;
            }
            else { }    //jeśli z W

            if (z != na)
            {
                switch (na) //przeliczanie z Watów
                {
                    case "W": //bez zmian 
                        wartosc = Math.Round(wartosc, 3);
                        wyjscie = wartosc;
                        break;
                    case "kW":
                        wartosc = wartosc / 1000;
                        wartosc = Math.Round(wartosc, 3);
                        wyjscie = wartosc;
                        break;
                    case "KM":
                        wartosc = wartosc * 0.00135962;
                        wartosc = Math.Round(wartosc, 3);
                        wyjscie = wartosc;
                        break;
                    case "HP":
                        wartosc = wartosc * 0.00134102;
                        wartosc = Math.Round(wartosc, 3);
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
    }
}
