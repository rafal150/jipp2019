using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters {
    class Volume : AbstractConverter, IConverter {
        public List<string> Units => new List<string> {
            "Litre",
            "Hectolitre",
        };
    }
}
