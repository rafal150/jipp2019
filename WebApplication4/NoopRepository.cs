using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConverterLogic;

namespace WebApplication4
{
    public class NoopRepository : IRepository<StatisticsEntryDto>
    {
        public IEnumerable<StatisticsEntryDto> GetAll()
        {
            return new List<StatisticsEntryDto>();
        }

        public void Save(StatisticsEntryDto dto)
        {
            return;
        }
    }
}
