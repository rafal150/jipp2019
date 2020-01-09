using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

namespace UnitConversion
{
    public partial class ConverterEntity : TableEntity
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }

        public string Name { get; set; }

        //public List<ConverterUnitEntity> Units { get; set; }
    }
}
