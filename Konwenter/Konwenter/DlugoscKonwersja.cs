using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class DlugoscKonwersja : IKonwersja
    {       
        public string nazwaKonwersji => "Dlugość"; //=> oznacza to samo co return "Długość"
        public List<string> jednostki => new List<string>(new[] { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });
        public double obliczenia(double wartoscWej, int indexJednostkiWej, int indexJednostkiWyjsc)
        {
            List<double> listaPrzeliczenNaJednostke = new List<double>();
            List<double> listaPrzeliczenZJednostki = new List<double>();
            listaPrzeliczenNaJednostke.Clear();
            listaPrzeliczenNaJednostke.Add(wartoscWej);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 10);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 100);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 1000);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 100000);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 25.4);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 304.8);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 914.4);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 1609344);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 185200);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 1852000);
            
            double wartoscPomocnicza = listaPrzeliczenNaJednostke.ElementAt(indexJednostkiWej);

            listaPrzeliczenZJednostki.Clear();
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.1);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.01);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0001);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0000001);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0393700787);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0032808);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.00010936);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.00000002137);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000005399);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0000005399);

            return listaPrzeliczenZJednostki.ElementAt(indexJednostkiWyjsc);

        }
        //public double naMilimetry(double wartoscWej, int indexJednostkiWejsc)
        //{
        //    listaPrzeliczenNaJednostke.Clear();
        //    listaPrzeliczenNaJednostke.Add(wartoscWej);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 10);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 100);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 1000);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 100000);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 25.4);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 304.8);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 914.4);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 1609344);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 185200);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 1852000);
        //    return listaPrzeliczenNaJednostke.ElementAt(indexJednostkiWejsc);
        //}
        //public double zMilimetry(double wartoscWej, int indexJednostkiWejsc, int indexJednostkiWyjsc)
        //{
        //    double wartoscPomocnicza = 0;
        //    wartoscPomocnicza = naMilimetry(wartoscWej, indexJednostkiWejsc);
        //    listaPrzeliczenZJednostki.Clear();
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.1);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.01);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0001);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0000001);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0393700787);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0032808);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.00010936);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.00000002137);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000005399);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0000005399);
        //    return listaPrzeliczenZJednostki.ElementAt(indexJednostkiWyjsc);
        //}
    }
}
