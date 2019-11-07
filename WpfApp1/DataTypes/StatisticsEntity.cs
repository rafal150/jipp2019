using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WpfApp1
{
    public class StatisticsEntity : TableEntity
    {
        public int Id { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(10)]
        public string From { get; set; }

        [StringLength(10)]
        public string To { get; set; }

        public decimal? OryginalValue { get; set; }

        public decimal? CalculatedValue { get; set; }
    }
}

