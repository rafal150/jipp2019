using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_jednostek
{
    public class Miara //klasa - pobiera nazwe miary
    {
        public int Miara_ID { get; }
        public string Nazwa_miary { get; }
        public int Typ_ID { get; }

        public Miara(int miara_ID, string nazwa_miary, int typ_ID)
        {
            Miara_ID = miara_ID;
            Nazwa_miary = nazwa_miary;
            Typ_ID = typ_ID;
        }
    }
}
