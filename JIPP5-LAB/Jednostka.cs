using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB
{
    public class Jednostka
    {
        private readonly Dictionary<Jednostki, Func<decimal, decimal>> factorDictionary;

        public string Nazwa { get; }
        public string Jednostkaa { get; }
        public Jednostki Typ { get; }

        public Jednostka(string nazwa, string jednostkaa, Jednostki typ, Dictionary<Jednostki, Func<decimal, decimal>> factors)
        {
            Nazwa = nazwa;
            Jednostkaa = jednostkaa;
            Typ = typ;
            factorDictionary = factors;
        }

        public decimal Przelicz(decimal wartosc, Jednostki dojednostki)
        {
            return factorDictionary[dojednostki].Invoke(wartosc);
        }
    }
}
