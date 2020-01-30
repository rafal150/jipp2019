using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters {
    class DataCapacity : AbstractConverter, IConverter {
        public List<string> Units => new List<string> {
            "Gigabyte",
            "Bluray",
        };

        public double ConvertGigabyteToBluray(double value) {
            return value / 25;
        }
        public double ConvertBlurayToGigabyte(double value) {
            return value * 25;
        }
    }
}
