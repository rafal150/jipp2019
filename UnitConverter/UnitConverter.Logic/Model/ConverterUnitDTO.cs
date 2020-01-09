namespace UnitConversion
{
    public partial class ConverterUnitDTO
    {
        public ConverterDTO Converter { get; set; }

        public string Name { get; set; }

        public string ConversionToBaseValueFormula { get; set; }

        public string ConversionFromBaseValueFormula { get; set; }
    }
}
