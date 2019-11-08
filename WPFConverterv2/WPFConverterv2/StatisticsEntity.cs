using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WPFConverterv2
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

        public StatisticsEntity(int Id, DateTime dateTime, string unitFrom, string unitTo, double rawValue, double convertedValue, string type)
        {
            id = Id;
            DateTime = dateTime;
            UnitFrom = unitFrom;
            UnitTo = unitTo;
            RawValue = rawValue;
            ConvertedValue = convertedValue;
            Type = type;
            PartitionKey = "ThanksApp";
            RowKey = type;
            


        }

        public StatisticsEntity()
        {

        }

    }
}