using System;

namespace Konwerter_Azure
{
    public class StatisticDTO // do pobierania i zapisu danych do bazy, uwspolnienie
    {
        public int id { get; set; }
        public DateTime? czas { get; set; }
        public string grupa { get; set; }
        public string przeliczZ { get; set; }
        public decimal? dane { get; set; }
        public string przeliczNa { get; set; }
        public decimal? wynik { get; set; }
    }

}
