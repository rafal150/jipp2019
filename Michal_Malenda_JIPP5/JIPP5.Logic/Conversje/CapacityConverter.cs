using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB
{
    public class CapacityConverter : IKonwerter
    {

        public string Nazwa => "Pojemnosc_danych";
        public List<string> JakieJednostki => new List<string>() {
            "GIGABYTE",
            "CDROM",
        };

        public decimal Converter(string UnitFrom, decimal value, string UnitTo)
        {
            if (UnitFrom == "GIGABYTE")
            {
                value *= (decimal)1000;
            }
            else if (UnitFrom == "CDROM")
            {
                value *= (decimal)650;
            }

            if (UnitTo == "GIGABYTE")
            {
                value /= (decimal)1000;
            }
            else if (UnitTo == "CDROM")
            {
                value /= (decimal)650;
            }
            return value;
        }
    }
}
