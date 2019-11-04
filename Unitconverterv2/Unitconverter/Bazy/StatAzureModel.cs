using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Unitconverter
{
    class StatAzureModel: TableEntity
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public int? RawValue { get; set; }

        public int? ConvertedValue { get; set; }
    }
}
