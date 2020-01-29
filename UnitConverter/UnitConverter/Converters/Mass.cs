using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters {
    class Mass : AbstractConverter, IConverter {
        public List<string> Units => new List<string> {
            "Milligram",
            "Gram",
            "Decagram",
            "Kilogram",
            "Ton",
        };

        public double ConvertGramToMilligram(double value) {
            return value * 1000.0;
        }
        public double ConvertGramToDecagram(double value) {
            return value * 0.1;
        }
        public double ConvertGramToKilogram(double value) {
            return value * 0.001;
        }
        public double ConvertGramToTon(double value) {
            return value * 0.000001;
        }
        public double ConvertMilligramToGram(double value) {
            return value * 0.001;
        }
        public double ConvertMilligramToDecagram(double value) {
            return ConvertGramToDecagram(ConvertMilligramToGram(value));
        }
        public double ConvertMilligramToKilogram(double value) {
            return ConvertGramToKilogram(ConvertMilligramToGram(value));
        }
        public double ConvertMilligramToTon(double value) {
            return ConvertGramToTon(ConvertMilligramToGram(value));
        }
        public double ConvertDecagramToGram(double value) {
            return value * 10.0;
        }
        public double ConvertDecagramToMilligram(double value) {
            return ConvertGramToMilligram(ConvertDecagramToGram(value));
        }
        public double ConvertDecagramToKilogram(double value) {
            return ConvertGramToKilogram(ConvertDecagramToGram(value));
        }
        public double ConvertDecagramToTon(double value) {
            return ConvertGramToTon(ConvertDecagramToGram(value));
        }
        public double ConvertKilogramToGram(double value) {
            return value * 1000.0;
        }
        public double ConvertKilogramToMilligram(double value) {
            return ConvertGramToMilligram(ConvertKilogramToGram(value));
        }
        public double ConvertKilogramToDecagram(double value) {
            return ConvertGramToDecagram(ConvertKilogramToGram(value));
        }
        public double ConvertKilogramToTon(double value) {
            return ConvertGramToTon(ConvertKilogramToGram(value));
        }
        public double ConvertTonToGram(double value) {
            return value * 1000000.0;
        }
        public double ConvertTonToMilligram(double value) {
            return ConvertGramToMilligram(ConvertTonToGram(value));
        }
        public double ConvertTonToDecagram(double value) {
            return ConvertGramToDecagram(ConvertTonToGram(value));
        }
        public double ConvertTonToKilogram(double value) {
            return ConvertGramToKilogram(ConvertTonToGram(value));
        }
    }
}