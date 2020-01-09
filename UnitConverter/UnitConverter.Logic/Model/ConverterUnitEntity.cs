using Microsoft.WindowsAzure.Storage.Table;

namespace UnitConversion
{
    public partial class ConverterUnitEntity : TableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ConversionToBaseValueFormula { get; set; }

        public string ConversionFromBaseValueFormula { get; set; }

        public string ConverterRowKey { get; set; }
    }
}
