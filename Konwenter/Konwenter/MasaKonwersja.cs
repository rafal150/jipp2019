using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class MasaKonwersja : IKonwersja
    {       
        public List<string> jednostki => new List<string>(new[] { "mg", "g", "dg", "kg", "T", "uncja", "funt", "karat", "kwintal"});
        public string nazwaKonwersji => "Masa";

        public double obliczenia(double wartoscWej, int indexJednostkiWej, int indexJednostkiWyjsc)
        {
            List<double> listaPrzeliczenNaJednostke = new List<double>();
            List<double> listaPrzeliczenZJednostki = new List<double>();
            listaPrzeliczenNaJednostke.Clear();
            listaPrzeliczenNaJednostke.Add(wartoscWej);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 1000);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 10000);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 1000000);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 1000000000);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 28349.5231);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 453592.37);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 200);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 100000000);

            double wartoscPomocnicza = listaPrzeliczenNaJednostke.ElementAt(indexJednostkiWej);

            listaPrzeliczenZJednostki.Clear();
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.001);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0001);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000001);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000000001);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000035274);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000002246);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.005);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0001);

            return listaPrzeliczenZJednostki.ElementAt(indexJednostkiWyjsc);
        }
        
        //public double naMiligramy (double wartoscWej, int indexJednostkiWejsc)
        //{
        //    listaPrzeliczenNaJednostke.Clear();

        //    listaPrzeliczenNaJednostke.Add(wartoscWej);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej *1000);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej *10000);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej *1000000);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej *1000000000);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 28349.5231);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 453592.37);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej *200);
        //    listaPrzeliczenNaJednostke.Add(wartoscWej * 100000000);
        //    return listaPrzeliczenNaJednostke.ElementAt(indexJednostkiWejsc);
        //}
        //public double zMiligramy(double wartoscWej, int indexJednostkiWejsc, int indexJednostkiWyjsc)
        //{
        //    double wartoscPomocnicza = 0;
        //    wartoscPomocnicza = naMiligramy(wartoscWej, indexJednostkiWejsc);
        //    listaPrzeliczenZJednostki.Clear();

        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.001);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0001);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000001);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000000001);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000035274);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.000002246);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.005);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 0.0001);
        //    return listaPrzeliczenZJednostki.ElementAt(indexJednostkiWyjsc);


        //}
    }
}
