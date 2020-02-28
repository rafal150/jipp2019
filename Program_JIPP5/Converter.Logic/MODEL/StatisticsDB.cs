using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Converter
{
    public class StatisticsDB
    {


       

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string UnitFrom { get; set; }

        [StringLength(50)]
        public string UnitTo { get; set; }

        public decimal RawValue { get; set; }

        public decimal ConvertedValue { get; set; }

       
    }


}

