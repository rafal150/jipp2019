using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.SDK
{
    public class TableObject
    {
        public string Table { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public RateObject[] Rates { get; set; }
    }
}
