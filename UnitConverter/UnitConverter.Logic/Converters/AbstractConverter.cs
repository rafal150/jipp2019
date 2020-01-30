using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters {
    abstract class AbstractConverter {
        public string Name => GetType().Name;

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
    }
}
