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

        public decimal Converter(string UnitFrom, decimal Result, string UnitTo)
        {
            if (UnitFrom == "Miligramy")
            {
                Result *= (decimal)0.001;
            }
            else if (UnitFrom == "Dekagramy")
            {
                Result *= 10;
            }
            else if (UnitFrom == "Kilogramy")
            {
                Result *= 1000;
            }
            else if (UnitFrom == "Tony")
            {
                Result *= 1000000;
            }
            else if (UnitFrom == "Uncje")
            {
                Result *= (decimal)28.3495231;
            }
            else if (UnitFrom == "Funty")
            {
                Result *= (decimal)453.59237;
            }
            else if (UnitFrom == "Karaty")
            {
                Result *= (decimal)0.2;
            }
            else if (UnitFrom == "Kwintale")
            {
                Result *= 100000;
            }

            if (UnitTo == "Miligramy")
            {
                Result *= 1000;
            }
            else if (UnitTo == "Dekagramy")
            {
                Result *= (decimal)0.1;
            }
            else if (UnitTo == "Kilogramy")
            {
                Result *= (decimal)0.001;
            }
            else if (UnitTo == "Tony")
            {
                Result *= 1000000;
            }
            else if (UnitTo == "Uncje")
            {
                Result *= (decimal)0.0352739619;
            }
            else if (UnitTo == "Funty")
            {
                Result *= (decimal)0.00220462262;
            }
            else if (UnitTo == "Karaty")
            {
                Result *= 5;
            }
            else if (UnitTo == "Kwintale")
            {
                Result *= (decimal)0.00001;
            }
            return Result;
        }
    }
}