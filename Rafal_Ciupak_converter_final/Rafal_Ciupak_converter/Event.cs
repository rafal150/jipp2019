namespace Rafal_Ciupak_converter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int Id { get; set; }

        public string zdarzenie { get; set; }

        public DateTime date { get; set; }
    }
}
