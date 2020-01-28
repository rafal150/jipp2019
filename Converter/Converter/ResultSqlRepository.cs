using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter4;

namespace Converter
{
    public class ResultSqlRepository : ICalculationResultRepository
    {
        public async Task AddResult(CalculationResultDTO result)
        {
            using (ResultModel context = new ResultModel())
            {
                context.CalculationResults.Add(new CalculationResult()
                {
                    CreatedAt = result.CreatedAt,
                    UnitType = result.UnitType,
                    ToUnit = result.ToUnit,
                    FromUnit = result.FromUnit,
                    ToValue = result.ToValue,
                    FromValue = result.FromValue,
                    Id = result.Id
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<CalculationResultDTO>> GetResults()
        {
            using (ResultModel context = new ResultModel())
            {
                return context.CalculationResults.
                    Select(obj => new CalculationResultDTO()
                    {
                        CreatedAt = obj.CreatedAt,
                        UnitType = obj.UnitType,
                        ToUnit = obj.ToUnit,
                        FromUnit =  obj.FromUnit,
                        ToValue = obj.ToValue,
                        FromValue = obj.FromValue,
                        Id = obj.Id
                    }).
                    ToList();
            }
        }
    }
}
