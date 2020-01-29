using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Services;

namespace CurrencyConverterPlugin
{
    public class CurrencyConverter : IConverter
    {
        public string Name => "Waluty";

        public List<string> Units => new List<string>(new[] { "PLN", "EUR", "GBP", "USD", "NOK", "SEK", "CHF" });

        public static double[] lMultiplier = new double[] { 1, 4.2461, 5.0381, 3.8475, 0.4270, 0.4029, 3.9629 }; // dane z 25.01.2020 - wiem, że niezbyt długo będą aktualne :D

        public double Convert(string unitFrom, string unitTo, double value)
        {
            double k1 = 0.0, k2 = 0.0;

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
