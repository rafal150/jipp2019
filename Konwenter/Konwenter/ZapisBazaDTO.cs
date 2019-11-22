using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    public class ZapisBazaDTO
    {
        public int id { get; set; }
        public DateTime? dataZapisu {get;set;}
        public string typKonwersji { get; set; }
        public string zJednostki { get; set; }
        public string naJednostke { get; set; }
        public decimal? daneWejsc { get; set; }
        public decimal? daneWyjsc { get; set; }
    }
}
