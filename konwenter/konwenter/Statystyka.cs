using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace konwenter
{
    public partial class Statystyka
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Rodzaj { get; set; }

        [StringLength(50)]
        public string JednostkaWyjściowa { get; set; }

        public decimal? Wartość { get; set; }
        
        [StringLength(50)]
        public string JednostkaDocelowa { get; set; }

        public decimal? Przekonwertowane { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
