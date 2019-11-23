using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverteAZ
{
    public class StatisticSqlRepository : IStatisticRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (Statistics context = new Statistics())
            {
                context.UnitConverterAZ.Add(new UnitConverterAZ()
                {
                    Type = statistic.Type,
                    Calculation_Time = statistic.Calculation_Time,
                    UnitFrom = statistic.UnitFrom,
                    Unit_To = statistic.Unit_To,
                    Value_From = statistic.Value_From,
                    Converted_Value = statistic.Converted_Value
                });



                //UnitConverterAZ st = new UnitConverterAZ();

                //st.Calculation_Time = DateTime.Now;
                //st.UnitFrom = a;
                //st.Value_From = c;
                //st.Unit_To = b;
                //st.Converted_Value = d;

                ////st.Unit_To = (double.Parse(d));


                context.SaveChanges();

            }
        }

            public IEnumerable<StatisticDTO> GetStatistic()
        {
            using (Statistics context = new Statistics())
            {

                return context.UnitConverterAZ.Select(obj => new StatisticDTO()
                {
                    Type = obj.Type,
                    Calculation_Time = obj.Calculation_Time,
                    UnitFrom = obj.UnitFrom,
                    Unit_To = obj.Unit_To,
                    Value_From = obj.Value_From,
                    Converted_Value = obj.Converted_Value
                }).ToList();



            }
        }
    }
}
