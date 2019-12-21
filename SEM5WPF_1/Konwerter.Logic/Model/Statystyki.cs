namespace SEM5WPF_1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class Statystyki
    {
        [Key]
        public int NumerPrzeliczenia { get; set; }

        public double? WartoscPodstawowa { get; set; }

        public double? WartoscPoKonwersji { get; set; }

        [Required]
        [StringLength(40)]
        public string WartoscA { get; set; }

        [Required]
        [StringLength(40)]
        public string WartoscB { get; set; }

        [StringLength(40)]
        public string JednostkaA { get; set; }

        [StringLength(40)]
        public string JednostkaB { get; set; }

        public DateTime? Data { get; set; }
    }
}
