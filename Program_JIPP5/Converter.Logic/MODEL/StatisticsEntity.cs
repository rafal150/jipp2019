using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Converter
{
    public class StatisticsEntity : TableEntity
    {

       
        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }

        public decimal RawValue { get; set; }

        public decimal ConvertedValue { get; set; }
       
    }
}
