using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class SqlRepo:IRepo
    {
        public void dodajRekord(RekordDTO rekord)
        {
            using (PrzezSqlServer context = new PrzezSqlServer())
            {
                context.Rekordy.Add(new Rekord()
                {
                    //Id = rekord.Id,
                    DateTime = rekord.DateTime,
                    Type = rekord.Type,
                    FromUnit = rekord.FromUnit,
                    ToUnit = rekord.ToUnit,
                    RawValue = rekord.RawValue,
                    ConvertedValue = rekord.ConvertedValue
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<RekordDTO> pobierzRekordy()
        {
            using (PrzezSqlServer context = new PrzezSqlServer())
            {
                return context.Rekordy.
                    Select(obj => new RekordDTO() { DateTime = obj.DateTime, Type = obj.Type, FromUnit = obj.FromUnit, ToUnit = obj.ToUnit, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue }).
                    ToList();
            }
        }

        public void wyczyscHistorie()
        {
            using (PrzezSqlServer context = new PrzezSqlServer())
            {
                IEnumerable<Rekord> doUsuniecia = context.Rekordy.Where(x => x.Id > 0);
                context.Rekordy.RemoveRange(doUsuniecia);
                context.SaveChanges();
            }
        }
    }
}
