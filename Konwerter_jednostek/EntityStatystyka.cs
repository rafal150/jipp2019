using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_jednostek
{
    public class EntityStatystyka : TableEntity
    {
        public DateTime Czas { get; set; }
        public string Nazwa_typu { get; set; }
        public string Nazwa_miary_wejscie { get; set; }
        public double Wartosc_do_konwersji { get; set; }
        public string Nazwa_miary_wyjscia { get; set; }
        public double Rezultat_konwersji { get; set; }

    }
}
