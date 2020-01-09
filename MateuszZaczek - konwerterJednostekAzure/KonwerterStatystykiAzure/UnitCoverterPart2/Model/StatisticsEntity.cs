using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZURE.Model
{
    public class StatisticsEntity : TableEntity
    {
        public string Type { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; internal set; }
        public string UnitTo { get; internal set; }
    }
}
