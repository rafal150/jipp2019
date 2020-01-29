using System;

namespace Konwerter8000
{
    public class LogDTO
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        public string ZJednostki { get; set; }

        public string DoJednostki { get; set; }

        public double? WartoscDoPrzeliczen { get; set; }

        public double? WartoscPrzeliczona { get; set; }
    }
}
