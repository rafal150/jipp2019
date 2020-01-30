using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Converters;

namespace TimePlugin {
    public class Time : IConverter {
        public string Name => GetType().Name;

        public List<string> Units => new List<string> {
            "Millisecond",
            "Second",
            "Minute",
            "Hour",
            "Day",
        };

        public double Convert(string unitFrom, string unitTo, double value) {
            if (unitFrom.ToLower() == unitTo.ToLower()) {
                return value;
            }

            // method name: ConvertSomethingToSomething
            string methodName = "Convert" + unitFrom + "To" + unitTo;
            if (GetType().GetMethod(methodName) == null) {
                throw new Exception("Method " + methodName + " does not exist");
            }
            // call method ConvertSomethingToSomething
            double result = (double) GetType().GetMethod(methodName).Invoke(this, new object[] { value });
            return result;
        }

        public double ConvertSecondToMillisecond(double value) {
            return value * 1000;
        }
        public double ConvertSecondToMinute(double value) {
            return value / 60;
        }
        public double ConvertSecondToHour(double value) {
            return value / 60 / 60;
        }
        public double ConvertSecondToDay(double value) {
            return value / 60 / 60 / 24;
        }
        public double ConvertMillisecondToSecond(double value) {
            return value / 1000;
        }
        public double ConvertMillisecondToMinute(double value) {
            return ConvertSecondToMinute(ConvertMillisecondToSecond(value));
        }
        public double ConvertMillisecondToHour(double value) {
            return ConvertSecondToHour(ConvertMillisecondToSecond(value));
        }
        public double ConvertMillisecondToDay(double value) {
            return ConvertSecondToDay(ConvertMillisecondToSecond(value));
        }
        public double ConvertMinuteToSecond(double value) {
            return value * 60;
        }
        public double ConvertMinuteToMillisecond(double value) {
            return ConvertSecondToMillisecond(ConvertMinuteToSecond(value));
        }
        public double ConvertMinuteToHour(double value) {
            return ConvertSecondToHour(ConvertMinuteToSecond(value));
        }
        public double ConvertMinuteToDay(double value) {
            return ConvertSecondToDay(ConvertMinuteToSecond(value));
        }
        public double ConvertHourToSecond(double value) {
            return value * 60 * 60;
        }
        public double ConvertHourToMillisecond(double value) {
            return ConvertSecondToMillisecond(ConvertHourToSecond(value));
        }
        public double ConvertHourToMinute(double value) {
            return ConvertSecondToMinute(ConvertHourToSecond(value));
        }
        public double ConvertHourToDay(double value) {
            return ConvertSecondToDay(ConvertHourToSecond(value));
        }
        public double ConvertDayToSecond(double value) {
            return value * 24 * 60 * 60;
        }
        public double ConvertDayToMillisecond(double value) {
            return ConvertSecondToMillisecond(ConvertDayToSecond(value));
        }
        public double ConvertDayToMinute(double value) {
            return ConvertSecondToMinute(ConvertDayToSecond(value));
        }
        public double ConvertDayToHour(double value) {
            return ConvertSecondToHour(ConvertDayToSecond(value));
        }
    }
}
