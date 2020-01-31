using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public interface ICalcRepository
    {
         Task AddResult(CalculationResultDTO result);
         Task<List<CalculationResultDTO>> GetResults();
    }
}
