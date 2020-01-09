using System.Collections.Generic;

namespace UnitConversion
{
    public interface IServiceRepository
    {
        void AddConversionHistory(ConversionHistoryDTO conversionHistory);
        IEnumerable<ConversionHistoryDTO> GetConversionHistory();
        void SaveConverter(string converterType, string newConverterType);
        void DeleteConverter(string converterType);
        void SaveConverterUnit(string ConverterType, string ConverterUnitName, string Name, string ConversionToBaseValueFormula, string ConversionFromBaseValueFormula);
        void DeleteConverterUnit(string ConverterType, string Name);
        IEnumerable<ConverterDTO> GetConverters();
    }
}
