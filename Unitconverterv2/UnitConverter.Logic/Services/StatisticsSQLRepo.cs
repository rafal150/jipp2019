using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter
{
    public class StatisticsSQLRepo: IStatisticsRepository
    {
        public void AddStatistic(StatDTO statistic)
        {
            using (BazaUnitConverter baza = new BazaUnitConverter())
            {
                UnitConverter unit = new UnitConverter()
                {
                    DateTime = DateTime.Now,
                    Type = statistic.Type,
                    FromUnit = statistic.FromUnit,
                    ToUnit = statistic.ToUnit,
                    RawValue = statistic.RawValue,
                    ConvertedValue = statistic.ConvertedValue
                };
                baza.UnitConverters.Add(unit);
                baza.SaveChanges();

            }
        }
        public IEnumerable<StatDTO> GetStatistics()
        {
            using(BazaUnitConverter baza = new BazaUnitConverter())
            {
                return baza.UnitConverters.Select(obj => new StatDTO(){
                    DateTime = obj.DateTime,
                    Type = obj.Type,
                    FromUnit = obj.FromUnit,
                    ToUnit = obj.ToUnit,
                    RawValue = obj.RawValue,
                    ConvertedValue = obj.ConvertedValue
                }).ToList();
            }
            
        }
    }
}
