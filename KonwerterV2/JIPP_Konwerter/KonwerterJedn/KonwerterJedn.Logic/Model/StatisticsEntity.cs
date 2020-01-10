using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace KonwerterJedn.Model
{
    public class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }

        public string UnitFrom { get; set; }

        public string UnitTo { get; set; }

        public string ValueFrom { get; set; }

        public string ValueTo { get; set; }

        public string Type { get; set; }

        public DateTime DateTime { get; set; }
       
    }
}
