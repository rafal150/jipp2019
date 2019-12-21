using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Model
{
    public class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }
        public string TypJednostki { get; set; }

        public string JednostkaZ { get; set; }
        public string JednostkaDo { get; set; }
        public int IloscPrzed { get; set; }
        public int IloscPo { get; set; }

        public DateTime? Data { get; set; }
    }
}
