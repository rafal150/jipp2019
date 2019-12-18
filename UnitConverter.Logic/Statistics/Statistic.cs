using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UnitConverter.Statistics
{
    [Table("Statistics")]
    public class Statistic
    {
        //     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string type { get; set; }
        [StringLength(50)]
        public string fromUnit { get; set; }
        [StringLength(50)]
        public string toUnit { get; set; }
        public double startValue { get; set; }
        public double finalValue { get; set; }

        public DateTime? date { get; set; }


    
 

    }
}
