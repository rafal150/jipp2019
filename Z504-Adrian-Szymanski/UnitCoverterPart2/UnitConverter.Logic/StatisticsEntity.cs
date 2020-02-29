using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2
{
    internal class StatisticsEntity : TableEntity
    {

        public int id { get; set; }

        public DateTime? DateTime { get; set; }

        public string UnitFrom { get; set; }


        public string UnitTo { get; set; }

        public double? RawValue { get; set; }

        public double? ConvertedValue { get; set; }


        public string Type { get; set; }

        internal static object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }




    }
}
