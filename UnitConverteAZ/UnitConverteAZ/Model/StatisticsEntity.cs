using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverteAZ
{
    class StatisticsEntity : TableEntity

    {

        public int Id { get; set; }
        public Nullable<System.DateTime> Calculation_Time { get; set; }
        public string UnitFrom { get; set; }
        public Nullable<double> Value_From { get; set; }
        public string Unit_To { get; set; }
        public Nullable<double> Converted_Value { get; set; }
        public string Type { get; set; }
    }
}
