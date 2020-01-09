namespace UnitConversion
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ConverterUnit")]
    public partial class ConverterUnit
    {
        public int Id { get; set; }

        public Converter Converter { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ConversionToBaseValueFormula { get; set; }

        [Required]
        [StringLength(255)]
        public string ConversionFromBaseValueFormula { get; set; }
    }
}
