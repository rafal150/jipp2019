using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters {
    class Time : AbstractConverter, IConverter {
        public List<string> Units => new List<string> {
            "Millisecond",
            "Second",
            "Minute",
            "Hour",
            "Day",
        };
    }
}
