using System;
using System.Collections.Generic;
using System.Text;
using zal.Logika.Serwisy;


namespace MocKonwerterPlugin
{
    class KonwerterPlugin
    {
        class Konwerter : IConverter
        {
            public string Name => "Konwertermocy";

            public List<string> Units => new List<string>(new[] { "Wat", "Kilowat", "KM" });

            public decimal Convert(string unitFrom, string unitTo, decimal value)
            {
                if (unitFrom == "Wat" && unitTo == "Kilowat")
                {
                    value = value * 0.001M;

                }
                if (unitFrom == "Wat" && unitTo == "KM")
                {
                    value = value * 0.0014m;

                }
                if (unitFrom == "Kilowat" && unitTo == "Wat")
                {
                    value = value * 1000m;

                }
                if (unitFrom == "Kilowat" && unitTo == "KM")
                {
                    value = value * 1.3596m;

                }
                if (unitFrom == "KM" && unitTo == "Wat")
                {
                    value = value * 735.4988m;

                }
                if (unitFrom == "KM" && unitTo == "Kilowat")
                {
                    value = value * 0.7355m;

                }
                return value;
            }
        }



    }
}
