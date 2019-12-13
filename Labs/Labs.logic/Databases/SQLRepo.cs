using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs.Databases;
using Labs.Converters;
//using Labs.Properties

namespace Labs.Databases
{
    public class SQLRepo: InterfaceRepository
    {
        public IEnumerable<Values> GetValues()
        {
            using (SQLModel context = new SQLModel())
            {
                return context.Values.Select(obj => new Values() { category = obj.category, from = obj.from, to = obj.to, initial = obj.initial, converted = obj.converted, DateTime = obj.DateTime }).ToList();
            }
        }

        public void AddCalcs(Values values)
        {
            using (SQLModel context = new SQLModel())
            {
                context.Values.Add(new SQLValues()
                {
                    category = values.category,
                    from = values.from,
                    to = values.to,
                    initial = values.initial,
                    converted = values.converted,
                    DateTime = values.DateTime
                });

                context.SaveChanges();
            }
        }

    }
}
