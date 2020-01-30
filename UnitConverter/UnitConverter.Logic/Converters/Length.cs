using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters {
    class Length : AbstractConverter, IConverter {
        public List<string> Units => new List<string> {
            "Metre",
            "Kilometre",
            "Lightyear",
        };

        public double ConvertKilometreToMetre(double value) {
            return value * 1000;
        }
        public double ConvertKilometreToLightyear(double value) {
            return value / 9460700000000;
        }
        public double ConvertMetreToKilometre(double value) {
            return value / 1000;
        }
        public double ConvertMetreToLightyear(double value) {
            return ConvertKilometreToLightyear(ConvertMetreToKilometre(value));
        }
        public double ConvertLightyearToKilometre(double value) {
            return value * 9460700000000;
        }
        public double ConvertLightyearToMetre(double value) {
            return ConvertKilometreToMetre(ConvertLightyearToKilometre(value));
        }
    }
}
