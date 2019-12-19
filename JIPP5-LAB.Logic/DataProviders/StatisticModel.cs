namespace JIPP5_LAB.DataProviders
{
    using JIPP5_LAB.SDK;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Z502_21.Statistics")]
    public class StatisticModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string FromUnit { get; set; }

        [Required]
        [StringLength(50)]
        public string ToUnit { get; set; }

        public decimal RawData { get; set; }

        public decimal Converted { get; set; }
        public StatisticModel()
        {

        }
        public StatisticModel(StatisticsDTO dto)
        {
            Date = dto.Date;
            FromUnit = dto.FromUnit;
            ToUnit = dto.ToUnit;
            RawData = dto.RawData;
            Converted = dto.Converted;
        }
    }
}