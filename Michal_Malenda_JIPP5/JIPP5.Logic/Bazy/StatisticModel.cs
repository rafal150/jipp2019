namespace JIPP5_LAB.Bazy
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Stats")]
    public class StatisticModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public decimal RawValue { get; set; }
        public decimal ConvertedValue { get; set; }
        public string Type { get; set; }
    }
}