using System;
using System.Collections.Generic;
using System.Text;
using UnitCoverterPart2.Services;

namespace SzymanskiCzasuPlugin
{
    class CzasuPlugin
    {
        class ASConverter : IConverter
        {
            public string Name => "CzasuKonwerter";

            public List<string> Units => new List<string>(new[] { "sekunda", "godzina", "dzien" });

            public double Convert(string unitFrom, string unitTo, double value)
            {
                if (unitFrom == "sekunda" && unitTo == "godzina")        //sekunda na godzina 
                {
                    value = value * 0.000278;

                }
                if (unitFrom == "sekunda" && unitTo == "dzien")        //sekunda na dzien
                {
                    value = value * 0.000012;

                }
                if (unitFrom == "godzina" && unitTo == "sekunda")        //godzina  na sekunda
                {
                    value = value * 3600;

                }
                if (unitFrom == "godzina" && unitTo == "dzien")        //godzina na dzien
                {
                    value = value * 0.041667;

                }
                if (unitFrom == "dzien" && unitTo == "sekunda")        //dzien na sekunde
                {
                    value = value * 86400;

                }
                if (unitFrom == "dzien" && unitTo == "godzina")        //dzien na godzina
                {
                    value = value * 24;

                }
                return value;
            }
        }

    }
}
