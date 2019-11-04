using System.Collections.Generic;

namespace UnitConversion
{
    public interface IServiceRepository
    {
        void AddConversionHistory(ConversionHistoryDTO conversionHistory);
        IEnumerable<ConversionHistoryDTO> GetConversionHistory();
    }
}
