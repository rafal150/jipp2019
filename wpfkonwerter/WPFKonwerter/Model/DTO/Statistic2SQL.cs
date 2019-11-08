
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFKonwerter.Model.DTO
{
    public class Statistic2SQL : IStatisticsRepo
    {  
        public void SaveStats(Statistics stats)
        {
            using (UnitsConverterEntities uce= new UnitsConverterEntities())
            {
                uce.Statistics_AC.Add(new Statistics_AC()
                {
                    CategoryType = stats.CategoryType,
                    ConversionDT = stats.ConversionDT,
                    UnitFrom = stats.UnitFrom,
                    ValueFrom = stats.ValueFrom,
                    UnitTo = stats.UnitTo,
                    ValueTo = stats.ValueTo
                }
               );
                uce.SaveChanges();
            }
               
        }
        public List<Statistics> GetStats()
        {
            using (UnitsConverterEntities uce = new UnitsConverterEntities())
            {
                return uce.Statistics_AC.Select(x => 
                                            new Statistics()
                                            {
                                                ConversionDT = x.ConversionDT,
                                                CategoryType = x.CategoryType,
                                                Id = x.Id,
                                                UnitFrom = x.UnitFrom,
                                                ValueFrom = x.ValueFrom,
                                                UnitTo = x.UnitTo,
                                                ValueTo = x.ValueTo,
                                            }).ToList();
            }
        }
    }
}
