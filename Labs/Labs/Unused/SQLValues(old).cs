/* using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Labs.Databases
{
    public partial class SQLValues
    {
        public int id { get; set; }
        public string category { get; set; }

        [StringLength(50)]
        public string from { get; set; }
        
        [StringLength(50)]
        public string to { get; set; }
        public int? initial { get; set; }
        public int? converted { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
*/