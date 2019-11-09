using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MójKonwerterJednostek.Dane;
using MójKonwerterJednostek.Jednostki;

namespace MójKonwerterJednostek.Konwertery
{
    class WriteRecord
    {
        public bool RecordSaved;
        
        public WriteRecord(int Input, int Output, decimal myOutputValue, decimal myInputValue, IStatisticsRepository repo)
        {
            this.RecordSaved = true;
            try
            {
                //using (StatisticModel context = new StatisticModel())
                //{

                //    Statistic St = new Statistic()
                //    { DateTime = DateTime.Now,
                //        UnitFrom = Enum.GetName(typeof(UnitTypes), Input),
                //        UnitTo = Enum.GetName(typeof(UnitTypes), Output),
                //        RawValue = myOutputValue,
                //        ConvertedValue = myInputValue,
                //        Type = ((UnitTypes)Input).GetEnumDescription()
                //    };
                //    context.Statistic.Add(St);
                //    context.SaveChanges();
                //}
                StatisticDTO St = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = Enum.GetName(typeof(UnitTypes), Input),
                    UnitTo = Enum.GetName(typeof(UnitTypes), Output),
                    RawValue = myOutputValue,
                    ConvertedValue = myInputValue,
                    Type = ((UnitTypes)Input).GetEnumDescription()
                };
                repo.AddStatistic(St);
            }
            catch (System.Data.DataException)
            {
                RecordSaved = false;
            }
        }
    }
}
