namespace lab1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tabela1
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TypJednostki { get; set; }

        [StringLength(50)]
        public string JednostkaZ { get; set; }

        [StringLength(50)]
        public string JednostkaDo { get; set; }

        public int IloscPrzed { get; set; }

        public int IloscPo { get; set; }

        public DateTime? Data { get; set; }
    }
}
