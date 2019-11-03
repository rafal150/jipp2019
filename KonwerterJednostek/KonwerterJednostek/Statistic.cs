namespace KonwerterJednostek
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Statistic
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [StringLength(10)]
        public string From { get; set; }

        [StringLength(10)]
        public string To { get; set; }

        public decimal ValueToConvert { get; set; }

        public decimal ConvertedValue { get; set; }
    }
}
