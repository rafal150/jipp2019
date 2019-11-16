using System;

namespace JIPP5_LAB.SDK
{
    public interface IView
    {
        string Header { get; }
        event EventHandler<StatisticsDTO> ConvertedValueCompleted;
    }
}