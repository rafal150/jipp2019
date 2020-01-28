using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;

namespace Converter
{
    public class CalculationResultEntity : TableEntity
    {
        public DateTime DateTime { get; set; }

        public string UnitType { get; set; }

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public double FromValue { get; set; }

        public double ToValue { get; set; }

    }
}
