using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Przelicznik_Jednostek.Services;

namespace PluginConverter
{
    public class CurrencyConverter : iKonwerter
   
    {

        public string Name => "Waluty";

        public List<string> Units => new List<string>(new[] { "PLN", "EUR", "GBP", "USD", "NOK", "SEK", "CHF" });

        public static decimal[] lMultiplier = new decimal[] { 1, 4.2461M, 5.0381M, 3.8475M, 0.4270M, 0.4029M, 3.9629M }; // dane z 25.01.2020 - wiem, że niezbyt długo będą aktualne :D

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal k1 = 0.0M, k2 = 0.0M;

            int i = 0;

            foreach (string s in Units)
            {
                if (unitFrom == s)
                    k1 = lMultiplier[i];
                if (unitTo == s)
                    k2 = lMultiplier[i];

                i += 1;

            }


            return k1 * value / k2;
        }




    }
}
