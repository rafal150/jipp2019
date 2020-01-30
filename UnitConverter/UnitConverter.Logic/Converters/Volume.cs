using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters {
    class Volume : AbstractConverter, IConverter {
        public List<string> Units => new List<string> {
            "Litre",
            "Decilitre",
            "Hectolitre",
        };

        public double ConvertLitreToHectolitre(double value) {
            return value / 100;
        }
        public double ConvertLitreToDecilitre(double value) {
            return value / 10;
        }
        public double ConvertDecilitreToLitre(double value) {
            return value * 10;
        }
        public double ConvertDecilitreToHectolitre(double value) {
            return ConvertLitreToHectolitre(ConvertDecilitreToLitre(value));
        }
        public double ConvertHectolitreToLitre(double value) {
            return value * 100;
        }
        public double ConvertHectolitreToDecilitre(double value) {
            return ConvertLitreToDecilitre(ConvertHectolitreToLitre(value));
        }
    }
}
