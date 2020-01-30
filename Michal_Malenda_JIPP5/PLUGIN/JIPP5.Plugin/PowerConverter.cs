using JIPP5.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5.Plugin
{
    public class PowerConverter : IKonwerter
    {
        public string Nazwa => "Moc";

        public List<string> JakieJednostki => new List<string>()
        {
            "Miliwat",
            "Wat",
            "Kilowat",
            "KonieMechaniczne",
        };

        public decimal Converter(string zJednostki, decimal wartosc, string doJednostki)
        {
            if (zJednostki == "Miliwat")
            {
                wartosc *= (decimal)0.1;
            }
            else if (zJednostki == "Kilowat")
            {
                wartosc *= 1000;
            }
            else if (zJednostki == "KonieMechaniczne")
            {
                wartosc *= (decimal)745.699872;
            }

            if (doJednostki == "Miliwat")
            {
                wartosc *= (decimal)10;
            }
            else if (doJednostki == "Kilowat")
            {
                wartosc *= (decimal)0.001;
            }
            else if (doJednostki == "KonieMechaniczne")
            {
                wartosc *= (decimal)0.00134102209;
            }

            return wartosc;
        }
    }
}
