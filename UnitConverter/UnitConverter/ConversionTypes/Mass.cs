using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.ConversionTypes {
    class Mass : AbstractConversionType {
        public Mass() {
            ComboboxItems = new string[] {
                "Milligram",
                "Decagram",
                "Gram",
                "Kilogram",
                "Ton",
            };
        }
        public float ConvertGramToMilligram(float value) {
            return value * 1000.0f;
        }
        public float ConvertGramToDecagram(float value) {
            return value * 0.1f;
        }
        public float ConvertGramToKilogram(float value) {
            return value * 0.001f;
        }
        public float ConvertGramToTon(float value) {
            return value * 0.000001f;
        }
        public float ConvertMilligramToGram(float value) {
            return value * 0.001f;
        }
        public float ConvertMilligramToDecagram(float value) {
            return ConvertGramToDecagram(ConvertMilligramToGram(value));
        }
        public float ConvertMilligramToKilogram(float value) {
            return ConvertGramToKilogram(ConvertMilligramToGram(value));
        }
        public float ConvertMilligramToTon(float value) {
            return ConvertGramToTon(ConvertMilligramToGram(value));
        }
        public float ConvertDecagramToGram(float value) {
            return value * 10.0f;
        }
        public float ConvertDecagramToMilligram(float value) {
            return ConvertGramToMilligram(ConvertDecagramToGram(value));
        }
        public float ConvertDecagramToKilogram(float value) {
            return ConvertGramToKilogram(ConvertDecagramToGram(value));
        }
        public float ConvertDecagramToTon(float value) {
            return ConvertGramToTon(ConvertDecagramToGram(value));
        }
        public float ConvertKilogramToGram(float value) {
            return value * 1000.0f;
        }
        public float ConvertKilogramToMilligram(float value) {
            return ConvertGramToMilligram(ConvertKilogramToGram(value));
        }
        public float ConvertKilogramToDecagram(float value) {
            return ConvertGramToDecagram(ConvertKilogramToGram(value));
        }
        public float ConvertKilogramToTon(float value) {
            return ConvertGramToTon(ConvertKilogramToGram(value));
        }
        public float ConvertTonToGram(float value) {
            return value * 1000000.0f;
        }
        public float ConvertTonToMilligram(float value) {
            return ConvertGramToMilligram(ConvertTonToGram(value));
        }
        public float ConvertTonToDecagram(float value) {
            return ConvertGramToDecagram(ConvertTonToGram(value));
        }
        public float ConvertTonToKilogram(float value) {
            return ConvertGramToKilogram(ConvertTonToGram(value));
        }
    }
}