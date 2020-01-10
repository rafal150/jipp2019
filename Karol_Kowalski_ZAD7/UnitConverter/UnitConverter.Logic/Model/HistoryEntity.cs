using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace UnitConverter.Logic.Model
{
    public class HistoryEntity : TableEntity
    {
        public DateTime? DateTime { get; set; }

        public string ConversionType { get; set; }

        public string UnitFrom { get; set; }

        public string ValueToConvert { get; set; }

        public string UnitTo { get; set; }

        public string ConvertedValue { get; set; }
    }
}
