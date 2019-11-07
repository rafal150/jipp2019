using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Model
{
    public partial class DbSql
    {
        public int id { get; set; }
        public string conversionType { get; set; }
        public string fromUnit { get; set; }
        public string valueToConvert { get; set; }
        public string toUnit { get; set; }
        public string convertedValue { get; set; }
        public DateTime dateTime { get; set; }
    }
}
