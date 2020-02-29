using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek.Services
{
    public class WeightConverter : iKonwerter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncji", "funtów", "karatów", "kwintali" });

        public static decimal[] wMultiplier = new decimal[] { 1000000, 1000, 100, 1, 0.001M, 35.27M, 2.20M, 5000, 0.01M };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {

            decimal k1 = 0.0M, k2 = 0.0M;

            int i = 0;

            foreach (string s in Units)
            {
                if (unitFrom == s)
                    k1 = wMultiplier[i];
                if (unitTo == s)
                    k2 = wMultiplier[i];

                i += 1;

            }


            return k2 * value / k1;




        }

     
    }
}
