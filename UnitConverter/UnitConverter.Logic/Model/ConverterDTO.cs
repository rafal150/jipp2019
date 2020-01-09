namespace UnitConversion
{
    using System;
    using System.Collections.Generic;

    public partial class ConverterDTO
    {
        public DateTime? Created { get; set; }

        public string Name { get; set; }

        public List<ConverterUnitDTO> Units { get; set; }
    }
}
