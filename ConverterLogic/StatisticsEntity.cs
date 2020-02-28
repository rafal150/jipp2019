using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    class StatisticsEntity : TableEntity
    {
        public DateTime date { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string fromValue { get; set; }
        public double resultValue { get; set; }
    }
}
