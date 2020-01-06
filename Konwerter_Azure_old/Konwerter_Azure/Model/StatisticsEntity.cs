using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_Azure.Model
{
    class StatisticsEntity : TableEntity
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
