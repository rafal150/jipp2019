using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.ConversionTypes {
    abstract class AbstractConversionType {
        public string[] ComboboxItems { get; set; }

        public float Convert(int unitFromIndex, int unitToIndex, float value) {
            if (unitFromIndex == unitToIndex) {
                return value;
            }
            unitFromIndex--;
            unitToIndex--;
            // method name: ConvertSomethingToSomething
            string methodName = "Convert" + ComboboxItems[unitFromIndex] + "To" + ComboboxItems[unitToIndex];
            // call method ConvertSomethingToSomething
            float result = (float) GetType().GetMethod(methodName).Invoke(this, new object[] { value });
            return result;
        }
    }
}
