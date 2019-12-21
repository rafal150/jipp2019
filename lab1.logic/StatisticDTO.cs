using System;

namespace lab1
{
    public class StatisticDTO
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }
        public string JednostkaZ { get; set; }
        public string JednostkaDo { get; set; }

        public int IloscPrzed { get; set; }

        public int IloscPo { get; set; }
        public string TypJednostki { get; set; }
    }
}