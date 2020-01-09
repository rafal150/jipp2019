using System;

namespace KonwerterZSQLiAZUREiPLUGIN
{
    public class DBO
    {
       
        public DateTime? DataGenerowania { get; set; }

        public string LogKonwersji { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }

        public int? RawValue { get; set; }

        public int? ConvertedValue { get; set; }
        public string Type { get; set; }
    }
}