using System;

namespace UnitConversion
{
    public class ConverterClassTypeAttribute : Attribute
    {
        public ClassType ClassType { get; private set; }
        public ConverterClassTypeAttribute(ClassType classType)
        {
            ClassType = classType;
        }
    }

    public enum ClassType
    {
        Universal = 0,
        Constant = 1
    }
}
