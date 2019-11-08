using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Model;

namespace Konwerter
{
    public class StatystykiSqlRepo:IStatystykiRepo //dodawanie i odczyt z bazy SQL
    {
        public void Dodaj_do_bazy(StatystykiObiekt stats)
        {
            using (KonwContext kontext = new KonwContext())
            {
                    kontext.Konwerter_stat.Add(new Konwerter_stat()
                    { 
                        DateTime= stats.DateTime, 
                        UnitFrom= stats.UnitFrom,
                        UnitTo= stats.UnitTo,
                        RawValue = stats.RawValue,
                        ConvertedValue= stats.ConvertedValue,
                        Type = stats.Type
                    });
                    kontext.SaveChanges();
            }
        }
        public IEnumerable<StatystykiObiekt> GetStatistics()
        {
            using (KonwContext kontext = new KonwContext())
            {
                return kontext.Konwerter_stat.
                    Select(obj => new StatystykiObiekt() { DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue, Type = obj.Type }).
                    ToList();
            }
        }
    }
}
