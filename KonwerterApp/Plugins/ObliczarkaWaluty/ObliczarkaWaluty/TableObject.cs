using System;

namespace ObliczarkaWaluty
{
    internal class TableObject
    {
        public string Table { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public RateObject[] Rates { get; set; }
    }
}