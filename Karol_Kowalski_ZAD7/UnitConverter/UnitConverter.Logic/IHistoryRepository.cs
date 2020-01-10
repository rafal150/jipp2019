using System.Collections.Generic;

namespace UnitConverter.Logic
{
    public interface IHistoryRepository
    {
        void AddConversionItem(HistoryDTO conversionItem);
        IEnumerable<HistoryDTO> GetLastConversions();
    }
}
