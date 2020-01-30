using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter8000.Konwersje;

namespace Konwerter8000SekundaKwadransPlugin
{
    public class Konwerter8000SekundaKwadransPlugin : IKonwerter8000
    {
        public string NazwaKategorii => "Czas";

        public List<string> Jednostki => new List<string>(new[] { "Kwadrans", "Sekunda",});

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {

            string ZJ = zJednostki;
            string DJ = doJednostki;
            if (ZJ == DJ)
            {
                return wartosc;
            }
            if (zJednostki == "Kwadrans")
            {
                return wartosc * 900;
            }
            if (zJednostki == "Sekunda")
            {

                return wartosc / 900;
            }
            return 1;
        }
    }
}
