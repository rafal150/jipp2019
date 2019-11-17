using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Azure.Services
{
    class PrzeliczPowierzchnieKonwerter : IConverter
    {
        public string Nazwa => "Powierzchnia";

        public List<string> Jednostki => new List<string>(new[] { "hektar", "ar", "metry kwadratowe" });

        private string wynik;

        public decimal Przelicz(string idZ, string idNa, decimal input)
        {
            if (idZ == "hektar" && idNa == "hektar")
                wynik = input.ToString();

            if (idZ == "hektar" && idNa == "ar") // celsjusz na kelvin
                wynik = (input / decimal.Parse("100")).ToString();
            if (idZ == "hektar" && idNa == "metry kwadratowe") // celsjusz na faren
                wynik = (input * decimal.Parse("10000")).ToString();

            return decimal.Parse(wynik);
        }
    }
}
