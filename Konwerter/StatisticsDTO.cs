using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Konwerter
{
    public class StatisticsDTO
    {
        public int id { get; set; }
        public string conversionType { get; set; }
        public string fromUnit { get; set; }
        public string valueToConvert { get; set; }
        public string toUnit { get; set; }
        public string convertedValue { get; set; }
        public DateTime dateTime { get; set; }
    }
}
