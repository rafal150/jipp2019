using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Model
{
    public class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }

        public DateTime ConvertingTime { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }

        public double Result { get; set; }

        public double Value { get; set; }
        public string PhysicalProperty { get; set; }
    }
}
