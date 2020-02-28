using System;

namespace ConverterSDK
{
    public interface IConverterPlug
    {
        String GetFrom();
        String GetTo();
        Func<double, double> GetConversionFunc();

    }
}
