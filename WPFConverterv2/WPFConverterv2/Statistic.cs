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
    public partial class Statistic
    {

        public int id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string UnitFrom { get; set; }

        [StringLength(50)]
        public string UnitTo { get; set; }

        public double? RawValue { get; set; }

        public double? ConvertedValue { get; set; }

        [StringLength(50)]
        public string Type { get; set; }




    }
}
