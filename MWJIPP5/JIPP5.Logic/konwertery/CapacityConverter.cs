using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB
{
    public class CapacityConverter : IKonwerter
    {
        public string Nazwa => "Pojemnosc-danych";

        public List<string> JakieJednostki => new List<string>() {
            "Megabajty",
            "CDROM",
        };

        public decimal Converter(string UnitFrom, decimal value, string UnitTo)
        {
            if (UnitFrom == "Megabajty")
            {
                value *= (decimal)1;
            }
            else if (UnitFrom == "CDROM")
            {
                value *= (decimal)650;
            }

            if (UnitTo == "Megabajty")
            {
                value *= (decimal)1;
            }
            else if (UnitTo == "CDROM")
            {
                value /= (decimal)650;
            }
            return value;
        }
    }
}