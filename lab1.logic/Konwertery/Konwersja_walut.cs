using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.logic.Konwertery
{

    public partial class Konwersja_walut : IKonwersja
    {
        public string Nazwa => "Waluty";

        public List<string> Jednostki => new List<string>(new[] { "Euro", "PLN" });
        public int Konwertuj(string z, string na, double wartosc)
        {
            int wynik;
            //referencja - pln
            if (z == "Euro")
            {
                double euro_rate = 0;
                Currency currency = new Currency();
                euro_rate = currency.GetEuro();

                wartosc = wartosc* euro_rate;

            }
            if (z == "PLN") wartosc = wartosc;
            if (na == "Euro")
            {
                double euro_rate = 0;
                Currency currency = new Currency();
                euro_rate = currency.GetEuro();

                wartosc = wartosc / euro_rate;

            }
            if (na == "PLN") wartosc = wartosc;
            wynik = (int)wartosc;
            return wynik;
        }


    }
}

