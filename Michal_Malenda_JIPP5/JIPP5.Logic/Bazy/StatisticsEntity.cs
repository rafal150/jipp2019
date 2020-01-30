using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace JIPP5_LAB.Bazy
{
    public class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public DateTime DateTime { get; set; }

        public decimal Converterd { get; set; }
        public decimal RawValue { get; set; }
    }
}