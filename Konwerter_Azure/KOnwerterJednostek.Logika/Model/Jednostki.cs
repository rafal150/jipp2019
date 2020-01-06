namespace Konwerter_Azure.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jednostki")]
    public partial class Jednostki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idJednostki { get; set; }

        public int idGrupy { get; set; }

        [StringLength(30)]
        public string nazwa { get; set; }

        public virtual Grupy Grupy { get; set; }
    }
}
