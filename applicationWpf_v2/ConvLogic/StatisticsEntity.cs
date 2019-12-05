using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationWpf
{
    class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string SourceUnit { get; set; }
        public double SourceValue { get; set; }
        public string ConvertedUnit { get; set; }
        public double ConvertedValue { get; set; }
    }
}
