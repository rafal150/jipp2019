namespace UnitConversion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Converter")]
    public partial class Converter
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<ConverterUnit> Units { get; set; }
    }
}
