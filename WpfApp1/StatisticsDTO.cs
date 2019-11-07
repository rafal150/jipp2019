using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WpfApp1
{
    public class StatisticsDTO
    {
        public int Id { get; set; }//prawdopodbnie też nullowalna

        public DateTime? Time { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public decimal? OryginalValue { get; set; }

        public decimal? CalculatedValue { get; set; }
    }
}
