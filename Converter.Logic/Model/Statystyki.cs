using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Konwerter
{

    [Table("Statystyki")]
    public partial class Statystyki
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Czas { get; set; }

        [Required]
        [StringLength(50)]
        public string Rodzaj { get; set; }

        [Required]
        [StringLength(50)]
        public string JednostkaZ { get; set; }

        public double WartośćPrzed { get; set; }

        [Required]
        [StringLength(50)]
        public string JednostkaDo { get; set; }

        public double? WartośćPo { get; set; }

        [StringLength(100)]
        public string Komentarz { get; set; }
    }
}
