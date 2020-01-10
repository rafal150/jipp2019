using System;
using System.ComponentModel.DataAnnotations;

namespace Logic
{

    public partial class CONVERSION_LOG
    {
        [Key]
        public long CL_Id { get; set; }

        [StringLength(10)]
        public string CL_UnitFrom { get; set; }

        public decimal? CL_ValueFrom { get; set; }

        [StringLength(10)]
        public string CL_UnitTo { get; set; }

        public decimal? CL_ValueTo { get; set; }

        [StringLength(20)]
        public string CL_UnitType { get; set; }

        public DateTime? CL_Date { get; set; }
    }
}
