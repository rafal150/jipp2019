using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB
{
    public class TemperatureConverter : IKonwerter
    {
        public string Nazwa => "Temperatury";

        public List<string> JakieJednostki => new List<string>()
        {
            "Celcjusz",
            "Farenheit",
            "Rankine",
            "Kelvin",
        };

        public decimal Converter(string zJednostki, decimal wartosc, string doJednostki)
        {
            if (zJednostki == "Celcjusz")
            {
                wartosc += (decimal)273.15;
            }
            else if (zJednostki == "Farenheit")
            {
                wartosc = (wartosc + (decimal)459.67) * ((decimal)5 / (decimal)9);
            }
            else if (zJednostki == "Rankine")
            {
                wartosc *= ((decimal)5 / (decimal)9);
            }

            if (doJednostki == "Celcjusz")
            {
                wartosc -= (decimal)273.15;
            }
            else if (doJednostki == "Farenheit")
            {
                wartosc = (wartosc * ((decimal)9 / (decimal)5)) - (decimal)459.67;
            }
            else if (doJednostki == "Rankine")
            {
                wartosc *= ((decimal)9 / (decimal)5);
            }

            return wartosc;
        }
    }
}