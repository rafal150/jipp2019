using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB
{
    public class LengthConverter : IKonwerter
    {
        public string Nazwa => "Dlugosc";

        public List<string> JakieJednostki => new List<string>() {
            "Milimetry",
            "Centymetry",
            "Metry",
            "Decymetry",
            "Kilometry",
            "Cale",
            "Stopy",
            "Jardy",
            "Mile",
            "Kable",
            "Mile morskie"
        };

        public decimal Converter(string zJednostki, decimal wartosc, string doJednostki)
        {
            if (zJednostki == "Milimetry")
            {
                wartosc *= (decimal)0.001;
            }
            else if (zJednostki == "Centymetry")
            {
                wartosc *= (decimal)0.01;
            }
            else if (zJednostki == "Decymetry")
            {
                wartosc *= (decimal)0.1;
            }
            else if (zJednostki == "Kilometry")
            {
                wartosc *= (decimal)1000;
            }
            else if (zJednostki == "Cale")
            {
                wartosc *= (decimal)0.0254;
            }
            else if (zJednostki == "Stopy")
            {
                wartosc *= (decimal)0.3048;
            }
            else if (zJednostki == "Jardy")
            {
                wartosc *= (decimal)0.9144;
            }
            else if (zJednostki == "Mile")
            {
                wartosc *= (decimal)1609.344;
            }
            else if (zJednostki == "Kable")
            {
                wartosc *= (decimal)185.2;
            }
            else if (zJednostki == "Mile morskie")
            {
                wartosc *= (decimal)1852;
            }

            if (doJednostki == "Milimetry")
            {
                wartosc *= 1000;
            }
            else if (doJednostki == "Centymetry")
            {
                wartosc *= 100;
            }
            else if (doJednostki == "Decymetry")
            {
                wartosc *= 10;
            }
            else if (doJednostki == "Kilometry")
            {
                wartosc *= (decimal)0.001;
            }
            else if (doJednostki == "Cale")
            {
                wartosc *= (decimal)39.37;
            }
            else if (doJednostki == "Stopy")
            {
                wartosc *= (decimal)3.2808399;
            }
            else if (doJednostki == "Jardy")
            {
                wartosc *= (decimal)1.0936133;
            }
            else if (doJednostki == "Mile")
            {
                wartosc *= (decimal)0.000621371192;
            }
            else if (doJednostki == "Kable")
            {
                wartosc *= (decimal)0.005399568034;
            }
            else if (doJednostki == "Mile morskie")
            {
                wartosc *= (decimal)0.0005399568034;
            }
            return wartosc;
        }
    }
}