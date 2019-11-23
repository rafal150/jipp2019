namespace JIPP5_LAB.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Z511_10.Statistics")]
    public class StatisticModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string FromUnit { get; set; }

        [Required]
        [StringLength(50)]
        public string ToUnit { get; set; }

        public decimal RawData { get; set; }

        public decimal Converted { get; set; }
    }
}
