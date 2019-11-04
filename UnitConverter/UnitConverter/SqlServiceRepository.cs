using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConversion;

namespace UnitConversion
{
    public class SqlServiceRepository : IServiceRepository
    {
        public void AddConversionHistory(ConversionHistoryDTO conversionHistory)
        {
            using (ConverterContext db = new ConverterContext())
            {
                ConversionHistory ch = new ConversionHistory()
                {
                    Created = conversionHistory.Created,
                    BaseUnit = conversionHistory.BaseUnit,
                    BaseValue = conversionHistory.BaseValue,
                    ConversionType = conversionHistory.ConversionType,
                    TargetUnit = conversionHistory.TargetUnit,
                    TargetValue = conversionHistory.TargetValue
                };
                db.ConversionHistories.Add(ch);
                db.SaveChanges();
            }
        }

        public IEnumerable<ConversionHistoryDTO> GetConversionHistory()
        {
            using (ConverterContext db = new ConverterContext())
            {
                return db.ConversionHistories.Select(x => new ConversionHistoryDTO()
                {
                    BaseUnit = x.BaseUnit,
                    BaseValue = x.BaseValue,
                    ConversionType = x.ConversionType,
                    Created = x.Created,
                    TargetUnit = x.TargetUnit,
                    TargetValue = x.TargetValue
                }).ToList();
            }
        }
    }
}
