using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace kalkulator
{
    public partial class statystyki
    {
        [Key]
        public int Ido { get; set; }

        public string KATEGORIA { get; set; }

        
        public int WARTOSC_POCZATKOWA { get; set; }

        
        public int WARTOSC_KONCOWA { get; set; }

        
        public DateTime DATA_GODZINA { get; set; }

        public string KTO { get; set; }
    }
}
