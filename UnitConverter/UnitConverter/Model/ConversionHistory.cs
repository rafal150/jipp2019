namespace UnitConversion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConversionHistory")]
    public partial class ConversionHistory
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }

        [Required]
        [StringLength(255)]
        public string ConversionType { get; set; }

        [Required]
        [StringLength(50)]
        public string BaseUnit { get; set; }

        public decimal BaseValue { get; set; }

        [Required]
        [StringLength(50)]
        public string TargetUnit { get; set; }

        public decimal TargetValue { get; set; }
    }
}
