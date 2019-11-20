using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Labs.Databases
{
    public class Entity : TableEntity
    {
        public string category { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public double? initial { get; set; }
        public double? converted { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
