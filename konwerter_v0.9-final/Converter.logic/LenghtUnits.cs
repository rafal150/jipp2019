namespace konwerter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LenghtUnits
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitName { get; set; }

        public decimal UnitBaseValue { get; set; }
    }
}
