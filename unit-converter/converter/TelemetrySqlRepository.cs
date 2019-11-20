using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{

    class TelemetrySqlRepository : ITelemetryRepository
    {

        public void AddTelemetry(TelemetryDTO telemetry)
        {
            using (var ctx = new ConverterCtx())
            {
                var t = new Telemetry()
                {
                    Date = telemetry.Date,
                    Type = telemetry.Type,
                    UnitFrom = telemetry.UnitFrom,
                    UnitTo = telemetry.UnitTo,
                    ValueFrom = (float)telemetry.ValueFrom,
                    ValueTo = (float)telemetry.ValueTo
                };

                ctx.Telemetry.Add(t);
                ctx.SaveChanges();
            }
        }

        public IEnumerable<TelemetryDTO> GetTelemetries()
        {
            using (var ctx = new ConverterCtx())
            {
                return ctx.Telemetry.Select(obj => new TelemetryDTO() {
                    Date = obj.Date,
                    Type = obj.Type,
                    UnitFrom = obj.UnitFrom,
                    UnitTo = obj.UnitTo,
                    ValueFrom = obj.ValueFrom,
                    ValueTo = obj.ValueTo,
                }).ToList();
            }
        }
    }
}
