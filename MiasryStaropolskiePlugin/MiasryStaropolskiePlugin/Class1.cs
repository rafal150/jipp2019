using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwenter;


namespace MiasryStaropolskiePlugin
{
    public class MiaryStaropolskieKonwersja : IKonwersja
    {
        public string nazwaKonwersji => "Miary Staropolskie"; //=> oznacza to samo co return "Długość"
        public List<string> jednostki => new List<string>(new[] { "Sztuka", "Para", "Tuzin", "Mendel", "Sztyga", "Izba", "Kopa", "Gros", "Wielki Gros"});
        public double obliczenia(double wartoscWej, int indexJednostkiWej, int indexJednostkiWyjsc)
        {
            List<double> listaPrzeliczenNaJednostke = new List<double>();
            List<double> listaPrzeliczenZJednostki = new List<double>();
            listaPrzeliczenNaJednostke.Clear();
            listaPrzeliczenNaJednostke.Add(wartoscWej);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 2);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 12);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 15);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 20);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 40);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 60);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 144);
            listaPrzeliczenNaJednostke.Add(wartoscWej * 1728);
            

            double wartoscPomocnicza = listaPrzeliczenNaJednostke.ElementAt(indexJednostkiWej);

            listaPrzeliczenZJednostki.Clear();
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza /2);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza / 12);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza /15);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza /20);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza /40);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza /60);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza /144);
            listaPrzeliczenZJednostki.Add(wartoscPomocnicza /1728);
            

            return listaPrzeliczenZJednostki.ElementAt(indexJednostkiWyjsc);
        }
    }
}
