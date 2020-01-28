using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public interface ICalculationResultRepository
    {
         Task AddResult(CalculationResultDTO result);
         Task<List<CalculationResultDTO>> GetResults();
    }
}
