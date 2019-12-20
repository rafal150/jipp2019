using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB
{
    public class WeightConverter : IKonwerter
    {
        public string Nazwa => "Masa";

        public List<string> JakieJednostki => new List<string>() {
            "Miligramy",
            "Dekagramy",
            "Kilogramy",
            "Tony",
            "Uncje",
            "Funty",
            "Karaty",
            "Kwintale",
            "Gramy",
        };

        public decimal Converter(string zJednostki, decimal wartosc, string doJednostki)
        {
            if (zJednostki == "Miligramy")
            {
                wartosc *= (decimal)0.001;
            }
            else if (zJednostki == "Dekagramy")
            {
                wartosc *= 10;
            }
            else if (zJednostki == "Kilogramy")
            {
                wartosc *= 1000;
            }
            else if (zJednostki == "Tony")
            {
                wartosc *= 1000000;
            }
            else if (zJednostki == "Uncje")
            {
                wartosc *= (decimal)28.3495231;
            }
            else if (zJednostki == "Funty")
            {
                wartosc *= (decimal)453.59237;
            }
            else if (zJednostki == "Karaty")
            {
                wartosc *= (decimal)0.2;
            }
            else if (zJednostki == "Kwintale")
            {
                wartosc *= 100000;
            }

            if (doJednostki == "Miligramy")
            {
                wartosc *= 1000;
            }
            else if (doJednostki == "Dekagramy")
            {
                wartosc *= (decimal)0.1;
            }
            else if (doJednostki == "Kilogramy")
            {
                wartosc *= (decimal)0.001;
            }
            else if (doJednostki == "Tony")
            {
                wartosc *= 1000000;
            }
            else if (doJednostki == "Uncje")
            {
                wartosc *= (decimal)0.0352739619;
            }
            else if (doJednostki == "Funty")
            {
                wartosc *= (decimal)0.00220462262;
            }
            else if (doJednostki == "Karaty")
            {
                wartosc *= 5;
            }
            else if (doJednostki == "Kwintale")
            {
                wartosc *= (decimal)0.00001;
            }
            return wartosc;
        }
    }
}