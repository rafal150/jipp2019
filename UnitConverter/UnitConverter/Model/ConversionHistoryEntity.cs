namespace UnitConversion
{
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConversionHistoryEntity : TableEntity
    {
        public DateTime? Created { get; set; }

        public string ConversionType { get; set; }

        public string BaseUnit { get; set; }

        public decimal BaseValue { get; set; }

        public string TargetUnit { get; set; }

        public decimal TargetValue { get; set; }
    }
}
