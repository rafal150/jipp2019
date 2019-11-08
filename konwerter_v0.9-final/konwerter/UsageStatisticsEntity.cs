using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace konwerter
{
    internal class UsageStatisticsEntity : TableEntity
    {
        //public int ID { get; set; }

        public DateTime DateTime { get; set; }

        public string UnitType { get; set; }

        public string InputUnit { get; set; }

        public string OutputUnit { get; set; }

        public decimal Value { get; set; }
    }
}