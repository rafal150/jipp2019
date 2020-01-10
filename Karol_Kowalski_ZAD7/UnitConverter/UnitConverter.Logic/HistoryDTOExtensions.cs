namespace UnitConverter.Logic
{
    public static class HistoryDTOExtensions
    {
        public static StatisticDTO ToStatisticDTO(this HistoryDTO historyItem)
        {
            return new StatisticDTO()
            {
                DateTime = historyItem.DateTime,
                Type = historyItem.ConversionType,
                UnitFrom = historyItem.UnitFrom,
                RawValue = historyItem.ValueToConvert,
                UnitTo = historyItem.UnitTo,
                ConvertedValue = historyItem.ConvertedValue,
            };
        }
    }
}
