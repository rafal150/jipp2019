using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class TemperaturaKonwersja : IKonwersja
    {
        public string nazwaKonwersji => "Temperatura"; //=> oznacza to samo co return "Długość"
        public List<string> jednostki => new List<string>(new[] { "Celcjusz", "Farenheit", "Kelvin", "Rankine"});
        public double obliczenia(double wartoscWej, int indexJednostkiWej, int indexJednostkiWyjsc)
        {
            List<double> listaPrzeliczenNaJednostke = new List<double>();
            List<double> listaPrzeliczenZJednostki = new List<double>();
            listaPrzeliczenNaJednostke.Clear();
            listaPrzeliczenNaJednostke.Add(wartoscWej); //celcjusz na celcjusz
            listaPrzeliczenNaJednostke.Add((wartoscWej - 32) / 1.8); //faren na celcjusz
            listaPrzeliczenNaJednostke.Add(wartoscWej - 273.15); //kelvin na celcjusz
            listaPrzeliczenNaJednostke.Add((wartoscWej - 491.67) / 1.8); //rankin na celcjusz

            double wartoscPomocnicza = listaPrzeliczenNaJednostke.ElementAt(indexJednostkiWej);

            listaPrzeliczenZJednostki.Clear();
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 1.8 + 32);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza + 273.15);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 1.8 + 491.67);

            return listaPrzeliczenZJednostki.ElementAt(indexJednostkiWyjsc);
        }

        //public double naCelcjusza(double wartoscWej, int indexJednostkiWejsc)
        //{
        //    listaPrzeliczenNaJednostke.Clear();
        //    listaPrzeliczenNaJednostke.Add(wartoscWej); //celcjusz na celcjusz
        //    listaPrzeliczenNaJednostke.Add((wartoscWej-32)/1.8); //faren na celcjusz
        //    listaPrzeliczenNaJednostke.Add(wartoscWej - 273.15); //kelvin na celcjusz
        //    listaPrzeliczenNaJednostke.Add((wartoscWej - 491.67) / 1.8); //rankin na celcjusz
        //    return listaPrzeliczenNaJednostke.ElementAt(indexJednostkiWejsc);
        //}
        //public double zCelcjusza(double wartoscWej, int indexJednostkiWejsc, int indexJednostkiWyjsc)
        //{
        //    double wartoscPomocnicza = 0;
        //    wartoscPomocnicza = naCelcjusza(wartoscWej, indexJednostkiWejsc);
        //    listaPrzeliczenZJednostki.Clear();
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 1.8 + 32);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza + 273.15);
        //    listaPrzeliczenZJednostki.Add(wartoscPomocnicza * 1.8 + 491.67);
        //    return listaPrzeliczenZJednostki.ElementAt(indexJednostkiWyjsc);
        //}
       
    }
}
