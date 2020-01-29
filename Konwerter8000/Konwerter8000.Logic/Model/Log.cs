using System;
using System.ComponentModel.DataAnnotations;

namespace Konwerter8000.Model
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        [StringLength(50)]
        public string ZJednostki { get; set; }

        [StringLength(50)]
        public string DoJednostki { get; set; }

        public double? WartoscDoPrzeliczen { get; set; }

        public double? WartoscPrzeliczona { get; set; }

    }
}
