using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace JIPP5_LAB.DataProviders
{
    public class StatisticsEntity : TableEntity
    {
        public string Type { get; set; }

        public DateTime DateTime { get; set; }
    }
}