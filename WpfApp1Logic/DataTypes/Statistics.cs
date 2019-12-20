namespace WpfApp1.Logic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using WpfApp1.SDK;

    public partial class Statistics
    {
        public int Id { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(10)]
        public string From { get; set; }

        [StringLength(10)]
        public string To { get; set; }

        public decimal? OryginalValue { get; set; }

        public decimal? CalculatedValue { get; set; }
    }
}
