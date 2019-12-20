using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    public interface ITelemetryRepository
    {
        void AddTelemetry(TelemetryDTO telemetry);
        IEnumerable<TelemetryDTO> GetTelemetries();
    }
}
