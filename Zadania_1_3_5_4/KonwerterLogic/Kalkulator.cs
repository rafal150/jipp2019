namespace Konwerter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kalkulator
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Rodzaj { get; set; }

        [StringLength(50)]
        public string JednostkaWyjsciowa { get; set; }

        public double? Wartosc { get; set; }

        [StringLength(50)]
        public string JednostkaDocelowa { get; set; }

        public double? Przekonwertowane { get; set; }

        public DateTime? Data { get; set; }

    }
}
