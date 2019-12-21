using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEM5WPF_1.Model
{
    class StatystykiEntities : TableEntity
    {
       // [Key]
        public int NumerPrzeliczenia { get; set; }

        public double? WartoscPodstawowa { get; set; }

        public double? WartoscPoKonwersji { get; set; }

       // [Required]
       // [StringLength(40)]
        public string WartoscA { get; set; }

       // [Required]
       // [StringLength(40)]
        public string WartoscB { get; set; }

       // [StringLength(40)]
        public string JednostkaA { get; set; }

       // [StringLength(40)]
        public string JednostkaB { get; set; }

        public DateTime? Data { get; set; }
    }
}
