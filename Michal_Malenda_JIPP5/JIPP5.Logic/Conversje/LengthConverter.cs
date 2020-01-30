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

        public decimal Converter(string UnitFrom, decimal Result, string UnitTo)
        {
            if (UnitFrom == "Milimetry")
            {
                Result *= (decimal)0.001;
            }
            else if (UnitFrom == "Centymetry")
            {
                Result *= (decimal)0.01;
            }
            else if (UnitFrom == "Decymetry")
            {
                Result *= (decimal)0.1;
            }
            else if (UnitFrom == "Kilometry")
            {
                Result *= (decimal)1000;
            }
            else if (UnitFrom == "Cale")
            {
                Result *= (decimal)0.0254;
            }
            else if (UnitFrom == "Stopy")
            {
                Result *= (decimal)0.3048;
            }
            else if (UnitFrom == "Jardy")
            {
                Result *= (decimal)0.9144;
            }
            else if (UnitFrom == "Mile")
            {
                Result *= (decimal)1609.344;
            }
            else if (UnitFrom == "Kable")
            {
                Result *= (decimal)185.2;
            }
            else if (UnitFrom == "Mile morskie")
            {
                Result *= (decimal)1852;
            }

            if (UnitTo == "Milimetry")
            {
                Result *= 1000;
            }
            else if (UnitTo == "Centymetry")
            {
                Result *= 100;
            }
            else if (UnitTo == "Decymetry")
            {
                Result *= 10;
            }
            else if (UnitTo == "Kilometry")
            {
                Result *= (decimal)0.001;
            }
            else if (UnitTo == "Cale")
            {
                Result *= (decimal)39.37;
            }
            else if (UnitTo == "Stopy")
            {
                Result *= (decimal)3.2808399;
            }
            else if (UnitTo == "Jardy")
            {
                Result *= (decimal)1.0936133;
            }
            else if (UnitTo == "Mile")
            {
                Result *= (decimal)0.000621371192;
            }
            else if (UnitTo == "Kable")
            {
                Result *= (decimal)0.005399568034;
            }
            else if (UnitTo == "Mile morskie")
            {
                Result *= (decimal)0.0005399568034;
            }
            return Result;
        }
    }
}